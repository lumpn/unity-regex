//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Sequence : PatternBase
    {
        private readonly PatternBase[] patterns;

        public Sequence(params PatternBase[] patterns)
        {
            this.patterns = patterns;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})", string.Join<PatternBase>(")(?:", patterns));
        }
    }
}
