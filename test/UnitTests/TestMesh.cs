using System;
using System.Collections.Generic;
using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestMesh
    {
        #region Triangle

        [Fact]
        public void TestMesh_Triangle_MeshId()
        {
            var mesh = ToolboxForTests.CreateTestTriangleMesh();
            
            Assert.Equal(12, mesh.MeshId);
        }

        [Fact]
        public void TestMesh_Triangle_VerticesCoordinates()
        {
            var mesh = ToolboxForTests.CreateTestTriangleMesh();
            
            List<double> expected = new List<double>
            {
                0,0,0,10,0,0,10,-15.1,0
            };
            
            Assert.Equal(expected, mesh.Coordinates);
        }

        [Fact]
        public void TestMesh_Triangle_FacesIds()
        {
            var mesh = ToolboxForTests.CreateTestTriangleMesh();
            
            List<int> expected = new List<int>
            {
                0,1,2
            };
            
            Assert.Equal(expected, mesh.Indices);
        }

        #endregion

        #region Cube

        [Fact]
        public void TestMesh_Cube_MeshId()
        {
            var mesh = ToolboxForTests.CreateTestCubeMesh();
            
            Assert.Equal(0, mesh.MeshId);
        }

        [Fact]
        public void TestMesh_Cube_VerticesCoordinates()
        {
            var mesh = ToolboxForTests.CreateTestCubeMesh();
            
            List<double> expected = new List<double>
            {
                0.0, 0.0, 0.0,
                10.0, 0.0, 0.0,
                10.0, 0.0, 20.0,
                0.0, 0.0, 20.0,
                0.0, 30.0, 0.0,
                10.0, 30.0, 0.0,
                10.0, 30.0, 20.0,
                0.0, 30.0, 20.0
            };
            
            Assert.Equal(expected, mesh.Coordinates);
        }

        [Fact]
        public void TestMesh_Cube_FacesIds()
        {
            var mesh = ToolboxForTests.CreateTestCubeMesh();
            
            List<int> expected = new List<int>
            {
                // Front side
                0, 1, 2,
                0, 2, 3,
                
                // Bottom side
                0, 1, 4,
                1, 4, 5,
                
                // Left side
                0, 4, 3,
                4, 3, 7,
                
                // Right side
                1, 2, 5,
                2, 5, 6,
                
                // Top side
                2, 3, 7,
                2, 6, 7,
                
                // Back side
                4, 5, 7,
                5, 6, 7
            };
            
            Assert.Equal(expected, mesh.Indices);
        }

        #endregion

        #region Exceptions

        [Fact]
        public void TestColor_Incorrect_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Mesh
            {
                MeshId = -1,
                Indices = new List<int>{0,1,2},
                Coordinates = new List<double>
                {
                    0.0,0.0,0.0,
                    10.0,0.0,0.0,
                    10.0,5.0,0.0
                }
            });
            Assert.Equal("MeshId should be >= 0", exception.Message);
        }   

        #endregion
    }
}