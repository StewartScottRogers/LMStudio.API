 To create a .NET 9.0 solution for the described lexer and Abstract Syntax Tree (AST) generator, we need to follow the guidelines provided carefully. Below is a structured approach to achieve this:

### Step 1: Initialize a New Solution in Visual Studio
Create a new solution named "LexerSolution" using Visual Studio 2022. Add a Class Library project within this solution.

### Step 2: Define the Project Structure
Ensure each class, interface, enumeration, and record is in its own file as specified.

#### Example File Structure:
```
/LexerSolution
    /LexerProject
        /Tokens // Enumeration for tokens
        /AST // Abstract Syntax Tree classes
        /Parsing // Lexing and Parsing logic
        /Tests // Unit Tests
```

### Step 3: Develop the Code

#### Tokens Enum (in `Tokens.cs`):
Define token types using an enumeration.

```csharp
namespace LexerProject.Tokens
{
    public enum TokenType
    {
        Assignment,
        If,
        Then,
        End,
        Print,
        Identifier,
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        LParen,
        RParen,
        SemiColon,
        // Add other tokens here
    }
}
```

#### AST Classes (in `AST.cs`):
Define classes for the Abstract Syntax Tree nodes.

```csharp
namespace LexerProject.AST
{
    public abstract class Statement { }

    public class AssignStatement : Statement
    {
        public string Identifier { get; }
        public Expression Expression { get; }

        public AssignStatement(string identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
    }

    // Define other statement and expression classes similarly
}
```

#### Parsing Logic (in `Parser.cs`):
Implement the lexer and parser logic to generate the AST.

```csharp
using LexerProject.Tokens;
using System.Collections.Generic;

namespace LexerProject.Parsing
{
    public class Lexer
    {
        private readonly string _input;
        private int _position;
        private char _currentChar;

        public Lexer(string input)
        {
            _input = input;
            _position = 0;
            _currentChar = _input[_position];
        }

        private void Advance()
        {
            _position++;
            _currentChar = _position < _input.Length ? _input[_position] : '\0';
        }

        private char Peek()
        {
            int peekPosition = _position + 1;
            return peekPosition < _input.Length ? _input[peekPosition] : '\0';
        }

        public Token GetNextToken()
        {
            while (_currentChar != '\0')
            {
                if (char.IsWhiteSpace(_currentChar))
                {
                    Advance();
                    continue;
                }

                // Handle identifiers and numbers
                if (char.IsLetter(_currentChar))
                {
                    var identifier = "";
                    while (_currentChar != '\0' && (char.IsLetterOrDigit(_currentChar)))
                    {
                        identifier += _currentChar;
                        Advance();
                    }

                    return new Token(TokenType.Identifier, identifier);
                }

                if (char.IsDigit(_currentChar))
                {
                    var number = "";
                    while (_currentChar != '\0' && char.IsDigit(_currentChar))
                    {
                        number += _currentChar;
                        Advance();
                    }

                    return new Token(TokenType.Number, number);
                }

                // Handle individual characters
                switch (_currentChar)
                {
                    case ':':
                        if (Peek() == '=')
                        {
                            Advance();
                            Advance();
                            return new Token(TokenType.Assignment, ":=");
                        }
                        break;
                    case ';':
                        Advance();
                        return new Token(TokenType.SemiColon, ";");
                    // Handle other cases similarly
                }

                Advance();
            }

            return new Token(TokenType.EOF, null);
        }
    }
}
```

#### Unit Tests (in `Tests.cs`):
Write unit tests to ensure the lexer and parser logic works correctly.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerProject.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestBasicLexing()
        {
            var lexer = new Lexer("x := 10 + 5; print x;");
            var tokens = new List<Token>();

            while (true)
            {
                var token = lexer.GetNextToken();
                if (token.Type == TokenType.EOF) break;
                tokens.Add(token);
            }

            // Assert the tokens list against expected values
        }
    }
}
```

### Step 4: Documentation and README
Document the project in a `README.md` file, explaining the purpose, structure, and usage of the lexer and AST generator.

### Step 5: Testing and Iteration
Run unit tests to ensure everything works as expected. Refactor and iterate based on test results.

This approach ensures adherence to all specified guidelines and requirements for the project.