# File: AstNodes/KeywordPatternAstNode.cs

using System;

namespace LexerApp.AstNodes
{
    public class KeywordPatternAstNode
    {
        public string Name { get; }
        public object Pattern { get; }

        public KeywordPatternAstNode(string name, object pattern)
        {
            Name = name;
            Pattern = pattern;
        }
    }
}

To create a complete .NET 9.0 Solution for the Lexer based on the provided grammar, we need to follow the steps outlined in your prompt. Below is an example of how you can structure the solution, including the necessary classes, interfaces, enumerations, and records.

### File System Structure