using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppScriptForMovie
{
    public class ImageToString
    {
        public static string ConvertImageToBase64(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

              public static System.Drawing.Image Base64ToImage(string base64String)
              {
                  // Convert Base64 String to byte[]
                  byte[] imageBytes = Convert.FromBase64String(base64String);
                  MemoryStream ms = new MemoryStream(imageBytes, 0,
                    imageBytes.Length);

                  // Convert byte[] to Image
                  ms.Write(imageBytes, 0, imageBytes.Length);
                  Image image = Image.FromStream(ms, true);
                  return image;
              }
    }
}
