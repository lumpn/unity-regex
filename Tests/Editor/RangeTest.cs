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
    }
}
