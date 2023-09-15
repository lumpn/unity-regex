//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public sealed class CaptureTest
    {
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

            var capture = new NamedCapture("phone", phone);

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

    }
}
