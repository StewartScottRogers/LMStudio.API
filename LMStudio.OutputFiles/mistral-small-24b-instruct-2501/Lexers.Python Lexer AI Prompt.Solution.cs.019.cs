using System;
using System.Collections.Generic;

public class AstNode
{
    public readonly string NodeName;
    private readonly List<AstNode> Children = new();

    public AstNode(string nodeName)
    {
        NodeName = nodeName;
    }

    public void AddChild(AstNode child)
    {
        Children.Add(child);
    }

    public IEnumerable<AstNode> GetChildren()
    {
        return Children;
    }
}

public class Lexer
{
    private readonly string sourceCode;

    public Lexer(string sourceCode)
    {
        this.sourceCode = sourceCode;
    }

    public IEnumerable<TokensTuple> Tokenize()
    {
        var tokens = new List<Token>();
        int position = 0;

        while (position < source.Length)
        {
            if (char.IsWhiteSpace(source[position]))
            {
                position++;
                continue;
            }

            if (char.IsLetterOrDigit(source[position]) || source[position] == '_')
            {
                var wordBuilder = new StringBuilder();
                while (position < source.Length && (char.IsLetterOrDigit(source[position]) || source[position] == '_'))
                {
                    wordBuilder.Append(source[position]);
                    position++;
                }
                yield return wordBuilder.ToString();
            }
            else
            {
                throw new Exception("Unexpected character encountered.");
            }
        }

        private static IEnumerable<Token> Tokenize(string input)
        {
            int position = 0;
            while (position < input.Length)
            {
                if (char.IsWhiteSpace(input[position]))
                {
                    position++;
                    continue;
                }

                if (char.IsLetterOrDigit(input[position]) || input[position] == '_')
                {
                    var word = new StringBuilder();
                    while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
                    {
                        word.Append(input[position++]);
                    }
                    // Handle the token based on the identified word
                }

To create a .NET 9.0 Solution in C# that includes a Lexer for the given grammar, an Abstract Syntax Tree (AST) Pretty Printer, and all nodes in the AST, we need to follow these steps:

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new project.
3. Select "Class Library" template.
4. Name the solution `LexerSolution` and the project `LexerLibrary`.
5. Ensure the target framework is .NET 9.0.

### File Structure