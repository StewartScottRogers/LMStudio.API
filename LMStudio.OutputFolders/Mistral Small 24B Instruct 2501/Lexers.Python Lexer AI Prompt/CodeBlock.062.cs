namespace LexerLibrary
{
    public interface INodeVisitor
    {
        void Visit(Node node);
    }

    public class Node
    {
        // Base class for all nodes in the Abstract Syntax Tree (AST)
        public void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

Given the requirements and the grammar provided, we will create a .NET 9.0 Class Library solution that includes:

1. A Lexer to tokenize the input based on the given grammar.
2. An Abstract Syntax Tree (AST) generation from the tokens.
3. An AST Pretty Printer to visualize the tree.
4. Unit tests using Microsoft's Unit Test Framework.

Let's break down the steps to create this solution in C# with Visual Studio 2022, adhering to the coding style and guidelines provided.

### Solution Structure

1. **Solution Name**: `LexerSolution`
2. **Project Name**: `LexerLibrary`

### Project Files

1. **Interfaces**
   - IToken.cs
   - ILexer.cs
   - INode.cs
   - IStatementNode.cs
   - IExpressionNode.cs
   - ICompoundStatementNode.cs
   - ISimpleStatementNode.cs
   - IFunctionDefNode.cs
   - IClassDefNode.cs

- **IToken.cs**