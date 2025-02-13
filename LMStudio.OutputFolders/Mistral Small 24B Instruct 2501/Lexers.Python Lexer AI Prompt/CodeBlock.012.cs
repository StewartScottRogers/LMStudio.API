using System.IO;
using Microsoft.Extensions.Logging;

public class AstPrettyPrinter : IAstVisitor
{
    private readonly TextWriter _writer;
    private int _indentLevel = 0;

    public AstPrettyPrinter(TextWriter writer)
    {
        _writer = writer ?? throw new ArgumentNullException(nameof(writer));
    }

    public void Visit(Node node)
    {
        if (node == null) return;

        // Add your visit logic here to handle different node types.
        // This is a placeholder method.
        Console.WriteLine(node.ToString());
    }
}
}

### Project Structure

1. **LexerClassLibrary**
   - **AbstractSyntaxTree**
     - `AstNode.cs`
     - `AssignmentNode.cs`
     - `ClassDefNode.cs`
     - `FunctionDefNode.cs`
     - `ImportStmtNode.cs`
     - `MatchStmtNode.cs`
     - `ReturnStmtNode.cs`
     - `TryStmtNode.cs`
     - `WhileStmtNode.cs`
     - `WithStmtNode.cs`
     - `YieldExprNode.cs`

To create a .NET 9.0 Solution that includes a Lexer for the given grammar, an Abstract Syntax Tree (AST) Pretty Printer, and all nodes in the AST, follow these steps:

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new solution by selecting `File > New > Project`.
3. Choose `Class Library` as the project type.
4. Name your solution (e.g., `PythonLexer`) and ensure it targets .NET 9.0.
5. Click `Create`.

### File System Structure