//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Alternation : Pattern
    {
        private readonly Pattern[] patterns;

        public Alternation(params Pattern[] patterns)
        {
            this.patterns = patterns;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})", string.Join<Pattern>(")|(?:", patterns));
        }
    }
}
