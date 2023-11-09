using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetAMTC
{
    public class ImageLoader : IImageLoader
    {
        public Bitmap LoadImageFromFile(string filePath)
        {
            Bitmap loadedImage = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    loadedImage = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                }
            }
            catch (FileNotFoundException ex)
            {
           
                Console.WriteLine("File not found: " + ex.Message);
                throw; // Rethrow the exception to maintain the original behavior
            }
            catch (ArgumentException ex)
            {
                
                Console.WriteLine("Invalid image format: " + ex.Message);
                throw; // Rethrow the exception to maintain the original behavior
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("Error loading the image: " + ex.Message);
                throw; // Rethrow the exception to maintain the original behavior
            }
            return loadedImage;
        }




    }

}
