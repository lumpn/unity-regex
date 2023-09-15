//----------------------------------------
// MIT License
// Copyright(c) 2023 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Verbatim : Pattern
    {
        private readonly string pattern;

        public Verbatim(string pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return pattern;
        }
    }
}
