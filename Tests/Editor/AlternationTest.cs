//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public sealed class AlternationTest
    {
        [Test]
        public void Alternation()
        {
            var foo = new Literal("foo");
            var bar = new Literal("bar");

            var alt1 = foo | bar;
            var alt2 = new Alternation(foo, bar);
            var alt3 = foo.Or(bar);

            Assert.AreEqual("(?:foo)|(?:bar)", alt1.ToString());
            Assert.AreEqual("(?:foo)|(?:bar)", alt2.ToString());
            Assert.AreEqual("(?:foo)|(?:bar)", alt3.ToString());

            var regex = alt1.ToRegex();

            Assert.IsTrue(regex.IsMatch("foo"));
            Assert.IsTrue(regex.IsMatch("bar"));
            Assert.IsFalse(regex.IsMatch("baz"));
        }
    }
}
