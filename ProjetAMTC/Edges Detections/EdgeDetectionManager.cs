using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC.Edges_Detections
{
    /// <summary>
    /// Implementation of the <see cref="IEdgeDetectionManager"/> interface for applying edge detection on Bitmap images.
    /// </summary>
    public class EdgeDetectionManager : IEdgeDetectionManager
    {
        const double RedWeight = 0.3;
        const double GreenWeight = 0.59;
        const double BlueWieght = 0.11;

        /// <summary>
        /// Applies edge detection to the input image using the specified matrices for x and y gradients.
        /// </summary>
        /// <param name="source">The input Bitmap image.</param>
        /// <param name="xMatrix">The matrix for x gradients.</param>
        /// <param name="yMatrix">The matrix for y gradients.</param>
        /// <param name="preview">Flag indicating whether to return a preview image.</param>
        /// <returns>The resulting edge-detected Bitmap image.</returns>
        public Bitmap ApplyEdgeDetection(Bitmap source, double[,] xMatrix, double[,] yMatrix, bool preview)
        {

            // Check if the input source image is null
            if (source == null)
            {
                return null;
            }

            int width = source.Width;
            int height = source.Height;
            // Create a new Bitmap to store the result
            Bitmap result = new Bitmap(width, height);

            if (xMatrix == null || yMatrix == null)
            {
                // No edge detection selected, return the original image
                result = source;
                return result;
            }

            // Loop through each pixel in the image
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    // Calculate the x and y gradients
                    double xGradient = CalculateXGradient(source, xMatrix, x, y);
                    double yGradient = CalculateYGradient(source, yMatrix, x, y);

                    // Calculate the magnitude of the gradient
                    double gradientMagnitude = CalculateGradientMagnitude(xGradient, yGradient);

                    // Calculate a new pixel value based on the gradient magnitude
                    int newValue = CalculateNewPixelValue(gradientMagnitude);

                    // Set the pixel in the result image with the new value
                    result.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
                }
            }

            // Return either the result image or a copy of the source image based on the 'preview' flag
            return preview ? new Bitmap(result) : result;
        }

        /// <summary>
        /// Calculates the x-gradient for a given pixel using a specified x-gradient matrix.
        /// </summary>
        /// <param name="source">The source image.</param>
        /// <param name="xMatrix">The x-gradient matrix.</param>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <returns>The calculated x-gradient value.</returns>
        public double CalculateXGradient(Bitmap source, double[,] xMatrix, int x, int y)
        {
            double xGradient = 0.0;
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    // Get the color of the neighbor pixel
                    Color neighborColor = source.GetPixel(x + i, y + j);
                    // Calculate the grayscale value of the neighbor pixel
                    double grayValue = neighborColor.R * RedWeight + neighborColor.G * GreenWeight + neighborColor.B * BlueWieght;
                    // Calculate the x-gradient component using the xMatrix
                    xGradient += grayValue * xMatrix[i + 1, j + 1];
                }
            }
            return xGradient;
        }

        /// <summary>
        /// Calculates the y-gradient for a given pixel using a specified y-gradient matrix.
        /// </summary>
        /// <param name="source">The source image.</param>
        /// <param name="yMatrix">The y-gradient matrix.</param>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <returns>The calculated y-gradient value.</returns>
        public double CalculateYGradient(Bitmap source, double[,] yMatrix, int x, int y)
        {
            double yGradient = 0.0;
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    // Get the color of the neighbor pixel
                    Color neighborColor = source.GetPixel(x + i, y + j);
                    // Calculate the grayscale value of the neighbor pixel
                    double grayValue = neighborColor.R * RedWeight + neighborColor.G * GreenWeight + neighborColor.B * BlueWieght;
                    // Calculate the y-gradient component using the yMatrix
                    yGradient += grayValue * yMatrix[i + 1, j + 1];
                }
            }
            return yGradient;
        }

        /// <summary>
        /// Calculates the magnitude of the gradient from its x and y components.
        /// </summary>
        /// <param name="xGradient">The x-gradient component.</param>
        /// <param name="yGradient">The y-gradient component.</param>
        /// <returns>The calculated magnitude of the gradient.</returns>
        public double CalculateGradientMagnitude(double xGradient, double yGradient)
        {
            return Math.Sqrt(xGradient * xGradient + yGradient * yGradient);
        }

        /// <summary>
        /// Calculates the new pixel value based on the gradient magnitude.
        /// Ensures the value is within the 0-255 range.
        /// </summary>
        /// <param name="gradientMagnitude">The magnitude of the gradient.</param>
        /// <returns>The calculated new pixel value.</returns>
        public int CalculateNewPixelValue(double gradientMagnitude)
        {
            // Ensure the value is within the 0-255 range
            return (int)Math.Max(0, Math.Min(255, gradientMagnitude));
        }
    }
}