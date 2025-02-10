using System;
using System.Collections.Generic;
using System.Linq;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string Input;
        private int Position;

        public Lexer(string input)
        {
            Input = input;
            Position = 0;
        }

        public Token GetNextToken()
        {
            while (Position < Input.Length && char.IsWhiteSpace(Input[Position]))
            {
                Position++;
            }

            if (Position >= Input.Length)
            {
                return new Token(TokenType.EndOfFile, "");
            }

            var currentChar = Input[Position];
            switch (currentChar)
            {
                case '(':
                    return new Token(TokenType.LeftParenthesis, currentChar.ToString());
                case ')':
                    return new Token(TokenType.RightParenthesis, currentChar.ToString());
                case '{':
                    return new Token(TokenType.LeftBrace, currentChar.ToString());
                case '}':
                    return new Token(TokenType.RightBrace, currentChar.ToString());
                case '[':
                    return new Token(TokenType.LeftBracket, currentChar.ToString());
                case ']':
                    return new Token(TokenType.RightBracket, completeTokens);
                case '.':
                    return new Token(TokenType.Period, completeTokens);
                case '+':
                    return new Token(TokenType.Plus, completeTokens);
                case '-':
                    return new Token(TokenType.Minus, completeTokens);
                case '*':
                    return new Token(TokenType.Asterisk, completeTokens);
                case '/':
                    return new Token(TokenType.Slash, completeTokens);
                case '@':
                    return new Token(TokenType.ATSign, completeTokens);
                case '%':
                    return new Token(Token.TokenType.Modulus, completeTokens);
                case '&':
                    return new Token(Token.TokenType.Ampersand, completeTokens);
                case '|':
                    return new Token(Token.TokenType.Pipe, completeTokens);
                case '^':
                    return new Token(Token.TokenType.Caret, completeTokens);
                case '+=':
                    return new Token(Token.TokenType.PlusEquals, "+=");
                case '-=':
                    return new Token(Token.TokenType.MinusEquals, "-=");
                case '*=':
                    return new Token(Token.TokenType.MultiplyEquals, "*=");
                case '@=':
                    return new Token(Token.TokenType.AtEquals, "@=");
                case '/=':
                    return new Token(Token.TokenType.DivideEquals, "/=");
                case '%=':
                    return new Token(Token.TokenType.ModulusEquals, "%=");
                case '&=':
                    return new Token(Token.TokenType.AndEquals, "&=");
                case '|=':
                    return new Token(Token.TokenType.OrEquals, "|=");
                case '^=':
                    return new Token(TokenTokenType.XorEquals, "^=");
                case '<<=':
                    return new Token(TokenTokenType.LeftShiftEquals, "<<=");
                case '>>=':
                    return new Token(TokenTokenType.RightShiftEquals, ">>=");
                case '**=':
                    return new Token(TokenTokenType.PowerEquals, "**=");

# Solution Structure

The solution will consist of the following projects and files:

1. **LexerLibrary**
   - **Interfaces**
     - ILexer.cs
     - INode.cs
   - **Enumerations**
     - TokenKindEnum.cs
   - **Records**
     - LexerResultTuple.cs
   - **Classes**
     - Lexer.cs
     - AbstractSyntaxTreePrettyPrinter.cs
     - Node.cs (Abstract)
     - StatementNode.cs
     - CompoundStmtNode.cs
     - SimpleStmtsNode.cs
     - AssignmentNode.cs
     - ExpressionNode.cs
     - FunctionDefNode.cs
     - IfStmtNode.cs
     - ClassDefNode.cs
     - WithStmtNode.cs
     - ForStmtNode.cs
     | TryStmtNode.cs
     | WhileStmtNode.cs
     | MatchStmtNode.cs

Let's break down the steps to create a .NET 9.0 solution for lexing the given grammar, generating an Abstract Syntax Tree (AST), and implementing a Pretty Printer for the AST.

### Step 1: Initialize a New Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new solution.
3. Add a new Class Library project to the solution.
4. Name the project `PythonLexer`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as follows:

- **AstNode.cs**
- **AstNodeVisitor.cs**
- **CompoundStmtNode.cs**
- **DelStatementNode.cs**
- **ExpressionStatementNode.cs**
- **ImportStatementNode.cs**
- **Lexer.cs**
- **PrettyPrinter.cs**
- **ReturnStatementNode.cs**
- **SimpleStatementNode.cs**
- **SyntaxTreeNodeInterface.cs**

### Solution Steps

1. **Initialize a new .NET 9.0 Solution in Visual Studio.**
2. **Create the necessary files for each class, interface, enumeration, and record.**
3. **Implement the Lexer for the Abstract Syntax Tree (AST).**
4. **Generate the AST Pretty Printer.**
5. **Develop unit tests using Microsoft's Unit Test Framework.**

### Solution Structure

1. **Project Name**: `PythonLexer`
2. **Solution Files**:
   - `PythonLexer.sln` (Solution File)
3. **Project Files**:
   - `PythonLexer.csproj` (Class Library Project File)

4. **File System Structure**: