// Initialize a new Solution in Visual Studio.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LexerLibrary
{
    // Define the project structure ensuring each class, interface, enumeration, and record is in its own file.

    public enum TokenType
    {
        Identifier,
        Number,
        String,
        Keyword,
        Operator,
        Punctuation,
        Newline,
        EndMarker
    }

    public class Lexer
    {
        private readonly string input;
        private int position;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public void Tokenize()
        {
            while (this.position < this.input.Length)
            {
                if (char.IsWhiteSpace(this.input[this.position]))
                {
                    this.position++;
                    continue;
                }

                // Implement tokenization logic based on the grammar provided
                // For simplicity, let's assume we are tokenizing individual characters as tokens
                var token = this.input[this.position];
                Console.WriteLine($"Token: {token}");
            }

        }
    }
}

public static class LexerExtensions
{
    public static bool IsStatement(this string input)
    {
        return !string.IsNullOrEmpty(input.Trim()) && input.Trim() != "NEWLINE";
    }

    public static bool IsCompoundStmt(this string input)
    {
        // Implement logic to check if the statement is a compound statement based on the grammar
        return false;
    }
}

# Lexer
public interface ILexer
{
    IEnumerable<(string Token, string Value)> Lex(string input);
}

public class PythonLexer : ILexer
{
    private readonly HashSet<string> Keywords = new() { "def", "class", "return", "import", "from", "as", "if", "elif", "else", "while", "for", "in", "try", "except", "finally", "match", "case", "with", "break", "continue", "global", "nonlocal", "del", "yield", "pass", "assert", "raise", "return", "import", "from", "as", "lambda", "True", "False", "None"  | '==' | '!=' | '<' | '>' | '<=' | '>=' | 'in' | 'not in' | 'is' | 'is not'

To create a .NET solution that includes a lexer for the given grammar, an Abstract Syntax Tree (AST) generator, and an AST pretty printer, we'll follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create the necessary files and folders:**
   - ClassLibraryProject
     - Classes
       - Lexer.cs
       - AstGenerator.cs
       - PrettyPrinter.cs
     - Interfaces
       - IToken.cs
       - IAstNode.cs
     - Enumerations
       - TokenType.cs
       - NodeType.cs
     - Records
       - TokenRecord.cs
       - AstNodeRecord.cs
     - UnitTests
       - LexerUnitTests.cs

### Step-by-Step Solution

1. **Initialize a new Solution in Visual Studio**:
   - Create a new .NET 9.0 solution.
   - Add a Class Library project to the solution.

2. **Define the Project Structure**:
   - Ensure each class, interface, enumeration, and record is in its own file.
   - Organize files into folders for better management (e.g., `Nodes`, `Lexer`, `Parser`, `PrettyPrinter`).

3. **Develop the Lexer**:
   - Create a lexer that can tokenize the given grammar.

4. **Generate Abstract Syntax Tree (AST) Nodes**:
   - Define classes for each node type in the AST.

5. **Implement the Pretty Printer**:
   - Create a class to pretty-print the AST.

6. **Unit Testing**:
   - Write unit tests using Microsoft's Unit Test Framework.

Below is the solution structure and code based on your requirements:

### Solution Structure