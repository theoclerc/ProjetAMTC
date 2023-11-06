using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC
{
    public static class RainbowFilter
    {
        public static Bitmap ApplyRainbowFilter(Bitmap bmp)
        {
            // Create a new temporary image with the same dimensions as the input image
            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            // Calculate the size of a vertical band to divide the image into four bands
            int raz = bmp.Height / 4;

            // Iterate through each pixel of the input image
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    // Get the color of the pixel at the current position
                    Color pixelColor = bmp.GetPixel(i, x);

                    // Divide the color components by 5 to reduce intensity
                    int red = pixelColor.R / 5;
                    int green = pixelColor.G / 5;
                    int blue = pixelColor.B / 5;

                    // Apply a rainbow filter based on the horizontal position of the pixel
                    if (i < raz)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(red, pixelColor.G, pixelColor.B));
                    }
                    else if (i < raz * 2)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(pixelColor.R, green, pixelColor.B));
                    }
                    else if (i < raz * 3)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(pixelColor.R, pixelColor.G, blue));
                    }
                    else if (i < raz * 4)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(red, pixelColor.G, blue));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(red, green, blue));
                    }
                }
            }
            // Return the filtered image
            return temp;
        }
    }
}
