//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public class QuantifierTest
    {
        [Test]
        public void TestOneOrMore()
        {
            var digit = Patterns.Digit;
            var number = new OneOrMore(digit);
            var number2 = digit.OneOrMore();

            Assert.AreEqual("(?:\\d)+", number.ToString());
            Assert.AreEqual("(?:\\d)+", number2.ToString());

            var regex = number.ToRegex();
            Assert.IsTrue(regex.IsMatch("1"));
            Assert.IsTrue(regex.IsMatch("12"));
            Assert.IsFalse(regex.IsMatch("a"));
        }

        [Test]
        public void TestZeroOrMore()
        {
            var a = new Literal("a");
            var b = new Literal("b");
            var anything = Patterns.AnyCharacter.ZeroOrMore();
            var pattern = new Sequence(a, anything, b);

            Assert.AreEqual("(?:a)(?:(?:.)*)(?:b)", pattern.ToString());

            var regex = pattern.ToRegex();
            Assert.IsTrue(regex.IsMatch("ab"));
            Assert.IsTrue(regex.IsMatch("a1b"));
            Assert.IsTrue(regex.IsMatch("a  b"));
            Assert.IsFalse(regex.IsMatch("a"));
            Assert.IsFalse(regex.IsMatch("b"));
        }

        [Test]
        public void TestOptional()
        {
            // +1 555-555-5555
            // country code and separators optional

            var digit = Patterns.Digit;
            var dash = Patterns.Dash;
            var space = Patterns.Space;
            var separator = new Optional(dash | space);

            var optionalPlus = Patterns.Plus.Optional();
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

        [Test]
        public void TestRepeat()
        {
            var a = new Literal("a");

            var aaa = new Repeat(a, 3);
            var aaa2 = a * 3;
            var aaa3 = a.RepeatedTimes(3);

            Assert.AreEqual("(?:a){3}", aaa.ToString());
            Assert.AreEqual("(?:a){3}", aaa2.ToString());
            Assert.AreEqual("(?:a){3}", aaa3.ToString());

            var regex = aaa.ToRegex();
            Assert.IsFalse(regex.IsMatch("aa"));
            Assert.IsTrue(regex.IsMatch("aaa"));
            Assert.IsTrue(regex.IsMatch("aaaa"));
            Assert.IsTrue(regex.IsMatch("123 aaa 456"));
            Assert.IsFalse(regex.IsMatch("aba"));
        }
    }
}
