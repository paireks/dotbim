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
        
        [JsonProperty("vertices_coordinates")]
        public List<double> VerticesCoordinates { get; set; }
        
        [JsonProperty("faces_ids")]
        public List<int> FacesIds { get; set; }
    }
}