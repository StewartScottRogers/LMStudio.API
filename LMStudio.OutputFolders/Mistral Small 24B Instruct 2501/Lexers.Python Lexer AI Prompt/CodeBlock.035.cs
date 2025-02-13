namespace LexerLibrary
{
    public enum TokenType
    {
        Identifier,
        Number,
        String,
        Keyword,
        Operator,
        Punctuation,
        Newline,
        Endmarker,
        Invalid
    }

    public record Token(ReadOnlyCollection<char> Text, TokenType Type);

    // Abstract Syntax Tree Node Classes
    public interface IAstNode { }
    public class AstRoot : IAstNode
    {
        public readonly ReadOnlyCollection<IAstNode> Statements;

        public AstRoot(IEnumerable<IAstNode> statements)
        {
            Statements = new List<IAstNode>(statements).AsReadOnly();
        }

        public void PrettyPrint(StreamWriter writer, string indent = "")
        {
            foreach (var statement in Statements)
            {
                if (statement is CompoundStatement compoundStatement)
                {
                    compoundStatement.PrettyPrint(writer, indent);
                }
                else if (statement is SimpleStatement simpleStatement)
                {
                    simpleStatement.PrettyPrint(writer, indent);
                }
            }
        }

To create a .NET 9.0 solution that includes a lexer for the given grammar and generates an Abstract Syntax Tree (AST) with a pretty printer, we need to follow these steps:

1. **Initialize a New Solution in Visual Studio**:
   - Create a new Class Library project.
   - Ensure the project is set up for .NET 9.0.

2. **Define Project Structure**:
   - Separate files for each class, interface, enumeration, and record.
   - Implement the lexer, AST nodes, AST pretty printer, and unit tests as described.

Below is a basic structure to get started with the solution. This includes the initialization of a new .NET 9.0 solution in Visual Studio 2022, creating separate files for each class, interface, enumeration, and record, and implementing the lexer, AST generation, and pretty printer. Additionally, unit tests will be included using Microsoft's Unit Test Framework.

### Solution Structure

1. **Lexer Class**: `Lexer.cs`
2. **AST Nodes**: `AstNode.cs`, `StatementNode.cs`, `ExpressionNode.cs`, etc.
3. **Abstract Syntax Tree (AST) Pretty Printer**: `AstPrettyPrinter.cs`
4. **Unit Tests**: `LexerTests.cs`

### Solution Structure