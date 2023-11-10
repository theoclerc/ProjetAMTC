using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ProjetAMTC;

namespace ProjetAMTC_Test
{
    /// <summary>
    /// Test class for the ImageManipulation class. ChatGPT was used to generate certain tests.
    /// </summary>
    [TestClass]
    public class ImageManipulationTests
    {
        /// <summary>
        /// Test to ensure that loading an image from a valid path is successful.
        /// </summary>
        [TestMethod]
        public void LoadImageFromFile_ValidFile_ShouldLoadImage()
        {
            // Arrange
            var imageLoader = new ProjetAMTC.ImageLoader();
            var relativePath = Path.Combine("TestFiles", "imageTest.jpg");
            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            // Act
            var loadedImage = imageLoader.LoadImageFromFile(absolutePath);

            // Assert
            Assert.IsNotNull(loadedImage);
        }

        /// <summary>
        /// Test to verify that an exception is thrown when attempting to load an image from a non-existent file path.
        /// </summary>
        [TestMethod]
        public void LoadImageFromFile_FileNotFound_ShouldThrowFileNotFoundException()
        {
            // Arrange
            var imageLoader = new ProjetAMTC.ImageLoader();
            var nonExistentPath = "nonExistentPath.jpg"; // Non existent path

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => imageLoader.LoadImageFromFile(nonExistentPath));
        }

        /// <summary>
        /// Test to ensure that attempting to load an image with an invalid file path results in a DirectoryNotFoundException.
        /// </summary>
        [TestMethod]
        public void LoadImage_InvalidFilePath_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var imageLoader = new ImageLoader();
            string invalidFilePath = "path/to/invalid/image.jpg";

            // Act & Assert
            Assert.ThrowsException<DirectoryNotFoundException>(() => imageLoader.LoadImageFromFile(invalidFilePath));
        }

        /// <summary>
        /// Test to ensure that attempting to load an image with a null file path results in an ArgumentNullException.
        /// </summary>
        [TestMethod]
        public void LoadImage_NullFilePath_ThrowsArgumentNullException()
        {
            // Arrange
            var imageLoader = new ImageLoader();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => imageLoader.LoadImageFromFile(null));
        }

        /// <summary>
        /// Test to verify that loading an image from a valid file path is successful.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that loading an image from a non-existent path returns null.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that loading an image with an invalid format returns null.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that saving a valid image is successful.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that saving an image with an invalid format throws an exception.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that saving an image to a non-writable directory throws an exception.
        /// </summary>
        [TestMethod]
        public void SaveImage_FilePathNotWritable_ThrowsException()
        {
            // Arrange
            IImageSaver imageSaver = new ImageSaver();
            Bitmap imageToSave = new Bitmap(100, 100);
            string filePath = "nonexistentDirectory/output.jpg"; // Specify a non-existent directory
            ImageFormat format = ImageFormat.Jpeg; // Specify the image format

            // Act and Assert
            Assert.ThrowsException<UnauthorizedAccessException>(() => imageSaver.SaveImage(imageToSave, filePath, format));
        }

        /// <summary>
        /// Test to ensure that copying to a square canvas from a wider image returns a proportional image.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that copying to a square canvas from a taller image returns a proportional image.
        /// </summary>
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

        /// <summary>
        /// Test to ensure that attempting to copy to a square canvas with zero width throws an exception.
        /// </summary>
        [TestMethod]
        public void CopyToSquareCanvas_ZeroWidth_ShouldThrowArgumentException()
        {
            // Arrange
            Bitmap image = new Bitmap(100, 100);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => image.CopyToSquareCanvas(0));
        }


        /// <summary>
        /// Test to ensure that attempting to copy to a square canvas with a negative width throws an exception.
        /// </summary>
        [TestMethod]
        public void CopyToSquareCanvas_NegativeWidth_ShouldThrowArgumentException()
        {
            // Arrange
            Bitmap image = new Bitmap(100, 100);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => image.CopyToSquareCanvas(-50));
        }

        /// <summary>
        /// BY GPT
        /// Test to ensure that saving an image to a directory with restricted access throws an UnauthorizedAccessException.
        /// </summary>
        [TestMethod]
        public void SaveImage_PermissionDenied_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            IImageSaver imageSaver = new ImageSaver();
            Bitmap image = new Bitmap(100, 100);
            string restrictedDirectoryPath = "C:\\Windows\\System32\\output.jpg"; // Assuming this directory requires elevated permissions
            ImageFormat format = ImageFormat.Jpeg;

            // Act & Assert
            Assert.ThrowsException<UnauthorizedAccessException>(() => imageSaver.SaveImage(image, restrictedDirectoryPath, format));
        }
    }
}

       
