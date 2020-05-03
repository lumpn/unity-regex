//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Text.RegularExpressions;

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
        }

        [Test]
        public void TestCapture()
        {
            // 555-555-5555
            var digit = Pattern.Digit;
            var dash = new Literal("-");

            var area = digit * 3;
            var exchange = digit * 3;
            var subscriber = digit * 4;

            var phone = area + dash + exchange + dash + subscriber;

            var capture = new Capture("phone", phone);

            var regex = capture.ToRegex(RegexOptions.Compiled);

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
