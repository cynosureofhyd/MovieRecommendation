using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            return result;
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