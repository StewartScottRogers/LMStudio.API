// AbstractSyntaxTreeNode.cs
public abstract class AbstractSyntaxTreeNode
{
    public abstract void Accept(IAstVisitor visitor);
}

// AstVisitor.cs
public interface IAstVisitor
{
    void Visit(AbstractSyntaxTreeNode node);
}

// StatementNode.cs
public sealed record StatementNode : AbstractSyntaxTreeNode
{
    // Implementation here
};

// CompoundStatementNode.cs
public sealed record CompoundStatementNode : StatementNode
{
    public var StatementsTuple { get; } = new();
};

// SimpleStatementsNode.cs
public sealed record SimpleStatementsNode : StatementNode
{
    // Implementation here
};

The given project requires a Lexer for the provided grammar, an Abstract Syntax Tree (AST) Pretty Printer, and various AST nodes. Additionally, 25 unit tests need to be generated for lexing the Abstract Syntax Tree.

Let's break down the solution steps:

1. **Initialize a new Solution in Visual Studio**:
   - Create a new .NET Class Library project.
   - Ensure it is set up for .NET 9.0 and can be opened in Visual Studio 2022.

2. **Define the Project Structure**:
   - Create separate files for each class, interface, enumeration, and record as per the coding style guidelines.

3. **Implement the Lexer, Abstract Syntax Tree (AST), and Pretty Printer**:

### Step 1: Initialize a new Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Set the target framework to .NET 9.0.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as follows:

1. **Lexer.cs**
2. **AstNode.cs**
3. **AstPrettyPrinter.cs**
4. **TokenType.cs** (Enumeration)
5. **Token.cs** (Record)

### File: Lexer.cs