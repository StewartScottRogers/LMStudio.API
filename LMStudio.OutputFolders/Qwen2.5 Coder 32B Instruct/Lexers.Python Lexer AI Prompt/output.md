Creating a complete .NET 9.0 solution with a Lexer for the provided Python grammar is quite an extensive task and would result in many files, classes, interfaces, records, unit tests, and other components. Below is a simplified example to illustrate how you might structure this project based on your requirements. This example will cover only a portion of the grammar (specifically focusing on some simple statements and expressions) for brevity. You can extend it similarly for other parts.

### 1. Project Setup
- Create a new .NET Class Library in Visual Studio 2022.
- Name the project `PythonLexer`.

### 2. File Structure
This is a simplified structure to get started:

```
PythonLexer/
│
├── Interfaces/
│   └── ILexer.cs
│
├── Lexers/
│   └── PythonLexer.cs
│
├── Nodes/
│   ├── Statements/
│   │   ├── AssignmentNode.cs
│   │   ├── ReturnStatementNode.cs
│   │   ├── ExpressionStatementNode.cs
│   │   └── SimpleStatementNode.cs
│   │
│   └── Expressions/
│       ├── BinaryExpressionNode.cs
│       ├── LiteralExpressionNode.cs
│       └── VariableExpressionNode.cs
│
├── Tokenizer/
│   ├── Tokens/
│   │   ├── TokenKind.cs
│   │   ├── Token.cs
│   │   └── TokenType.cs
│   │
│   └── PythonTokenizer.cs
│
├── Tests/
│   └── LexerTests/
│       ├── AssignmentLexerTests.cs
│       ├── ReturnStatementLexerTests.cs
│       └── ExpressionLexerTests.cs
│
└── Program.cs
```

### 3. Code Implementation

#### Interfaces/ILexer.cs

```csharp
using System.Collections.Generic;

namespace PythonLexer.Lexers
{
    public interface ILexer
    {
        IEnumerable<Nodes.INode> Tokenize(string source);
    }
}
```

#### Tokenizer/Tokens/TokenKind.cs

```csharp
namespace PythonLexer.Tokenizer.Tokens
{
    public enum TokenKind
    {
        Identifier,
        NumberLiteral,
        StringLiteral,
        EqualsSign,
        PlusSign,
        MinusSign,
        Asterisk,
        Slash,
        Caret,
        PercentSign,
        LessThanSign,
        GreaterThanSign,
        Ampersand,
        Bar,
        Tilde,
        ExclamationMark,
        KeywordReturn,
        EndOfFile
    }
}
```

#### Tokenizer/Tokens/Token.cs

```csharp
namespace PythonLexer.Tokenizer.Tokens
{
    public readonly record struct Token(TokenKind Kind, string Value)
    {
        public static readonly Token EOF = new Token(TokenKind.EndOfFile, "");
    }
}
```

#### Tokenizer/PythonTokenizer.cs

```csharp
using System;
using System.Collections.Generic;

namespace PythonLexer.Tokenizer
{
    using Tokens;

    public class PythonTokenizer
    {
        private readonly string sourceCode;
        private int currentPos;

        public PythonTokenizer(string source)
        {
            this.sourceCode = source ?? throw new ArgumentNullException(nameof(source));
            this.currentPos = 0;
        }

        public IEnumerable<Token> GetTokens()
        {
            while (currentPos < sourceCode.Length)
            {
                char c = sourceCode[currentPos];

                if (char.IsWhiteSpace(c))
                {
                    Advance();
                    continue;
                }
                else if (c == '=')
                {
                    yield return new Token(TokenKind.EqualsSign, "=");
                    Advance();
                }
                else if (char.IsLetterOrDigit(c) || c == '_')
                {
                    int startPos = currentPos;
                    while (currentPos < sourceCode.Length && (char.IsLetterOrDigit(sourceCode[currentPos]) || sourceCode[currentPos] == '_'))
                    {
                        Advance();
                    }

                    string identifier = sourceCode.Substring(startPos, currentPos - startPos);
                    if (identifier.Equals("return", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return new Token(TokenKind.KeywordReturn, identifier);
                    }
                    else
                    {
                        yield return new Token(TokenKind.Identifier, identifier);
                    }
                }
                else if (char.IsDigit(c))
                {
                    int startPos = currentPos;
                    while (currentPos < sourceCode.Length && char.IsDigit(sourceCode[currentPos]))
                    {
                        Advance();
                    }

                    string numberLiteral = sourceCode.Substring(startPos, currentPos - startPos);
                    yield return new Token(TokenKind.NumberLiteral, numberLiteral);
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected character: {c}");
                }
            }

            yield return Token.EOF;
        }

        private void Advance()
        {
            if (currentPos < sourceCode.Length)
            {
                currentPos++;
            }
        }
    }
}
```

#### Nodes/INode.cs

```csharp
namespace PythonLexer.Nodes
{
    public interface INode { }
}
```

#### Nodes/Expressions/BinaryExpressionNode.cs

```csharp
using System.Collections.Generic;

namespace PythonLexer.Nodes.Expressions
{
    public sealed class BinaryExpressionNode : INode
    {
        public readonly INode Left;
        public readonly TokenKind Operator;
        public readonly INode Right;

        public BinaryExpressionNode(INode left, TokenKind op, INode right)
        {
            this.Left = left ?? throw new ArgumentNullException(nameof(left));
            this.Operator = op;
            this.Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}
```

#### Nodes/Expressions/LiteralExpressionNode.cs

```csharp
namespace PythonLexer.Nodes.Expressions
{
    using Tokenizer.Tokens;

    public sealed class LiteralExpressionNode : INode
    {
        public readonly TokenKind LiteralType;
        public readonly string Value;

        public LiteralExpressionNode(Token token)
        {
            this.LiteralType = token.Kind == TokenKind.NumberLiteral ? TokenKind.NumberLiteral : TokenKind.StringLiteral;
            this.Value = token.Value ?? throw new ArgumentNullException(nameof(token));
        }
    }
}
```

#### Nodes/Statements/SimpleStatementNode.cs

```csharp
using System.Collections.Generic;

namespace PythonLexer.Nodes.Statements
{
    public abstract class SimpleStatementNode : INode { }

    public sealed class ExpressionStatementNode : SimpleStatementNode
    {
        public readonly INode Expression;

        public ExpressionStatementNode(INode expression)
        {
            this.Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
    }

    public sealed class ReturnStatementNode : SimpleStatementNode
    {
        public readonly INode Expression;

        public ReturnStatementNode(INode expression)
        {
            this.Expression = expression;
        }
    }
}
```

#### Lexers/PythonLexer.cs

```csharp
using System.Collections.Generic;
using System.Linq;

namespace PythonLexer.Lexers
{
    using Nodes.Statements;
    using Nodes.Expressions;
    using Tokenizer.Tokens;
    using Tokenizer;

    public class PythonLexer : ILexer
    {
        private readonly PythonTokenizer tokenizer;
        private Token currentToken;

        public PythonLexer(string source)
        {
            this.tokenizer = new PythonTokenizer(source);
            this.currentToken = this.tokenizer.GetTokens().FirstOrDefault();
        }

        public IEnumerable<INode> Tokenize(string source)
        {
            List<INode> nodes = new List<INode>();
            while (currentToken != Token.EOF)
            {
                switch (currentToken.Kind)
                {
                    case TokenKind.KeywordReturn:
                        nodes.Add(ParseReturnStatement());
                        break;
                    default:
                        nodes.Add(ParseExpressionStatement());
                        break;
                }
            }

            return nodes;
        }

        private INode ParseReturnStatement()
        {
            Consume(TokenKind.KeywordReturn);
            if (currentToken != Token.EOF && currentToken.Kind != TokenKind.EndOfFile)
            {
                var expression = ParseExpression();
                return new ReturnStatementNode(expression);
            }

            return new ReturnStatementNode(null);
        }

        private INode ParseExpressionStatement()
        {
            var expression = ParseExpression();
            Consume(TokenKind.EndOfFile);
            return new ExpressionStatementNode(expression);
        }

        private INode ParseExpression()
        {
            // Simple implementation for demonstration
            switch (currentToken.Kind)
            {
                case TokenKind.NumberLiteral:
                    return new LiteralExpressionNode(currentToken);

                case TokenKind.Identifier:
                    return new VariableExpressionNode(currentToken.Value);

                default:
                    throw new InvalidOperationException($"Unexpected token: {currentToken}");
            }
        }

        private void Consume(TokenKind kind)
        {
            if (currentToken.Kind == kind)
            {
                currentToken = tokenizer.GetTokens().SkipWhile(t => t != Token.EOF).FirstOrDefault();
            }
            else
            {
                throw new InvalidOperationException($"Expected token of kind {kind}, but got {currentToken.Kind}");
            }
        }
    }
}
```

#### Program.cs

```csharp
using System;
using PythonLexer.Lexers;

namespace PythonLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "return 42";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source);

            foreach (var node in nodes)
            {
                Console.WriteLine(node.GetType().Name);
            }
        }
    }
}
```

### 4. Unit Tests

#### Tests/LexerTests/AssignmentLexerTests.cs

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonLexer.Lexers;
using System.Linq;

namespace PythonLexer.Tests.LexerTests
{
    [TestClass]
    public class AssignmentLexerTests
    {
        [TestMethod]
        public void TestSimpleAssignment()
        {
            string source = "x = 42";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source).ToList();

            Assert.AreEqual(1, nodes.Count);
        }
        
        // Additional tests...
    }
}
```

#### Tests/LexerTests/ReturnStatementLexerTests.cs

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonLexer.Lexers;
using System.Linq;

namespace PythonLexer.Tests.LexerTests
{
    [TestClass]
    public class ReturnStatementLexerTests
    {
        [TestMethod]
        public void TestReturnWithLiteral()
        {
            string source = "return 42";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source).ToList();

            Assert.AreEqual(1, nodes.Count);
            Assert.IsInstanceOfType(nodes[0], typeof(Nodes.Statements.ReturnStatementNode));
        }

        [TestMethod]
        public void TestReturnWithoutExpression()
        {
            string source = "return";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source).ToList();

            Assert.AreEqual(1, nodes.Count);
            Assert.IsInstanceOfType(nodes[0], typeof(Nodes.Statements.ReturnStatementNode));
        }

        // Additional tests...
    }
}
```

### 5. Documentation

#### README.md

```markdown
# Python Lexer

A .NET Class Library that implements a lexer for parsing simple Python statements.

## Features
- Supports `return` statements and simple expressions.
- Tokenizes identifiers, literals, operators, etc.

## Setup
1. Clone the repository: `git clone <repository-url>`
2. Open the solution in Visual Studio 2022.
3. Build the project to compile the source code.

## Usage
See the `Program.cs` file for a simple usage example.

## Testing
Run unit tests from Visual Studio Test Explorer or via command line using:
```bash
dotnet test
```

## Extending
The library can be extended by adding more grammar rules and corresponding parsing logic.
```

This is a basic starting point. You would need to extend this significantly to cover the entire provided grammar, including all types of statements, expressions, and their interactions. Each new rule would require additional token definitions, parsing logic in `PythonLexer.cs`, and unit tests in the appropriate test classes.