//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public abstract class Pattern
    {
        public static Pattern Digit = new Literal("\\d");
        public static Pattern NonDigit = new Literal("\\D");

        public static Pattern Whitespace = new Literal("\\s");
        public static Pattern NonWhitespace = new Literal("\\S");

        public static Pattern Word = new Literal("\\w");
        public static Pattern NonWord = new Literal("\\W");

        public static Pattern AnyCharacter = new Literal(".");
        public static Pattern Space = new Literal(" ");
        public static Pattern Tab = new Literal("\t");
        public static Pattern Dash = new Literal("-");
        public static Pattern Slash = new Literal("/");
        public static Pattern Backslash = new Literal("\\");
        public static Pattern CarriageReturn = new Literal("\r");
        public static Pattern NewLine = new Literal("\n");
        public static Pattern Plus = new Literal("\\+");
        public static Pattern Dot = new Literal("\\.");

        public static Pattern UppercaseLetter = new Range('A', 'Z');
        public static Pattern LowercaseLetter = new Range('a', 'z');
        public static Pattern Letter = new Literal("[A-Za-z]");
        public static Pattern LetterOrDigit = Word;

        public static Pattern operator +(Pattern a, Pattern b)
        {
            return new Sequence(a, b);
        }

        public static Pattern operator *(Pattern pattern, int count)
        {
            return new Repeat(pattern, count);
        }

        public static Pattern operator |(Pattern a, Pattern b)
        {
            return new Alternation(a, b);
        }

        public abstract override string ToString();
    }
}
