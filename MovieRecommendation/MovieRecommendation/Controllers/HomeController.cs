using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

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
                MovieEntities db = new MovieEntities();
                db.Movies.Add(new Movie()
                    {

                    });
            }

            return View();
        }

        public ActionResult Search()
        {
            //using (var client = new HttpClient())
            //{
            //    var url = "http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
            //    client.BaseAddress = new Uri("http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0");
            //    HttpResponseMessage response = client.GetAsync(url).Result;

            //    var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0.json?apikey=67rr3k74bktcnnpbfpnbwgnq";

            //    //var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq";
            //    //client.BaseAddress = new Uri("http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq");
            //    //HttpResponseMessage anotherresponse = client.GetAsync(url).Result;
            //}
            return View();
        }

        [HttpGet]
        public ActionResult Search(string searchString)
        {
            using (var client = new HttpClient())
            {
                var url = "http://mymovieapi.com/?title=Rachcha&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
                client.BaseAddress = new Uri("http://mymovieapi.com/?title=Twister&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0");
                HttpResponseMessage response = client.GetAsync(url).Result;
                Stream receiveStream = response.Content.
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                txtBlock.Text = readStream.ReadToEnd();


                var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0.json?apikey=67rr3k74bktcnnpbfpnbwgnq";

                //var rottentomatoes = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq";
                //client.BaseAddress = new Uri("http://api.rottentomatoes.com/api/public/v1.0/movies.json?q=twister&page_limit=10&page=1&apikey=67rr3k74bktcnnpbfpnbwgnq");
                //HttpResponseMessage anotherresponse = client.GetAsync(url).Result;
            }
            return View();
        }
    }
}