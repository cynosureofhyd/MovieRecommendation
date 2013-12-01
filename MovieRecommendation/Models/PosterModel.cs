using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieRecommendation.Models
{
    [DataContract]
    public class PosterModel
    {
        [DataMember(Name = "imdb")]
        public string imdb { get; set; }

        [DataMember(Name = "cover")]
        public string cover { get; set; }
    }
}