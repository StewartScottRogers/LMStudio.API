using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class AstNode { }

    public class Statements : AstNode
    {
        public List<Statement> StatementsList { get; set; }
    }

    public class Statement : AstNode
    {
        public CompoundStmt CompoundStmt { get; set; }
        public SimpleStmts SimpleStmts { get; set; }
    }

    public class StatementNewline : AstNode
    {
        public CompoundStmt? CompoundStmt { get; set; }
        public string? EndMarker { get; set; }
        public SimpleStmts? SimpleStmts { get; set; }
    }

    // Add more classes, interfaces, enumerations, and records as needed to complete the solution.

To create a .NET 9.0 Solution for lexing the given grammar and generating an Abstract Syntax Tree (AST) with Pretty Printer functionality, we need to follow several steps. Below is a high-level overview of how to structure the solution along with sample code snippets for key components.

### Step-by-Step Solution

1. **Initialize the Solution in Visual Studio**:
   - Create a new .NET 9.0 Class Library project.
   - Ensure the project is set up to be compatible with Visual Studio 2022.

2. **Define Project Structure**:
   - Separate files for each class, interface, enumeration, and record.
   - Include comprehensive comments for any non-trivial logic or structure.

3. **Develop Unit Tests**:
   - Use Microsoft's Unit Test Framework to create unit tests.
   - Write three times as many unit tests as you thought you should.
   - Ensure all bounding conditions are tested.

Let's start by creating the necessary files and classes for the lexer, abstract syntax tree (AST) nodes, AST pretty printer, and unit tests.

### File System Structure