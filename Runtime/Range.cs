//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Range : PatternBase
    {
        private readonly char first;
        private readonly char last;

        public Range(char first, char last)
        {
            this.first = first;
            this.last = last;
        }

        public override string ToString()
        {
            return string.Format("[{0}-{1}]", first, last);
        }
    }
}
