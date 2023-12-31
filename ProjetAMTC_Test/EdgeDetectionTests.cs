﻿using NSubstitute;
using ProjetAMTC.Edges_Detections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetAMTC;
using ProjetAMTC.Filters;

namespace ProjetAMTC_Test
{
    /// <summary>
    /// Test class for the EdgeDetectionManager class. ChatGPT was used to help with certain tests.
    /// </summary>
    [TestClass]
    public class EdgeDetectionTests
    {
        /// <summary>
        /// Test method for the ApplyEdgeDetection method when a null source is provided.
        /// It should return null as the result.
        /// </summary>
        [TestMethod]
        public void ApplyEdgeDetection_NullSource_ReturnsNull()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            // Act
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(null, null, null, false);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Test method for the ApplyEdgeDetection method when no X matrix is provided.
        /// It should return the original image.
        /// </summary>
        [TestMethod]
        public void ApplyEdgeDetection_NoMatrixX_ReturnsOriginalImage()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            Bitmap source = new Bitmap(100,100);

            double[,] xMatrix = null;
            double[,] yMatrix = Matrix.Kirsch3x3Horizontal;
            // Act
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(source, xMatrix, yMatrix, false);

            // Assert
            Assert.AreEqual(source, result);
        }

        /// <summary>
        /// Test method for the ApplyEdgeDetection method when no Y matrix is provided.
        /// It should return the original image.
        /// </summary>
        [TestMethod]
        public void ApplyEdgeDetection_NoMatrixY_ReturnsOriginalImage()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            Bitmap source = new Bitmap(100, 100);

            double[,] xMatrix = Matrix.Laplacian3x3;
            double[,] yMatrix = null;
            // Act
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(source, xMatrix, yMatrix, false);

            // Assert
            Assert.AreEqual(source, result);
        }

        /// <summary>
        /// Test method for calculating the X gradient in a specific scenario with an expected result.
        /// </summary>
        [TestMethod]
        public void CalculateXGradient_SomeTestScenario_ExpectedResult()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            ImageFilterManager filterManager = new ImageFilterManager();
            Bitmap sourceImage = new Bitmap("TestFiles/imageTest.jpg");
            double[,] xMatrix = Matrix.Laplacian3x3;

            var expectedXGradient = 5.000000000000014;

            filterManager.ApplyRainbowFilter(sourceImage);

            // Act
            double result = edgeDetectionManager.CalculateXGradient(sourceImage, xMatrix, 1, 1);

            // Assert (replace with your actual expected result)
            Assert.AreEqual(expectedXGradient, result);
        }

        /// <summary>
        /// Test method for calculating the Y gradient in a specific scenario with an expected result.
        /// </summary>
        [TestMethod]
        public void CalculateYGradient_SomeTestScenario_ExpectedResult()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            ImageFilterManager filterManager = new ImageFilterManager();
            Bitmap sourceImage = new Bitmap("TestFiles/imageTest.jpg");
            double[,] yMatrix = Matrix.Kirsch3x3Vertical;

            var expectedXGradient = -17;

            filterManager.ApplyBlackWhiteFilter(sourceImage);

            // Act
            double result = edgeDetectionManager.CalculateYGradient(sourceImage, yMatrix, 1, 1);

            // Assert
            Assert.AreEqual(expectedXGradient, result);
        }

        /// <summary>
        /// Test method for calculating the Y gradient in another specific scenario with an expected result.
        /// </summary>
        [TestMethod]
        public void CalculateYGradient_SomeTestScenario_ExpectedResult2()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            ImageFilterManager filterManager = new ImageFilterManager();
            Bitmap sourceImage = new Bitmap("TestFiles/imageTest.jpg");
            double[,] yMatrix = Matrix.Kirsch3x3Horizontal;

            var expectedXGradient = -9.000000000000028;

            filterManager.ApplyBlackWhiteFilter(sourceImage);

            // Act
            double result = edgeDetectionManager.CalculateYGradient(sourceImage, yMatrix, 1, 1);

            // Assert
            Assert.AreEqual(expectedXGradient, result);
        }

        /// <summary>
        /// Test method for calculating the magnitude of the gradient in a specific scenario with an expected result.
        /// </summary>
        [TestMethod]
        public void CalculateGradientMagnitude_SomeTestScenario_ExpectedResult()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            // Act
            double result = edgeDetectionManager.CalculateGradientMagnitude(3.0, 4.0);

            // Assert
            Assert.AreEqual(5, result, 0.001); // Using a delta for double comparison
        }

        /// <summary>
        /// Test method for calculating the new pixel value with a gradient magnitude within the range.
        /// </summary>
        [TestMethod]
        public void CalculateNewPixelValue_GradientMagnitudeInRange_ReturnsMagnitude()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            // Act
            int result = edgeDetectionManager.CalculateNewPixelValue(127.0);

            // Assert
            Assert.AreEqual(127, result);
        }

        /// <summary>
        /// Test method for calculating the new pixel value with a gradient magnitude below the range.
        /// </summary>
        [TestMethod]
        public void CalculateNewPixelValue_GradientMagnitudeBelowRange_ReturnsMinimumValue()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            // Act
            int result = edgeDetectionManager.CalculateNewPixelValue(-10.0);

            // Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test method for calculating the new pixel value with a gradient magnitude above the range.
        /// </summary>
        [TestMethod]
        public void CalculateNewPixelValue_GradientMagnitudeAboveRange_ReturnsMaximumValue()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            // Act
            int result = edgeDetectionManager.CalculateNewPixelValue(300.0);

            // Assert
            Assert.AreEqual(255, result);
        }

        /// <summary>
        /// Test to ensure that edge detection is applied to each pixel in the image.
        /// </summary>
        [TestMethod]
        public void ApplyEdgeDetection_EachPixelProcessed()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            Bitmap sourceImage = new Bitmap(10, 10);
            double[,] xMatrix = Matrix.Laplacian3x3;
            double[,] yMatrix = Matrix.Kirsch3x3Vertical;

            // Act
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(sourceImage, xMatrix, yMatrix, false);

            // Assert
            for (int y = 1; y < sourceImage.Height - 1; y++)
            {
                for (int x = 1; x < sourceImage.Width - 1; x++)
                {
                    // Verify that each pixel in the result image has been processed
                    Color resultColor = result.GetPixel(x, y);
                    Assert.IsNotNull(resultColor);
                }
            }
        }
    }
}

