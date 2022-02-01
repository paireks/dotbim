using System;
using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestColor
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(255, 255, 255, 255)]
        [InlineData(178, 72, 5, 4)]
        public void TestColor_Correct(int r, int g, int b, int a)
        {
            Color color = new Color {R = r, G = g, B = b, A = a};
            Assert.True(ToolboxForTests.IsColorSame(color, (r, g, b, a)));
        }
        
        [Theory]
        [InlineData(-1, 0, 0, 0, "R value should be between 0-255")]
        [InlineData(0, 256, 0, 0, "G value should be between 0-255")]
        [InlineData(0, 0, 1000, 0, "B value should be between 0-255")]
        [InlineData(0, 0, 10, 256, "A value should be between 0-255")]
        public void TestColor_Incorrect_ThrowsException(int r, int g, int b, int a, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Color {R = r, G = g, B = b, A = a});
            Assert.Equal(message, exception.Message);
        }        
    }
}