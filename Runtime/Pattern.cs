//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Pattern : PatternBase
    {
        public static PatternBase Digit = new Pattern("\\d");
        public static PatternBase NonDigit = new Pattern("\\D");

        public static PatternBase Whitespace = new Pattern("\\s");
        public static PatternBase NonWhitespace = new Pattern("\\S");

        public static PatternBase Word = new Pattern("\\w");
        public static PatternBase NonWord = new Pattern("\\W");

        public static PatternBase AnyCharacter = new Pattern(".");
        public static PatternBase Space = new Pattern(" ");
        public static PatternBase Tab = new Pattern("\t");
        public static PatternBase Dash = new Pattern("-");
        public static PatternBase Slash = new Pattern("/");
        public static PatternBase Backslash = new Pattern("\\");
        public static PatternBase CarriageReturn = new Pattern("\r");
        public static PatternBase NewLine = new Pattern("\n");
        public static PatternBase Plus = new Pattern("\\+");
        public static PatternBase Dot = new Pattern("\\.");

        public static PatternBase UppercaseLetter = new Range('A', 'Z');
        public static PatternBase LowercaseLetter = new Range('a', 'z');
        public static PatternBase Letter = new Pattern("[A-Za-z]");
        public static PatternBase LetterOrDigit = Word;

        private readonly string pattern;

        private Pattern(string pattern)
        {
            this.pattern = pattern;
        }

        public override string ToString()
        {
            return pattern;
        }
    }
}
