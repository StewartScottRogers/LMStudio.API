# Initialization of Solution in Visual Studio

Create a new .NET 9.0 solution named `LexerSolution` using Visual Studio 2022.

1. **Project Structure**:
    - Create a Class Library project named `LexerLibrary`.
    - Inside `LexerLibrary`, create the following files:
        - `AbstractSyntaxTree.cs`
        - `AstNode.cs`
        - `Lexer.cs`
        - `PrettyPrinter.cs`
        - `TokenType.cs`

2. **Unit Tests**: Create a separate project for unit tests:
   - `AstNodeTests.cs`
   - `LexerTests.cs`

3. **Solution Structure**:
   - Solution Name: `PythonLexerSolution`
     - Project: `PythonLexerLibrary`
       - Classes:
         - `Lexer.cs`
         - `AbstractSyntaxTree.cs`
         - `PrettyPrinter.cs`
         - Various Node classes (e.g., `AssignmentNode.cs`, `FunctionDefNode.cs`, etc.)
       - Interfaces:
         - None for this project.
       - Enumerations:
        - None for this project
       - Records:
        - None for this project

### Solution Structure

1. **Initialize a new .NET 9.0 Solution in Visual Studio 2022.**
   - Create a new Class Library project named `LexerLibrary`.
   - Add necessary files and classes as per the solution structure.

**File System Structure:**

- LexerLibrary.csproj
- LexerLibrary.sln
- Ast/
  - Node/
    - AssignmentNode.cs
    - CompoundStatementNode.cs
    - SimpleStatementNode.cs
    - ... (other node types)
  - AbstractSyntaxTree.cs
- Lexer.cs
- PrettyPrinter.cs
- UnitTests/
  - TestLexer.cs

Below is the detailed implementation of the solution based on your specifications.

### File Structure: