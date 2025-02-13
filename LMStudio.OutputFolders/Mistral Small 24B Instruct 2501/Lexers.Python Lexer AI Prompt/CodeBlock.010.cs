namespace LexerLibrary
{
    public enum TokenType
    {
        // Keywords
        If,
        Else,
        While,
        For,
        Return,
        Break,
        Continue,
        Pass,
        Raise,
        Assert,
        Import,
        From,
        As,
        Def,
        Class,
        Match,
        Case,

        // Operators
        Plus,
        Minus,
        Star,
        Slash,
        DoubleSlash,
        Percent,
        At,
        BitwiseOr,
        BitwiseXor,
        BitwiseAnd,
        LeftShift,
        RightShift,
        Power,
        Eq,
        NotEq,
        Lt,
        Lte,
        Gt,
        Gte,
        In,
        NotIn,
        Is,
        IsNot,
        And,
        Or

To create a Class Library to lexer the provided grammar, we'll follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure** ensuring each class, interface, enumeration, and record is in its own file.
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project.**

Below is a step-by-step guide to create the solution as per the given requirements.

### Step 1: Initialize a new Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new Class Library (.NET Core) project.
3. Name the project `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record.

#### File: AbstractSyntaxTreePrinter.cs