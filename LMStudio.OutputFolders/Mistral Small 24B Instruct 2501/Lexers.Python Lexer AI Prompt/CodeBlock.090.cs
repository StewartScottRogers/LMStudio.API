using System;

namespace PythonLexer
{
    public enum TokenType
    {
        Name,
        Number,
        String,
        Indent,
        Dedent,
        Newline,
        Endmarker,
        // Add other token types as needed
    }

    public class Token
    {
        public readonly string Value;
        public readonly TokenType Type;

        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }
    }

    public enum TokenType
    {
        NAME,
        NUMBER,
        STRING,
        NEWLINE,
        INDENT,
        DEDENT,
        ENDMARKER,
        // Add other token types as needed based on the grammar
    }

    public class Lexer
    {
        private readonly string input;
        private int position;
        private char currentChar;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.currentChar = this.input[this.position];
        }

        private void Advance()
        {
            if (this.position < this.input.Length - 1)
            {
                this.position++;
                this.currentChar = this.input[this.position];
            }
        }

        public bool IsAtEnd()
        {
            return this.position >= this.input.Length;
        }

        public char Previous()
        {
            return this.input[this.position - 1];
        }

        public string Tokenize(string sourceCode)
        {
            string input = sourceCode;
            List<char> tokens = new List<char>();

            while (input != "")
            {
                // Handle whitespace
                if (char.IsWhiteSpace(input[0]))
                {
                    input = input.Substring(1);
                    continue;
                }

                // Handle comments
                if (input.StartsWith("//") || input.StartsWith("#"))
                {
                    int commentEnd = input.IndexOf("\n");
                    if (commentEnd == -1)
                        commentEnd = input.Length;
                    input = input.Substring(commentEnd + 1);
                    continue;
                }

                // Handle other tokens
                // Implement tokenization logic here

### Solution Steps

1. **Initialize a new Solution in Visual Studio**:
   - Create a new .NET 9.0 Class Library project.
   - Name the solution `LexerGrammarSolution`.
   - Ensure the project is set to use C#.

2. **Define the Project Structure**:
   - Create separate files for each class, interface, enumeration, and record as specified in the problem statement.

3. **Develop the Lexer Class Library**:
    - We will start by defining the necessary classes and records to represent the Abstract Syntax Tree (AST) nodes.
    - The lexer will tokenize the input grammar.
    - We'll implement a pretty printer for the AST.
    - Finally, we'll write unit tests to ensure the lexer works correctly.

### Solution Structure

1. **Solution Creation**:
   - Create a new .NET 9.0 Solution in Visual Studio 2022.
   - Add a Class Library project named `LexerLibrary`.

2. **Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.

3. **Coding Guidelines**:
   - Follow the coding style guidelines provided.
   - Use only the Microsoft Basic Component Library.
   - Implement LINQ where applicable.
   - Use streams for all input/output operations.

### Solution Structure

1. **Project Initialization**
   - Initialize a new .NET 9.0 solution in Visual Studio 2022.
   - Create a Class Library project named `LexerLibrary`.

2. **File System Structure**
   - Create separate files for each class, interface, enumeration, and record.

3. **Classes and Records**

### Token.cs