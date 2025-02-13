using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private readonly char[] tokens;

        public Lexer(string input)
        {
            this.input = input;
            this.tokens = input.ToCharArray();
            this.position = 0;
        }

        public TokenTuple Lex()
        {
            while (position < tokens.Length && Char.IsWhiteSpace(tokens[position]))
            {
                position++;
            }

            if (position >= tokens.Length)
            {
                return new TokenTuple(null, TokenType.END);
            }

            char currentChar = tokens[position];

            switch (currentChar)
            {
                case '=':
                    return new TokenTuple("=", TokenType.ASSIGN);

                // Add cases for other characters and keywords as needed
                default:
                    throw new InvalidOperationException($"Unexpected character: {currentCharacter}");
            }
        }

        public void Lex(string inputText)
        {
            var lexerResult = Lex(inputText);
            foreach (var token in lexerResult.Tokens)
            {
                Console.WriteLine(token);
            }
        }

    }
}

namespace YourNamespace.Ast
{
    public interface INode { }

    public class StatementListNode : INode
    {
        public readonly List<INode> Statements;

        public StatementListNode(List<INode> statements)
        {
            Statements = statements;
        }
    }

    // Define other nodes here...
    // For brevity, only a few nodes are defined. You need to define all nodes as per the grammar.
    public record Assignment(Expression LeftHandSide, Expression RightHandSide);

    public enum AugAssign
    {
        PlusEquals,
        MinusEquals,
        MultiplyEquals,
        AtEquals,
        DivideEquals,
        ModuloEquals,
        AndEquals,
        OrEquals,
        XorEquals,
        LeftShiftEquals,
        RightShiftEquals,
        PowerEquals,
        FloorDivideEquals
You want to create a .NET 9.0 solution in Visual Studio 2022 that includes a class library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and providing a pretty printer for the AST. Additionally, you need to write unit tests using Microsoft's Unit Test Framework. Below is a step-by-step guide to create this solution.

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new .NET Core Class Library project.
3. Name the project `LexerLibrary`.
4. Ensure the target framework is set to `.NET 9.0`.

Below is the structured code for the Lexer, Abstract Syntax Tree (AST) Pretty Printer, AST Nodes, and Unit Tests based on the provided grammar.

### Solution Structure