# Lexer Application

This solution provides a lexer for the given grammar, generates an Abstract Syntax Tree (AST), and includes a pretty printer for the AST. The project is structured to ensure each class, interface, enumeration, and record is in its own file.

## Solution Structure

### Project Files

1. **LexerApplication.sln** - Visual Studio solution file.
2. **LexerLibrary** - Class Library Project
   - **Class Files**:
     - `AbstractSyntaxTree.cs`
     - `AstNodePrinter.cs`
     - `AssignmentNode.cs`
     - `AugAssignNode.cs`
     - `BlockNode.cs`
     - `ClassDefNode.cs`
     - `CompoundStmtNode.cs`
     - `DelStmtNode.cs`
     - `ElseBlockNode.cs`
     - `ExprNode.cs`
     - `FunctionDefNode.cs`
     - `IfStmtNode.cs`
     - `ImportFromNameTuple.cs**
     - `ImportNameTuple.cs`
     - `NonlocalStmtTuple.cs**
     - `ReturnStmtTuple.cs**
     - `SimpleStmtsTuple.cs**
     - **TypeAliasTuple.cs**  // Note: This is just an example. The actual tuple names will be determined based on the method returning them.