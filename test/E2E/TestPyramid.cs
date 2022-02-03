using System.Collections.Generic;
using dotbim;
using Xunit;

namespace test.E2E
{
    public class TestPyramid
    {
        private void Create()
        {
            Mesh mesh = new Mesh
            {
                MeshId = 0,
                Coordinates = new List<double>
                {
                    // Base
                    0.0,0.0,0.0,
                    10.0,0.0,0.0,
                    10.0,10.0,0.0,
                    0.0,10.0,0.0,
                    
                    // Top
                    5.0,5.0,4.0
                },
                Indices = new List<int>
                {
                    // Base faces
                    0,1,2,
                    0,2,3,
                    
                    // Side faces
                    0,1,4,
                    1,2,4,
                    2,3,4,
                    3,0,4
                }
            };
            
            Element element = new Element
            {
                Color = new Color {A = 255, R = 255, G = 255, B = 0},
                MeshId = 0,
                Guid = "76e051c1-1bd7-44fc-8e2e-db2b64055068",
                Info = new Info{Keys = new List<string>{"Name"}, Values = new List<string>{"Pyramid"}},
                Rotation = new Rotation{Qx = 0, Qy = 0, Qz = 0, Qw = 1.0},
                Type = "Structure",
                Vector = new Vector{X = 0.0, Y = 0.0, Z = 0.0}
            };
            
            Info fileInfo = new Info
            {
                Keys = new List<string>{"Author", "Date"},
                Values = new List<string>{"John Doe", "28.09.1999"}
            };
            
            File file = new File
            {
                SchemaVersion = "1.0.0",
                Meshes = new List<Mesh>{mesh},
                Elements = new List<Element>{element},
                Info = fileInfo
            };
            
            file.Save("Pyramid.bim");
        }

        [Fact]
        public void TestPyramid_Properties()
        {
            Create();
            
            var file = File.Read("Pyramid.bim");

            #region Schema
            Assert.Equal("1.0.0", file.SchemaVersion);
            #endregion

            #region Info
            Assert.Equal(2, file.Info.Keys.Count);
            Assert.Equal(2, file.Info.Values.Count);
            
            Assert.Equal("Author", file.Info.Keys[0]);
            Assert.Equal("Date", file.Info.Keys[1]);
            
            Assert.Equal("John Doe", file.Info.Values[0]);
            Assert.Equal("28.09.1999", file.Info.Values[1]);
            #endregion

            #region Mesh

            Assert.Equal(1,file.Meshes.Count);
            Mesh mesh = file.Meshes[0];
            
            Assert.Equal(0, mesh.MeshId);
            
            List<double> expectedVertices = new List<double>
            {
                // Base
                0.0,0.0,0.0,
                10.0,0.0,0.0,
                10.0,10.0,0.0,
                0.0,10.0,0.0,
                    
                // Top
                5.0,5.0,4.0
            };
            Assert.Equal(expectedVertices, mesh.Coordinates);
            
            List<int> expectedFaces = new List<int>
            {
                // Base faces
                0,1,2,
                0,2,3,
                    
                // Side faces
                0,1,4,
                1,2,4,
                2,3,4,
                3,0,4
            };
            
            Assert.Equal(expectedFaces, mesh.Indices);
            
            #endregion

            #region Element

            Assert.Equal(1, file.Elements.Count);
            Element element = file.Elements[0];
            
            Assert.Equal("Structure", element.Type);
            Assert.Equal("76e051c1-1bd7-44fc-8e2e-db2b64055068", element.Guid);
            Assert.Equal(0, element.MeshId);
            Assert.Equal("Name", element.Info.Keys[0]);
            Assert.Equal("Pyramid", element.Info.Values[0]);
            Assert.True(ToolboxForTests.IsColorSame(element.Color, (255, 255, 0, 255)));
            Assert.True(ToolboxForTests.IsRotationSame(element.Rotation, (0,0,0,1), 0.01));
            Assert.True(ToolboxForTests.IsVectorSame(element.Vector, (0,0,0), 0.01));
            
            #endregion

        }
    }
}