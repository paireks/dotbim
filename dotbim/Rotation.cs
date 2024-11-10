using System;
using System.Text.Json.Serialization;

namespace dotbim
{
    /// <summary>
    /// Represents a rotation in three-dimensional space using a quaternion.
    /// </summary>
    [Serializable]
    public struct Rotation
    {
        /// <summary>
        /// The x-coordinate of the quaternion.
        /// </summary>
        [JsonPropertyName("qx")]
        public double Qx { get; set; }

        /// <summary>
        /// The y-coordinate of the quaternion.
        /// </summary>
        [JsonPropertyName("qy")]
        public double Qy { get; set; }

        /// <summary>
        /// The z-coordinate of the quaternion.
        /// </summary>
        [JsonPropertyName("qz")]
        public double Qz { get; set; }

        /// <summary>
        /// The w-coordinate of the quaternion.
        /// </summary>
        [JsonPropertyName("qw")]
        public double Qw { get; set; }
    }
}