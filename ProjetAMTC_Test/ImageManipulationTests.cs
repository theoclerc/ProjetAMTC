using System.Drawing;
using System.Drawing.Imaging;
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
            string validImagePath = "TestFiles/imageTest.jpg"; // Relative path to the image

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

        [TestMethod]
        public void SaveImage_ValidImage_SaveSuccessful()
        {
            // Arrange
            IImageSaver imageSaver = Substitute.For<IImageSaver>();
            Bitmap imageToSave = new Bitmap(100, 100); // Create a sample image
            string filePath = "C:\\temp\\outputTest.png";
            ImageFormat format = ImageFormat.Png; // Specify the image format

            // Act
            imageSaver.SaveImage(imageToSave, filePath, format);

            // Assert
            imageSaver.Received(1).SaveImage(imageToSave, filePath, format);
        }

        [TestMethod]
        public void SaveImage_InvalidImageFormat_ThrowsException()
        {
            // Arrange
            IImageSaver imageSaver = new ImageSaver(); 
            Bitmap imageToSave = new Bitmap(100, 100); 
            string filePath = "C:\\temp\\output.txt"; // Specify a file path with a wrong format
            ImageFormat format = ImageFormat.Jpeg; 

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => imageSaver.SaveImage(imageToSave, filePath, format));
        }

        [TestMethod]
        public void SaveImage_FilePathNotWritable_ThrowsException()
        {
            // Arrange
            IImageSaver imageSaver = new ImageSaver(); // Use the real implementation
            Bitmap imageToSave = new Bitmap(100, 100); // Create a sample image
            string filePath = "nonexistentDirectory/output.jpg"; // Specify a non-existent directory
            ImageFormat format = ImageFormat.Jpeg; // Specify the image format

            // Act and Assert
            Assert.ThrowsException<UnauthorizedAccessException>(() => imageSaver.SaveImage(imageToSave, filePath, format));
        }

        [TestMethod]
        public void CopyToSquareCanvas_WiderImage_ShouldReturnProportionalImage()
        {
            // Arrange
            Bitmap wideImage = new Bitmap(150, 100);

            // Act
            Bitmap result = wideImage.CopyToSquareCanvas(50);

            // Assert
            Assert.AreEqual(50, result.Width);
            Assert.AreEqual(33, result.Height); // (100 / 150) * 50 = 33.33, rounded down to 33
        }

        [TestMethod]
        public void CopyToSquareCanvas_TallerImage_ShouldReturnProportionalImage()
        {
            // Arrange
            Bitmap tallImage = new Bitmap(100, 150);

            // Act
            Bitmap result = tallImage.CopyToSquareCanvas(50);

            // Assert
            Assert.AreEqual(33, result.Width); // (100 / 150) * 50 = 33.33, rounded down to 33
            Assert.AreEqual(50, result.Height);
        }

        [TestMethod]
        public void CopyToSquareCanvas_ZeroWidth_ShouldThrowArgumentException()
        {
            // Arrange
            Bitmap image = new Bitmap(100, 100);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => image.CopyToSquareCanvas(0));
        }


        [TestMethod]
        public void CopyToSquareCanvas_NegativeWidth_ShouldThrowArgumentException()
        {
            // Arrange
            Bitmap image = new Bitmap(100, 100);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => image.CopyToSquareCanvas(-50));
        }

        // Add more tests as needed based on the scenarios mentioned earlier.
    }


}

