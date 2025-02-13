using System;
using System.Collections.Generic;

namespace LexerLibrary.Nodes
{
    public record AssignmentNode
    {
        public readonly string Name { get; init; }
        public readonly object Expression { get; init; }
        public readonly List<object> AnnotatedRhs { get; init; } = new();
    }
}
public record AugAssignNode
{
    public readonly string Operator { get; init; }

}
public record ReturnStmtNode
{
    public readonly var StarExpressionsTuple {get;} ;
}

public record RaiseStmtNode
{
    public readonly var ExpressionsTuple {get;} ;
}

public record GlobalStmtNode
{
    public readonly var NamesTuple {get;} ;
}

public record NonlocalStmtNode
{
    public readonly var NamesTuple {get;} ;
}

public record DelStmtNode
{
    public readonly var TargetsTuple;
}
public record YieldStmtNode
{
    public readonly var Expression;
}

public record AssertStmtNode
{
    public readonly var TestExpression;
    public readonly var MsgExpression;
}

public record ImportNameNode
{
    public readonly string ModuleName;
    public readonly List<string> AsNames;

    public ImportNameNode(string moduleName, List<string> asNames)
    {
        ModuleName = moduleName;
        AsNames = asNames ?? throw new ArgumentNullException(nameof(asNames));
    }
}

To create a .NET 9.0 Solution for the Lexer application described, we need to follow several steps. Below is a high-level overview of the solution structure and the key components that will be implemented:

1. **Initialize the Solution**:
   - Create a new Class Library project in Visual Studio 2022.
   - Ensure the project targets .NET 9.0.

2. **Define the Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.

3. **Develop the Lexer**:
   - Implement a lexer to tokenize the input based on the provided grammar.
   - Use streams for all input/output operations.
   - Utilize Fluent Interfaces wherever possible.
   - Implement LINQ where applicable.

4. **Generate the Abstract Syntax Tree (AST)**:
   - Create classes for each node in the AST.
   - Ensure that each class has methods to pretty print the tree.

5. **Pretty Printer**:
   - Create a PrettyPrinter class that can traverse the AST and generate a formatted string representation of it.

6. **Unit Tests**:
   - Write unit tests to cover various scenarios, including edge cases and boundary conditions.

Below is a .NET 9.0 solution that fulfills these requirements. The solution includes a Lexer for parsing the given grammar, an Abstract Syntax Tree (AST) with nodes, an AST Pretty Printer, and Unit Tests using Microsoft's Unit Test Framework.

### Solution Structure
1. **LexerLibrary**
   - **Classes**:
     - `Lexer.cs`
     - `Token.cs`
     - `TokenType.cs`
   - **Interfaces**:
     - None
   - **Enumerations**:
     - `TokenType.cs`
   - **Records**:
     - None

### File: Lexer.cs