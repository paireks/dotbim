using System.Collections.Generic;
using dotbim;
using Xunit;

namespace test.UnitTests
{
    public class TestInfo
    {
        [Fact]
        public void TestInfo_Correct()
        {
            Info info = new Info
            {
                Keys = new List<string>
                {
                    "Key_One", "Key_Two"
                },
                Values = new List<string>
                {
                    "Value_One", "Value_Two"
                }
            };
            
            Assert.Equal("Key_One", info.Keys[0]);
            Assert.Equal("Key_Two", info.Keys[1]);
            Assert.Equal("Value_One", info.Values[0]);
            Assert.Equal("Value_Two", info.Values[1]);
        }
    }
}