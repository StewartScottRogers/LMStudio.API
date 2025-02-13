// LexerLibrary/AbstractSyntaxTree.cs
using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public readonly struct SyntaxNodeTuple
    {
        public string NodeType { get; }
        public List<SyntaxNode> Children { get; }

        public SyntaxNodeTuple(string nodeType, List<SyntaxNode> children)
        {
            NodeType = nodeType;
            Children = children;
        }
    }
}

# Create a new solution in Visual Studio 2022
1. Open Visual Studio 2022.
2. Click on "Create a new project."
3. Select "Class Library" and click "Next."
4. Name the project (e.g., `PythonLexer`) and choose the location to save it.
5. Ensure that the target framework is set to `.NET 9.0`.
6. Click "Create."

### Project Structure

1. **Classes:**
   - Lexer.cs
   - AbstractSyntaxTreeNode.cs
   - StatementNode.cs
   - SimpleStatementNode.cs
   - CompoundStatementNode.cs
   - ExpressionNode.cs
   - FunctionDefNode.cs
   - IfStmtNode.cs
   - ClassDefNode.cs
   - WithStmtNode.cs
   - ForStmtNode.cs
   | TryStmtNode.cs

To create a .NET 9.0 Solution for the Lexer based on the provided grammar, we will follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project and key points of logic for easy comprehension.**

Here is a step-by-step guide to creating the solution:

### Step 1: Initialize the Solution
1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Add the following projects:
   - `AbstractSyntaxTree`
   - `AbstractSyntaxTreePrettyPrinter`
   - `LexerTests`

### Step 2: Define Project Structure

#### Lexer
- **Lexer.cs**: Main lexing logic.
- **Token.cs**: Token enumeration and properties.
- **ILexable.cs**: Interface for lexable items.

#### Abstract Syntax Tree (AST)
- **Node.cs**: Base class for all AST nodes.
- **StatementNode.cs**: Nodes for statements.
  - **CompoundStmtNode.cs**
  - **SimpleStmtNode.cs**
  - **AssignmentNode.cs**
  - **ReturnStmtNode.cs**
  - **RaiseStmtNode.cs**
  - **GlobalStmtNode.cs**
  - **NonlocalStmtNode.cs**
  - **DelStmtNode.cs**
  - **YieldStmtNode.cs**
  - **AssertStmtNode.cs**
  - **ImportNameNode.cs** (for `import_stmt`)
  - **ImportFromNode.cs** (for `import_from`)
  - **ClassDefRawNode.cs** (for `class_def_raw`)
  - **FunctionDefRawNode.cs** (for `function_def_raw`)
  - **ParamsNode.cs**
  - **StarEtcNode.cs**
  - **KwdsNode.cs**
  - **ParamNoDefaultNode.cs**
  - **ParamWithDefaultNode.cs**

The solution will consist of multiple classes and interfaces that work together to lex the given grammar into an Abstract Syntax Tree (AST). We'll also include a pretty printer for the AST and unit tests to ensure the correctness of our lexer.

### Solution Structure

1. **Class Library Project**
   - Create a new Class Library project in Visual Studio 2022.
   - Ensure all files are created with the appropriate naming conventions and coding style guidelines.

2. **Files and Directories**
   - Create separate files for each class, interface, enumeration, and record.
   - Example file structure: