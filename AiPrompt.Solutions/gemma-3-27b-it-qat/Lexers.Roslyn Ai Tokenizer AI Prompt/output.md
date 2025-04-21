Okay, this is a substantial undertaking! Here's a breakdown of the solution structure and code, adhering strictly to your requirements.  I'll provide the core components with explanations. Due to the complexity of Roslyn integration, I will focus on creating the basic framework for AST generation, printing, reflowing, and unit tests.  A fully functional compiler is beyond the scope of a single response, but this provides a solid foundation.

**Solution Structure:**

```
AstGenerator/
├── AstGenerator.sln
├── AstGenerator.Core/
│   ├── AstNode.cs          (Base class for AST nodes)
│   ├── IExpressionVisitor.cs (Interface for expression visitors)
│   ├── ExpressionRecord.cs  (Record to represent expressions)
│   ├── StatementRecord.cs   (Record to represent statements)
│   ├── CompilationUnit.cs    (Represents the entire compilation unit)
│   ├── AstPrettyPrinter.cs  (AST Pretty Printer)
│   ├── AstReflowGenerator.cs (AST Reflow Generator)
│   └── Enums.cs             (Enumerations for node types, etc.)
├── AstGenerator.Tests/
│   ├── AstLexingTests.cs    (Unit Tests)
│   └── TestHelper.cs        (Helper methods for tests)
└── Microsoft.CodeAnalysis (Roslyn dependencies - added via NuGet)
```

**1. `AstGenerator.Core/Enums.cs`:**

```csharp
namespace AstGenerator.Core;

public enum NodeType
{
    Unknown,
    ExpressionStatement,
    VariableDeclaration,
    AssignmentStatement,
    BinaryExpression,
    Literal,
}
```

**2. `AstGenerator.Core/AstNode.cs`:**

```csharp
namespace AstGenerator.Core;

public abstract class AstNode
{
    public NodeType NodeTypeValue { get; set; } = NodeType.Unknown;
}
```

**3. `AstGenerator.Core/IExpressionVisitor.cs`:**

```csharp
namespace AstGenerator.Core;

public interface IExpressionVisitor
{
    void Visit(ExpressionRecord expressionTuple);
    void Visit(StatementRecord statementTuple);
}
```

**4. `AstGenerator.Core/ExpressionRecord.cs`:**

```csharp
namespace AstGenerator.Core;

public record ExpressionRecord(string Value, NodeType NodeTypeValue) : IExpressionVisitor
{
    public void Visit(ExpressionRecord expressionTuple)
    {
        // Implement visitor logic if needed
    }

    public void Visit(StatementRecord statementTuple)
    {
        // Implement visitor logic if needed
    }
}
```

**5. `AstGenerator.Core/StatementRecord.cs`:**

```csharp
namespace AstGenerator.Core;

public record StatementRecord(string Value, NodeType NodeTypeValue) : IExpressionVisitor
{
    public void Visit(ExpressionRecord expressionTuple)
    {
        // Implement visitor logic if needed
    }

    public void Visit(StatementRecord statementTuple)
    {
        // Implement visitor logic if needed
    }
}
```

**6. `AstGenerator.Core/CompilationUnit.cs`:**

```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstGenerator.Core;

public class CompilationUnit
{
    private readonly List<StatementRecord> statementsList = new();

    public void AddStatement(string statementValue, NodeType nodeTypeValue)
    {
        statementsList.Add(new StatementRecord(statementValue, nodeTypeValue));
    }

    public (SyntaxTree SyntaxTreeTuple, CompilationUnit CompilationUnitTuple) GenerateAstFromCode(string sourceCode)
    {
        // Use Roslyn to parse the code and create an AST
        var tree = CSharpSyntaxTree.ParseText(sourceCode);
        return (tree, this);
    }

    public string PrettyPrint()
    {
        readonly string prettyPrintedAst = statementsList.Aggregate("", (currentValue, statementTuple) => currentValue + $"{statementTuple.NodeType}: {statementTuple.Value}\n");
        return prettyPrintedAst;
    }

    public void Reflow(string sourceCode)
    {
        // Implement AST reflowing logic here using Roslyn
        // This is a placeholder for code generation/execution
        Console.WriteLine($"Reflowing code: {sourceCode}");
    }
}
```

**7. `AstGenerator.Core/AstPrettyPrinter.cs`:**

```csharp
namespace AstGenerator.Core;

public class AstPrettyPrinter
{
    public string Print(CompilationUnit compilationUnit)
    {
        return compilationUnit.PrettyPrint();
    }
}
```

**8. `AstGenerator.Core/AstReflowGenerator.cs`:**

```csharp
namespace AstGenerator.Core;

public class AstReflowGenerator
{
    public void Reflow(CompilationUnit compilationUnit, string sourceCode)
    {
        compilationUnit.Reflow(sourceCode);
    }
}
```

**9. `AstGenerator.Tests/AstLexingTests.cs`:**

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator.Core;

namespace AstGenerator.Tests;

[TestClass]
public class AstLexingTests
{
    [TestMethod]
    public void TestGenerateAstFromSimpleCode()
    {
        // Arrange
        readonly string sourceCode = "int x = 10;";
        CompilationUnit compilationUnit = new();

        // Act
        var (syntaxTreeTuple, unitTuple) = compilationUnit.GenerateAstFromCode(sourceCode);

        // Assert
        Assert.IsNotNull(syntaxTreeTuple);
    }

    [TestMethod]
    public void TestPrettyPrintAst()
    {
        // Arrange
        CompilationUnit compilationUnit = new();
        compilationUnit.AddStatement("int x = 10;", NodeType.VariableDeclaration);
        compilationUnit.AddStatement("x = 20;", NodeType.AssignmentStatement);

        // Act
        AstPrettyPrinter printer = new();
        string prettyPrintedAst = printer.Print(compilationUnit);

        // Assert
        Assert.AreEqual("VariableDeclaration: int x = 10;\n", prettyPrintedAst);
    }

    [TestMethod]
    public void TestReflowAst()
    {
        // Arrange
        CompilationUnit compilationUnit = new();
        compilationUnit.AddStatement("int x = 10;", NodeType.VariableDeclaration);
        readonly string sourceCode = "int x = 10;";

        // Act
        AstReflowGenerator reflower = new();
        reflower.Reflow(compilationUnit, sourceCode);

        // Assert - This test currently only checks that the method runs without errors.  More robust testing would involve verifying generated code.
    }
}
```

**Important Considerations and Next Steps:**

*   **Roslyn Integration:** The `GenerateAstFromCode` and `Reflow` methods are placeholders. You'll need to use Roslyn APIs (e.g., `CSharpSyntaxTree.ParseText`, semantic analysis, code generation) to implement the actual AST creation and reflowing logic.
*   **Visitor Pattern:**  The `IExpressionVisitor` interface is a starting point for traversing the AST. Implement concrete visitors to perform specific actions on different node types (e.g., type checking, code transformation).
*   **Error Handling:** Add robust error handling to handle invalid input code and unexpected conditions during AST generation and reflowing.
*   **Unit Tests:** Expand the unit tests to cover all bounding conditions and edge cases.  Test for correct AST structure, node types, and generated code output.
*   **Reflow Logic:** The `AstReflowGenerator` needs a sophisticated algorithm to transform the AST back into valid C# code. This could involve formatting, indentation, and potentially more complex code restructuring.

This provides a basic framework that you can build upon to create a fully functional Abstract Syntax Tree generator, pretty printer, and reflow engine using Roslyn.  Remember to install the `Microsoft.CodeAnalysis` NuGet package in your project.
