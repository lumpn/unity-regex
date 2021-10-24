//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Repeat : PatternBase
    {
        private readonly PatternBase pattern;
        private readonly int count;

        public Repeat(PatternBase pattern, int count)
        {
            this.pattern = pattern;
            this.count = count;
        }

        public override string ToString()
        {
            return string.Format("(?:{0}){{{1}}}", pattern, count);
        }
    }
}
