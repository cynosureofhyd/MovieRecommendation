using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MovieRecommendation.Models;
using MovieRecommendation.Models.TestFolder;
using Newtonsoft.Json;

namespace MovieRecommendation.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Get()
        {
            string inputpath = "C:\\Users\\PrashMaya\\Desktop\\IMDBMovieTitleIds-0-2500.txt";
            string inputfolder = "C:\\Users\\PrashMaya\\My Documents\\First2500MoviesIMDB\\Movie{0}.txt";

            inputpath = String.Format(inputfolder, 1);
            string text = System.IO.File.ReadAllText(@inputpath);
            dynamic obj = ConvertToObj(text);
            HashSet<string> keys = new HashSet<string>();
            string[] lines = System.IO.File.ReadAllLines(@inputpath);
            return View();
        }

        public static dynamic ConvertToObj(string str)
        {
            dynamic moreInfo = JsonConvert.DeserializeObject(str);
            string temp = moreInfo[0]["plot"];
            return moreInfo;
        }

        public static void Process(string filetowritedownloadeddatato, string movieId)
        {
            //System.IO.File.WriteAllLines(@"C:\Users\PrashMaya\Desktop\WriteFirst50Lines.txt", titleIds.ToArray());
            using (var client = new HttpClient())
            {
                movieId = "tt" + movieId;
                string url = "http://mymovieapi.com/?ids={0}&type=json&plot=full&episode=1&lang=en-US&aka=simple&release=simple&business=0&tech=0";
                string anotherurl = String.Format(url, movieId);
                client.BaseAddress = new Uri(anotherurl);
                HttpResponseMessage anotherresponse = client.GetAsync(anotherurl).Result;

                object obj = JsonConvert.DeserializeObject<object>(anotherresponse.Content.ReadAsStringAsync().Result);

                dynamic moreInfo = JsonConvert.DeserializeObject(obj.ToString());
                string temp = moreInfo[0]["plot"];
            }
        }
    }
}
