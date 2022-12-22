using Newtonsoft.Json;
using System;

namespace dotbim
{
    [Serializable]
    [JsonObject("vector")]
    public struct Vector
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("z")]
        public double Z { get; set; }
    }
}