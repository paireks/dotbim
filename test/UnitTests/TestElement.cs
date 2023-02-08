using System;
using System.Collections.Generic;
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
            Assert.Equal("Value", element.Info["Key"]);
        }
        
        [Fact]
        public void TestElement_CorrectWithFaceColors_Properties()
        {
            Element element = ToolboxForTests.CreateFaceColoredCubeElement();
            
            Assert.Equal(0, element.MeshId);
            Assert.True(ToolboxForTests.IsVectorSame(element.Vector, (0.0, 0.0, 0.0), 0.001));
            Assert.True(ToolboxForTests.IsRotationSame(element.Rotation, (0.0, 0.0, 0.0, 1.0), 0.001));
            Assert.True(ToolboxForTests.IsColorSame(element.Color, (0,0,255,0)));
            Assert.Equal(new List<int>
            {
                // Front side
                255, 105, 180, 150, // Hot pink with transparency
                255, 192, 203, 255, // Pink
                    
                // Bottom side
                53, 57, 53, 255, // Onyx
                0, 0, 0, 255, // Black
                    
                // Left side
                243, 229, 171, 255, // Vanilla
                255, 255, 0, 255, // Yellow
                    
                // Right side
                9, 121, 105, 255, // Cadmium Green
                0, 128, 0, 255, // Green
                    
                // Top side
                0, 255, 255, 255, // Cyan
                0, 0, 255, 255, // Blue
                    
                // Back side
                226, 223, 210, 255, // Pearl
                255, 255, 255, 255, // White
            }, element.FaceColors);
            Assert.Equal("3028896f-cd51-4b3a-be54-08841b4e9081", element.Guid);
            Assert.Equal("Cube", element.Type);
            Assert.Equal("Value", element.Info["Key"]);
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