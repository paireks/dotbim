using System;
using Newtonsoft.Json;

namespace dotbim
{
    /// <summary>
    /// Represents a rotation in three-dimensional space using a quaternion.
    /// </summary>
    [Serializable]
    [JsonObject("rotation")]
    public struct Rotation
    {
        /// <summary>
        /// The x-coordinate of the quaternion.
        /// </summary>
        [JsonProperty("qx")]
        public double Qx { get; set; }

        /// <summary>
        /// The y-coordinate of the quaternion.
        /// </summary>
        [JsonProperty("qy")]
        public double Qy { get; set; }

        /// <summary>
        /// The z-coordinate of the quaternion.
        /// </summary>
        [JsonProperty("qz")]
        public double Qz { get; set; }

        /// <summary>
        /// The w-coordinate of the quaternion.
        /// </summary>
        [JsonProperty("qw")]
        public double Qw { get; set; }
    }
}