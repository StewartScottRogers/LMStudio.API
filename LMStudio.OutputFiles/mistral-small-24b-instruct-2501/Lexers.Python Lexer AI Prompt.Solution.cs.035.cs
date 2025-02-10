using System;

namespace LexerLibrary
{
    public abstract record Statement
    {
        public enum StatementType { CompoundStmt, SimpleStmts }
        public readonly StatementType Type;

        protected Statement(StatementType type)
        {
            Type = type;
        }

        public static Statement Parse(string input) => throw new NotImplementedException();
    };

    public record CompundStmt : Statement
    {
        // Implementation for CompundStmt
    };
}

public interface INodeVisitor
{
    void Visit(IReadOnlyList<INode> nodes);
}

public abstract class AbstractSyntaxTreeNode : INodeVisitor
{

}

To create a .NET 9.0 solution that lexes the provided grammar, generates an Abstract Syntax Tree (AST), and includes unit tests, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop the Lexer, AST Nodes, and Pretty Printer.**
4. **Write Unit Tests using Microsoft's Unit Test Framework.**

Let's start by creating the necessary project structure and implementing the core components.

### Project Structure

1. **LexerProject.sln**: Solution file.
2. **LexerLibrary**: Class Library project containing:
   - **AbstractSyntaxTree.cs**: AST nodes and pretty printer.
   - **Lexer.cs**: Lexer implementation.
   - **Token.cs**: Token definitions.
3. **LexerTests**: Unit Test Project for the Lexer.

Here is a step-by-step guide to create the solution:

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new solution with the following projects:
   - `PythonLexer` (Class Library)
   - `PythonLexer.Tests` (Unit Test Project)

### File System Structure