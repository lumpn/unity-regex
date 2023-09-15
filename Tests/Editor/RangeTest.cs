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
            Assert.IsTrue(IsMatch(Patterns.Word, "1"));
            Assert.IsTrue(IsMatch(Patterns.Word, "A"));
            Assert.IsTrue(IsMatch(Patterns.Word, "a"));
            Assert.IsTrue(IsMatch(Patterns.Word, "_"));
            Assert.IsFalse(IsMatch(Patterns.Word, "-"));

            Assert.IsTrue(IsMatch(Patterns.LetterOrDigit, "1"));
            Assert.IsTrue(IsMatch(Patterns.LetterOrDigit, "A"));
            Assert.IsTrue(IsMatch(Patterns.LetterOrDigit, "a"));
            Assert.IsFalse(IsMatch(Patterns.LetterOrDigit, "-"));
            Assert.IsFalse(IsMatch(Patterns.LetterOrDigit, "_"));
        }

        [Test]
        public void TestNegativeRange()
        {
            Assert.IsTrue(IsMatch(Patterns.NonLetter, "1"));
            Assert.IsFalse(IsMatch(Patterns.NonLetter, "a"));

            Assert.IsTrue(IsMatch(Patterns.NonDigit, "a"));
            Assert.IsFalse(IsMatch(Patterns.NonDigit, "1"));

            Assert.IsTrue(IsMatch(Patterns.NonLetterOrDigit, "!"));
            Assert.IsTrue(IsMatch(Patterns.NonLetterOrDigit, "_"));
            Assert.IsTrue(IsMatch(Patterns.NonLetterOrDigit, " "));
            Assert.IsFalse(IsMatch(Patterns.NonLetterOrDigit, "a"));
            Assert.IsFalse(IsMatch(Patterns.NonLetterOrDigit, "1"));
        }

        private static bool IsMatch(PatternBase pattern, string input)
        {
            return pattern.ToRegex().IsMatch(input);
        }
    }
}
