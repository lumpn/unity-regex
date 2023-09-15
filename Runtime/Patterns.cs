//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public static class Patterns
    {
        public static Pattern Digit = new Verbatim("\\d");
        public static Pattern NonDigit = new Verbatim("\\D");

        public static Pattern Whitespace = new Verbatim("\\s");
        public static Pattern NonWhitespace = new Verbatim("\\S");

        public static Pattern Word = new Verbatim("\\w");
        public static Pattern NonWord = new Verbatim("\\W");

        public static Pattern AnyCharacter = new Verbatim(".");
        public static Pattern Space = new Verbatim(" ");
        public static Pattern Tab = new Verbatim("\t");
        public static Pattern Dash = new Verbatim("-");
        public static Pattern Slash = new Verbatim("/");
        public static Pattern Backslash = new Verbatim("\\");
        public static Pattern CarriageReturn = new Verbatim("\r");
        public static Pattern NewLine = new Verbatim("\n");
        public static Pattern Plus = new Verbatim("\\+");
        public static Pattern Dot = new Verbatim("\\.");

        public static Pattern UppercaseLetter = new Verbatim("[A-Z]");
        public static Pattern LowercaseLetter = new Verbatim("[a-z]");
        public static Pattern Letter = new Verbatim("[A-Za-z]");
        public static Pattern NonLetter = new Verbatim("[^A-Za-z]");
        public static Pattern LetterOrDigit = new Verbatim("[A-Za-z0-9]");
        public static Pattern NonLetterOrDigit = new Verbatim("[^A-Za-z0-9]");
    }
}
