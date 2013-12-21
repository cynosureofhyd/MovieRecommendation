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
            return View();
        }

        public ActionResult LoadData()
        {
            //AddSampleRoleData();
            string inputpath = "C:\\Users\\PrashMaya\\Desktop\\IMDBMovieTitleIds-0-2500.txt";
            string inputfolder = "C:\\Users\\PrashMaya\\My Documents\\First2500MoviesIMDB\\Movie{0}.txt";
            inputpath = String.Format(inputfolder, 1);

            for (int i = 240; i < 2451; i++)
            {
                inputpath = String.Format(inputfolder, i);
                string text = System.IO.File.ReadAllText(@inputpath);
                if (text.Length > 10)
                {
                    dynamic obj = ConvertToObj(text);
                    LoadDataIntoDb(obj, i);
                }
            }

            HashSet<string> keys = new HashSet<string>();
            string[] lines = System.IO.File.ReadAllLines(@inputpath);
            return View();
        }

        private static void LoadDataIntoDb(dynamic obj, int path)
        {
            try
            {
                MovieEntities db = new MovieEntities();
               
                string imdbId = obj[0]["imdb_id"];
                
                //if(!db.Movies.Select(m => m.ImdbID == imdbId).First())
                if(db.Movies.Count() == 0 || !db.Movies.Select(m => m.ImdbID == imdbId).First())
                {
                    Int64 existingMovieId = 0;
                    if (db.Movies.Count() > 0)
                        existingMovieId = db.Movies.Count();
                    Movie movie = new Movie();
                    movie.ID = existingMovieId + 1;
                    movie.PlotDetailed = obj[0]["plot"];
                    movie.ImdbID = obj[0]["imdb_id"];
                    movie.PlotSimple = obj[0]["plot_simple"];
                    var tempruntime = obj[0]["runtime"];
                    movie.Runtime = ConvertRuntime(tempruntime.ToString());
                    movie.Rated = obj[0]["rated"];
                    movie.ImdbUrl = obj[0]["imdb_url"];
                    movie.AKA = obj[0]["also_known_as"][0];
                    movie.IMDBRating = obj[0]["rating"];
                    Int64 releaseDate = obj[0]["release_date"];
                    DateTime dtTime = new DateTime(Int32.Parse(releaseDate.ToString().Substring(0, 4)), Int32.Parse(releaseDate.ToString().Substring(4, 2)), Int32.Parse(releaseDate.ToString().Substring(6, 2)));
                    movie.ReleaseDate = dtTime;
                    movie.Title = obj[0]["title"];
                    Genres(obj, db);
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    var savedMovie = db.Movies.Where(m => m.ImdbID == movie.ImdbID).Distinct();

                    MoviePersonRole(obj, db);
                    var ListOfGenre = obj[0]["genres"];
                    Poster poster = new Poster();
                    poster.imdb = obj[0]["poster"]["imdb"];
                    poster.cover = obj[0]["poster"]["cover"];
                    PosterInfo posterInfo = new PosterInfo();
                    posterInfo.Imdb = poster.imdb;
                    posterInfo.Cover = poster.cover;
                    posterInfo.MovieId = savedMovie.First().ID;
                    db.PosterInfoes.Add(posterInfo);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                string inputfolder = "C:\\Users\\PrashMaya\\My Documents\\Exceptions\\Movie{0}.txt";
                string inputfile = String.Format(inputfolder, path);
                System.IO.File.WriteAllText(inputfile,ex.ToString());
                Console.WriteLine(ex.Message);
            }
        }

        public static void MoviePersonRole(dynamic obj, MovieEntities db)
        {
            string actorName = string.Empty;
            var actor = db.Roles.Where(a => a.Description == "Actor");
            for (int i = 0; i < obj[0]["actors"].Count; i++)
             {
                 Person per = new Person();
                 actorName = obj[0]["actors"][i];
                 //per.FirstName = 
             }
        }

        public static void SplitName(string name)
        {
            Person p = new Person();
            string[] ssize = name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            //string firstName = name.Substring(;
            for(int i = 0; i < ssize.Count(); i++)
            {
                p.FirstName = ssize[i];
                //p.MiddleName = ssize[]
            }
        }

        public static void Genres(dynamic genres, MovieEntities db)
        {
            Genre genre = new Genre();
            
            string genrename = "";
            for (int i = 0; i < genres[0]["genres"].Count; i++)
            {
                genrename = genres[0]["genres"][i];
                if (!String.IsNullOrWhiteSpace(genrename))
                {
                    var g = db.Genres.Where(gen => gen.Name == genrename).Distinct();
                }
            }

            //db.Genres.Add(genre);
            //db.SaveChanges();
        }

        public static int ConvertRuntime(string runtime)
        {
            string result = "";
            for(int i = 0; i < runtime.Length; i++)
            {
                if (char.IsDigit(runtime[i]))
                    result += runtime[i];
            }
            return Int32.Parse(result); ;
        }

        private static void ProcessDynamic(dynamic obj)
        {

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


        private static void AddSampleRoleData()
        {
            Role role = new Role();
            role.Description = "Director";
            MovieEntities db = new MovieEntities();
            db.Roles.Add(role);
            db.SaveChanges();
        }
    }
}
