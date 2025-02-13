public readonly struct Token
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
    Name,
    Number,
    String,
    Newline,
    Indent,
    Dedent,
    Endmarker,
    // Add other token types as needed based on the grammar
}
To create a .NET 9.0 solution that includes a class library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and pretty-printing it, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure with separate files for each class, interface, enumeration, and record.**
3. **Develop the Lexer, AST Nodes, Pretty Printer, and Unit Tests using Microsoft's Unit Test Framework.**

Here is the complete solution:

### 1. Initialize a new Solution in Visual Studio

Create a new .NET 9.0 Class Library project named `LexerLibrary`.

### 2. Define the Project Structure

#### File System Structure