using System.Collections.Generic;

namespace LexerLibrary
{
    public interface ILexer<TToken>
    {
        IEnumerable<TToken> Tokenize(string input);
    }
}