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

        [TestMethod]
        public void LoadImageFromFile_FileNotFound_ReturnsNull()
        {
            // Arrange
            IImageLoader imageLoader = Substitute.For<IImageLoader>();
            string nonExistentPath = "nonexistent.jpg"; // An invalid path

            // Setup the behavior to simulate an exception when loading the image
            imageLoader.LoadImageFromFile(nonExistentPath).Returns((Bitmap)null);

            // Act
            Bitmap loadedImage = imageLoader.LoadImageFromFile(nonExistentPath);

            // Assert
            Assert.IsNull(loadedImage);
            // You can add additional assertions to verify the behavior in this case.
        }

        [TestMethod]
        public void LoadImageFromFile_InvalidImageFormat_ReturnsNull()
        {
            // Arrange
            IImageLoader imageLoader = Substitute.For<IImageLoader>();
            string invalidImagePath = "ivalidFormat.txt";

            // Setup the behavior to simulate an exception when loading the image
            imageLoader.LoadImageFromFile(invalidImagePath).Returns((Bitmap)null);

            // Act
            Bitmap loadedImage = imageLoader.LoadImageFromFile(invalidImagePath);

            // Assert
            Assert.IsNull(loadedImage);
        }
    }
}
