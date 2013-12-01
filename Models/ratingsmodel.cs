using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRecommendation.Models
{
    public class ratingsmodel
    {
        public string criticsrating { get; set; }
        public int criticsscore { get; set; }
        public string audiencerating { get; set; }
        public int audiencescore { get; set; }
    }
}