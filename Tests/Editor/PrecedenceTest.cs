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
        [Test]
        public void AnchorsBeforeAlternation()
        {
            // precedence
            {
                var regex = new Regex("^a|b$");
                Pass(regex, "a");
                Pass(regex, "b");
                Pass(regex, "ab");
                Pass(regex, "acc");
                Pass(regex, "ccb");
            }

            // anchors first
            {
                var regex = new Regex("(^a)|(b$)");
                Pass(regex, "a");
                Pass(regex, "b");
                Pass(regex, "ab");
                Pass(regex, "acc");
                Pass(regex, "ccb");
            }

            // alternation first
            {
                var regex = new Regex("^(a|b)$");
                Pass(regex, "a");
                Pass(regex, "b");
                Fail(regex, "ab");
                Fail(regex, "acc");
                Fail(regex, "ccb");
            }

            // left-to-right
            {
                var regex = new Regex("((^a)|b)$");
                Pass(regex, "a");
                Pass(regex, "b");
                Pass(regex, "ab");
                Fail(regex, "acc");
                Pass(regex, "ccb");
            }

            // right-to-left
            {
                var regex = new Regex("^(a|(b$))");
                Pass(regex, "a");
                Pass(regex, "b");
                Pass(regex, "ab");
                Pass(regex, "acc");
                Fail(regex, "ccb");
            }
        }

        [Test]
        public void QuantifiersBeforeConcatenation()
        {
            // precedence
            {
                var regex = new Regex("ab*c");
                Pass(regex, "abbc");
                Pass(regex, "abc");
                Pass(regex, "ababc");
                Pass(regex, "ac");
                Fail(regex, "c");
            }

            // quantifiers first
            {
                var regex = new Regex("a(b*)c");
                Pass(regex, "abbc");
                Pass(regex, "abc");
                Pass(regex, "ababc");
                Pass(regex, "ac");
                Fail(regex, "c");
            }

            // concatenation first
            {
                var regex = new Regex("(ab)*c");
                Pass(regex, "abbc");
                Pass(regex, "abc");
                Pass(regex, "ababc");
                Pass(regex, "ac");
                Pass(regex, "c");
            }
        }


        [Test]
        public void QuantifiersBeforeAnchors()
        {
            // precedence
            {
                var regex = new Regex("^a+b$");
                Pass(regex, "aab");
                Pass(regex, "ab");
            }

            // quantifiers first
            {
                var regex = new Regex("^(a+)b$");
                Pass(regex, "aab");
                Pass(regex, "ab");
            }

            // anchors first
            {
                var regex = new Regex("(^a)+(b$)");
                Fail(regex, "aab");
                Pass(regex, "ab");
            }

            // left-to-right
            {
                var regex = new Regex("(((^a)+)b)$");
                Fail(regex, "aab");
                Pass(regex, "ab");
            }

            // right-to-left
            {
                var regex = new Regex("^(a+(b$))");
                Pass(regex, "aab");
                Pass(regex, "ab");
            }
        }

        [Test]
        public void QuantifiersBeforeConcatenationEx()
        {
            // precedence
            {
                var regex = new Regex("^ab+cd?$");
                Fail(regex, "");
                Fail(regex, "ab");
                Fail(regex, "abab");
                //Fail(regex, "ababcd");
                Pass(regex, "abbc");
                Pass(regex, "abbcd");
                Pass(regex, "abc");
                Pass(regex, "abcd");
            }

            // quantifiers first
            {
                var regex = new Regex("a(b+)c(d?)");
                Fail(regex, "");
                Fail(regex, "ab");
                Fail(regex, "abab");
                //Fail(regex, "ababcd");
                Pass(regex, "abbc");
                Pass(regex, "abbcd");
                Pass(regex, "abc");
                Pass(regex, "abcd");
            }

            // concatenation first
            {
                var regex = new Regex("(ab)+(cd)?");
                Fail(regex, "");
                Pass(regex, "ab");
                Pass(regex, "abab");
                Pass(regex, "ababcd");
                //Fail(regex, "abbc");
                //Fail(regex, "abbcd");
                //Fail(regex, "abc");
                Pass(regex, "abcd");
            }

            // left-to-right
            {
                var regex = new Regex("(((ab)+c)d)?");
                Pass(regex, "");
                Fail(regex, "ab");
                Fail(regex, "abab");
                Fail(regex, "ababcd");
                Pass(regex, "abbc");
                Pass(regex, "abbcd");
                Pass(regex, "abc");
                Pass(regex, "abcd");
            }

            // right-to-left
            {
                var regex = new Regex("(a(b+(c(d?))))");
                Pass(regex, "");
                Fail(regex, "ab");
                Fail(regex, "abab");
                Fail(regex, "ababcd");
                Pass(regex, "abbc");
                Pass(regex, "abbcd");
                Pass(regex, "abc");
                Pass(regex, "abcd");
            }
        }

        private static void Pass(Regex regex, string input)
        {
            Assert.IsTrue(regex.IsMatch(input));
        }

        private static void Fail(Regex regex, string input)
        {
            Assert.IsFalse(regex.IsMatch(input));
        }
    }
}
