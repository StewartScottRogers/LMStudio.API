using System;
using System.Collections.Generic;

namespace LexerSolution
{
    public abstract class AbstractSyntaxTree
    {
        public readonly IReadOnlyList<AbstractSyntaxNode> Nodes;

        protected AbstractSyntaxTree(IReadOnlyList<AbstractSyntaxNode> nodes)
        {
            Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
        }

        public virtual void PrettyPrint(StreamWriter writer, int indentLevel = 0)
        {
            var indentation = new string(' ', indentLevel * 4);
            foreach (var node in Nodes)
            {
                writer.WriteLine($"{indentation}{node.ToString()}");
                node.PrettyPrint(writer, indentLevel + 1);
            }
        }

To create a .NET 9.0 Solution that includes a Lexer for the given grammar, an Abstract Syntax Tree (AST) Pretty Printer, and all nodes in the AST, follow these steps:

### Step 1: Initialize the Solution

1. Open Visual Studio 2022.
2. Create a new `.NET` Class Library project named `LexerLibrary`.
3. Add the following project structure:
    - **Classes**: Each class will be in its own file.
    - **Interfaces**: Each interface will be in its own file.
    - **Enumerations**: Each enumeration will be in its own file.
    - **Records**: Each record will be in its own file.

### Solution Structure

1. **Lexer.cs**: Contains the lexer class to tokenize the input.
2. **AstNode.cs**: Base class for all AST nodes.
3. **AstVisitor.cs**: Interface for visiting AST nodes.
4. **StatementNodes.cs**: Classes for statement-related AST nodes.
5. **ExpressionNodes.cs**: Classes for expression-related AST nodes.
6. **PrettyPrinter.cs**: Class to pretty print the Abstract Syntax Tree (AST).
7. **Lexer.cs**: Lexer class to tokenize input based on the given grammar.

Below is the detailed structure and code implementation adhering to the provided guidelines:

### Solution Structure