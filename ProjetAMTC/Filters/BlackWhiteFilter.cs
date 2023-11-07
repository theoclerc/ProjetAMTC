using ProjetAMTC.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC
{
    public class BlackWhiteFilter : IImageFilter
    {
        // Method to apply the black and white filter
        public Bitmap ApplyFilter(Bitmap bmp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    // Get the color of the current pixel
                    c = bmp.GetPixel(x, y);
                    // Calculate the average RGB value to get the grayscale level
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    // Set the filtered pixel with the new grayscale color
                    bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }

            // Return the black and white filtered image
            return bmp;
        }
    }
}
