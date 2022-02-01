using System.Collections.Generic;
using dotbim;
using Xunit;

namespace test.E2E
{
    public class TestCubes
    {
        private void Create()
        {
            List<double> verticesCoordinates = new List<double>
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
            
            List<int> facesIds = new List<int>
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

            Mesh mesh = new Mesh{VerticesCoordinates = verticesCoordinates, FacesIds = facesIds, MeshId = 0};
            
            Element element1 = new Element
            {
                Color = new Color {A = 255, R = 255, G = 0, B = 0},
                MeshId = 0,
                Guid = "9f61b565-06a2-4bef-8b72-f37091ab54d6",
                Info = new Info{Keys = new List<string>{"Name"}, Values = new List<string>{"Red Cube"}},
                Rotation = new Rotation{Qx = 0.1, Qy = 0.3, Qz = 0.4, Qw = 1.0},
                Type = "Brick",
                Vector = new Vector{X = -100.0, Y = -100.0, Z = -100.0}
            };
            
            Element element2 = new Element
            {
                Color = new Color {A = 126, R = 0, G = 255, B = 0},
                MeshId = 0,
                Guid = "4d00c967-791a-42a6-a5e8-cf05831bc11d",
                Info = new Info{Keys = new List<string>{"Name"}, Values = new List<string>{"Green Cube"}},
                Rotation = new Rotation{Qx = 0, Qy = 0, Qz = 0, Qw = 1.0},
                Type = "Brick",
                Vector = new Vector{X = 0.0, Y = 0.0, Z = 0.0}
            };
            
            Element element3 = new Element
            {
                Color = new Color {A = 10, R = 0, G = 0, B = 255},
                MeshId = 0,
                Guid = "8501a5e3-4709-47d8-bd5d-33d745a435d5",
                Info = new Info{Keys = new List<string>{"Name"}, Values = new List<string>{"Blue Cube"}},
                Rotation = new Rotation{Qx = -2.2, Qy = -1.4, Qz = 1.5, Qw = -1.2},
                Type = "Brick",
                Vector = new Vector{X = 100.0, Y = 100.0, Z = 100.0}
            };
            
            Info fileInfo = new Info
            {
                Keys = new List<string>{"Author"},
                Values = new List<string>{"John Doe"}
            };
            
            File file = new File
            {
                SchemaVersion = "1.0.0",
                Meshes = new List<Mesh>{mesh},
                Elements = new List<Element>{element1, element2, element3},
                Info = fileInfo
            };
            
            file.Save("Cubes.bim");
        }
        
        [Fact]
        public void TestCubes_Properties()
        {
            Create();
            
            var file = File.Read("Cubes.bim");

            #region Schema
            Assert.Equal("1.0.0", file.SchemaVersion);
            #endregion

            #region Info
            Assert.Equal(1, file.Info.Keys.Count);
            Assert.Equal(1, file.Info.Values.Count);
            
            Assert.Equal("Author", file.Info.Keys[0]);
            Assert.Equal("John Doe", file.Info.Values[0]);
            #endregion

            #region Mesh

            Assert.Equal(1,file.Meshes.Count);
            Mesh mesh = file.Meshes[0];
            
            Assert.Equal(0, mesh.MeshId);
            
            List<double> expectedVertices = new List<double>
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
            Assert.Equal(expectedVertices, mesh.VerticesCoordinates);
            
            List<int> expectedFaces = new List<int>
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
            
            Assert.Equal(expectedFaces, mesh.FacesIds);
            
            #endregion

            #region Element

            Assert.Equal(3, file.Elements.Count);
            Element element1 = file.Elements[0];
            Element element2 = file.Elements[1];
            Element element3 = file.Elements[2];
            
            // First element
            
            Assert.Equal("Brick", element1.Type);
            Assert.Equal("9f61b565-06a2-4bef-8b72-f37091ab54d6", element1.Guid);
            Assert.Equal(0, element1.MeshId);
            Assert.Equal("Name", element1.Info.Keys[0]);
            Assert.Equal("Red Cube", element1.Info.Values[0]);
            Assert.True(ToolboxForTests.IsColorSame(element1.Color, (255, 0, 0, 255)));
            Assert.True(ToolboxForTests.IsRotationSame(element1.Rotation, (0.1,0.3,0.4,1), 0.01));
            Assert.True(ToolboxForTests.IsVectorSame(element1.Vector, (-100,-100,-100), 0.01));
            
            // Second element
            
            Assert.Equal("Brick", element2.Type);
            Assert.Equal("4d00c967-791a-42a6-a5e8-cf05831bc11d", element2.Guid);
            Assert.Equal(0, element2.MeshId);
            Assert.Equal("Name", element2.Info.Keys[0]);
            Assert.Equal("Green Cube", element2.Info.Values[0]);
            Assert.True(ToolboxForTests.IsColorSame(element2.Color, (0, 255, 0, 126)));
            Assert.True(ToolboxForTests.IsRotationSame(element2.Rotation, (0,0,0,1), 0.01));
            Assert.True(ToolboxForTests.IsVectorSame(element2.Vector, (0,0,0), 0.01));
            
            // Third element
            
            Assert.Equal("Brick", element3.Type);
            Assert.Equal("8501a5e3-4709-47d8-bd5d-33d745a435d5", element3.Guid);
            Assert.Equal(0, element3.MeshId);
            Assert.Equal("Name", element3.Info.Keys[0]);
            Assert.Equal("Blue Cube", element3.Info.Values[0]);
            Assert.True(ToolboxForTests.IsColorSame(element3.Color, (0, 0, 255, 10)));
            Assert.True(ToolboxForTests.IsRotationSame(element3.Rotation, (-2.2,-1.4,1.5,-1.2), 0.01));
            Assert.True(ToolboxForTests.IsVectorSame(element3.Vector, (100,100,100), 0.01));
            
            #endregion

        }
    }
}