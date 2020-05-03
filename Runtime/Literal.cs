//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.RegularExpressions
{
    public sealed class Literal : Pattern
    {
        private readonly string literal;

        public Literal(string literal)
        {
            this.literal = literal;
        }

        public override string ToString()
        {
            return literal;
        }
    }
}
