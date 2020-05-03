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

        public static Pattern RepeatedTimes(this Pattern a, int count)
        {
            return new Repeat(a, count);
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
