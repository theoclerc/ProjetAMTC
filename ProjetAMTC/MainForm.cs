using ProjetAMTC.Edges_Detections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TP1AMTC;

namespace ProjetAMTC
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap resultBitmap = null;
        private Bitmap filterBitmap = null;
        double[,] selectedXMatrix = null;
        double[,] selectedYMatrix = null;
        private IImageLoader fileLoader = new ImageLoader();
        private IImageSaver imageSaver = new ImageSaver();
        private IEdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

        public MainForm()
        {
            InitializeComponent();
            EnableFiltersButtons(false);
            EnableEdgesButtons(false);
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
                    pictureModified.Image = resultBitmap;
                    EnableFiltersButtons(true);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

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
                    RainbowFiltercheckBox.Checked = false;
                    NightFilterCheckBox.Checked = false;
                    BlackWhiteFilterCheckBox.Checked = false;
                    CheckedEdgesButtons(false);
                    selectedXMatrix = null;
                    selectedYMatrix = null;
                }
            }
        }

        private void ApplyEdgeDetection(Bitmap source, double[,] xMatrix, double[,] yMatrix, bool preview)
        {
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(source, xMatrix, yMatrix, preview);
            if (preview)
            {
                pictureModified.Image = result;
            }
            else
            {
                resultBitmap = result;
                pictureModified.Image = resultBitmap;
            }
        }

        private void ApplySelectedFilters()
        {
            bool filtersApplied = false;

            // Crée une copie de l'image originale pour la modification
            if (picPreview.Image != null)
            {
                resultBitmap = new Bitmap(picPreview.Image);
            }

            if (RainbowFiltercheckBox.Checked)
            {
                if (resultBitmap != null)
                {
                    resultBitmap = RainbowFilter.ApplyRainbowFilter(resultBitmap);
                    filtersApplied = true;
                }
            }

            if (NightFilterCheckBox.Checked)
            {
                if (resultBitmap != null)
                {
                    resultBitmap = NightFilter.ApplyNightFilter(resultBitmap, 1, 1, 1, 25);
                    filtersApplied = true;
                }
            }

            if (BlackWhiteFilterCheckBox.Checked)
            {
                if (resultBitmap != null)
                {
                    resultBitmap = BlackWhiteFilter.ApplyBlackWhite(resultBitmap);
                    filtersApplied = true;
                }
            }

            CheckedEdgesButtons(false);
            EnableEdgesButtons(filtersApplied);

            if (!filtersApplied)
            {
                pictureModified.Image = picPreview.Image;
            }
            else
            {
                pictureModified.Image = resultBitmap;
                filterBitmap = resultBitmap;
            }
        }

        private void RainbowFiltercheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApplySelectedFilters();
        }

        private void NightFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApplySelectedFilters();
        }

        private void BlackWhiteFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApplySelectedFilters();
        }

        private void LaplacianXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedXMatrix = Matrix.Laplacian3x3;

            if(selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3HXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedXMatrix = Matrix.Kirsch3x3Horizontal;

            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3VXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedXMatrix = Matrix.Kirsch3x3Vertical;

            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void LaplacianYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedYMatrix = Matrix.Laplacian3x3;

            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3HYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedYMatrix = Matrix.Kirsch3x3Horizontal;

            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3VYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedYMatrix = Matrix.Kirsch3x3Vertical;

            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void EnableEdgesButtons(bool instruction)
        {
            LaplacianXRadioButton.Enabled = instruction;
            LaplacianYRadioButton.Enabled = instruction;
            Kirsch3x3HXRadioButton.Enabled = instruction;
            Kirsch3x3HYRadioButton.Enabled = instruction;
            Kirsch3x3VXRadioButton.Enabled = instruction;
            Kirsch3x3VYRadioButton.Enabled = instruction;
        }

        private void CheckedEdgesButtons(bool instruction)
        {
            LaplacianXRadioButton.Checked = instruction;
            LaplacianYRadioButton.Checked = instruction;
            Kirsch3x3HXRadioButton.Checked = instruction;
            Kirsch3x3HYRadioButton.Checked = instruction;
            Kirsch3x3VXRadioButton.Checked = instruction;
            Kirsch3x3VYRadioButton.Checked = instruction;
        }

        private void EnableFiltersButtons(bool instruction)
        {
            RainbowFiltercheckBox.Enabled = instruction;
            NightFilterCheckBox.Enabled = instruction;
            BlackWhiteFilterCheckBox.Enabled = instruction;
        }


    }
}
