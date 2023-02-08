using System;
using System.Collections.Generic;
using dotbim;

namespace test
{
    public static class ToolboxForTests
    {
        public static bool IsColorSame(Color colorToCheck, (int r, int g, int b, int a) rgbExpected)
        {
            return colorToCheck.R == rgbExpected.r && colorToCheck.G == rgbExpected.g &&
                   colorToCheck.B == rgbExpected.b && colorToCheck.A == rgbExpected.a;
        }
        
        public static bool IsVectorSame(Vector vectorToCheck, (double x, double y, double z) vectorExpected,
            double tolerance)
        {
            return Math.Abs(vectorToCheck.X - vectorExpected.x) < tolerance &&
                   Math.Abs(vectorToCheck.Y - vectorExpected.y) < tolerance &&
                   Math.Abs(vectorToCheck.Z - vectorExpected.z) < tolerance;
        }

        public static bool IsRotationSame(Rotation rotationToCheck,
            (double qx, double qy, double qz, double qw) rotationExpected, double tolerance)
        {
            return Math.Abs(rotationToCheck.Qx - rotationExpected.qx) < tolerance &&
                   Math.Abs(rotationToCheck.Qy - rotationExpected.qy) < tolerance &&
                   Math.Abs(rotationToCheck.Qz - rotationExpected.qz) < tolerance &&
                   Math.Abs(rotationToCheck.Qw - rotationExpected.qw) < tolerance;
        }
        
        public static Mesh CreateTestTriangleMesh()
        {
            List<double> verticesCoordinates = new List<double>
            {
                0.0, 0.0, 0.0,
                10.0, 0.0, 0.0,
                10.0, -15.0, 0.0
            };

            List<int> facesIds = new List<int>
            {
                0,1,2
            };

            Mesh mesh = new Mesh
            {
                MeshId = 12,
                Coordinates = verticesCoordinates,
                Indices = facesIds,
            };

            return mesh;
        }

        public static Mesh CreateTestCubeMesh()
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

            Mesh mesh = new Mesh{Coordinates = verticesCoordinates, Indices = facesIds, MeshId = 0};

            return mesh;
        }

        public static Element CreateTestBlueElement()
        {
            Element element = new Element
            {
                Color = new Color
                {
                    A = 0,
                    R = 0,
                    G = 0,
                    B = 255
                },
                
                Guid = "b8a7a2ed-0c30-4c20-867e-baa1ef7b8353",
                
                Info = new Dictionary<string, string>
                {
                    {"Key", "Value"}
                },
                
                MeshId = 4,
                
                Rotation = new Rotation
                {
                    Qx = 1.0,
                    Qy = 1.5,
                    Qz = 2.0,
                    Qw = 2.5
                },
                
                Type = "Plate",
                
                Vector = new Vector
                {
                    X = 0.20,
                    Y = 0.30,
                    Z = 0.40
                }
            };

            return element;
        }

        public static Element CreateFaceColoredCubeElement()
        {
            Element element = new Element
            {
                Color = new Color
                {
                    A = 0,
                    R = 0,
                    G = 0,
                    B = 255
                },
                
                FaceColors = new List<int>
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
                },
                
                Guid = "3028896f-cd51-4b3a-be54-08841b4e9081",
                
                Info = new Dictionary<string, string>
                {
                    {"Key", "Value"}
                },
                
                MeshId = 0,
                
                Rotation = new Rotation
                {
                    Qx = 0.0,
                    Qy = 0.0,
                    Qz = 0.0,
                    Qw = 1.0
                },
                
                Type = "Cube",
                
                Vector = new Vector
                {
                    X = 0.0,
                    Y = 0.0,
                    Z = 0.0
                }
            };

            return element;
        }

        public static File CreateTestFileWithTriangleBluePlate()
        {
            File file = new File
            {
                Elements = new List<Element>
                {
                    new Element
                    {
                        Color = new Color {A = 255, R = 0, G = 120, B = 120},
                        Guid = "d4f28792-e1e9-4e31-bcee-740dbda61e20",
                        Info = new Dictionary<string, string>
                        {
                            {"Name", "Triangle"}
                        },
                        MeshId = 0,
                        Rotation = new Rotation{Qx = 0, Qy = 0, Qz = 0, Qw = 1.0},
                        Type = "Plate",
                        Vector = new Vector{X = 0.0, Y = 0.0, Z = 0.0}
                    }
                },
                
                Meshes = new List<Mesh>
                {
                    new Mesh
                    {
                        Coordinates = new List<double>
                        {
                            0.0,0.0,0.0,
                            10.0,0.0,0.0,
                            10.0,-15.0,0.0
                        },
                        Indices = new List<int> {0,1,2},
                        MeshId = 0
                    }
                },
                
                Info = new Dictionary<string, string>
                {
                    {"Author", "Jane Doe"}
                },
                
                SchemaVersion = "1.0.0"
            };

            return file;
        }
    }
}