using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC.Filters
{
    public interface IImageFilterManager
    {
        Bitmap ApplyNightFilter(Bitmap bmp, int alpha, int red, int blue, int green);
        Bitmap ApplyRainbowFilter(Bitmap bmp);
        Bitmap ApplyBlackWhiteFilter(Bitmap bmp);
    }
}
