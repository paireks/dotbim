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
                VerticesCoordinates = verticesCoordinates,
                FacesIds = facesIds,
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

            return mesh;
        }
    }
}