using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class AbstractSyntaxTreeNode
    {
        public string NodeType { get; }
        protected readonly List<AbstractSyntaxTreeNode> ChildNodes = new();

        protected AbstractSyntaxTreeNode(string nodeType)
        {
            NodeType = nodeType;
        }

        public void AddChild(AbstractSyntaxTreeNode child)
        {
            ChildNodes.Add(child);
        }

        public IEnumerable<AbstractSyntaxTreeNode> GetChildren()
        {
            return ChildNodes;
        }
    }

This solution will be organized as follows:

### Project Structure
1. **LexerProject.sln**: Solution file.
2. **LexerLibrary.csproj**: Class library project file.
3. **Lexer.cs**: Main lexer class.
4. **SyntaxNode.cs**: Base class for all syntax nodes.
5. **AbstractSyntaxTreePrinter.cs**: Pretty printer for the Abstract Syntax Tree (AST).
6. **UnitTests.cs**: Unit tests for the lexer.

### File Structure