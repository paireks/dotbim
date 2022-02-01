using System;
using dotbim;

namespace test
{
    public static class ToolboxForTests
    {
        public static bool IsColorSame(Color colorToCheck, (int r, int g, int b, int a) rgbExpected)
        {
            return colorToCheck.R == rgbExpected.r && colorToCheck.G == rgbExpected.g &&
                   colorToCheck.B == rgbExpected.b && colorToCheck.A == rgbExpected.a;
        }
        
        public static bool IsVectorSame(Vector vectorToCheck, (double x, double y, double z) vectorExpected,
            double tolerance)
        {
            return Math.Abs(vectorToCheck.X - vectorExpected.x) < tolerance &&
                   Math.Abs(vectorToCheck.Y - vectorExpected.y) < tolerance &&
                   Math.Abs(vectorToCheck.Z - vectorExpected.z) < tolerance;
        }

        public static bool IsRotationSame(Rotation rotationToCheck,
            (double qx, double qy, double qz, double qw) rotationExpected, double tolerance)
        {
            return Math.Abs(rotationToCheck.Qx - rotationExpected.qx) < tolerance &&
                   Math.Abs(rotationToCheck.Qy - rotationExpected.qy) < tolerance &&
                   Math.Abs(rotationToCheck.Qz - rotationExpected.qz) < tolerance &&
                   Math.Abs(rotationToCheck.Qw - rotationExpected.qw) < tolerance;
        }
    }
}