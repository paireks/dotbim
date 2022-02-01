using System;
using Newtonsoft.Json;

namespace dotbim
{
    [Serializable]
    [JsonObject("color")]
    public struct Color
    {
        private int _r;
        private int _g;
        private int _b;
        private int _a;
        [JsonProperty("r")]
        public int R
        {
            get => _r;
            set
            {
                if (value >= 0 && value <= 255)
                {
                    _r = value;
                }
                else
                {
                    throw new ArgumentException("R value should be between 0-255");
                }
            }
        }
        [JsonProperty("g")]
        public int G
        {
            get => _g;
            set
            {
                if (value >= 0 && value <= 255)
                {
                    _g = value;
                }
                else
                {
                    throw new ArgumentException("G value should be between 0-255");
                }
            }
        }
        [JsonProperty("b")]
        public int B
        {
            get => _b;
            set
            {
                if (value >= 0 && value <= 255)
                {
                    _b = value;
                }
                else
                {
                    throw new ArgumentException("B value should be between 0-255");
                }
            }
        }
        [JsonProperty("a")]
        public int A
        {
            get => _a;
            set
            {
                if (value >= 0 && value <= 255)
                {
                    _a = value;
                }
                else
                {
                    throw new ArgumentException("A value should be between 0-255");
                }
            }
        }
    }
}