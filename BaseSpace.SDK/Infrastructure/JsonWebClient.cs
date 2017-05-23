using System;
using System.Net;
using Common.Logging;
using Illumina.BaseSpace.SDK.Deserialization;
using Illumina.BaseSpace.SDK.ServiceModels;
using Illumina.BaseSpace.SDK.Types;
using Illumina.TerminalVelocity;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Serialization;
using ServiceStack.Text;
using Moq;

namespace Illumina.BaseSpace.SDK
{
    public class JsonWebClient : IWebClient
    {
        private readonly JsonServiceClient client;
        private readonly JsonServiceClient clientBilling;

        private readonly ServiceStack.Logging.ILog logger = new Mock<ServiceStack.Logging.ILog>().Object;

        private readonly IClientSettings settings;


        public JsonWebClient(IClientSettings settings, IRequestOptions defaultOptions = null)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this.settings = settings;
            DefaultRequestOptions = defaultOptions ?? new RequestOptions();
           
			/*  DISABLED TO TEST 
            // call something on this object so it gets initialized in single threaded context
            HttpEncoder.Default.SerializeToString();

			//need to add the following call for Mono -- https://bugzilla.xamarin.com/show_bug.cgi?id=12565
			if (Helpers.IsRunningOnMono())
			{
				HttpEncoder.Current = HttpEncoder.Default;
			}

            HttpEncoder.Current.SerializeToString();
			*/
            client = new JsonServiceClient(settings.BaseSpaceApiUrl);
            client.RequestFilter += WebRequestFilter;

            if (settings.TimeoutMin > 0)
                client.Timeout = TimeSpan.FromMinutes(settings.TimeoutMin);

            clientBilling = new JsonServiceClient(settings.BaseSpaceBillingApiUrl);
            clientBilling.RequestFilter += WebRequestFilter;
        }

        static JsonWebClient()
        {
            // setting this just to make sure it's not set in Linux
            JsonDataContractSerializer.Instance.UseBcl = false;
            // BaseSpace uses this format for DateTime
            JsConfig.DateHandler =DateHandler.ISO8601;

            JsConfig<Uri>.DeSerializeFn = s => new Uri(s, s.StartsWith("http") ? UriKind.Absolute : UriKind.Relative);

            // setup custom deserializers
            JsConfig<IContentReference<IAbstractResource>>.RawDeserializeFn = ReferenceDeserializer.JsonToReference;
            
            JsConfig<PropertyCompact>.RawDeserializeFn = PropertyDeserializer.JsonToPropertyCompact;
            JsConfig<Types.Property>.RawDeserializeFn = PropertyDeserializer.JsonToProperty;

            JsConfig<INotification<object>>.RawDeserializeFn = MiscDeserializers.NotificationDeserializer;
            JsConfig<PropertyItemsResourceList>.RawDeserializeFn = PropertyDeserializer.JsonToPropertyItemsResourceList;     
        }

        public IWebProxy WebProxy
        {
            get { return client.Proxy; }
            set { client.Proxy = value; }
        }

        public IRequestOptions DefaultRequestOptions { get; set; }

        public TReturn Send<TReturn>(AbstractRequest<TReturn> request, IRequestOptions options = null)
            where TReturn : class
        {
            try
            {
                if (logger.IsDebugEnabled)
                {
                    var debugMessage = request.GetDebugLogMessage();
                    if (!string.IsNullOrWhiteSpace(debugMessage))
                    {
                        logger.Debug(debugMessage);
                    }
                }

                
                TReturn result = null;
                options = options ?? DefaultRequestOptions;

                var clientForRequest = PickClientForApiName(request.GetApiName());
				var log = new Mock<Common.Logging.ILog>().Object;
                RetryLogic.DoWithRetry(options.RetryAttempts, request.GetName(),
                    () => result = request.GetSendFunc(clientForRequest)(), log);
                return result;
            }
            catch (WebServiceException webx)
            {
                string errorCode = string.Empty;
                if (!string.IsNullOrEmpty(webx.ErrorCode))
                {
                    errorCode = string.Format(" ({0})", webx.ErrorCode);
                }
                var msg = string.Format("{0} status: {1} ({2}) Message: {3}{4}", request.GetName(), webx.StatusCode,
                    webx.StatusDescription, webx.ErrorMessage, errorCode);
                throw new BaseSpaceException(msg, webx.ErrorCode, webx);
            }
            catch (Exception x)
            {
                throw new BaseSpaceException(request.GetName() + " failed", string.Empty, x);
            }
        }

        private JsonServiceClient PickClientForApiName(ApiNames apiName)
        {
            switch (apiName)
            {
                case ApiNames.BASESPACE:
                    return client;
                case ApiNames.BASESPACE_BILLING:
                    return clientBilling;
                default:
                    throw new ArgumentOutOfRangeException("apiName");
            }
        }

        private void WebRequestFilter(HttpWebRequest req)
        {
            if (settings.Authentication != null)
            {
                settings.Authentication.UpdateHttpHeader(req);
            }
        }
    }
}