//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class OneOrMore : Pattern
    {
        private readonly Pattern pattern;

        public OneOrMore(Pattern pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})+", pattern);
        }
    }
}
