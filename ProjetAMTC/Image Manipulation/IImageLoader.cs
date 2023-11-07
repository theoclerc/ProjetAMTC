using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC
{
    public interface IImageLoader
    {
        Bitmap LoadImageFromFile(string filePath);
    }
}
