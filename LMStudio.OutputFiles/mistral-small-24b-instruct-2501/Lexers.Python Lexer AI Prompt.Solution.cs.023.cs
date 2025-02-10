using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class AstNode
    {
        public readonly string TokenValue;
        protected AstNode(string tokenValue)
        {
            TokenValue = tokenValue;
        }
    }

    // Define all nodes in the Abstract Syntax Tree here

    public sealed class CompoundStmt : AstNode
    {
        private readonly List<Statement> Statements;

        public CompoundStmt(List<Statement> statements)
        {
            Statements = statements;
        }

        // Additional methods and properties can be added as needed.
    }
}

public interface IAbstractSyntaxTreeVisitor
{
    void Visit(AstNode node);
}

public abstract class AstNode
{
    public abstract void Accept(IAbstractSyntaxTreeVisitor visitor);

    // Other common properties and methods for AST nodes can be added here.
}

// Define the various types of AST nodes based on the given grammar.