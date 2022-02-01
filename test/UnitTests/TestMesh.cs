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
                0,0,0,10,0,0,10,-15,0
            };
            
            Assert.Equal(expected, mesh.VerticesCoordinates);
        }

        [Fact]
        public void TestMesh_Triangle_FacesIds()
        {
            var mesh = ToolboxForTests.CreateTestTriangleMesh();
            
            List<int> expected = new List<int>
            {
                0,1,2
            };
            
            Assert.Equal(expected, mesh.FacesIds);
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
            
            Assert.Equal(expected, mesh.VerticesCoordinates);
        }

        [Fact]
        public void TestMesh_Cube_FacesIds()
        {
            var mesh = ToolboxForTests.CreateTestCubeMesh();
            
            List<int> expected = new List<int>
            {
                // Front side
                1, 2, 3,
                1, 3, 4,
                
                // Bottom side
                1, 2, 5,
                2, 5, 6,
                
                // Left side
                1, 5, 4,
                5, 4, 8,
                
                // Right side
                2, 3, 6,
                3, 6, 7,
                
                // Top side
                3, 4, 8,
                3, 7, 8,
                
                // Back side
                5, 6, 8,
                6, 7, 8
            };
            
            Assert.Equal(expected, mesh.FacesIds);
        }

        #endregion

        #region Exceptions

        [Fact]
        public void TestColor_Incorrect_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Mesh
            {
                MeshId = -1,
                FacesIds = new List<int>{0,1,2},
                VerticesCoordinates = new List<double>
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