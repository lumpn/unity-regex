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
