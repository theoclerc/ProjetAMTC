using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC
{
    public static class NightFilter
    {
        public static Bitmap ApplyNightFilter(Bitmap bmp, int alpha, int red, int blue, int green)
        {
            // Create a new temporary image with the same dimensions as the input image
            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            // Iterate through each pixel of the input image
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    // Get the color of the pixel at the current position
                    Color pixelColor = bmp.GetPixel(i, x);

                    // Apply a color filter based on the alpha, red, green, and blue parameters
                    Color newColor = Color.FromArgb(
                        pixelColor.A / alpha,
                        pixelColor.R / red,
                        pixelColor.G / green,
                        pixelColor.B / blue
                    );

                    // Set the filtered color for the corresponding pixel in the temporary image
                    temp.SetPixel(i, x, newColor);
                }
            }
            // Return the filtered image
            return temp;
        }

    }
}
