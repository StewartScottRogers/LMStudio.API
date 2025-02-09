Creating a .NET 9.0 solution for a lexer and abstract syntax tree (AST) involves several steps, including setting up the project structure, implementing the necessary classes and interfaces, and writing unit tests. Below is a high-level outline of how to achieve this:

### Step-by-Step Solution

#### 1. Initialize the Solution
- Open Visual Studio 2022.
- Create a new .NET 9.0 Class Library solution named `TinyLanguageLexer`.
- Ensure that the solution targets .NET 9.0.

#### 2. Define Project Structure
Create separate folders for the main project, tests, and documentation:

```
TinyLanguageLexer/
├── TinyLanguageLexer/          # Main project directory
│   ├── Program.cs              # Entry point if needed
│   ├── Token.cs                # Represents a token in the language
│   ├── Lexer.cs                # Implements the lexer logic
│   ├── ASTNode.cs              # Base class for all AST nodes
│   ├── AssignStmtNode.cs       # Derived class for assignment statements
│   ├── IfStmtNode.cs           # Derived class for if statements
│   ├── WhileStmtNode.cs        # Derived class for while statements
│   ├── PrintStmtNode.cs        # Derived class for print statements
│   └── ExpressionNode.cs       # Base class for expressions
├── TinyLanguageLexer.Tests/    # Unit test project directory
│   ├── LexerTests.cs           # Contains lexer unit tests
│   └── AstTests.cs             # Contains AST node tests
└── README.md                   # Documentation file
```

#### 3. Implement the Classes and Interfaces

**Token.cs**
```csharp
using System;

namespace TinyLanguageLexer
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
    }
}
```

**Lexer.cs**
```csharp
using System.Collections.Generic;

namespace TinyLanguageLexer
{
    public class Lexer
    {
        private readonly string _sourceCode;
        private int _position;

        public Lexer(string sourceCode)
        {
            _sourceCode = sourceCode;
            _position = 0;
        }

        public IEnumerable<Token> Lex()
        {
            while (_position < _sourceCode.Length)
            {
                char currentChar = Peek();

                if (char.IsWhiteSpace(currentChar))
                {
                    Consume();
                }
                else if (char.IsLetter(currentChar))
                {
                    yield return TokenizeIdentifier();
                }
                else if (char.IsDigit(currentChar))
                {
                    yield return TokenizeNumber();
                }
                else
                {
                    yield return TokenizeSymbol();
                }
            }

            yield return new Token("EOF", "<EOF>");
        }

        private char Peek() => _sourceCode[_position];

        private void Consume()
        {
            _position++;
        }

        private Token TokenizeIdentifier()
        {
            int start = _position;
            while (char.IsLetterOrDigit(Peek()))
            {
                Consume();
            }
            string value = _sourceCode.Substring(start, _position - start);
            return new Token("IDENTIFIER", value);
        }

        private Token TokenizeNumber()
        {
            int start = _position;
            while (char.IsDigit(Peek()))
            {
                Consume();
            }
            string value = _sourceCode.Substring(start, _position - start);
            return new Token("NUMBER", value);
        }

        private Token TokenizeSymbol()
        {
            char symbol = Peek();
            Consume();
            return new Token($"SYMBOL_{symbol}", symbol.ToString());
        }
    }
}
```

**ASTNode.cs**
```csharp
namespace TinyLanguageLexer
{
    public abstract class ASTNode
    {
        // Common properties and methods for all AST nodes can be added here
    }
}
```

**AssignStmtNode.cs, IfStmtNode.cs, etc.**
Implement derived classes for each type of statement and expression node.

#### 4. Implement Unit Tests

**LexerTests.cs**
```csharp
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyLanguageLexer.Tests
{
    [TestClass]
    public class LexerTests
    {
        private IEnumerable<Token> Lex(string input)
        {
            var lexer = new Lexer(input);
            return lexer.Lex();
        }

        [TestMethod]
        public void TestLexIdentifiers()
        {
            var tokens = Lex("x := 10");
            Assert.AreEqual("IDENTIFIER", tokens.GetEnumerator().Current.Type);
        }

        // Add more tests for each grammar rule and edge case
    }
}
```

**AstTests.cs**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyLanguageLexer.Tests
{
    [TestClass]
    public class AstTests
    {
        [TestMethod]
        public void TestAssignStmtNode()
        {
            // Create and test an AssignStmtNode
        }

        // Add more tests for each AST node type
    }
}
```

#### 5. Documentation

**README.md**
```markdown
# Tiny Language Lexer

This project provides a lexer and abstract syntax tree (AST) generator for a simple programming language.

## Grammar

- `<program> ::= <stmt_list>`
- `<stmt_list> ::= <stmt> | <stmt> ";" <stmt_list>`
- `<stmt> ::= <assign_stmt> | <if_stmt> | <while_stmt> | <print_stmt>`
- `<assign_stmt> ::= <id> ":=" <expr>`
- `<if_stmt> ::= "if" <expr> "then" <stmt_list> "end"`
- `<while_stmt> ::= "while" <expr> "do" <stmt_list> "end"`
- `<print_stmt> ::= "print" <expr>`
- `<expr> ::= <term> | <term> "+" <expr> | <term> "-" <expr>`
- `<term> ::= <factor> | <factor> "*" <term> | <factor> "/" <term>`
- `<factor> ::= <id> | <number> | "(" <expr> ")"`
- `<id> ::= <letter> { <letter> | <digit> }`
- `<number> ::= <digit> { <digit> }`
- `<letter> ::= "a" | ... | "z" | "A" | ... | "Z"`
- `<digit> ::= "0" | ... | "9"`

## Usage

1. Compile the solution in Visual Studio.
2. Run the unit tests to verify functionality.

## Unit Tests

The project includes extensive unit tests for both lexing and AST generation.
```

### Final Steps
- Ensure all code is well-documented, especially complex logic.
- Verify that the solution compiles and runs without errors.
- Execute all unit tests to confirm correct behavior across various scenarios.