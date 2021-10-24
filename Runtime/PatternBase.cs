//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public abstract class PatternBase
    {
        public abstract override string ToString();

        public static PatternBase operator +(PatternBase a, PatternBase b)
        {
            return new Sequence(a, b);
        }

        public static PatternBase operator *(PatternBase pattern, int count)
        {
            return new Repeat(pattern, count);
        }

        public static PatternBase operator |(PatternBase a, PatternBase b)
        {
            return new Alternation(a, b);
        }
    }
}
