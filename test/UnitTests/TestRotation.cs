using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestRotation
    {
        [Theory]
        [InlineData(1.0, 2.0, 3.0, 25.0)]
        [InlineData(0.0, 0.0, 0.0, 0.0)]
        [InlineData(-5.0, 10.0, 15.0, -100)]
        public void TestRotation_Correct(double qx, double qy, double qz, double qw)
        {
            Rotation rotation = new Rotation{Qx = qx, Qy = qy, Qz = qz, Qw = qw};
            Assert.True(ToolboxForTests.IsRotationSame(rotation, (qx, qy, qz, qw), 0.0001));
        }
    }
}