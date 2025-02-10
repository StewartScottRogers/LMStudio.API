// File: TokenType.cs
public enum TokenType
{
    // Define token types based on the grammar provided
    Identifier,
    Number,
    String,
    Newline,
    Indent,
    Dedent,
    EndMarker,
    Colon,
    Semicolon,
    Comma,
    Equals,
    PlusEquals,
    MinusEquals,
    StarEquals,
    AtEquals,
    SlashEquals,
    PercentEquals,
    AmpersandEquals,
    PipeEquals,
    CaretEquals,
    LeftShiftEquals,
    RightShiftEquals,
    DoubleStarEquals,
    DoubleSlashEquals,
    ReturnStatement,
    RaiseStatement,
    GlobalStatement,
    NonlocalStatement,
    DelStatement,
    YieldStatement,
    AssertStatement,
    ImportStatement,
    TypeAliasDeclaration,

Based on the provided grammar, we'll create a C# solution that includes a lexer for parsing the given grammar. The solution will also include an Abstract Syntax Tree (AST) and a pretty printer for the AST.

### Solution Structure

1. **Lexer**: A class to tokenize the input based on the given grammar.
2. **AST Nodes**: Classes representing various nodes in the AST.
3. **Pretty Printer**: A class to print the AST in a readable format.
4. **Unit Tests**: Unit tests for lexing and parsing the Abstract Syntax Tree.

### Solution Structure