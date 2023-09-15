//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Repeat : Pattern
    {
        private readonly Pattern pattern;
        private readonly int count;

        public Repeat(Pattern pattern, int count)
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
