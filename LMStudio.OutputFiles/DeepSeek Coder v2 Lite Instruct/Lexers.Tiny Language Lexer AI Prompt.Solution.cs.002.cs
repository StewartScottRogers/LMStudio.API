using System;

public class ASTPrinter
{
    public void Print(ASTNode node, string indent = "")
    {
        if (node == null) return;

        switch (node)
        {
            case ProgramNode program:
                Console.WriteLine($"{indent}Program");
                PrintStatements(program.Statements, $"{indent}  ");
                break;
            case StatementListNode statements:
                PrintStatements(statements, indent);
                break;
            case AssignStatementNode assign:
                Console.WriteLine($"{indent}Assign {assign.Target.Name} :=");
                Print(assign.Value, $"{indent}  ");
                break;
            case IfStatementNode _if:
                Console.WriteLine($"{indent}If");
                Print(_if.Condition, $"{indent}  ");
                Print(_if.ThenBranch, $"{indent}  ");
                break;
            case WhileStatementNode _while:
                Console.WriteLine($"{indent}While");
                Print(_while.Condition, $"{indent}  ");
                Print(_while.Body, $"{indent}  ");
                break;
            case PrintStatementNode print:
                Console.WriteLine($"{indent}Print");
                Print(print.Expression, $"{indent}  ");
                break;
            case BinaryExpressionNode binary:
                Console.WriteLine($"{indent}{binary.Operator.Type}");
                Print(binary.Left, $"{indent}  ");
                Print(binary.Right, $"{indent}  ");
                break;
            case IdentifierNode identifier:
                Console.WriteLine($"{indent}{identifier.Name}");
                break;
            case NumberNode number:
                Console.WriteLine($"{indent}{number.Value}");
                break;
        }
    }

    private void PrintStatements(StatementListNode statements, string indent)
    {
        foreach (var statement in statements.Statements)
        {
            Print(statement, indent);
            Console.WriteLine();
        }
    }
}