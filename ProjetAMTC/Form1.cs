using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TP1AMTC;

namespace ProjetAMTC
{
    public partial class Form1 : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap resultBitmap = null;
        private double[,] xEdgeDetectionMatrix = null;
        private double[,] yEdgeDetectionMatrix = null;
        private string selectedXEdgeDetection = null; // Store the selected items
        private string selectedYEdgeDetection = null; // Store the selected items
        private IImageLoader fileLoader = new ImageLoader();
        private IImageSaver imageSaver = new ImageSaver();

        public Form1()
        {
            InitializeComponent();

            // Set the default edge detection method to "None"
            xEdgeDetection.SelectedIndex = 0;
            yEdgeDetection.SelectedIndex = 0;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select an image file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Use the file loader to load the image
                originalBitmap = fileLoader.LoadImageFromFile(ofd.FileName);

                if (originalBitmap != null)
                {
                    // Copy the original image to a square canvas and display it
                    resultBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                    picPreview.Image = resultBitmap;

                    // Apply the default edge detection method
                    ApplyEdgeDetection(true);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Apply edge detection (final) before saving the image
            ApplyEdgeDetection(false);

            if (resultBitmap != null)
            {
                // Open a save file dialog to specify the file name and format
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Determine the image format based on the file extension
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    // Save the result image with the specified format
                    imageSaver.SaveImage(resultBitmap, sfd.FileName, imgFormat);

                    // Reset the result image and edge detection method
                    resultBitmap = null;
                    pictureModified.Image = picPreview.Image;
                    xEdgeDetection.SelectedIndex = 0;
                    yEdgeDetection.SelectedIndex = 0;
                }
            }
        }

        private void ApplyEdgeDetection(bool preview)
        {
            if (resultBitmap == null)
            {
                return;
            }

            Bitmap selectedSource = resultBitmap;

            if (selectedSource != null)
            {
                if (preview)
                {
                    // Display the preview of the edge detection result
                    pictureModified.Image = ApplyEdgeDetection(selectedSource, xEdgeDetectionMatrix, yEdgeDetectionMatrix);
                }
                else
                {
                    // Update the final result image
                    resultBitmap = ApplyEdgeDetection(selectedSource, xEdgeDetectionMatrix, yEdgeDetectionMatrix);
                }
            }

            Bitmap ApplyEdgeDetection(Bitmap source, double[,] xMatrix, double[,] yMatrix)
            {
                int width = source.Width;
                int height = source.Height;

                Bitmap result = new Bitmap(width, height);

                switch (selectedXEdgeDetection)
                {
                    case "None":
                        xMatrix = null; // No edge detection, set the matrix to null
                        break;
                    case "Laplacian 3x3":
                        //xMatrix = Matrix.Laplacian3x3;
                        break;
                    case "Laplacian 5x5":
                        //xMatrix = Matrix.Laplacian5x5;
                        break;
                    case "LaplacianOfGaussian":
                        //xMatrix = Matrix.LaplacianOfGaussian;
                        break;
                    case "Gaussian3x3":
                        //xMatrix = Matrix.Gaussian3x3;
                        break;
                    case "Gaussian5x5Type1":
                        //xMatrix = Matrix.Gaussian5x5Type1;
                        break;
                    case "Gaussian5x5Type2":
                        //xMatrix = Matrix.Gaussian5x5Type2;
                        break;
                    case "Sobel3x3Horizontal":
                        //xMatrix = Matrix.Sobel3x3Horizontal;
                        break;
                    case "Sobel3x3Vertical":
                        //xMatrix = Matrix.Sobel3x3Vertical;
                        break;
                    case "Prewitt3x3Horizontal":
                        //xMatrix = Matrix.Prewitt3x3Horizontal;
                        break;
                    case "Prewitt3x3Vertical":
                        //xMatrix = Matrix.Prewitt3x3Vertical;
                        break;
                    case "Kirsch3x3Horizontal":
                        //xMatrix = Matrix.Kirsch3x3Horizontal;
                        break;
                    case "Kirsch3x3Vertical":
                        //xMatrix = Matrix.Kirsch3x3Vertical;
                        break;
                }

                switch (selectedYEdgeDetection)
                {
                    case "None":
                        yMatrix = null; // No edge detection, set the matrix to null
                        break;
                    case "Laplacian 3x3":
                        //yMatrix = Matrix.Laplacian3x3;
                        break;
                    case "Laplacian 5x5":
                        //yMatrix = Matrix.Laplacian5x5;
                        break;
                    case "LaplacianOfGaussian":
                        //yMatrix = Matrix.LaplacianOfGaussian;
                        break;
                    case "Gaussian3x3":
                        //yMatrix = Matrix.Gaussian3x3;
                        break;
                    case "Gaussian5x5Type1":
                        //yMatrix = Matrix.Gaussian5x5Type1;
                        break;
                    case "Gaussian5x5Type2":
                        //yMatrix = Matrix.Gaussian5x5Type2;
                        break;
                    case "Sobel3x3Horizontal":
                        //yMatrix = Matrix.Sobel3x3Horizontal;
                        break;
                    case "Sobel3x3Vertical":
                        //yMatrix = Matrix.Sobel3x3Vertical;
                        break;
                    case "Prewitt3x3Horizontal":
                        //yMatrix = Matrix.Prewitt3x3Horizontal;
                        break;
                    case "Prewitt3x3Vertical":
                        //yMatrix = Matrix.Prewitt3x3Vertical;
                        break;
                    case "Kirsch3x3Horizontal":
                        //yMatrix = Matrix.Kirsch3x3Horizontal;
                        break;
                    case "Kirsch3x3Vertical":
                        //yMatrix = Matrix.Kirsch3x3Vertical;
                        break;
                }

                if (xMatrix == null && yMatrix == null)
                {
                    // No edge detection selected, return the original image
                    return source;
                }

                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        double xGradient = 0.0;
                        double yGradient = 0.0;

                        // Calculate gradients using xMatrix and yMatrix
                        for (int j = -1; j <= 1; j++)
                        {
                            for (int i = -1; i <= 1; i++)
                            {
                                Color neighborColor = source.GetPixel(x + i, y + j);
                                double grayValue = neighborColor.R * 0.3 + neighborColor.G * 0.59 + neighborColor.B * 0.11;
                                xGradient += grayValue * xMatrix[i + 1, j + 1];
                                yGradient += grayValue * yMatrix[i + 1, j + 1];
                            }
                        }

                        // Calculate the magnitude of the gradient
                        double gradientMagnitude = Math.Sqrt(xGradient * xGradient + yGradient * yGradient);

                        // Apply the gradient magnitude as a new pixel value
                        int newValue = (int)Math.Max(0, Math.Min(255, gradientMagnitude));
                        result.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
                    }
                }

                return result;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Check if both combo boxes have selected items

            if (xEdgeDetection.SelectedIndex == 0 || yEdgeDetection.SelectedIndex == 0)
            {
                MessageBox.Show("Please select values for X axis and Y axis.");
                return;
            }

            // If both combo boxes have selected items, apply the edge detection
            ApplyEdgeDetection(true);
        }

        private void xEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update xEdgeDetectionMatrix according to selection
            selectedXEdgeDetection = xEdgeDetection.SelectedItem.ToString();
        }

        private void yEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update yEdgeDetectionMatrix according to selection
            selectedYEdgeDetection = yEdgeDetection.SelectedItem.ToString();
        }

        private void RainbowFiltercheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Apply the rainbow filter and reset the edge detection method
            resultBitmap = RainbowFilter.ApplyRainbowFilter(new Bitmap(picPreview.Image));
            pictureModified.Image = resultBitmap;
            xEdgeDetection.SelectedIndex = 0;
            yEdgeDetection.SelectedIndex = 0;
        }

        private void NightFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Apply the night filter and reset the edge detection method
            resultBitmap = NightFilter.ApplyNightFilter(new Bitmap(picPreview.Image), 1, 1, 1, 25);
            pictureModified.Image = resultBitmap;
            xEdgeDetection.SelectedIndex = 0;
            yEdgeDetection.SelectedIndex = 0;
        }

        private void BlackWhiteFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //resultBitmap = BlackWhiteFilter.ApplyBlackWhite(new Bitmap(picPreview.Image), 1, 1, 1, 25);
            pictureModified.Image = resultBitmap;
            xEdgeDetection.SelectedIndex = 0;
            yEdgeDetection.SelectedIndex = 0;
        }

        private void LaplacianXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /// EDGE DETECTION
        }

        private void Kirsch3x3HXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /// EDGE DETECTION
        }

        private void Kirsch3x3VXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /// EDGE DETECTION
        }

        private void LaplacianYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /// EDGE DETECTION
        }

        private void Kirsch3x3HYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /// EDGE DETECTION
        }

        private void Kirsch3x3VYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /// EDGE DETECTION
        }
    }
}
