using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotbim
{
    /// <summary>
    /// Represents a file in the BIM format.
    /// </summary>
    [Serializable]
    [JsonObject("file")]
    public class File
    {
        /// <summary>
        /// Saves the file to the specified path.
        /// </summary>
        /// <param name="path">The path to save the file to.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the path does not end with ".bim".
        /// </exception>
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
                    Formatting = Formatting.Indented,
                };
                serializer.Serialize(file, this);
            }
        }

        /// <summary>
        /// Reads a file from the specified path.
        /// </summary>
        /// <param name="path">The path of the file to read.</param>
        /// <returns>A File object representing the contents of the file.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the path does not end with ".bim".
        /// </exception>
        public static File Read(string path)
        {
            if (!path.EndsWith(".bim"))
            {
                throw new ArgumentException("Path should end up with .bim");
            }

            using (StreamReader file = System.IO.File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer()
                {
                    MaxDepth = 64
                };
                return (File) serializer.Deserialize(file, typeof(File));
            }
        }

        /// <summary>
        /// The schema version of the BIM file.
        /// </summary>
        [JsonProperty("schema_version")]
        public string SchemaVersion { get; set; }

        /// <summary>
        /// The list of meshes in the file.
        /// </summary>
        [JsonProperty("meshes")]
        public List<Mesh> Meshes { get; set; }

        /// <summary>
        /// The list of elements in the file.
        /// </summary>
        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }

        /// <summary>
        /// Additional information about the file.
        /// </summary>
        [JsonProperty("info")]
        public Dictionary<string, string> Info { get; set; }
    }
}