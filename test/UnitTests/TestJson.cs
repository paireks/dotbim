using System.Linq;
using System.Text.Json;
using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestJson
    {
        [Fact]
        public void TestJson_FileRead_ThrowsMaxDepth()
        {
            string path = "TestJson.bim";
            string json = CreateJsonString(1000);

            CreateFile(path, json);

            Assert.Throws<JsonException>(() => {
                var fileRead = File.Read(path);
            });
        }

        [Fact]
        public void TestJson_FileRead_PassMaxDepth()
        {
            string path = "TestJson.bim";
            string json = CreateJsonString(10);

            CreateFile(path, json);

            var fileRead = File.Read(path);

            Assert.Equal("1.0.0", fileRead.SchemaVersion);
        }

        [Fact]
        public void TestJson_Deserialize_ThrowsMaxDepth()
        {
            string json = CreateJsonString(1000);

            Assert.Throws<JsonException>(() => { 
                var parsedJson = JsonSerializer.Deserialize<object>(json);
            });
        }

        private string CreateJsonString(int nRep)
        {
            string json = string.Concat(Enumerable.Repeat("{\"a\":", nRep)) + "1" +
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