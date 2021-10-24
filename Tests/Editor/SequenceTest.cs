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
            // ABC
            var a = new Literal("A");
            var b = new Literal("B");
            var c = new Literal("C");

            var abc1 = a + b + c;
            var abc2 = new Sequence(a, b, c);
            var abc3 = a.FollowedBy(b).FollowedBy(c);

            Assert.AreEqual("ABC", abc1.ToString());
            Assert.AreEqual("ABC", abc2.ToString());
            Assert.AreEqual("ABC", abc3.ToString());

            var regex = abc1.ToRegex();

            Assert.IsTrue(regex.IsMatch("ABC"));
            Assert.IsTrue(regex.IsMatch("123 ABC 456"));
            Assert.IsFalse(regex.IsMatch("abc"));
        }
    }
}
