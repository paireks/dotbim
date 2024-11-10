using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotbim
{
    /// <summary>
    /// Represents a file in the BIM format.
    /// </summary>
    [Serializable]
    public class File
    {
        /// <summary>
        /// Saves the file to the specified path.
        /// </summary>
        /// <param name="path">The path to save the file to.</param>
        /// <param name="format">True = Formatting.Indented will be used for json, false = Formatting.None will be used.
        /// If you want a file to be more optimized - use false there.
        /// If you want to make it more human-readable - use true there.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the path does not end with ".bim".
        /// </exception>
        public void Save(string path, bool format = true)
        {
            if (!path.EndsWith(".bim"))
            {
                throw new ArgumentException("Path should end up with .bim");
            }

            string jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = format });
            System.IO.File.WriteAllText(path, jsonString);
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
            
            string jsonString = System.IO.File.ReadAllText(path);
            return JsonSerializer.Deserialize<File>(jsonString);
        }

        /// <summary>
        /// The schema version of the BIM file.
        /// </summary>
        [JsonPropertyName("schema_version")]
        public string SchemaVersion { get; set; }

        /// <summary>
        /// The list of meshes in the file.
        /// </summary>
        [JsonPropertyName("meshes")]
        public List<Mesh> Meshes { get; set; }

        /// <summary>
        /// The list of elements in the file.
        /// </summary>
        [JsonPropertyName("elements")]
        public List<Element> Elements { get; set; }

        /// <summary>
        /// Additional information about the file.
        /// </summary>
        [JsonPropertyName("info")]
        public Dictionary<string, string> Info { get; set; }
    }
}