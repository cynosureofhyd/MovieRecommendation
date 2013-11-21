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

        public ActionResult Get()
        {
            //System.IO.File.WriteAllLines(@"C:\Users\PrashMaya\Desktop\WriteFirst50Lines.txt", titleIds.ToArray());
            using (var client = new HttpClient())
            {
                string url = "http://mymovieapi.com/?ids={0}&type=json&plot=full&episode=1&lang=en-US&aka=simple&release=simple&business=0&tech=0";
                string anotherurl = String.Format(url, "tt1343092");

                string json = GetJsonFromWebService(anotherurl);
                //client.BaseAddress = new Uri(anotherurl);
                //HttpResponseMessage anotherresponse = client.GetAsync(anotherurl).Result;
                //object obj = JsonConvert.DeserializeObject<object>(anotherresponse.Content.ReadAsStringAsync().Result);

                Test waitingFor = Deserialise(json);
                RootObject haha = DeserialiseRootObject(json);
                //Test waitingFor = Deserialise(obj.ToString());
                //List<string> tempString = new List<string>();
                //tempString.Add(obj.ToString());
                //System.IO.File.WriteAllLines(movietitleId, tempString);
            }
            return View();
        }


        private static string GetJsonFromWebService(string url)
        {
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

        public static Test Deserialise(string json)
        {
            var obj = Activator.CreateInstance<Test>();
            using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (Test)serializer.ReadObject(memoryStream);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Test finall = jss.Deserialize<Test>(json);
                return obj;
            }
        }

        public static RootObject DeserialiseRootObject(string json)
        {
            var obj = Activator.CreateInstance<RootObject>();
            using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (RootObject)serializer.ReadObject(memoryStream);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                RootObject finall = jss.Deserialize<RootObject>(json);
                return obj;
            }
        }
    }
}
