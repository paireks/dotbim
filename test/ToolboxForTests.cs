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
    }
}