using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestVector
    {
        [Theory]
        [InlineData(1.0, 2.0, 3.0)]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(-5.0, 10.0, 15.0)]
        public void TestVertex_Correct(double x, double y, double z)
        {
            Vector vector = new Vector{X = x, Y = y, Z = z};
            Assert.True(ToolboxForTests.IsVectorSame(vector, (x, y, z), 0.0001));
        }
    }
}