using System;
using Newtonsoft.Json;

namespace dotbim
{
    [Serializable]
    [JsonObject("element")]
    public class Element
    {
        private string _guid;
        
        [JsonProperty("mesh_id")]
        public int MeshId { get; set; }
        
        [JsonProperty("vector")]
        public Vector Vector { get; set; }
        
        [JsonProperty("rotation")]
        public Rotation Rotation { get; set; }

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

        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("color")]
        public Color Color { get; set; }
        
        [JsonProperty("info")]
        public Info Info { get; set; }
    }
}