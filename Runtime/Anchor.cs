//----------------------------------------
// MIT License
// Copyright(c) 2023 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Anchor : PatternBase
    {
        private readonly PatternBase pattern;

        public Anchor(PatternBase pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("^(?:{0})$", pattern);
        }
    }
}
