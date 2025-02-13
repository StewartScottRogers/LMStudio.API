using System;

namespace LexerLibrary
{
    public abstract class AstNode
    {
        public readonly string Text;
        public AstNode(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class Statements : AstNode
    {
        public List<AstNode> StatementList { get; set; } = new();

        public Statements(List<AstNode> statements)
        {
            StatementList = statements;
        }
    }

    public abstract class AstNode { }

    public class Statement : AstNode
    {
        // To be defined based on the grammar
    }

    public class CompoundStatement : Statement
    {
        // To be defined based on the grammar
    }

    public class SimpleStatements : Statement
    {
        // To be defined based on the grammar
    }

    public class Assignment : SimpleStatements
    {
        // To be defined based on the Grammar
    }

    public class ReturnStatement : SimpleStatements
    {
        // To be defined based on the Grammar
    }

    // Other classes for each statement type in the grammar would follow a similar pattern.

    Below is the outline of the solution structure and initial implementation steps:

### Solution Steps

1. **Initialize a new Solution in Visual Studio**
   - Create a new .NET 9.0 Solution.
   - Add a Class Library project to the solution.
   - Ensure all coding will be in C#.
   - Set up the solution to be usable in Visual Studio 2022.

### File System Structure
1. **Lexer.cs**
2. **AbstractSyntaxTreeNode.cs**
3. **AbtractSyntaxTreePrettyPrinter.cs**
4. **TestLexer.cs**

### Solution Steps

1. **Initialize a new .NET 9.0 Solution in Visual Studio.**
   - Create a new Class Library project.
   - Ensure the solution is usable in Visual Studio 2022.

2. **Define the Project Structure:**
   - Create separate files for each class, interface, enumeration, and record.

3. **Implement the Lexer:**
   - Create a lexer to tokenize the input based on the provided grammar.
   - Generate an Abstract Syntax Tree (AST) from the tokens.
   - Implement a pretty printer for the AST.

4. **Unit Testing:**
   - Write unit tests using Microsoft's Unit Test Framework to cover all entry points and boundary conditions.

Let's start by setting up the .NET 9.0 Solution in Visual Studio 2022.

### Step 1: Initialize the Solution

1. Open Visual Studio 2022.
2. Create a new project: `File -> New -> Project`.
3. Select `.NET Core` (or `.NET Standard`) as the project type.
4. Choose "Class Library" and name it `LexerLibrary`.

### Directory Structure