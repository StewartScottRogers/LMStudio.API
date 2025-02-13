using System;

namespace PythonLexer
{
    public enum TokenType
    {
        NAME,
        NUMBER,
        STRING,
        FSTRING_START,
        FSTRING_MIDDLE,
        FSTRING_END,
        AWAIT,
        NEWLINE,
        INDENT,
        DEDENT,
        ENDMARKER,
        ELLIPSIS,
        TYPE_COMMENT,
        COMMENT
****
To create a .NET 9.0 Solution that includes a Lexer for the provided grammar, an Abstract Syntax Tree (AST) Pretty Printer, and all nodes in the AST, we need to follow these steps:

1. **Initialize a New Solution**: Create a new .NET 9.0 solution in Visual Studio.
2. **Define the Project Structure**: Ensure each class, interface, enumeration, and record is in its own file.
3. **Develop Unit Tests**: Use Microsoft's Unit Test Framework to write comprehensive unit tests.

Below is a step-by-step implementation of the solution:

### Step 1: Initialize a New Solution
Create a new .NET Class Library project in Visual Studio 2022 and name it `LexerLibrary`.

### Step 2: Define the Project Structure
Ensure each class, interface, enumeration, and record is in its own file.

### File System Structure