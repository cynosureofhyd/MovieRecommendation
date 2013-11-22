using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieRecommendation.Models
{
    [DataContract]
    public class Test
    {
        [DataMember(Name ="plot")]
        public string plot { get; set; }

        [DataMember(Name ="genres")]
        public List<string> genres { get; set; }

        [DataMember(Name ="rated")]
        public string rated { get; set; }

        [DataMember(Name="rating")]
        public string rating { get; set; }

        [DataMember(Name="language")]
        public List<string> language { get; set; }

        [DataMember(Name = "country")]
        public List<string> Country { get; set; }

        [DataMember(Name = "release_date")]
        public string ReleaseDate { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "year")]
        public int year { get; set; }

        [DataMember(Name="filming_locations")]
        public string FilmingLocations { get; set; } //TODO: This is a string of values which need to be converted

        [DataMember(Name = "imdb_id")]
        public string ImdbId { get; set; }

        [DataMember(Name = "directors")]
        public List<string> Directors { get; set; }

        [DataMember(Name = "writers")]
        public List<string> Writers { get; set; }

        [DataMember(Name = "actors")]
        public List<string> Actors { get; set; }

        [DataMember(Name="plot_simple")]
        public string PlotSimple { get; set;  }

        [DataMember(Name = "poster")]
        public PosterModel Poster { get; set; }

        [DataMember(Name = "runtime")]
        public string Runtime { get; set; }

        [DataMember(Name = "imdb_url")]
        public string ImdbUrl { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "also_known_as")]
        public string AlsoKnownAs { get; set; }
    }
}