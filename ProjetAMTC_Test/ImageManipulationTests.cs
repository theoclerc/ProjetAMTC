using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ProjetAMTC;

namespace ProjetAMTC_Test
{
    [TestClass]
    public class ImageManipulationTests
    {
        [TestMethod]
        public void LoadImageFromFile_ValidPath_Success()
        {
            // Arrange
            string validImagePath = "imageTest.jpg"; // Relative path to the image

            // Act
            Image loadedImage = Image.FromFile(validImagePath);

            // Assert
            Assert.IsNotNull(loadedImage);
        }

    }
}
