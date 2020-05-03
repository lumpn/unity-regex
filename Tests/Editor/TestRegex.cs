//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Lumpn.RegularExpressions
{
    [TestFixture]
    public sealed class TestRegex
    {
        [Test]
        public void TestSequence()
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

        [Test]
        public void TestRepeat()
        {
            // AAA
            var a = new Literal("A");

            var aaa1 = a * 3;
            var aaa2 = new Repeat(a, 3);
            var aaa3 = a.RepeatedTimes(3);

            Assert.AreEqual("(?:A){3}", aaa1.ToString());
            Assert.AreEqual("(?:A){3}", aaa2.ToString());
            Assert.AreEqual("(?:A){3}", aaa3.ToString());

            var regex = aaa1.ToRegex();

            Assert.IsTrue(regex.IsMatch("AAA"));
            Assert.IsTrue(regex.IsMatch("AAAAAA"));
            Assert.IsTrue(regex.IsMatch("123 AAA 456"));
            Assert.IsFalse(regex.IsMatch("ABA"));
        }

        [Test]
        public void TestCapture()
        {
            // 555-555-5555
            var digit = Pattern.Digit;
            var dash = Pattern.Dash;

            var area = digit * 3;
            var exchange = digit * 3;
            var subscriber = digit * 4;

            var phone = area + dash + exchange + dash + subscriber;

            var capture = new Capture("phone", phone);

            var regex = capture.ToRegex();

            var match1 = regex.Match("555-555-5555");
            var match2 = regex.Match("My phone number is 555-555-5555, and yours?");
            var match3 = regex.Match("127.0.0.1");

            Assert.IsTrue(match1.Success);
            Assert.IsTrue(match2.Success);
            Assert.IsFalse(match3.Success);

            Assert.AreEqual("555-555-5555", match1.Groups["phone"].ToString());
            Assert.AreEqual("555-555-5555", match2.Groups["phone"].ToString());
            Assert.AreEqual(string.Empty, match3.Groups["phone"].ToString());
        }

        [Test]
        public void TestAlternation()
        {
            var foo = new Literal("foo");
            var bar = new Literal("bar");

            var alt1 = foo | bar;
            var alt2 = new Alternation(foo, bar);
            var alt3 = foo.Or(bar);

            Assert.AreEqual("(?:foo|bar)", alt1.ToString());
            Assert.AreEqual("(?:foo|bar)", alt2.ToString());
            Assert.AreEqual("(?:foo|bar)", alt3.ToString());

            var regex = alt1.ToRegex();

            Assert.IsTrue(regex.IsMatch("foo"));
            Assert.IsTrue(regex.IsMatch("bar"));
            Assert.IsFalse(regex.IsMatch("baz"));
        }

        [Test]
        public void TestOptional()
        {
            // +1 555-555-5555
            // country code and separators optional

            var digit = Pattern.Digit;
            var dash = Pattern.Dash;
            var space = Pattern.Space;
            var separator = new Optional(dash | space);

            var optionalPlus = Pattern.Plus.Optional();
            var someDigits = new OneOrMore(digit);

            var countryCode = new Optional(optionalPlus + someDigits);
            var phone = countryCode + separator + digit * 3 + separator + digit * 3 + separator + digit * 4;

            var regex = phone.ToRegex();

            Assert.IsTrue(regex.IsMatch("+1 555-555-5555"));
            Assert.IsTrue(regex.IsMatch("1-555-555-5555"));
            Assert.IsTrue(regex.IsMatch("555-555-5555"));
            Assert.IsTrue(regex.IsMatch("555 555 5555"));
            Assert.IsTrue(regex.IsMatch("+911-555-555-5555"));
            Assert.IsFalse(regex.IsMatch("127.0.0.1"));
        }
    }
}
