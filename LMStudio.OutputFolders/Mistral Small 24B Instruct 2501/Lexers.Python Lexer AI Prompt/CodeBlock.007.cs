using System;
namespace LexerLibrary
{
    public interface ILexer
    {
        void Tokenize(string input);
    }
}