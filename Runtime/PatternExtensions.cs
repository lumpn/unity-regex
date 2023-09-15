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
        public static Pattern FollowedBy(this Pattern a, Pattern b)
        {
            return new Sequence(a, b);
        }

        public static Pattern RepeatedTimes(this Pattern pattern, int count)
        {
            return new Repeat(pattern, count);
        }

        public static Pattern Optional(this Pattern pattern)
        {
            return new Optional(pattern);
        }

        public static Pattern ZeroOrMore(this Pattern pattern)
        {
            return new ZeroOrMore(pattern);
        }

        public static Pattern OneOrMore(this Pattern pattern)
        {
            return new OneOrMore(pattern);
        }

        public static Pattern Or(this Pattern a, Pattern b)
        {
            return new Alternation(a, b);
        }

        public static Pattern Anchored(this Pattern pattern)
        {
            return new Anchor(pattern);
        }

        public static Regex ToRegex(this Pattern pattern, RegexOptions options = RegexOptions.None)
        {
            return new Regex(pattern.ToString(), options);
        }

        public static Regex ToRegex(this Pattern pattern, RegexOptions options, TimeSpan timeout)
        {
            return new Regex(pattern.ToString(), options, timeout);
        }
    }
}
