using System;
using System.Collections.Generic;
using System.Linq;
using dotbim;
using Newtonsoft.Json;
using Xunit;

namespace test.UnitTests
{
    public class TestBigFile
    {
        [Fact]
        public void TestBigFile_NestedJson_ThrowsMaxDepth()
        {
            string path = "BigFile.bim";
            string json = CreateJsonString(1000);

            CreateFile(path, json);

            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => {
                var fileRead = File.Read(path);
            });
        }

        [Fact]
        public void TestBigFile_NestedJson_PassMaxDepth()
        {
            string path = "BigFile.bim";
            string json = CreateJsonString(10);

            CreateFile(path, json);

            var fileRead = File.Read(path);

            Assert.Equal("1.0.0", fileRead.SchemaVersion);
        }

        [Fact]
        public void TestBigFile_Deserialize_ThrowsMaxDepth()
        {
            string json = CreateJsonString(1000);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { MaxDepth = 64 };

            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => { 
                var parsedJson = JsonConvert.DeserializeObject(json);
            });
        }

        private string CreateJsonString(int nRep)
        {
            string json = string.Concat(Enumerable.Repeat("{a:", nRep)) + "1" +
            string.Concat(Enumerable.Repeat("}", nRep));

            return $"{{\"schema_version\":\"1.0.0\" ,\"a\":{json}}}";
        }

        private void CreateFile(string path, string text)
        {
            using (System.IO.StreamWriter file = System.IO.File.CreateText(path))
            {
                file.Write(text);
            }
        }
    }
}