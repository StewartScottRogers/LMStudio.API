namespace Lexer.Lexer
{
    public enum TokenType
    {
        Name,
        Number,
        String,
        True,
        False,
        None,
        Newline,
        Indent,
        Dedent,
        Endmarker,
        Colon,
        Comma,
        Semicolon,
        LParen,
        RParen,
        LBracket,
        RBracket,
        LCurly,
        RCurly,
        Arrow,
        Equals,
        Plus,
        Minus,
        Star,
        Slash,
        Percent,
        Ampersand,
        Pipe,
        Caret,
        Tilde,
        At,
        LessThan,
        GreaterThan,
        Dot,
        Comma,
    | Colon,

## Solution Structure

### Project: PythonLexer
- **Classes**:
  - `Lexer`
  - `Token`
  - `TokenType`
  - `AbstractSyntaxTreeNode`
  - `AstPrettyPrinter`
  - **AST Nodes**: (Each node class in its own file)
    - `AssignmentStatementNode`
    - `SimpleStatementNode`
    - `CompoundStatementNode`
    - `FunctionDefinitionNode`
    - `ClassDefinitionNode`
    - `IfStatementNode`
    - `WhileStatementNode`
    - `ForStatementNode`
    - `WithStatementNode`
    - `TryStatementNode`
    - `MatchStatementNode`
    - **other nodes as needed**

Below is the structure for a .NET 9.0 solution that meets your specifications. This solution includes a class library to lex the given grammar, generate an Abstract Syntax Tree (AST), and pretty-print the AST. Additionally, it includes unit tests using Microsoft's Unit Test Framework.

### Solution Structure