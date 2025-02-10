using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string sourceCode;
        private int position;
        private char currentChar;

        public Lexer(string sourceCode)
        {
            this.sourceCode = sourceCode;
            this.position = 0;
            this.currentChar = (position < sourceCode.Length) ? sourceCode[position] : '\0';
        }

        public void Advance()
        {
            position++;
            if (position < SourceText.Length)
            {
                currentChar = sourceText[position];
            }
        }

        private bool IsAtEnd() => CurrentChar == '\0';

        private char CurrentChar => currentChar;

        private string SourceText => sourceText;

To create a .NET 9.0 solution that lexes the given grammar, generates an Abstract Syntax Tree (AST), and pretty prints the AST, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure.**
3. **Create separate files for each class, interface, enumeration, and record.**
4. **Develop unit tests using Microsoft's Unit Test Framework.**
5. **Include a .README or documentation summarizing the project.**

Below is the solution that meets all the specified requirements.

### Solution Structure
- **Solution Name**: LexerSolution
- **Project Name**: LexerLibrary
- **Files**:
  - `Lexer.cs`
  - `AbstractSyntaxTree.cs`
  - `AbstractSyntaxTreePrettyPrinter.cs`
  - `StatementNode.cs`
  - `CompoundStmtNode.cs`
  - `SimpleStmtsNode.cs`
  - `AssignmentNode.cs`
  - `ReturnStmtNode.cs`
  - `RaiseStmtNode.cs`
  - `GlobalStmtNode.cs`
  - `NonlocalStmtNode.cs`
  - `DelStmtNode.cs`
  - `YieldStmtNode.cs`
  - `AssertStmtNode.cs`
  - `ImportStmtNode.cs`
  - `FunctionDefNode.cs`
  - `IfStmtNode.cs`
  - `ClassDefNode.cs`
  - `WithStmtNode.cs`
  - `ForStmtNode.cs`
  - `TryStmtNode.cs`
  - `WhileStmtNode.cs`
  - **AST Nodes**

1. **Statements**
   - CompoundStatement
   - SimpleStatements

2. **Simple Statements**
   - Assignment
   - TypeAlias
   - StarExpressions
   - ReturnStatement
   - ImportStatement
   - RaiseStatement
   - PassStatement
   - DeleteStatement
   - YieldStatement
   - AssertStatement
   - BreakStatement
   - ContinueStatement
   - GlobalStatement
   - NonlocalStatement

To create a .NET 9.0 Solution that lexes the given grammar and generates an Abstract Syntax Tree (AST) pretty printer, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project.**

Below is the solution structure and code for the Lexer, Abstract Syntax Tree (AST) nodes, AST Pretty Printer, and Unit Tests.

### Solution Structure