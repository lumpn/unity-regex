//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Capture : Pattern
    {
        private readonly string name;
        private readonly Pattern pattern;

        public Capture(string name, Pattern pattern)
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
