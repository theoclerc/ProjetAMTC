using ProjetAMTC;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
/// Class responsible for saving images to a file.
/// </summary>
public class ImageSaver : IImageSaver
{
    /// <summary>
    /// Saves the specified image to the specified file path with the specified image format.
    /// </summary>
    /// <param name="image">The image to be saved.</param>
    /// <param name="filePath">The path where the image will be saved.</param>
    /// <param name="format">The format in which the image will be saved.</param>
    public void SaveImage(Bitmap image, string filePath, ImageFormat format)
    {
        string fileExtension = Path.GetExtension(filePath).ToLower();

        if (format == ImageFormat.Png && fileExtension == ".png" ||
            format == ImageFormat.Jpeg && fileExtension == ".jpg" ||
            format == ImageFormat.Bmp && fileExtension == ".bmp")
        {
            string directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
            {
                throw new UnauthorizedAccessException("The directory does not exist.");
            }

            try
            {
                using (var streamWriter = new StreamWriter(filePath, false))
                {
                    image.Save(streamWriter.BaseStream, format);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have permission to write to the directory.");
            }
        }
        else
        {
            throw new ArgumentException("Unsupported image format. Supported formats are PNG, JPEG, and BMP.");
        }
    }
}


