// File: AstNode.cs
namespace LexerLibrary.Ast
{
    public abstract class AstNode { }
}

// File: StatementNode.cs
namespace LexerLibrary.Ast
{
    public class StatementNode : AstNode { }
}

// File: ExpressionNode.cs
namespace LexerLibrary.Ast
{
    public class ExpressionNode : AstNode { }
}

// File: PrintStatementNode.cs
namespace LexerLibrary.Ast
{
    public class PrintStatementNode : StatementNode
    {
        public readonly ExpressionNode Expression;

        public PrintStatementNode(ExpressionNode expression)
        {
            Expression = expression;
        }
    }
}

// File: AssignStatementNode.cs
namespace LexerLibrary.Ast
{
    public class AssignStatementNode : StatementNode
    {
        public readonly string Id;
        public readonly ExpressionNode Expression;

        public AssignStatementNode(string id, ExpressionNode expression)
        {
            Id = id;
            Expression = expression;
        }
    }
}

// File: IfStatementNode.cs
namespace LexerLibrary.Ast
{
    public class IfStatementNode : StatementNode
    {
        public readonly ExpressionNode Condition;
        public readonly StatementListNode Body;

        public IfStatementNode(ExpressionNode condition, StatementListNode body)
        {
            Condition = condition;
            Body = body;
        }
    }
}

// File: WhileStatementNode.cs
namespace LexerLibrary.Ast
{
    public class WhileStatementNode : StatementNode
    {
        public readonly ExpressionNode Condition;
        public readonly StatementListNode Body;

        public WhileStatementNode(ExpressionNode condition, StatementListNode body)
        {
            Condition = condition;
            Body = body;
        }
    }
}

// File: AbstractSyntaxTree.cs
using LexerLibrary.Lexer;
using System.Collections.Generic;

namespace LexerLibrary.Ast
{
    public class AbstractSyntaxTree
    {
        private readonly List<StatementNode> statementList;

        public AbstractSyntaxTree()
        {
            statementList = new List<StatementNode>();
        }

        public var StatementListTuple GetStatements() => (statementList);
    }
}

// File: PrettyPrinter.cs
using System.Text;

namespace LexerLibrary.Ast
{
    public class PrettyPrinter
    {
        private readonly StringBuilder output;

        public PrettyPrinter()
        {
            output = new StringBuilder();
        }

        public string Print(AbstractSyntaxTree ast)
        {
            foreach (var statement in ast.GetStatements().statementList)
            {
                PrintStatement(statement);
            }
            return output.ToString();
        }

        private void PrintStatement(StatementNode node)
        {
            if (node is AssignStatementNode assignStmt)
            {
                PrintAssignStatement(assignStmt);
            }
            else if (node is IfStatementNode ifStmt)
            {
                PrintIfStatement(ifStmt);
            }
            else if (node is WhileStatementNode whileStmt)
            {
                PrintWhileStatement(whileStmt);
            }
            else if (node is PrintStatementNode printStmt)
            {
                PrintPrintStatement(printStmt);
            }
        }

        private void PrintAssignStatement(AssignStatementNode node)
        {
            output.Append(node.Id).Append(" := ").Append(PrintExpression(node.Expression)).AppendLine();
        }

        private void PrintIfStatement(IfStatementNode node)
        {
            output.Append("if ").Append(PrintExpression(node.Condition)).Append(" then").AppendLine();
            foreach (var stmt in node.Body.GetStatements().statementList)
            {
                PrintStatement(stmt);
            }
            output.AppendLine("end");
        }

        private void PrintWhileStatement(WhileStatementNode node)
        {
            output.Append("while ").Append(PrintExpression(node.Condition)).Append(" do").AppendLine();
            foreach (var stmt in node.Body.GetStatements().statementList)
            {
                PrintStatement(stmt);
            }
            output.AppendLine("end");
        }

        private void PrintPrintStatement(PrintStatementNode node)
        {
            output.Append("print ").Append(PrintExpression(node.Expression)).AppendLine();
        }

        private string PrintExpression(ExpressionNode node)
        {
            // Implement expression printing logic here.
            return "";
        }
    }
}