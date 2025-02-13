using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LexerLibrary
{
    public class Token
    {
        public string Type { get; }
        public string Value { get; }

        public Token(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"({Type}, {Value})";
    }

    public static class TokenType
    {
        public const string Name = "Name";
        public const string Number = "Number";
        public const string StringLiteral = "StringLiteral";
        public const string Newline = "Newline";
        public const string Indent = "Indent";
        public const string Dedent = "Dedent";
        public const string Endmarker = "Endmarker";
        public readonly string AssignmentToken = ":=";
        public readonly string AugAssignTokens = "+=-*/@%&|=^<<=>>=**=//=";
        public readonly string ComparisonOperators = "==!=<<=>=>innot inis is not";
        public readonly string BitwiseOperators = "|^&<<>>";
        public readonly string ArithmeticOperators = "+-*~/**/@%";
        public readonly string AssignmentOperators = AugAssignTokens.Split(' ');
        private List<string> AugAssignTokens = new List<string>()
        {
            "+=", "-=","*=","@=","/=","%=","&=","|=","^=",
            "<<=",">>=","**=","//="
        };
Here is the solution for the given requirements. This includes a class library to lexer the provided grammar, generate an Abstract Syntax Tree (AST), and pretty-print the AST. Additionally, I have included 25 unit tests for lexing the Abstract Syntax Tree.

### Solution Structure

1. **Lexer Class**: Responsible for tokenizing the input code.
2. **AstNode Classes**: Represent different nodes in the AST.
3. **AstPrettyPrinter Class**: Pretty prints the AST.
4. **Unit Tests**: Ensure the correctness of the lexing and AST generation process.

Here is a complete .NET 9.0 Solution following the provided specifications:

### File Structure