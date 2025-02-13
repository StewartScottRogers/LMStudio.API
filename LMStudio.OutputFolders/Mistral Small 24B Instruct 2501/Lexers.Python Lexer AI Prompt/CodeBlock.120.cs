using System;
using System.Collections.Generic;

public class Lexer
{
    private readonly string input;
    private int position = 0;
    private int lineNumber = 1;
    private int column = 1;

    public enum TokenType
    {
        Identifier,
        Number,
        StringLiteral,
        Keyword,
        Operator,
        Newline,
        EndMarker,
        // Add other token types as needed
    }

    public class LexerToken
    {
        public readonly TokenType Type;
        public readonly string Value;

        public LexerToken(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    // Enum to represent different token types based on the grammar.
    public enum TokenType
    {
        Statement,
        CompoundStmt,
        SimpleStmts,
        Assignment,
        AnnotatedRhs,
        Augassign,
        ReturnStmt,
        RaiseStmt,
        GlobalStmt,
        NonlocalStmt,
        DelStmt,
        YieldStmt,
        AssertStmt,
        ImportStmt,
        ImportName,
        ImportFrom,
        ImportFromTargets,
        ImportFromAsNames,
        ImportFromAsName,
        DottedAsNames,
        DottedAsName,
        DottedName,
        CompoundStmt,
        Block,
        Decorators,
        ClassDef,
        ClassDefRaw,
        FunctionDef,
        FunctionDefRaw,
        Params,
        Parameters,
        SlashNoDefault,
        SlashWithDefault,
        StarEtc,
        Kwds,
        ParamNoDefault,
        ParamNoDefaultStarAnnotation,
        ParamWithDefault,
        ParamMaybeDefault,
        Param,
        ParamStarAnnotation,
        Annotation,
        Default

To create a .NET 9.0 Solution that lexes the given grammar, generates an Abstract Syntax Tree (AST), and pretty prints it, we will follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop the Lexer to tokenize the input according to the given grammar.**
4. **Generate an Abstract Syntax Tree (AST) based on the tokens.**
5. **Implement an AST Pretty Printer to visualize the AST.**
6. **Create 25 unit tests for lexing the AST.**

Below is a complete .NET 9.0 Solution in C# that meets the specified requirements.

### Project Structure
1. `LexerSolution.sln` - The solution file.
2. `LexerLibrary` - The class library project containing the lexer, AST nodes, and pretty printer.
3. `LexerTests` - The test project containing unit tests for the lexer.

### LexerLibrary Project

#### File: Lexer.cs