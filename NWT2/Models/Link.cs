using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NWT2.Models
{
    public class Link
    {
        public static Link To(string routeName, object routeValues = null)
           => new Link
           {
               RouteName = routeName,
               RouteValues = routeValues,
               Method = GetMethod,
               Relations = null
           };

        public static Link ToCollection(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = new string[] { "Collection" }
            };
        public const string GetMethod = "GET";

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3, NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        [JsonProperty(Order = -2, PropertyName = "rel", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [XmlIgnore]
        public string RouteName { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [XmlIgnore]
        public object RouteValues { get; set; }
    }
}
