﻿using System;
using System.Runtime.Serialization;

namespace Illumina.BaseSpace.SDK.Types
{
    [DataContract(Name = "Project")]
    public class ProjectCompact : AbstractResource, IPropertyContent
    {
        [DataMember(IsRequired = true)]
        public override string Id { get; set; }

        [DataMember]
        public UserCompact UserOwnedBy { get; set; }

        [DataMember]
        public override Uri Href { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        public string Type
        {
            get { return Property.TYPE_PROJECT; }
        }

        public override string ToString()
        {
            return string.Format("Href: {0}; Name: {1}", Href, Name);
        }
    }

    [DataContract()]
    public class Project : ProjectCompact, IPropertyContainingResource
    {
        [DataMember]
        public Uri HrefSamples { get; set; }

        [DataMember]
        public Uri HrefAppResults { get; set; }

        [DataMember]
        public Uri HrefBaseSpaceUI { get; set; }

        [DataMember]
        public PropertyContainer Properties { get; set; }
    }

    public enum ProjectsSortByParameters { Id, Name, DateCreated }

    [DataContract()]
    public class ProjectList : AbstractQueryParameters
    {
        [DataMember]
        public ProjectsSortByParameters SortBy { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
