using System;
using Newtonsoft.Json;

namespace dotbim
{
    /// <summary>
    /// Represents a three-dimensional vector with double-precision floating-point coordinates.
    /// </summary>
    [Serializable]
    [JsonObject("vector")]
    public struct Vector
    {
        /// <summary>
        /// The x-coordinate of the vector.
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// The y-coordinate of the vector.
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <summary>
        /// The z-coordinate of the vector.
        /// </summary>
        [JsonProperty("z")]
        public double Z { get; set; }
    }

}