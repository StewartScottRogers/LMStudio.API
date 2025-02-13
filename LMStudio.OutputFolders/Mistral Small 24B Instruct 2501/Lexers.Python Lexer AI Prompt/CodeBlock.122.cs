### Solution Structure

The solution will include the following projects and files:

1. **ClassLibrary (Lexer)**
   - `AbstractSyntaxTreeNode.cs`
   - `AssignmentNode.cs`
   - `AstPrettyPrinter.cs`
   - `AugassignNode.cs`
   - `BlockNode.cs`
   - `ClassDefNode.cs`
   - `CompoundStmtNode.cs`
   - `DelStmtNode.cs`
   - `ElseBlockNode.cs`
   - `ExceptBlockNode.cs`
   - `FinallyBlockNode.cs`
   - `ForStmtNode.cs`
   - `FunctionDefNode.cs`
   - `GlobalStmtNode.cs`
   - `IfStmtNode.cs`
   - `ImportFromTargetAsNamesTuple.cs`
   - `ImportFromTargetsTuple.cs`
   - `ImportNameAsNamesTuple.cs`
   - `ImportStmtTuple.cs`
   - `MatchCaseBlockTuple.cs`
   - `NamedExpressionTuple.cs`
   - `ParamsTuple.cs`
   - `SimpleStmtsTuple.cs`
   - **StatementNewlineTuple** :
        - CompoundStmt
        - SimpleStmts

To create a .NET 9.0 Solution in C# that meets the specified requirements, we need to follow these steps:

1. Initialize a new Solution in Visual Studio.
2. Define the project structure ensuring each class, interface, enumeration, and record is in its own file.
3. Implement the Lexer for the Abstract Syntax Tree (AST).
4. Generate nodes for the AST.
5. Create an AST Pretty Printer.
6. Develop unit tests using Microsoft's Unit Test Framework.

Below is a .NET 9.0 Solution structured according to your specifications. This solution includes a Class Library for lexing the provided grammar, generating an Abstract Syntax Tree (AST), and pretty-printing the AST. Additionally, it includes unit tests for lexing the AST.

### Solution Structure