//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Capture : PatternBase
    {
        private readonly string name;
        private readonly PatternBase pattern;

        public Capture(string name, PatternBase pattern)
        {
            this.name = name;
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("(?<{0}>{1})", name, pattern);
        }
    }
}
