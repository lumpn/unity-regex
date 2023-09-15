//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Text.RegularExpressions;

namespace Lumpn.RegularExpressions
{
    public sealed class Literal : Pattern
    {
        private readonly string literal;

        public Literal(string literal)
        {
            this.literal = Regex.Escape(literal);
        }

        public override string ToString()
        {
            return literal;
        }
    }
}
