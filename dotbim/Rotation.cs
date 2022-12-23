using System;
using Newtonsoft.Json;

namespace dotbim
{
    [Serializable]
    [JsonObject("rotation")]
    public struct Rotation
    {
        [JsonProperty("qx")]
        public double Qx { get; set; }
        
        [JsonProperty("qy")]
        public double Qy { get; set; }
        
        [JsonProperty("qz")]
        public double Qz { get; set; }
        
        [JsonProperty("qw")]
        public double Qw { get; set; }
    }
}