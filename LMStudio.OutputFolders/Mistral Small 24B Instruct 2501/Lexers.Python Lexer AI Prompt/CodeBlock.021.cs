using System;
using System.Collections.Generic;

public record StatementTuple(Statement Statement)
{
    public override string ToString()
    {
        return $"Statement: {Statement}";
    }
}

public abstract class AstNode
{
}

public class CompoundStmt : AstNode
{
}

public class SimpleStmts : AstNode
{
}

public class Assignment : AstNode
{
}

public class TypeAlias : AstNode
{
}

public class StarExpressions : AstNode
{
}

public class ReturnStmt : AstNode
{
}

public class ImportStmt : AstNode
{
}

public class RaiseStmt : AstNode
{
}

public class PassStmt : AstNode
{
}

public class DelStmt : AstNode
{
}

public class YieldStmt : AstNode
{
}

public class AssertStmt : AssertionErrorTuple
{
    public Expression Condition { get; set; }
    public Expression Message { get; set; }

    public void PrettyPrint()
    {
        Console.WriteLine($"Assert {Condition.PrettyPrint()} {Message?.PrettyPrint()}");
    }
}

public class BreakStmt
{
}

public class ContinueStmt
{
}

public class GlobalStmt
{
}

public class NonlocalStmt
{
}

public class PassStmt
{
    public void PrettyPrint()
    {
        Console.WriteLine("pass");
    }

    public override string ToString()
    {
        return "PassStmt";
    }
}


# File System Structure

We will organize the solution into separate files for each class, interface, enumeration, and record. Here is the proposed file structure: