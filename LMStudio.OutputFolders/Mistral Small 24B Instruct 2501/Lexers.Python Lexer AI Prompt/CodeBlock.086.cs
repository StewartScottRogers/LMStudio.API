using System;

namespace LexerLibrary
{
    public enum TokenType
    {
        NAME,
        NUMBER,
        STRING,
        FSTRING_START,
        FSTRING_MIDDLE,
        FSTRING_END,
        NEWLINE,
        INDENT,
        DEDENT,
        ENDMARKER,
        LPAREN,
        RPAREN,
        LSQUARE,
        RSQUARE,
        COLON,
        COMMA,
        SEMI_COLON,
        POW,
        PLUS,
        MINUS,
        STAR,
        SLASH,
        VBAR,
        AMPER,
        CIRCUMFLEX,
    | LSHIFT,
    | RSHIFT,
    | PERCENT,
    | AT,
    | EQ, NEGATE,
    | DOUBLE_SLASH

Let's break down the solution into manageable steps and create a .NET 9.0 Solution in C# that includes a lexer for the provided grammar, an Abstract Syntax Tree (AST) generator, an AST pretty printer, and unit tests.

### Step-by-Step Solution

1. **Initialize the Solution**:
   - Create a new solution in Visual Studio.
   - Add a Class Library project to the solution.

2. **Define Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.

3. **Implement Lexer, AST Nodes, and Pretty Printer**:

### File: AbstractSyntaxTreePrettyPrinter.cs