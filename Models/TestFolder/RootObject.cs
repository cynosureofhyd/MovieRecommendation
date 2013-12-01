using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRecommendation.Models.TestFolder
{
    [Serializable]
    public class RootObject
    {
        public string plot { get; set; }
        public List<string> genres { get; set; }
        public string rated { get; set; }
        public double rating { get; set; }
        public List<string> language { get; set; }
        public int rating_count { get; set; }
        public List<string> country { get; set; }
        public int release_date { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string filming_locations { get; set; }
        public string imdb_id { get; set; }
        public List<string> directors { get; set; }
        public List<string> writers { get; set; }
        public List<string> actors { get; set; }
        public string plot_simple { get; set; }
        public Poster poster { get; set; }
        public List<string> runtime { get; set; }
        public string type { get; set; }
        public string imdb_url { get; set; }
        public List<string> also_known_as { get; set; }
    }
}