//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class ZeroOrMore : Pattern
    {
        private readonly Pattern pattern;

        public ZeroOrMore(Pattern pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})*", pattern);
        }
    }
}
