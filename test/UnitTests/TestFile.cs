using System.Collections.Generic;
using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestFile
    {
        [Fact]
        public void TestFile_Correct_ElementProperties()
        {
            File file = ToolboxForTests.CreateTestFileWithTriangleBluePlate();
            
            Assert.Equal(1, file.Elements.Count);
            var element = file.Elements[0];
            
            Assert.True(ToolboxForTests.IsColorSame(element.Color, (0, 120, 120, 255)));
            Assert.Equal("d4f28792-e1e9-4e31-bcee-740dbda61e20", element.Guid);
            Assert.Equal("Name", element.Info.Keys[0]);
            Assert.Equal("Triangle", element.Info.Values[0]);
            Assert.Equal(0, element.MeshId);
            Assert.True(ToolboxForTests.IsRotationSame(element.Rotation, (0.0, 0.0, 0.0, 1.0), 0.001));
            Assert.Equal("Plate", element.Type);
            Assert.True(ToolboxForTests.IsVectorSame(element.Vector, (0,0,0), 0.001));
        }
    }
}