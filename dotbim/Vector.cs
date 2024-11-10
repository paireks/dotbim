using System;
using System.Text.Json.Serialization;

namespace dotbim
{
    /// <summary>
    /// Represents a three-dimensional vector with double-precision floating-point coordinates.
    /// </summary>
    [Serializable]
    public struct Vector
    {
        /// <summary>
        /// The x-coordinate of the vector.
        /// </summary>
        [JsonPropertyName("x")]
        public double X { get; set; }

        /// <summary>
        /// The y-coordinate of the vector.
        /// </summary>
        [JsonPropertyName("y")]
        public double Y { get; set; }

        /// <summary>
        /// The z-coordinate of the vector.
        /// </summary>
        [JsonPropertyName("z")]
        public double Z { get; set; }
    }

}