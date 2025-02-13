Sure, let's break down the solution into steps and create a .NET 9.0 Solution as per your requirements.

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new Class Library project.
3. Name the project `LexerLibrary`.
4. Ensure the target framework is .NET 9.0.

### Step 2: Define the Project Structure

We will create separate files for each class, interface, enumeration, and record. Here's the structure:

```
LexerLibrary
│
├── Lexer.cs
├── ASTNode.cs
├── AbstractSyntaxTree.cs
├── PrettyPrinter.cs
└── Token.cs
```

### Step 3: Implement the Classes

#### Lexer.cs

```csharp
using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;

        public Lexer(string input)
        {
            this.input = input;
        }

        public var TokenStreamTuple GenerateTokenStream()
        {
            var tokenList = new List<Token>();

            while (position < input.Length)
            {
                char currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                }
                else if (char.IsLetter(currentChar))
                {
                    tokenList.Add(GenerateId());
                }
                else if (char.IsDigit(currentChar))
                {
                    tokenList.Add(GenerateNumber());
                }
                else
                {
                    tokenList.Add(GenerateSpecialToken());
                }
            }

            return new var { Tokens = tokenList };
        }

        private Token GenerateId()
        {
            int startPos = position;
            while (position < input.Length && (char.IsLetterOrDigit(input[position])))
            {
                position++;
            }

            string idValue = input.Substring(startPos, position - startPos);
            return new Token(TokenType.Identifier, idValue);
        }

        private Token GenerateNumber()
        {
            int startPos = position;
            while (position < input.Length && char.IsDigit(input[position]))
            {
                position++;
            }

            string numberValue = input.Substring(startPos, position - startPos);
            return new Token(TokenType.Number, numberValue);
        }

        private Token GenerateSpecialToken()
        {
            int startPos = position;
            switch (input[position])
            {
                case '+':
                    position++;
                    return new Token(TokenType.Plus, "+");
                case '-':
                    position++;
                    return new Token(TokenType.Minus, "-");
                case '*':
                    position++;
                    return new Token(TokenType.Multiply, "*");
                case '/':
                    position++;
                    return new Token(TokenType.Divide, "/");
                case '(':
                    position++;
                    return new Token(TokenType.LParen, "(");
                case ')':
                    position++;
                    return new Token(TokenType.RParen, ")");
                case ':':
                case '=':
                    if (input[position] == ':' && input[position + 1] == '=')
                    {
                        position += 2;
                        return new Token(TokenType.Assign, ":=");
                    }
                    break;
                case ';':
                    position++;
                    return new Token(TokenType.Semicolon, ";");
            }

            throw new InvalidOperationException("Unknown character: " + input[position]);
        }
    }
}
```

#### ASTNode.cs

```csharp
namespace LexerLibrary
{
    public abstract class AstNode
    {
        // Base class for all AST nodes
    }

    public class ProgramNode : AstNode
    {
        public readonly var StatementListTuple StatementList;

        public ProgramNode(var statementList)
        {
            this.StatementList = statementList;
        }
    }

    public class StatementNode : AstNode
    {
        // Base class for all statements
    }

    public class AssignStatementNode : StatementNode
    {
        public readonly string Identifier;
        public readonly ExpressionNode Expression;

        public AssignStatementNode(string identifier, ExpressionNode expression)
        {
            this.Identifier = identifier;
            this.Expression = expression;
        }
    }

    // Define other AST nodes similarly...
}
```

#### Token.cs

```csharp
namespace LexerLibrary
{
    public enum TokenType
    {
        Identifier,
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        LParen,
        RParen,
        Assign,
        Semicolon,
        If,
        Then,
        End,
        While,
        Do,
        Print
    }

    public class Token
    {
        public readonly TokenType Type;
        public readonly string Value;

        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
```

#### AbstractSyntaxTree.cs

```csharp
using System.Collections.Generic;

namespace LexerLibrary
{
    public class AbstractSyntaxTree
    {
        public readonly ProgramNode Root;

        public AbstractSyntaxTree(var tokenStream)
        {
            // Parse the token stream and build the AST
            this.Root = new ProgramNode(ParseStatementList(tokenStream.Tokens));
        }

        private var StatementListTuple ParseStatementList(IEnumerable<Token> tokens)
        {
            // Implement statement list parsing logic
        }
    }
}
```

#### PrettyPrinter.cs

```csharp
namespace LexerLibrary
{
    public class PrettyPrinter
    {
        public string Print(AstNode node)
        {
            if (node is ProgramNode programNode)
            {
                return PrintProgram(programNode);
            }

            throw new InvalidOperationException("Unknown AST node type");
        }

        private string PrintProgram(ProgramNode node)
        {
            // Implement program printing logic
        }
    }
}
```

### Step 4: Unit Testing

Create a new Test Project in the solution and add unit tests for lexing.

#### LexerTests.cs

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LexerLibrary.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestLexer()
        {
            var input = "x := 42 + y;";
            var lexer = new Lexer(input);
            var tokenStream = lexer.GenerateTokenStream();

            Assert.AreEqual(6, tokenStream.Tokens.Count);

            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Identifier && t.Value == "x"));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Assign));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Number && t.Value == "42"));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Plus));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Identifier && t.Value == "y"));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Semicolon));
        }

        // Add more tests for different scenarios
    }
}
```

### Step 5: Documentation

Create a `README.md` file with project documentation.

```markdown
# Lexer Library

This library provides functionality to lex and parse a simple programming language grammar into an Abstract Syntax Tree (AST). It includes a pretty printer to visualize the AST and unit tests to ensure correctness.

## Project Structure

- **Lexer.cs**: Contains the lexing logic.
- **ASTNode.cs**: Defines the AST nodes.
- **Token.cs**: Defines tokens used in lexing.
- **AbstractSyntaxTree.cs**: Builds the AST from a token stream.
- **PrettyPrinter.cs**: Pretty prints the AST.

## Usage

1. Create an instance of `Lexer` with input code.
2. Generate token stream using `GenerateTokenStream`.
3. Parse the token stream to build an Abstract Syntax Tree.
4. Use `PrettyPrinter` to visualize the AST.

## Unit Tests

The project includes unit tests for lexing different statements and expressions.

## Authors
Your Name
```

### Step 6: Re-think and Refine

Ensure all steps are correct, refactor if necessary, and rethink the solution to make sure it meets the requirements comprehensively. This involves testing edge cases, optimizing performance, and ensuring code readability and maintainability.

This should give you a comprehensive start on creating a Lexer for the given grammar in a .NET 9.0 environment following your specified guidelines.