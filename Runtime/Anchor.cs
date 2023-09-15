//----------------------------------------
// MIT License
// Copyright(c) 2023 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Anchor : Pattern
    {
        private readonly Pattern pattern;

        public Anchor(Pattern pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return string.Format("^(?:{0})$", pattern);
        }
    }
}
