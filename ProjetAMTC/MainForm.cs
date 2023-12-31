﻿using ProjetAMTC.Edges_Detections;
using ProjetAMTC.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

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
        private IImageFilterManager imageFilterManager = new ImageFilterManager();


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

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Check if the selected file exists
                if (File.Exists(ofd.FileName))
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
                    else
                    {
                        // Display a message box for unsupported image format
                        MessageBox.Show("Unsupported image format. Please select a valid image file (png, jpg, bmp).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Display a message box for non-existent file
                    MessageBox.Show("The selected file does not exist. Please choose a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Check if the selected directory exists
                    string directory = Path.GetDirectoryName(sfd.FileName);
                    if (!Directory.Exists(directory))
                    {
                        // Display a message box for non-existent directory
                        MessageBox.Show("The specified directory does not exist. Please choose a valid directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop further processing if directory doesn't exist
                    }

                    // Determine the image format based on the file extension
                    string fileExtension = Path.GetExtension(sfd.FileName).ToLower();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == ".bmp")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == ".jpg")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }
                    else if (fileExtension != ".png")
                    {
                        // Display a message box for unsupported image format
                        MessageBox.Show("Unsupported image format. Please select a valid image format (png, jpg, bmp).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop further processing if format is not supported
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
            // Apply edge detection to the source image
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(source, xMatrix, yMatrix, preview);

            // If preview is enabled, display the result in the preview picture box
            if (preview)
            {
                pictureModified.Image = result;
            }
            // Otherwise, set the result as the main result bitmap and update the displayed image
            else
            {
                resultBitmap = result;
                pictureModified.Image = resultBitmap;
            }
        }

        private void ApplySelectedFilters()
        {
            bool filtersApplied = false;

            // Create a copy of the original image for modification
            if (picPreview.Image != null)
            {
                resultBitmap = new Bitmap(picPreview.Image);
            }

            // Apply Rainbow filter if selected
            if (RainbowFiltercheckBox.Checked)
            {
                if (resultBitmap != null)
                {
                    resultBitmap = imageFilterManager.ApplyRainbowFilter(resultBitmap);
                    filtersApplied = true;
                }
            }

            // Apply Night filter if selected
            if (NightFilterCheckBox.Checked)
            {
                if (resultBitmap != null)
                {
                    resultBitmap = imageFilterManager.ApplyNightFilter(resultBitmap,1,1,1,25);
                    filtersApplied = true;
                }
            }

            // Apply Black and White filter if selected
            if (BlackWhiteFilterCheckBox.Checked)
            {
                if (resultBitmap != null)
                {
                    resultBitmap = imageFilterManager.ApplyBlackWhiteFilter(resultBitmap);
                    filtersApplied = true;
                }
            }

            // Disable edge detection buttons and enable filters buttons based on whether filters were applied
            CheckedEdgesButtons(false);
            EnableEdgesButtons(filtersApplied);

            // Update the displayed image based on whether filters were applied
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

            // If the Y matrix is also selected, apply edge detection
            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3HXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedXMatrix = Matrix.Kirsch3x3Horizontal;

            // If the Y matrix is also selected, apply edge detection
            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3VXRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedXMatrix = Matrix.Kirsch3x3Vertical;

            // If the Y matrix is also selected, apply edge detection
            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void LaplacianYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedYMatrix = Matrix.Laplacian3x3;

            // If the X matrix is also selected, apply edge detection
            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3HYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedYMatrix = Matrix.Kirsch3x3Horizontal;

            // If the X matrix is also selected, apply edge detection
            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        private void Kirsch3x3VYRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedYMatrix = Matrix.Kirsch3x3Vertical;

            // If the X matrix is also selected, apply edge detection
            if (selectedYMatrix != null)
            {
                ApplyEdgeDetection(filterBitmap, selectedXMatrix, selectedYMatrix, false);
            }
        }

        // Enable or disable edge detection buttons
        private void EnableEdgesButtons(bool instruction)
        {
            LaplacianXRadioButton.Enabled = instruction;
            LaplacianYRadioButton.Enabled = instruction;
            Kirsch3x3HXRadioButton.Enabled = instruction;
            Kirsch3x3HYRadioButton.Enabled = instruction;
            Kirsch3x3VXRadioButton.Enabled = instruction;
            Kirsch3x3VYRadioButton.Enabled = instruction;
        }

        // Check or uncheck edge detection buttons
        private void CheckedEdgesButtons(bool instruction)
        {
            LaplacianXRadioButton.Checked = instruction;
            LaplacianYRadioButton.Checked = instruction;
            Kirsch3x3HXRadioButton.Checked = instruction;
            Kirsch3x3HYRadioButton.Checked = instruction;
            Kirsch3x3VXRadioButton.Checked = instruction;
            Kirsch3x3VYRadioButton.Checked = instruction;
        }

        // Enable or disable filter buttons
        private void EnableFiltersButtons(bool instruction)
        {
            RainbowFiltercheckBox.Enabled = instruction;
            NightFilterCheckBox.Enabled = instruction;
            BlackWhiteFilterCheckBox.Enabled = instruction;
        }
    }
}
