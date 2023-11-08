using ProjetAMTC;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class ImageSaver : IImageSaver
{
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


