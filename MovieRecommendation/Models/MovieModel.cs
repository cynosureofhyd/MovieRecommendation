using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MovieRecommendation.Models
{
    public class MovieModel
    {
        [JsonProperty(PropertyName="id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "id")]
        public List<string> genres { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string title { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int year { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int runtime { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string mpaa_rating { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string critics_consensus { get; set; }

        [JsonProperty(PropertyName = "id")]
        public releasedates releasedates { get; set; }

        [JsonProperty(PropertyName = "id")]
        public ratingsmodel ratings { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string synopsis { get; set; }

        [JsonProperty(PropertyName = "id")]
        public postersmodel posters { get; set; }

        [JsonProperty(PropertyName = "id")]
        public CastModel cast { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string studio { get; set; }

        [JsonProperty(PropertyName = "id")]
        public List<string> links { get; set; }
    }
}