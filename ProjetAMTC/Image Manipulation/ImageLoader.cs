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
            catch (Exception ex)
            {
                // Handle any exceptions, e.g., file not found or invalid image format
                // You can log the exception or show an error message to the user
                MessageBox.Show("Error loading the image: " + ex.Message);
            }
            return loadedImage;

        }

    }

}
