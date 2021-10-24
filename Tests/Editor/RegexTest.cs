//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public sealed class RegexTest
    {


        [Test]
        public void TestLeftToRightPrecedence()
        {
            var leftToRightPrecedence = new Literal("^(?:a+|b+)$"); // equivalent to `[ab]+`

            var regex = leftToRightPrecedence.ToRegex();
            Assert.IsTrue(regex.IsMatch("aa"));
            Assert.IsTrue(regex.IsMatch("bb"));
            Assert.IsTrue(regex.IsMatch("ab"));
            Assert.IsTrue(regex.IsMatch("aab"));
            Assert.IsTrue(regex.IsMatch("abb"));
            Assert.IsTrue(regex.IsMatch("aba"));
            Assert.IsTrue(regex.IsMatch("bab"));
        }

        [Test]
        public void TestNonCapturingGroup()
        {
            var nonCapturing = new Literal("^(?:a+)|(?:b+)$");

            var regex = nonCapturing.ToRegex();
            Assert.IsTrue(regex.IsMatch("aa"));
            Assert.IsTrue(regex.IsMatch("bb"));
            Assert.IsTrue(regex.IsMatch("ab"));
            Assert.IsTrue(regex.IsMatch("aab"));
            Assert.IsTrue(regex.IsMatch("abb"));
            Assert.IsTrue(regex.IsMatch("aba"));
            Assert.IsTrue(regex.IsMatch("bab"));
        }

        [Test]
        public void TestAnchors()
        {
            var anchors = new Literal("^foo$");
            Assert.AreEqual("^foo$", anchors.ToString());

            var regex = anchors.ToRegex();
            Assert.IsTrue(regex.IsMatch("foo"));
            Assert.IsFalse(regex.IsMatch("food"));
            Assert.IsFalse(regex.IsMatch("pfoo"));
        }

        [Test]
        public void TestAlternationWithAnchors()
        {
            var alternation = new Literal("^a|b$");
            //Assert.AreEqual("^(?:a|b)$", alternation.ToString());

            var regex = alternation.ToRegex();
            Assert.IsTrue(regex.IsMatch("a"));
            Assert.IsTrue(regex.IsMatch("b"));
            Assert.IsFalse(regex.IsMatch("aa"));
            Assert.IsFalse(regex.IsMatch("ab"));
        }

        [Test]
        public void TestAlternationPrecedence()
        {
            var a = new Literal("a+");
            var b = new Literal("b+");

            var alt = a | b;
            //Assert.AreEqual("(?:a+)|(?:b+)", alt.ToString());

            var regex = alt.ToRegex();
            Assert.IsTrue(regex.IsMatch("aa"));
            Assert.IsTrue(regex.IsMatch("bb"));
            Assert.IsTrue(regex.IsMatch("ab"));
            Assert.IsTrue(regex.IsMatch("aab"));
            Assert.IsTrue(regex.IsMatch("abb"));
            Assert.IsTrue(regex.IsMatch("aba"));
            Assert.IsTrue(regex.IsMatch("bab"));
        }

    }
}
