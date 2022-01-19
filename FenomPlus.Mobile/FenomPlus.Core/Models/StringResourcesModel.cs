using System;
using System.Collections.Generic;

namespace FenomPlus.Core.Models
{
    public class StringResourcesModel
    {
        public class StringResource
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Comment { get; set; }
        }

        public List<StringResource> StringResources { get; set; }
    }
}
