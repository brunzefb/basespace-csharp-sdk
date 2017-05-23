using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Illumina.BaseSpace.SDK.Types
{
    [DataContract]
    public class ApiResponse<TResponse> : IApiResponse<TResponse>
    {
        private IList<INotification<object>> notifications = new List<INotification<object>>();
        private ServiceStack.ResponseStatus status = new ServiceStack.ResponseStatus();

        public ApiResponse() { }

        public ApiResponse(TResponse responseContent)
        {
            Response = responseContent;
        }

        [DataMember(IsRequired = true)]
        public virtual TResponse Response { get; set; }

        [DataMember(IsRequired = true)]
        public ServiceStack.ResponseStatus ResponseStatus
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember(IsRequired = true)]
        public IList<INotification<object>> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }
    }
}
