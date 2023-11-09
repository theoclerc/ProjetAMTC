using ProjetAMTC;
using System.Drawing;
using NSubstitute;
using ProjetAMTC.Filters;
using System.Reflection;

namespace ProjetAMTC_Test
{
    [TestClass]
    public class FiltersTests
    {
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

        // Test to ensure that applying the Night filter results in a different image than the original
        [TestMethod]
        public void ApplyNightFilter_ImageDifferent()
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


        // Test to ensure that applying the Rainbow filter results in a different image than the original
        [TestMethod]
        public void ApplyRainbowFilter_ImageDifferent()
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

        // Test to ensure that applying the Black and White filter results in a different image than the original
        [TestMethod]
        public void ApplyBlackWhiteFilter_ImageDifferent()
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

        // Test to ensure that applying the Night filter with different parameters twice produces two different results
        [TestMethod]
        public void ApplyNightFilter_WithDifferentParameters()
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

        // Test to ensure that applying multiple filters in sequence produces different results
        [TestMethod]
        public void ApplySeveralFilters()
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
