using System;

namespace LexerLibrary
{
    public abstract class AbstractSyntaxTreeNode
    {
        public readonly string TokenType;
        public readonly string TokenValue;

        protected AbstractSyntaxTreeNode(string tokenType, string tokenValue)
        {
            TokenType = tokenType;
            TokenValue = tokenValue;
        }
    }

To create a .NET 9.0 Solution for lexing the given grammar and generating an Abstract Syntax Tree (AST) along with a Pretty Printer, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure ensuring each class, interface, enumeration, and record is in its own file.**
3. **Develop the lexer for the Abstract Syntax Tree (AST).**
4. **Generate all nodes in the AST.**
5. **Implement an AST Pretty Printer.**
6. **Develop unit tests using Microsoft's Unit Test Framework.**

Let's break down the solution into manageable steps and create the necessary files and classes.

### Solution Structure

1. **LexerLibrary.sln** - The solution file.
2. **LexerLibrary.csproj** - The project file.
3. **AbstractSyntaxTreePrinter.cs** - Class for pretty-printing the AST.
4. **AstrNode.cs** - Base class for all AST nodes.
5. **ClassDefinitionNode.cs** - Node for class definitions.
6. **FunctionDefinitionNode.cs** - Node for function definitions.
7. **ImportStatementNode.cs** - Node for import statements.
8. **ReturnStatementNode.cs** - Node for return statements.
9. **AssignmentStatementNode.cs** - Node for assignment statements.
10. **IfStatementNode.cs** - Node for if statements.
11. **WhileStatementNode.cs** - Node for while statements.
12. **ForStatementNode.cs** - Node for for statements.
13. **WithStatementNode.cs** - Node for with statements.
14. **TryStatementNode.cs** - Node for try statements.
15. **MatchStatementNode.cs** - Node for match statements.
16. **ImportStatementNode.cs** - Node for import statements.
17. **ClassDefinitionNode.cs** - Node for class definitions.
18. **FunctionDefinitionNode.cs** - Node for function definitions.
19. **TypeAliasNode.cs** - Node for type alias definitions.
20. **AssignmentNode.cs** - Node for assignment statements.
21. **ReturnStatementNode.cs** - Node for return statements.
22. **RaiseStatementNode.cs** - Node for raise statements.
23. **GlobalStatementNode.cs** - Node for global statements.
24. **NonlocalStatementNode.cs** - Node for nonlocal statements.
25. **DelStatementNode.cs** - Node for del statements.
26. **YieldStatementNode.cs** - Node for yield statements.
27. **AssertStatementNode.cs** - Node for assert statements.
28. **ImportStatementNode.cs** - Node for import statements.
29. **FunctionDefinitionNode.cs** - Node for function definitions.
30. **ClassDefinitionNode.cs** - Node for class definitions.
31. **IfStatementNode.cs** - Node for if statements.
32. **WhileStatementNode.cs** - Node for while statements.
33. **ForStatementNode.cs** - Node for for statements.
34. **WithStatementNode.cs** - Node for with statements.
35. **TryStatementNode.cs** - Node for try statements.
36. **ExceptStatementNode.cs** - Node for except statements.
37. **MatchStatementNode.cs** - Node for match statements.
38. **TypeAliasNode.cs** - Node for type alias statements.

To create a .NET 9.0 Solution in C# that includes the described functionality, we'll follow these steps:

1. Initialize a new Solution in Visual Studio.
2. Define the project structure with separate files for each class, interface, enumeration, and record.
3. Implement the Lexer for generating an Abstract Syntax Tree (AST).
4. Implement the AST Pretty Printer.
5. Generate unit tests using Microsoft's Unit Test Framework.

Below is a comprehensive solution that adheres to your guidelines and specifications.

### Solution Structure

1. **Solution**: `LexerSolution`
2. **Projects**:
   - `LexerLibrary` (Class Library)
   - `LexerTests` (Unit Tests)

### File System Structure