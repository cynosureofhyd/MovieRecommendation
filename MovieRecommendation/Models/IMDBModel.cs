using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MovieRecommendation.Models
{
    public class IMDBModel
    {
        [JsonProperty(PropertyName = "plot")]
        public string plot { get; set; }

        public List<Genre> genre { get; set; }

        public string Rated { get; set; }

        public float rating { get; set; }

        public List<string> Language { get; set; }

        public List<string> Country { get; set; }

        public int releasedate { get; set; }

        public string imdbid { get; set; }

        public string filminglocations { get; set; }

        public List<string> writers { get; set; }

        public List<string> actors { get; set; }

        public string plotsimple { get; set; }

        public string runtime { get; set; }

        public List<string> poster { get; set; }

        public string imdburl { get; set; }

        public string alsoknownas { get; set; }

    }
}