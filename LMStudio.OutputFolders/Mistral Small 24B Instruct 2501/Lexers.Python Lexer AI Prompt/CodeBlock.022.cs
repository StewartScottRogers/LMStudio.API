using System;

namespace LexerLibrary
{
    public enum TokenType
    {
        Newline,
        Indent,
        Dedent,
        Endmarker,
        Name,
        String,
        Number,
        // Add other token types as needed based on the grammar
    }
}