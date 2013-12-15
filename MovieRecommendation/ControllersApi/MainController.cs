using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRecommendation.Utilities;

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


        //private static void storeimages(MovieEntities db)
        //{
        //    var data = db.PosterInfoes.All
        //}

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