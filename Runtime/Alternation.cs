//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Alternation : PatternBase
    {
        private readonly PatternBase[] patterns;

        public Alternation(params PatternBase[] patterns)
        {
            this.patterns = patterns;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})", string.Join<PatternBase>(")|(?:", patterns));
        }
    }
}
