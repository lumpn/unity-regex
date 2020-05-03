//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Optional : Pattern
    {
        private readonly Pattern pattern;

        public Optional(Pattern pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})?", pattern);
        }
    }
}
