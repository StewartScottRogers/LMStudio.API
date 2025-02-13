using System;
using System.IO;
using System.Text;

namespace PythonLexerLibrary
{
    public class AstPrettyPrinter
    {
        private readonly TextWriter writer;

        public AstPrettyPrinter(TextWriter writer)
        {
            this.writer = writer;
        }

        public void Print(AstNode node)
        {
            if (node == null) return;

            var indentLevel = 0;
            Print(node, ref indentLevel);
        }

        private void Print(AstNode node, ref int indentLevel)
        {
            // Implement the pretty printing logic here
            // For example:
            Console.WriteLine(new string(' ', indentLevel * 4) + node.ToString());

            if (node is CompoundStatement compoundStatement)
            {
                foreach (var statement in compoundStatement.Statements)
                {
                    Visit(statement);
                }
            }

            // Add more visit methods for other nodes as needed
        }

To create a .NET 9.0 solution that lexes the given grammar, generates an Abstract Syntax Tree (AST), and includes a Pretty Printer for the AST, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project and key points of logic for easy comprehension.**

Below is the structure and code for the solution based on the provided requirements.

### File System Structure