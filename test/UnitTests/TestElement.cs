using System;
using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestElement
    {

        [Fact]
        public void TestElement_Correct_Properties()
        {
            Element element = ToolboxForTests.CreateTestBlueElement();
            
            Assert.Equal(4, element.MeshId);
            Assert.True(ToolboxForTests.IsVectorSame(element.Vector, (0.2, 0.3, 0.4), 0.001));
            Assert.True(ToolboxForTests.IsRotationSame(element.Rotation, (1.0, 1.5, 2.0, 2.5), 0.001));
            Assert.True(ToolboxForTests.IsColorSame(element.Color, (0,0,255,0)));
            Assert.Equal("b8a7a2ed-0c30-4c20-867e-baa1ef7b8353", element.Guid);
            Assert.Equal("Plate", element.Type);
            Assert.Equal("Key", element.Info.Keys[0]);
            Assert.Equal("Value", element.Info.Values[0]);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        public void TestElement_WrongGuid_ThrowsException(string guid)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Element {Guid = guid});
            Assert.Equal("Guid is not correct. Create Guid with proper component.", exception.Message);
        }
    }
}