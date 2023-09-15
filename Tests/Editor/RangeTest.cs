//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        public void TestRange()
        {
            var range = new Range('a', 'f');

            Assert.AreEqual("[a-f]", range.ToString());

            var regex = range.ToRegex();
            Assert.IsTrue(regex.IsMatch("a"));
            Assert.IsTrue(regex.IsMatch("b"));
            Assert.IsFalse(regex.IsMatch("z"));
        }

        [Test]
        public void TestMetaCharacters()
        {
            Assert.IsTrue(IsMatch(Pattern.Word, "1"));
            Assert.IsTrue(IsMatch(Pattern.Word, "A"));
            Assert.IsTrue(IsMatch(Pattern.Word, "a"));
            Assert.IsTrue(IsMatch(Pattern.Word, "_"));
            Assert.IsFalse(IsMatch(Pattern.Word, "-"));

            Assert.IsTrue(IsMatch(Pattern.LetterOrDigit, "1"));
            Assert.IsTrue(IsMatch(Pattern.LetterOrDigit, "A"));
            Assert.IsTrue(IsMatch(Pattern.LetterOrDigit, "a"));
            Assert.IsFalse(IsMatch(Pattern.LetterOrDigit, "-"));
            Assert.IsFalse(IsMatch(Pattern.LetterOrDigit, "_"));
        }

        [Test]
        public void TestNegativeRange()
        {
            Assert.IsTrue(IsMatch(Pattern.NonLetter, "1"));
            Assert.IsFalse(IsMatch(Pattern.NonLetter, "a"));

            Assert.IsTrue(IsMatch(Pattern.NonDigit, "a"));
            Assert.IsFalse(IsMatch(Pattern.NonDigit, "1"));

            Assert.IsTrue(IsMatch(Pattern.NonLetterOrDigit, "!"));
            Assert.IsTrue(IsMatch(Pattern.NonLetterOrDigit, "_"));
            Assert.IsTrue(IsMatch(Pattern.NonLetterOrDigit, " "));
            Assert.IsFalse(IsMatch(Pattern.NonLetterOrDigit, "a"));
            Assert.IsFalse(IsMatch(Pattern.NonLetterOrDigit, "1"));
        }

        private static bool IsMatch(PatternBase pattern, string input)
        {
            return pattern.ToRegex().IsMatch(input);
        }
    }
}
