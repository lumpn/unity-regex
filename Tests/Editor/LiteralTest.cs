//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public class LiteralTest
    {
        [Test]
        public void PreservesSequence()
        {
            var literal = new Literal("foo");
            var regex = literal.ToRegex();

            Assert.IsTrue(regex.IsMatch("foo"));
            Assert.IsFalse(regex.IsMatch("f"));
            Assert.IsFalse(regex.IsMatch("fo"));
            Assert.IsFalse(regex.IsMatch("o"));
            Assert.IsFalse(regex.IsMatch("oo"));
        }

        [Test]
        public void EscapesDot()
        {
            var literal = new Literal(".");
            var regex = literal.ToRegex();

            Assert.IsTrue(regex.IsMatch("."));
            Assert.IsFalse(regex.IsMatch("a"));
        }
    }
}
