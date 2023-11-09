using NSubstitute;
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
    [TestClass]
    public class EdgeDetectionTests
    {
        // Test who must return a null value if a source value is given into edge detection method
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

        [TestMethod]
        public void ApplyEdgeDetection_NoMatrix_ReturnsOriginalImage()
        {
            // Arrange
            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
            Bitmap source = new Bitmap(100,100);

            double[,] xMatrix = null;
            double[,] yMatrix = null;
            // Act
            Bitmap result = edgeDetectionManager.ApplyEdgeDetection(source, xMatrix, yMatrix, false);

            // Assert
            Assert.AreEqual(source, result);
        }

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
    }
}
