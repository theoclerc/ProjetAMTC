using ProjetAMTC;
using System.Drawing;
using NSubstitute;
using ProjetAMTC.Filters;
using System.Reflection;

namespace ProjetAMTC_Test
{
    /// <summary>
    /// Test class for the Filters class.
    /// </summary>
    [TestClass]
    public class FiltersTests
    {
        /// <summary>
        /// Test to ensure that the ApplyNightFilter method is called with the expected arguments.
        /// </summary>
        [TestMethod]
        public void ApplyNightFilter_CallsApplyNightFilterMethodWithExpectedArguments()
        {
            // Arrange
            IImageFilterManager filterManager = Substitute.For<IImageFilterManager>();
            string imagePath = "TestFiles/imageTest.jpg";

            // Use NSubstitute to create a substitute for Bitmap
            Bitmap baseImage = new Bitmap(imagePath);

            // Act
            filterManager.ApplyNightFilter(baseImage, 2, 3, 4, 5);

            // Assert
            filterManager.Received().ApplyNightFilter(baseImage, 2, 3, 4, 5);
        }

        // <summary>
        /// Test to ensure that the ApplyRainbowFilter method is called with the expected arguments.
        /// </summary>
        [TestMethod]
        public void ApplyRainbowFilter_CallsApplyNightFilterMethodWithExpectedArguments()
        {
            // Arrange
            IImageFilterManager filterManager = Substitute.For<IImageFilterManager>();
            string imagePath = "TestFiles/imageTest.jpg";

            // Use NSubstitute to create a substitute for Bitmap
            Bitmap baseImage = new Bitmap(imagePath);

            // Act
            filterManager.ApplyRainbowFilter(baseImage);

            // Assert
            filterManager.Received().ApplyRainbowFilter(baseImage);
        }

        /// <summary>
        /// Test to ensure that the ApplyBlackWhiteFilter method is called with the expected arguments.
        /// </summary>
        [TestMethod]
        public void ApplyBlackWhiteFilter_CallsApplyNightFilterMethodWithExpectedArguments()
        {
            // Arrange
            IImageFilterManager filterManager = Substitute.For<IImageFilterManager>();
            string imagePath = "TestFiles/imageTest.jpg";

            // Use NSubstitute to create a substitute for Bitmap
            Bitmap baseImage = new Bitmap(imagePath);

            // Act
            filterManager.ApplyBlackWhiteFilter(baseImage);

            // Assert
            filterManager.Received().ApplyBlackWhiteFilter(baseImage);
        }

        /// <summary>
        /// Test to ensure that applying the Night filter results in a different image than the original.
        /// </summary>
        [TestMethod]
        public void ApplyNightFilter_DifferentImagesAfterFiltering()
        {
            // Arrange
            ImageFilterManager filterManager = new ImageFilterManager();
            string imagePath = "TestFiles/imageTest.jpg";

            // Act
            Bitmap baseImage = new Bitmap(imagePath);
            var filteredImage = filterManager.ApplyNightFilter(baseImage, 2, 3, 4, 5);

            // Assert
            Assert.IsNotNull(filteredImage);
            Assert.AreNotEqual(baseImage, filteredImage);
        }


        /// <summary>
        /// Test to ensure that applying the Rainbow filter results in a different image than the original.
        /// </summary>
        [TestMethod]
        public void ApplyRainbowFilter_DifferentImagesAfterFiltering()
        {
            // Arrange
            ImageFilterManager filterManager = new ImageFilterManager();
            string imagePath = "TestFiles/imageTest.jpg";

            // Act
            Bitmap baseImage = new Bitmap(imagePath);
            var filteredImage = filterManager.ApplyRainbowFilter(baseImage);

            // Assert
            Assert.IsNotNull(filteredImage);
            Assert.AreNotEqual(baseImage, filteredImage);
        }

        /// <summary>
        /// Test to ensure that applying the Black and White filter results in a different image than the original.
        /// </summary>
        [TestMethod]
        public void ApplyBlackWhiteFilter_DifferentImagesAfterFiltering()
        {
            // Arrange
            ImageFilterManager filterManager = new ImageFilterManager();
            string imagePath = "TestFiles/imageTest.jpg";

            // Act
            Bitmap baseImage = new Bitmap(imagePath);
            // Create a copy of the base image to avoid modifying the original
            Bitmap copyImage = new Bitmap(baseImage);
            var filteredImage = filterManager.ApplyBlackWhiteFilter(copyImage);

            // Assert
            Assert.IsNotNull(filteredImage);
            Assert.AreNotEqual(filteredImage, baseImage);
        }

        /// <summary>
        /// Test to ensure that applying the Night filter with different parameters twice produces two different results.
        /// </summary>
        [TestMethod]
        public void ApplyNightFilter_DifferentResultsWithDifferentParameters()
        {
            // Arrange
            ImageFilterManager filterManager = new ImageFilterManager();
            string imagePath = "TestFiles/imageTest.jpg";

            // Act
            Bitmap baseImage = new Bitmap(imagePath);
            var firstFiltered = filterManager.ApplyNightFilter(baseImage, 2, 3, 4, 12);
            var secondFiltered = filterManager.ApplyNightFilter(baseImage, 2, 3, 4, 5);

            // Assert
            Assert.IsNotNull(firstFiltered);
            Assert.IsNotNull(secondFiltered);
            // Ensure that applying the filter with the same parameters twice produces the same result
            Assert.AreNotEqual(firstFiltered, secondFiltered);
        }

        /// <summary>
        /// Test to ensure that applying multiple filters in sequence produces different results.
        /// </summary>
        [TestMethod]
        public void ApplySeveralFilters_DifferentResultsAfterMultipleFilters()
        {
            // Arrange
            ImageFilterManager filterManager = new ImageFilterManager();
            string imagePath = "TestFiles/imageTest.jpg";

            // Act
            Bitmap baseImage = new Bitmap(imagePath);
            var filteredImage = filterManager.ApplyRainbowFilter(baseImage);
            var secondFilter = filterManager.ApplyNightFilter(filteredImage, 1, 1, 1, 25);
            var nightOnlyFilter = filterManager.ApplyNightFilter(baseImage, 1, 1, 1, 25);

            // Assert
            Assert.IsNotNull(filteredImage);
            Assert.IsNotNull(secondFilter);
            Assert.IsNotNull(nightOnlyFilter);
            Assert.AreNotEqual(secondFilter, nightOnlyFilter);
        }
    }
}
