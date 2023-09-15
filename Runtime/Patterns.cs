//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public static class Patterns
    {
        public static PatternBase Digit = new Verbatim("\\d");
        public static PatternBase NonDigit = new Verbatim("\\D");

        public static PatternBase Whitespace = new Verbatim("\\s");
        public static PatternBase NonWhitespace = new Verbatim("\\S");

        public static PatternBase Word = new Verbatim("\\w");
        public static PatternBase NonWord = new Verbatim("\\W");

        public static PatternBase AnyCharacter = new Verbatim(".");
        public static PatternBase Space = new Verbatim(" ");
        public static PatternBase Tab = new Verbatim("\t");
        public static PatternBase Dash = new Verbatim("-");
        public static PatternBase Slash = new Verbatim("/");
        public static PatternBase Backslash = new Verbatim("\\");
        public static PatternBase CarriageReturn = new Verbatim("\r");
        public static PatternBase NewLine = new Verbatim("\n");
        public static PatternBase Plus = new Verbatim("\\+");
        public static PatternBase Dot = new Verbatim("\\.");

        public static PatternBase UppercaseLetter = new Verbatim("[A-Z]");
        public static PatternBase LowercaseLetter = new Verbatim("[a-z]");
        public static PatternBase Letter = new Verbatim("[A-Za-z]");
        public static PatternBase NonLetter = new Verbatim("[^A-Za-z]");
        public static PatternBase LetterOrDigit = new Verbatim("[A-Za-z0-9]");
        public static PatternBase NonLetterOrDigit = new Verbatim("[^A-Za-z0-9]");
    }
}
