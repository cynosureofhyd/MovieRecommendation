using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppScriptForMovie
{
    class DownloadImagesToLocal
    {
        public static void Download()
        {
            string serverPath = @"C:\Users\PrashMaya\Pictures\MovieRecommendation\";
            string localFilenameImdb = @"C:\Users\PrashMaya\Pictures\MovieRecommendation\{0}.jpg";
            string localFilenameCover = @"C:\Users\PrashMaya\Pictures\MovieRecommendation\Cover-{0}.jpg";
            var db = new MovieEntities();
            int i = 0; 
            foreach (var poster in db.PosterInfoes)
            {
                using (MyWebClient client = new MyWebClient())
                {
                    try
                    {
                        if (poster.Imdb != null)
                        {
                            var imdbId = db.Movies.Where(m => m.ID == poster.MovieId).ToList();
                            //imdbId = db.Movies.Where(s => s.ID == poster.MovieId).ToList();
                            int count = imdbId.Count();
                            serverPath = string.Format(serverPath, imdbId.First().ImdbID);
                            localFilenameImdb = string.Format(localFilenameImdb,  imdbId.First().ImdbID);
                            localFilenameCover = string.Format(localFilenameCover, imdbId.First().ImdbID);

                            //if (!Directory.Exists(serverPath))
                            //    Directory.CreateDirectory(serverPath);

                            client.DownloadFile(poster.Imdb, localFilenameImdb);
                            i++;
                            localFilenameImdb = @"C:\Users\PrashMaya\Pictures\MovieRecommendation\{0}.jpg";
                            //serverPath = @"C:\Users\PrashMaya\Pictures\{0}\";
                        }
                        //client.DownloadFile(poster.Cover, localFilenameCover);
                    }
                    catch(Exception ex)
                    {
                        i++;
                        continue;
                    }
                }
            }
        }
    }
}
