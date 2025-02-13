public sealed class SimpleStmtNode : StatementNode
{
    private readonly List<SimpleStatementNode> simpleStatements;

    public SimpleStmtNode(List<SimpleStatementNode> simpleStatements)
    {
        this.simpleStatements = new List<SimpleStatementNode>(simpleStatements);
    }

    public var SimpleStatementsTuple => (SimpleStatementTuple) this.simpleStatements;
}
}

### Solution Structure

1. **Class Library Project**
   - Create a Class Library project named `LexerLibrary`.
   - Ensure the project is compatible with .NET 9.0 and Visual Studio 2022.

2. **File System Structure**
   - Each class, interface, enumeration, and record will be in its own file.
   - The solution will include:
     - `Tokens.cs`
     - `Lexer.cs`
     - `AstNode.cs`
     - `StatementNodes.cs`
     - `ExpressionNodes.cs`
     - `AbstractSyntaxTreePrettyPrinter.cs`
     - `TestProject.cs`

Let's start by defining the project structure and creating the necessary files.

### Project Structure