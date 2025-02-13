using System;
using System.Collections.Generic;

public class PrettyPrinter
{
    private readonly List<Stmt> statements;

    public PrettyPrinter(List<Stmt> stmts)
    {
        this.statements = stmts;
    }

    public string Print()
    {
        StringBuilder sb = new();
        foreach (var stmt in statements)
            sb.Append(PrettyPrintStatement(stmt) + "\n");

        return sb.ToString();
    }

    private string PrettyPrintStatement(Stmt stmt)
    {
        switch (stmt)
        {
            case AssignStmt a:
                return $"{a.Ident} := {PrettyPrintExpression(a.Expr)}";
            case IfStmt i:
                return $"if {i.Conditional} then {PrettyPrintStatements(i.Body)} end";
            case WhileStmt w:
                return $"while {w.Condition} do {PrettyPrintStatements(w.Body)} end";
            case PrintStmt p:
                return $"{p.Print} {p.Ident}";
            default: throw new ArgumentException("Unexpected statement type");
        }
    }

    private string PrettyPrintStatements(List<Stmt> stmts)
    {
        if (!stmts.Count) return "";

        var statements = new StringBuilder();
        foreach (var stmt in stmts)
            statements.Append(PrettyPrintStatement(stmt));

        return statements.ToString();
    }
}