public enum TokenType
    {
        Name,
        Number,
        String,
        Newline,
        Indent,
        Dedent,
        Endmarker,
        Comment,
        // Add more tokens as needed based on the grammar
    }
}

Creating a .NET 9.0 solution to lex and parse the provided grammar involves several steps. Below is a high-level overview of the solution structure, followed by the implementation details for each component.

### Solution Structure

1. **Lexer Class**: Responsible for tokenizing the input string based on the given grammar.
2. **Abstract Syntax Tree (AST) Nodes**: Classes representing different nodes in the AST.
3. **AST Pretty Printer**: Responsible for converting the AST back into a human-readable format.
4. **Unit Tests**: Unit tests to validate the lexer and parser functionality.

Below is the structure of the solution:

### Project Structure