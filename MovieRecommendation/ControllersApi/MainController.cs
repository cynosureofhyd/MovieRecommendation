using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MovieRecommendation.Models;
using MovieRecommendation.Utilities;
using Newtonsoft.Json;

namespace MovieRecommendation.ControllersApi
{
    public class MainController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [ActionName("mymovies")]
        public IEnumerable<object> Get(int? id)
        {
            MovieEntities db = new MovieEntities();
            var result = (from m in db.Movies
                         join p in db.PosterInfoes
                            on m.ID equals p.MovieId  
                         select new
                         {
                             m.Title,
                             p.Imdb,
                             p.Cover, 
                             p.LocalPath
                         }).Take(10);
            Image t = Test(result.First().Imdb);
            // Save the image as a JPEG.
            t.Save("c:\\button.jpeg", ImageFormat.Jpeg);
            dynamic finalresult = new ExpandoObject();
            finalresult = result.First();
            byte[] temp = GetBytes(result.First().LocalPath);
            finalresult.LocalPath = ByteArrayToImage.byteArrayToImage(temp);
            return finalresult;
        }

        [HttpPost]
        [ActionName("getAllImages")]
        public object GetAllImages([FromBody]ImagesInput imagesInput)
        {

            var test = Get();
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
            foreach (var requiredMovie in requiredtop100Movies)
            {
                results.Add(new MovieAndPosterInfo()
                {
                    Movie = requiredMovie.Movie,
                    Poster = requiredMovie.PosterInfo
                });
            }
            return Json<List<MovieAndPosterInfo>>(results);
        }

        public HttpResponseMessage Get()
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
            foreach (var requiredMovie in requiredtop100Movies)
            {
                results.Add(new MovieAndPosterInfo()
                {
                    Movie = requiredMovie.Movie,
                    Poster = requiredMovie.PosterInfo
                });
            }



            string yourJson = JsonConvert.SerializeObject(results, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            //string yourJson = GetJsonFromSomewhere();
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");
            return response;
        }

        private static Image Test(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}