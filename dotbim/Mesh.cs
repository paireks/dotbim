using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dotbim
{
    public class Mesh
    {
        private int _meshId;
        
        [JsonProperty("mesh_id")]
        public int MeshId {
            get => _meshId;
            set
            {
                if (value >= 0)
                {
                    _meshId = value;
                }
                else
                {
                    throw new ArgumentException("MeshId should be >= 0");
                }
            }
        }
        
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
        
        [JsonProperty("indices")]
        public List<int> Indices { get; set; }
    }
}