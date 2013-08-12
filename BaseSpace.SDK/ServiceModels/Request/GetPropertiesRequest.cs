﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Illumina.BaseSpace.SDK.Types;

namespace Illumina.BaseSpace.SDK.ServiceModels
{
    [DataContract]
    public class GetPropertiesRequest : AbstractRequest<GetPropertiesResponse>
    {
        public GetPropertiesRequest()
        {
            HttpMethod = HttpMethods.GET;
        }

        public GetPropertiesRequest(IPropertyContainingResource parentResource)
            : this()
        {
            HrefParentResource = parentResource.Href;
        }

        public Uri HrefParentResource { get; set; }


        internal override string GetLogMessage()
        {
            return string.Empty;
        }

        protected override string GetUrl()
        {
            if (HrefParentResource == null)
            {
                return null;
            }
            return string.Format("{0}/{1}", HrefParentResource.ToString(), "properties");
        }  
    }
}