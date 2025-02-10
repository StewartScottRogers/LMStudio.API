using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class AstNode
    {
        protected readonly List<AstNode> Children = new();

        public void AddChild(AstNode child)
        {
            Children.Add(child);
        }

        public IEnumerable<AstNode> GetChildren()
        {
            return Children;
        }
    }

    public record ProgramNode : AstNode { }
    public record StmtListNode : AstNode { }
    public record AssignStmtNode : AstNode
    {
        public Token IdToken { get; init; }
        public Token ExprToken { get; init; }
    }
    public record IfStmtNode : AstNode
    {
        public Token CondToken { get; init; }
        public StmtListNode ThenBody { get; init; }
    }
    public record WhileStmtNode : AstNode
    {
        public Token CondToken { get; init; }
        public StmtListNode DoBody { get; init; }
    }
    public record PrintStmtNode : AstNode
    {
        public Token ExprToken { get; init; }
    }

    // Add more node types as needed for expr, term, factor, etc.
}