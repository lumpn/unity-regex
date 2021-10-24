//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    [TestFixture]
    public sealed class PrecedenceTest
    {
        private static readonly string[] inputs =
        {
                "a",
                "aab",
                "ab",
                "abbc",
                "abc",
                "ababc",
                "ac",
                "b",
                "c",
                "cb",
        };

        [Test]
        public void AnchorsPreceedAlternations()
        {
            var precedence = "^a|b$";
            var anchorsFirst = "(^a)|(b$)";
            var alternationsFirst = "^(a|b)$";
            var leftToRight = "((^a)|b)$";
            var rightToLeft = "^(a|(b$))";

            Assert.IsTrue(AreEqual(precedence, anchorsFirst, inputs));
            Assert.IsFalse(AreEqual(precedence, alternationsFirst, inputs));
            Assert.IsFalse(AreEqual(precedence, leftToRight, inputs));
            Assert.IsFalse(AreEqual(precedence, rightToLeft, inputs));
        }

        [Test]
        public void QuantifiersPreceedConcatenations()
        {
            var precedence = "ab*c";
            var quantifiersFirst = "a(b*)c";
            var concatenationsFirst = "(ab)*c";

            Assert.IsTrue(AreEqual(precedence, quantifiersFirst, inputs));
            Assert.IsFalse(AreEqual(precedence, concatenationsFirst, inputs));
        }


        [Test]
        public void QuantifiersPreceedAnchors()
        {
            var precedence = "^a+b$";
            var quantifiersFirst = "^(a+)b$";
            var anchorsFirst = "(^a)+(b$)";

            Assert.IsTrue(AreEqual(precedence, quantifiersFirst, inputs));
            Assert.IsFalse(AreEqual(precedence, anchorsFirst, inputs));
        }

        private static bool AreEqual(string pattern1, string pattern2, string[] inputs)
        {
            var regex1 = new Regex(pattern1);
            var regex2 = new Regex(pattern2);

            foreach (var input in inputs)
            {
                var match1 = regex1.IsMatch(input);
                var match2 = regex2.IsMatch(input);

                if (match1 != match2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
