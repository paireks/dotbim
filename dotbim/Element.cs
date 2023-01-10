using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dotbim
{
    /// <summary>
    /// Represents an element in a BIM file.
    /// </summary>
    [Serializable]
    [JsonObject("element")]
    public class Element
    {
        private string _guid;

        /// <summary>
        /// The identifier of the mesh associated with the element.
        /// </summary>
        [JsonProperty("mesh_id")]
        public int MeshId { get; set; }

        /// <summary>
        /// The position of the element.
        /// </summary>
        [JsonProperty("vector")]
        public Vector Vector { get; set; }

        /// <summary>
        /// The rotation of the element.
        /// </summary>
        [JsonProperty("rotation")]
        public Rotation Rotation { get; set; }

        /// <summary>
        /// The globally unique identifier for the element.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is not a valid globally unique identifier.
        /// </exception>
        [JsonProperty("guid")]
        public string Guid
        {
            get => _guid;
            set
            {
                if (System.Guid.TryParse(value, out _))
                {
                    _guid = value;
                }
                else
                {
                    throw new ArgumentException("Guid is not correct. Create Guid with proper component.");
                }
            }
        }

        /// <summary>
        /// The type of the element.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The color of the element.
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// Additional information about the element.
        /// </summary>
        [JsonProperty("info")]
        public Dictionary<string, string> Info { get; set; }
    }

}