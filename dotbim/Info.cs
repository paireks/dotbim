using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dotbim
{
    [Serializable]
    [JsonObject("info")]
    public class Info
    {
        [JsonProperty("keys")]
        public List<string> Keys { get; set; }
        
        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }
}