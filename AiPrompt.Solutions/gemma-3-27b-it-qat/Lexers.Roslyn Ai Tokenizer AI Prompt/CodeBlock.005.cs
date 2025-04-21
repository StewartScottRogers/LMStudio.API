using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstGenerator.Core;

public class CompilationUnit
{
    private readonly List<StatementRecord> statementsList = new();

    public void AddStatement(string statementValue, NodeType nodeTypeValue)
    {
        statementsList.Add(new StatementRecord(statementValue, nodeTypeValue));
    }

    public (SyntaxTree SyntaxTreeTuple, CompilationUnit CompilationUnitTuple) GenerateAstFromCode(string sourceCode)
    {
        // Use Roslyn to parse the code and create an AST
        var tree = CSharpSyntaxTree.ParseText(sourceCode);
        return (tree, this);
    }

    public string PrettyPrint()
    {
        readonly string prettyPrintedAst = statementsList.Aggregate("", (currentValue, statementTuple) => currentValue + $"{statementTuple.NodeType}: {statementTuple.Value}\n");
        return prettyPrintedAst;
    }

    public void Reflow(string sourceCode)
    {
        // Implement AST reflowing logic here using Roslyn
        // This is a placeholder for code generation/execution
        Console.WriteLine($"Reflowing code: {sourceCode}");
    }
}