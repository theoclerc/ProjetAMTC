using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC
{
    internal interface IImageSaver
    {
        void SaveImage(Bitmap image, string filePath, ImageFormat format);
    }
}
