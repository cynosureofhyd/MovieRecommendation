using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ConsoleAppScriptForMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertToBase64Image();
            //string wow = ImageToByteArray();
            //Image im = ImageToString.Base64ToImage(wow);
            DeleteDups();
            //LoadDataIntoDb();
        }

        static string ImageToByteArray(string url)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(url);
            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
            //ImageToString.
        }


        static void ConvertToBase64Image()
        {
            MovieEntities db = new MovieEntities();
            foreach(PosterInfo poster in db.PosterInfoes)
            {
                if(poster.Imdb != null && !string.IsNullOrWhiteSpace(poster.Imdb))
                {
                    string base64 = ImageToByteArray(poster.Imdb);
                    poster.LocalPath = base64;
                    db.SaveChanges();       
                }
            }
        }


        static void DeleteDups()
        {
            MovieEntities db = new MovieEntities();
            HashSet<string> movies = new HashSet<string>();
            var dups = db.Movies.GroupBy(i => i.ImdbID).Where(x => x.Count() > 1).Distinct();
            foreach (var movie in db.Movies)
            {
                var test = db.Movies.Where(p => p.Title == "Peter Pan");
                var q = test.ToList();
                if(q.Count > 1)
                {
                    //var delete =
                    for (int k = 1; k < q.Count(); k++ )
                    {
                        try
                        {
                            var movies1 = q.ToList();
                            long tempid = movies1.ElementAt(k).ID;
                                //// TODO: This query is to find the valid record which should not be deleted inside the posterinfo class
                            var validPosterInfo = (from h in db.PosterInfoes
                                                   where h.MovieId == tempid
                                                  select h).ToList();
                            if (validPosterInfo.Count() == 0)
                            {
                                db.Movies.Remove(q.ElementAt(k));
                                db.SaveChanges();
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                        //db.PosterInfoes.Remove(q.ElementAt(0));
                    //db.SaveChanges();
                    //Console.WriteLine("Hello");
                }
            }

                foreach (var item in movies)
                {
                    var m = db.Movies.Where(s => s.ImdbID == item);
                    db.Movies.Remove(m.First());
                    db.SaveChanges();
                }
            Console.WriteLine(movies.Count());
        }

        static void LoadDataIntoDb()
        {
            string inputpath = "C:\\Users\\PrashMaya\\Desktop\\IMDBMovieTitleIds-0-2500.txt";
            string inputfolder = "C:\\Users\\PrashMaya\\My Documents\\First2500MoviesIMDB\\Movie{0}.txt";
            MovieEntities db = new MovieEntities();

            for(int i = 0; i < 2450; i++)
            {
                string currentFile = string.Format(inputfolder, i);
                string text = System.IO.File.ReadAllText(@inputpath);
                dynamic obj = ConvertToObj(text);
                Movie movie = new Movie();
                movie.PlotDetailed = obj[0]["plot"];
            }
        }

        public static dynamic ConvertToObj(string str)
        {
            dynamic moreInfo = JsonConvert.DeserializeObject(str);
            string temp = moreInfo[0]["plot"];
            return moreInfo;
        }
    }
}
