using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public enum TokenType
    {
        // Add all token types here based on the grammar provided
        Identifier,
        Number,
        String,
        Newline,
        EndMarker,
        // ... other token types
    }

    public record LexerTokenTuple
    (
        readonly int LineNumber,
        readonly int CharacterPosition,
        readonly string TokenText,
        readonly LexerTokenType TokenType
    );
}

public enum LexerTokenType
{
    Identifier,
    Keyword,
    Operator,
    Punctuation,
    Literal,
    NewLine,
    EndMarker,
    Whitespace,
    Invalid
}

public interface ILexer
{
    IEnumerable<LexerTuple> Lex(string input);
}
public class Tokenizer:ILexer
{
    public Tokenizer() {}

    private static readonly Regex WhitespaceRegex = new Regex(@"\s+", RegexOptions.Compiled);

    // This method will tokenize the input string and return a list of tokens.
    public List<Token> Tokenize(string input)
    {
        var tokens = new List<Token>();

        int position = 0;
        while (position < input.Length)
        {
            char currentChar = input[position];

            if (char.IsWhiteSpace(currentChar))
            {
                position++;
                continue;
            }

            // Check for keywords and other tokens
            if (TryMatchKeywordOrToken(ref position, ref input, out var token))
            {
                // Add the matched token to the lexer result
                yield return token;
            }
            else
            {
                throw new Exception($"Unexpected character at position {position}");
            }
        }

        private static bool IsWhitespace(char c)
        {
            return char.IsWhiteSpace(c);
        }

        private static bool IsLetter(char c)
        {
            return char.IsLetter(c) || c == '_';
        }

        private static bool IsDigit(char c)
        {
            return char.IsDigit(c);
        }

        private static bool IsNameChar(char c)
        {
            return IsDigit(c) || IsNameChar(c) || c == '_' || c == '?';
        }

        public class Lexer
        {
            private readonly string Input;
            private int Position;

            public Lexer(string input)
            {
                this.Input = input;
                this.Position = 0;
            }

            public Token GetNextToken()
            {
                while (this.Position < this.Input.Length && char.IsWhiteSpace(this.Input[this.Position]))
                {
                    this.Position++;
                }

                if (this.Position >= this.Input.Length)
                {
                    return new EndMarker();
                }

                char currentChar = this.Input[this.Position];

                if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    return new IdentifierToken(this, currentChar);
                }
                else if (char.IsDigit(currentChar))
                {
                    return new NumberToken(this, currentChar);
                }
                else
                {
                    // Handle other tokens like operators, delimiters, etc.
                    return new Token(this, currentChar);
                }
            }

            private readonly List<string> tokenPatterns = new() { "[a-zA-Z_][a-zA-Z0-9_]*", "\\+", "-", "\\*", "/", "//", "==", ">=", "<="};

To create a complete .NET 9.0 Solution for the given Lexer and Abstract Syntax Tree (AST) requirements, we'll follow these steps:

1. **Initialize a new Solution in Visual Studio**:
   - Create a new Class Library project.
   - Add necessary files for classes, interfaces, enumerations, and records.

2. **Define the Project Structure**:
   - Ensure each class, interface, enumeration, and record is in its own file.

3. **Implement the Lexer**:
   - Create a lexer to tokenize the given grammar.
   - Generate an Abstract Syntax Tree (AST) from the tokens.
   - Implement a pretty printer for the AST.

4. Write Unit Tests:
    - Ensure that the lexer and AST generation are functioning correctly by writing comprehensive unit tests using Microsoft's Unit Test Framework.

To achieve this, we'll follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record as per the provided coding style guidelines.**
3. **Implement the Lexer, AST nodes, and Pretty Printer.**
4. **Write unit tests using Microsoft's Unit Test Framework.**

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new .NET 9.0 Class Library project.
3. Name the solution `PythonLexer`.

### Project Structure

The project structure will be as follows: