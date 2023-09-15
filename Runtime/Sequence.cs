//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Sequence : Pattern
    {
        private readonly Pattern[] patterns;

        public Sequence(params Pattern[] patterns)
        {
            this.patterns = patterns;
        }

        public override string ToString()
        {
            return string.Format("(?:{0})", string.Join<Pattern>(")(?:", patterns));
        }
    }
}
