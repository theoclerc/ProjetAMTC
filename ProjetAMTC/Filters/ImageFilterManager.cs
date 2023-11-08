using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC.Filters
{
    public class ImageFilterManager : IImageFilterManager
    {
        public Bitmap ApplyNightFilter(Bitmap bmp, int alpha, int red, int blue, int green)
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

        public Bitmap ApplyRainbowFilter(Bitmap bmp)
        {
            // Create a new temporary image with the same dimensions as the input image
            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            // Calculate the size of a vertical band to divide the image into four bands
            int verticalBandSize = bmp.Height / 4;

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
                    if (i < verticalBandSize)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(red, pixelColor.G, pixelColor.B));
                    }
                    else if (i < verticalBandSize * 2)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(pixelColor.R, green, pixelColor.B));
                    }
                    else if (i < verticalBandSize * 3)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(pixelColor.R, pixelColor.G, blue));
                    }
                    else if (i < verticalBandSize * 4)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(red, pixelColor.G, blue));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(red, green, blue));
                    }
                }
            }

            return temp;
        }

        public Bitmap ApplyBlackWhiteFilter(Bitmap bmp)
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
