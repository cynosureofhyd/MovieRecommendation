using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MovieRecommendation.Models;
using Newtonsoft.Json;

namespace MovieRecommendation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Images()
        {
            MovieEntities db = new MovieEntities();
            var top100Movies = db.Movies.Take(100).ToList();
            var requiredtop100Movies = from d in db.Movies.Take(100)
                                       join poster in db.PosterInfoes on d.ID equals poster.MovieId
                                       select new
                                       {
                                           Movie = d,
                                           PosterInfo = poster
                                       };
            List<MovieAndPosterInfo> results = new List<MovieAndPosterInfo>();
            foreach(var requiredMovie in requiredtop100Movies)
            {
                results.Add(new MovieAndPosterInfo()
                    {
                        Movie = requiredMovie.Movie,
                        Poster = requiredMovie.PosterInfo
                    });
            }

            return PartialView("Images", results);
            //return PartialView("Main", requiredtop100Movies.Select(s => s.Movie));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            using (var client = new HttpClient())
            {
                var url = "http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
                client.BaseAddress = new Uri("http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0");
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync();
            }
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string searchString)
        {
            GetAllLinks();
            //GetData();
            using (var client = new HttpClient())
            {
                var topRentedMovieLists = "http://api.rottentomatoes.com/api/public/v1.0/lists.json?apikey=67rr3k74bktcnnpbfpnbwgnq";
                //var language = "http://mymovieapi.com/?title=?&lang=en-US";
                //var url = "http://mymovieapi.com/?title=Rachcha&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
                //client.BaseAddress = new Uri("http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0");
                //client.BaseAddress = new Uri(language);
                //HttpResponseMessage response = client.GetAsync(language).Result;
                //Type t1 = typeof(string);
                //var t = response.Content.ReadAsAsync(t1).Result;
                
                //var temp = response.Content.ReadAsAsync<JsonArray
                //object obj = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result);
       
                //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //txtBlock.Text = readStream.ReadToEnd();

                //Stream theStream = await gHttpClient.GetStreamAsync(theURI);
                var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies.json?apikey=67rr3k74bktcnnpbfpnbwgnq";

                //var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq";
                //client.BaseAddress = new Uri("http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq");
                client.BaseAddress = new Uri(rottentomatoes);

                HttpResponseMessage anotherresponse = client.GetAsync(rottentomatoes).Result;
                //object obj = JsonConvert.DeserializeObject<object>(anotherresponse.Content.ReadAsStringAsync().Result);
            }
            return View();
        }



        private static void GetAllLinks()
        {
            //GetData();
            using (var client = new HttpClient())
            {
                var topRentedMovieLists = "http://api.rottentomatoes.com/api/public/v1.0/lists.json?apikey=67rr3k74bktcnnpbfpnbwgnq";



                //var language = "http://mymovieapi.com/?title=?&lang=en-US";
                //var url = "http://mymovieapi.com/?title=Rachcha&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
                //client.BaseAddress = new Uri("http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0");
                //client.BaseAddress = new Uri(language);
                //HttpResponseMessage response = client.GetAsync(language).Result;
                //Type t1 = typeof(string);
                //var t = response.Content.ReadAsAsync(t1).Result;

                //var temp = response.Content.ReadAsAsync<JsonArray
                //object obj = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result);

                //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //txtBlock.Text = readStream.ReadToEnd();

                //Stream theStream = await gHttpClient.GetStreamAsync(theURI);
                var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey=67rr3k74bktcnnpbfpnbwgnq";

                //var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq";
                //client.BaseAddress = new Uri("http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq");
                client.BaseAddress = new Uri(rottentomatoes);

                HttpResponseMessage anotherresponse = client.GetAsync(rottentomatoes).Result;
                //object obj = JsonConvert.DeserializeObject<object>(anotherresponse.Content.ReadAsStringAsync().Result);
            }
        }

        private async Task GetData()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://mymovieapi.com/?title=Rachcha&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var carJsonString = await response.Content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}