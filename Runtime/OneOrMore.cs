//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class OneOrMore : PatternBase
    {
        private readonly PatternBase pattern;

        public OneOrMore(PatternBase pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})+", pattern);
        }
    }
}
