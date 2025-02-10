public enum TokenType
{
    Name,
    Number,
    String,
    Newline,
    Indent,
    Dedent,
    Endmarker,
    Plus,
    Minus,
    Star,
    Slash,
    Backslash,
    Percent,
    Ampersand,
    Pipe,
    Tilde,
    At,
    LessThanEqualTo,
    GreaterThanEqualTo,
    EqualSign,
    NotEqualSign,
    Colon,
    Semicolon,
    Comma,
    Period,
    LeftParenthesis,
    RightParenthesis,
    LeftBracket,
    RightBracket,
    LeftBrace,
    RightBrace,
    Backslash,
    Asterisk,
    Plus,
    Minus,
    Slash,
    Backslash,
    Caret,
    Percent,
    AtSymbol,
    Tilde,
    Equals,
    Colon,
    Semicolon,
    OpenParen,
    CloseParen,
    OpenBracket,
    CloseBracket,
    OpenCurly,
    CloseCurly,
    OpenSquare,
    CloseSquare,
    Ellipsis,
    Arrow,
    AtSign,
    Dot,
    Comma
    Await,
    ASYNC,

# Solution Steps

1. **Initialize a new .NET Solution in Visual Studio 2022**:
   - Create a new Class Library project named `LexerLibrary`.
   - Add necessary projects for unit testing.

2. **Define the Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.
   - Ensure each file is named appropriately and follows the naming conventions specified.

3. **Implement the Lexer Class Library**:
   - Implement a lexer that can tokenize the given grammar.
   - Generate an Abstract Syntax Tree (AST) from the tokens.
   - Create a pretty printer for the AST.

4. **Unit Testing**:
   - Write unit tests using Microsoft's Unit Test Framework to ensure the lexer and parser work correctly.

Below is a step-by-step guide to creating the solution in Visual Studio 2022:

### Step 1: Initialize a New Solution

1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Ensure the target framework is .NET 9.0.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as per the grammar provided.

#### File: StatementNode.cs