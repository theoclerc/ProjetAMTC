using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAMTC.Edges_Detections
{
    internal interface IEdgeDetectionManager
    {
        Bitmap ApplyEdgeDetection(Bitmap source, double[,] xMatrix, double[,] yMatrix, bool preview);
        double CalculateXGradient(Bitmap source, double[,] xMatrix, int x, int y);
        double CalculateYGradient(Bitmap source, double[,] yMatrix, int x, int y);
        double CalculateGradientMagnitude(double xGradient, double yGradient);
        int CalculateNewPixelValue(double gradientMagnitude);
    }
}
