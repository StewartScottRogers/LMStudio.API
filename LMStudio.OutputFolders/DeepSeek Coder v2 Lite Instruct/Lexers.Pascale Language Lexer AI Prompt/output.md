 To create a Lexer for the Pascal language as described in your prompt, we need to follow a structured approach. Below is a high-level plan and some initial code snippets to get started with this project. This will be a C# class library that can be used in Visual Studio 2022 targeting .NET 9.0.

### Project Structure
1. **Lexer**: Contains the core lexer logic.
2. **AST**: Contains classes for Abstract Syntax Tree (AST) nodes.
3. **ASTPrinter**: Contains a pretty printer for AST nodes.
4. **Tests**: Unit tests for testing the lexer and AST functionalities.

### Initial Code Snippets
Let's start with defining some basic structures that will be used across the project:

#### 1. Lexer Namespace
This namespace will contain the core lexer logic, including token types and the actual lexing function.

```csharp
namespace Lexer
{
    public enum TokenType
    {
        // Keywords
        Program, Const, Type, Var, Procedure, Function, Begin, End, If, Then, Else, While, Do, Repeat, For, To, Downto, Case, Of, With, Goto, Not, And, Or, Div, Mod, In, Array, Record, Set, File, Of, Nil
        
        // Identifiers and literals
        Identifier, Number, StringLiteral, BooleanLiteral
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
```

#### 2. Lexer Implementation
Here's a basic lexing function that reads from a character stream and produces tokens:

```csharp
using System.Collections.Generic;
using System.Text;

namespace Lexer
{
    public class Lexer
    {
        private readonly string _text;
        private int _position;

        public Lexer(string text)
        {
            _text = text;
            _position = 0;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (_position < _text.Length)
            {
                char currentChar = _text[_position];
                if (char.IsLetter(currentChar))
                {
                    tokens.Add(NextTokenForIdentifierOrKeyword());
                }
                else if (char.IsDigit(currentChar))
                {
                    tokens.Add(NextTokenForNumber());
                }
                else if (currentChar == '\'')
                {
                    tokens.Add(NextTokenForStringLiteral());
                }
                // Add handling for other token types...

                _position++;
            }

            return tokens;
        }

        private Token NextTokenForIdentifierOrKeyword()
        {
            var sb = new StringBuilder();
            while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_'))
            {
                sb.Append(_text[_position]);
                _position++;
            }

            string identifierStr = sb.ToString();
            TokenType type;
            if (!TokenTypeMap.TryGetValue(identifierStr, out type))
            {
                type = TokenType.Identifier;
            }

            return new Token(type, identifierStr);
        }

        private Token NextTokenForNumber()
        {
            var sb = new StringBuilder();
            while (_position < _text.Length && char.IsDigit(_text[_position]))
            {
                sb.Append(_text[_position]);
                _position++;
            }

            if (_position < _text.Length && _text[_position] == '.')
            {
                sb.Append('.');
                _position++;
                while (_position < _text.Length && char.IsDigit(_text[_position]))
                {
                    sb.Append(_text[_position]);
                    _position++;
                }
            }

            return new Token(TokenType.Number, sb.ToString());
        }

        private Token NextTokenForStringLiteral()
        {
            var sb = new StringBuilder();
            _position++; // Skip the opening quote
            while (_position < _text.Length && _text[_position] != '\'')
            {
                sb.Append(_text[_position]);
                _position++;
            }
            _position++; // Skip the closing quote

            return new Token(TokenType.StringLiteral, sb.ToString());
        }

        private static readonly Dictionary<string, TokenType> TokenTypeMap = new Dictionary<string, TokenType>
        {
            {"program", TokenType.Program},
            {"const", TokenType.Const},
            // Add other keywords...
        };
    }
}
```

This setup provides a basic lexer that can tokenize Pascal-like syntax. Further steps involve expanding the lexing function to handle all specified grammar rules and refining the AST structure and pretty printer as described in your project requirements.