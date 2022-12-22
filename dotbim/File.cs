using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace dotbim
{
    [Serializable]
    [JsonObject("file")]
    public class File
    {
        public void Save(string path)
        {
            if (!path.EndsWith(".bim"))
            {
                throw new ArgumentException("Path should end up with .bim");
            }

            using (StreamWriter file = System.IO.File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                serializer.Serialize(file, this);
            }
        }

        public static File Read(string path)
        {
            if (!path.EndsWith(".bim"))
            {
                throw new ArgumentException("Path should end up with .bim");
            }

            using (StreamReader file = System.IO.File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (File)serializer.Deserialize(file, typeof(File));
            }
        }

        [JsonProperty("schema_version")]
        public string SchemaVersion { get; set; }

        [JsonProperty("meshes")]
        public List<Mesh> Meshes { get; set; }

        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }

        [JsonProperty("info")]
        public Dictionary<string, string> Info { get; set; }
    }
}