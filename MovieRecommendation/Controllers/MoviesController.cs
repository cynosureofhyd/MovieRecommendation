using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRecommendation.Controllers
{
    public class MoviesController : ApiController
    {

        private static string GetJsonDataFromMoviesApi(string searchTerm)
        {
            var url = string.Format("http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q={0}&rsz=large&start=0", searchTerm);
            var req = (HttpWebRequest)WebRequest.Create(url);
            //req.Referer = "http://mywebsite.com";
            var res = (HttpWebResponse)req.GetResponse();
            string responseJson;
            using (var streamReader = new StreamReader(res.GetResponseStream()))
            {
                responseJson = streamReader.ReadToEnd();
            }
            return responseJson;
        }
    }
}
