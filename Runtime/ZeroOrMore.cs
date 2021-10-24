//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class ZeroOrMore : PatternBase
    {
        private readonly PatternBase pattern;

        public ZeroOrMore(PatternBase pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})*", pattern);
        }
    }
}
