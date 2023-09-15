//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public abstract class Pattern
    {
        public abstract override string ToString();

        public static Pattern operator +(Pattern a, Pattern b)
        {
            return new Sequence(a, b);
        }

        public static Pattern operator *(Pattern pattern, int count)
        {
            return new Repeat(pattern, count);
        }

        public static Pattern operator |(Pattern a, Pattern b)
        {
            return new Alternation(a, b);
        }
    }
}
