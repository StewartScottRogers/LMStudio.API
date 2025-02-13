using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;
        private readonly List<Token> tokens = new();

        public Lexer(string input)
        {
            this.input = input;
        }

        public IEnumerable<Token> Tokenize()
        {
            while (!IsAtEnd())
            {
                var start = Current;

                ScanToken();

                if (Current > 0 && tokens[^1].Type == TokenType.EndMarker)
                    break;
            }

            return new LexerResultTuple(tokens);
        }

        private void ScanToken()
        {

        }

        private char Peek()
        {
            if (IsAtEnd())
            {
                return '\0';
            }
            return sourceCode[nextPosition];
        }

        private bool IsAtEnd()
        {
            return nextPosition >= sourceCode.Length;
        }

        private void Advance()
        {
            nextPosition++;
        }

        private char Peek()
        {
            if (IsAtEnd())
                return '\0';
            return sourceCode[nextPosition];
        }

        private char Consume(char expected)
        {
            if (Peek() == expected)
            {
                Advance();
                return expected;
            }
            throw new SyntaxError($"Expected '{expected}' but found '{Peek()}'");
        }

To create a complete .NET 9.0 Solution for the given grammar, we need to follow several steps:

1. **Initialize a New Solution in Visual Studio**:
    - Create a new solution with multiple projects.
    - Ensure that each class, interface, enumeration, and record is in its own file.

2. **Define the Project Structure**:
   - We'll create separate files for each component of the solution (classes, interfaces, enumerations, records).
   - Each file will be named according to its content's role in the grammar.

3. **Implement the Lexer**:
   - This will involve creating a class that can tokenize input based on the provided grammar rules.
   - Use LINQ for processing and filtering tokens.

4. **Generate Abstract Syntax Tree (AST) Nodes**:
    - Create classes or records to represent different nodes of the AST.

5. **Pretty Printer for the AST**:
   - A method that prints the AST in a readable format.

6. **Unit Tests**:
    - Write unit tests using Microsoft's Unit Test Framework to cover lexing, parsing, and pretty printing.

Here is the structure of the solution:

### Solution Structure