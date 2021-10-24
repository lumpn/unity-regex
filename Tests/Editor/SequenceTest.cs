//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public class SequenceTest
    {
        [Test]
        public void Sequence()
        {
            var a = new Literal("a");
            var b = new Literal("b");
            var c = new Literal("c");

            var abc = new Sequence(a, b, c);
            var abc2 = a + b + c;
            var abc3 = a.FollowedBy(b).FollowedBy(c);

            Assert.AreEqual("(?:a)(?:b)(?:c)", abc.ToString());
            Assert.AreEqual("(?:(?:a)(?:b))(?:c)", abc2.ToString());
            Assert.AreEqual("(?:(?:a)(?:b))(?:c)", abc3.ToString());

            var regex = abc.ToRegex();
            Assert.IsTrue(regex.IsMatch("abc"));
            Assert.IsTrue(regex.IsMatch("123 abc 456"));
            Assert.IsFalse(regex.IsMatch("ab"));
            Assert.IsFalse(regex.IsMatch("bc"));
        }
    }
}
