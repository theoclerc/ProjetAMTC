using ProjetAMTC;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class ImageSaver : IImageSaver
{
    public void SaveImage(Bitmap image, string filePath, ImageFormat format)
    {
        using (var streamWriter = new StreamWriter(filePath, false))
        {
            image.Save(streamWriter.BaseStream, format);
        }
    }
}


