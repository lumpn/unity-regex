//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System;
using System.Text.RegularExpressions;

namespace Lumpn.RegularExpressions
{
    public static class PatternExtensions
    {
        public static PatternBase FollowedBy(this PatternBase a, PatternBase b)
        {
            return new Sequence(a, b);
        }

        public static PatternBase RepeatedTimes(this PatternBase pattern, int count)
        {
            return new Repeat(pattern, count);
        }

        public static PatternBase Or(this PatternBase a, PatternBase b)
        {
            return new Alternation(a, b);
        }

        public static PatternBase Optional(this PatternBase pattern)
        {
            return new Optional(pattern);
        }

        public static Regex ToRegex(this PatternBase pattern, RegexOptions options = RegexOptions.None)
        {
            return new Regex(pattern.ToString(), options);
        }

        public static Regex ToRegex(this PatternBase pattern, RegexOptions options, TimeSpan timeout)
        {
            return new Regex(pattern.ToString(), options, timeout);
        }
    }
}
