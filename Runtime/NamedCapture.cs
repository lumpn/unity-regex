//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Text.RegularExpressions;

namespace Lumpn.RegularExpressions
{
    public sealed class NamedCapture : Pattern
    {
        private readonly string name;
        private readonly Pattern pattern;

        public NamedCapture(string name, Pattern pattern)
        {
            this.name = name;
            this.pattern = pattern;
        }

        public string GetValue(Match match)
        {
            return match.Groups[name].Value;
        }

        public override string ToString()
        {
            return string.Format("(?<{0}>{1})", name, pattern);
        }
    }
}
