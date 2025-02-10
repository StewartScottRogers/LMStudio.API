using System.Collections.Generic;

namespace Lexer.AstNodes
{
    public class StatementNode : AstNode
    {
        public List<StatementNode> Statements { get; private set; }

        public StatementNode(IEnumerable<StatementNode> statements)
        {
            Statements = new List<StatementNode>(statements);
        }
    }
}

To create a .NET 9.0 solution for the described lexer and abstract syntax tree (AST) pretty printer, we will follow these steps:

1. **Initialize a new Solution in Visual Studio:**
   - Create a new Class Library project.
   - Add necessary projects for unit tests.

2. **Define the Project Structure:**
   - Ensure each class, interface, enumeration, and record is in its own file.

3. **Develop the Lexer:**
   - Implement the lexing functionality to parse the given grammar.

4. **Generate Abstract Syntax Tree (AST) Nodes:**
   - Create nodes that represent different parts of the AST.

5. **Create an AST Pretty Printer:**
   - Develop a utility to print the AST in a readable format.

6. **Unit Testing:**
   - Write unit tests to ensure the lexer, parser, and pretty printer work correctly.

Below is the implementation based on your requirements:

### Solution Structure

1. **Lexer**
2. **Abstract Syntax Tree (AST)**
3. **Pretty Printer**
4. **Unit Tests**

### Project Setup

Initialize a new solution in Visual Studio 2022 with the following project structure:
- `LexerLibrary` (Class Library)
- `LexerLibrary.Tests` (Unit Test Project)

### LexerLibrary

#### File: Lexer.cs