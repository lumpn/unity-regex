//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Lumpn.RegularExpressions.Tests
{
    /// <summary>
    /// Order of precedence in .NET:
    /// 1. Escape character
    /// 2. Groups and ranges
    /// 3. Quantifiers
    /// 4. Anchors and sequences
    /// 5. Alternation
    /// </summary>
    [TestFixture]
    public sealed class OperatorPrecedenceTest
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
        public void AnchorsBeforeAlternation()
        {
            var precedence = "^a|b$";
            var anchorsFirst = "(^a)|(b$)";
            var alternationsFirst = "^(a|b)$";
            var leftToRight = "((^a)|b)$";
            var rightToLeft = "^(a|(b$))";

            Assert.IsTrue(AreEqual(precedence, anchorsFirst));
            Assert.IsFalse(AreEqual(precedence, alternationsFirst));
            Assert.IsFalse(AreEqual(precedence, leftToRight));
            Assert.IsFalse(AreEqual(precedence, rightToLeft));
        }

        [Test]
        public void QuantifierBeforeSequence()
        {
            var precedence = "ab*c";
            var quantifiersFirst = "a(b*)c";
            var sequencesFirst = "(ab)*c";

            Assert.IsTrue(AreEqual(precedence, quantifiersFirst));
            Assert.IsFalse(AreEqual(precedence, sequencesFirst));
        }


        [Test]
        public void QuantifierBeforeAnchors()
        {
            var precedence = "^a+b$";
            var quantifiersFirst = "^(a+)b$";
            var anchorsFirst = "(^a)+(b$)";

            Assert.IsTrue(AreEqual(precedence, quantifiersFirst));
            Assert.IsFalse(AreEqual(precedence, anchorsFirst));
        }

        private static bool AreEqual(string pattern1, string pattern2)
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
