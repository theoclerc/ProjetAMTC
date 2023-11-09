using NSubstitute;
using ProjetAMTC.Edges_Detections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetAMTC;
using System.Drawing.Drawing2D;

namespace ProjetAMTC_Test
{
    /* [TestClass]
     public class EdgeDetectionTests
     {
         [TestMethod]
         public void CalculateXGradient_ReturnsExpectedValue()
         {
             // Arrange
             IEdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();
             double[,] xMatrix = Matrix.Laplacian3x3; // Use the Laplacian 3x3 matrix
             int x = 1; // Replace with your desired x coordinate
             int y = 1; // Replace with your desired y coordinate

             // Create a substitute for the Bitmap
             var substituteBitmap = Substitute.For<Bitmap>();

             // Define the expected behavior of the substitute Bitmap
             // You need to specify the behavior for GetPixel and properties like Width and Height
             substituteBitmap.Width.Returns(3); // Replace with your desired width
             substituteBitmap.Height.Returns(3); // Replace with your desired height
             substituteBitmap.GetPixel(Arg.Any<int>(), Arg.Any<int>()).Returns(
                 Color.FromArgb(255, 0, 0), // Replace with desired color values
                 Color.FromArgb(0, 255, 0), // Replace with desired color values
                 Color.FromArgb(0, 0, 255), // Replace with desired color values
                 Color.FromArgb(255, 255, 0), // Replace with desired color values
                 Color.FromArgb(0, 255, 255), // Replace with desired color values
                 Color.FromArgb(255, 0, 255), // Replace with desired color values
                 Color.FromArgb(128, 128, 128), // Replace with desired color values
                 Color.FromArgb(64, 64, 64), // Replace with desired color values
                 Color.FromArgb(192, 192, 192) // Replace with desired color values
             );


             // Act
             double result = edgeDetectionManager.CalculateXGradient(substituteBitmap, xMatrix, x, y);

             // Assert
             // Replace the expectedValue with the value you expect based on the given behavior
             double expectedValue = 42.0; // Replace with your expected result
             Assert.AreEqual(expectedValue, result);
         }*/

  
}

