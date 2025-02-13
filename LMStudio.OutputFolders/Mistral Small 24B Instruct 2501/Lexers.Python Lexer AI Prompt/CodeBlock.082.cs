using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class AstNode
    {
        // Base class for all AST nodes
        public readonly string NodeType;
        protected AstNode(string nodeType)
        {
            this.NodeType = nodeType;
        }
    }

    public class StatementsList : AstNode
    {
        public List<AstNode> Statements { get; init; } = new List<AstNode>();
        public StatementsList()
           : base("StatementsList")
        {
        }
    }

    public abstract class Statement : AstNode
    {

    }

    // Simple statements
    public record AssignmentStatement(string Name, string Expression) : Statement;

    public record TypeAliasStatement(string Name, string TypeParams, string Expression) : Statement;
    public record StarExpressionsStatement(StarExpressionsTuple StarExpressions);
    public record ReturnStatement(StarExpressionsTuple StarExpressions); ;
    public record ImportStatement(DottedAsNamesTuple DottedAsNames);
    public record RaiseStatement(string? Expression, string? FromExpression) { };
    public record AssertStatement(string Expression, string? SecondExpression) { };
    public enum Keyword
    {
        Return,
        ImportFrom,
        Pass,
        Del,
        Yield,
        Break,
        Continue,
        Global,
        Nonlocal,
        If,
        For,
        While,
        With,
        Match,
        Try,
        Except,
        Finally,
        Else,
        Elif,
        Raise,
        Return,
        Assert,
        TypeAlias