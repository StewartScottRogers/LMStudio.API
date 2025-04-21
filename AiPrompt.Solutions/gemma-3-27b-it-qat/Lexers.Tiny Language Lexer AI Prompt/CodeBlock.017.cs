using System;
using System.Text;

namespace LexerLibrary;

public class AstPrettyPrinter
{
    private readonly StringBuilder _stringBuilder = new StringBuilder();
    private int _indentLevel = 0;

    public string Print(AstNode node)
    {
        _stringBuilder.Clear();
        PrintNode(node);
        return _stringBuilder.ToString();
    }

    private void PrintNode(AstNode node, bool isLast = true)
    {
        Indent();
        _stringBuilder.Append($"{node.NodeType}: ");

        switch (node)
        {
            case ProgramNode programNode:
                _stringBuilder.AppendLine("Program");
                foreach (var statement in programNode.Statements)
                {
                    PrintNode(statement);
                }
                break;
            case StatementListNode statementListNode:
                _stringBuilder.AppendLine("Statement List");
                foreach (var statement in statementListNode.Statements)
                {
                    PrintNode(statement);
                }
                break;
            case AssignStatementNode assignStatementNode:
                _stringBuilder.Append($"Assign '{assignStatementNode.Identifier}' = ");
                PrintNode(assignStatementNode.Expression);
                _stringBuilder.AppendLine();
                break;
            case IfStatementNode ifStatementNode:
                _stringBuilder.AppendLine("If Statement");
                PrintNode(ifStatementNode.Condition);
                PrintNode(ifStatementNode.ThenBlock);
                break;
            case WhileStatementNode whileStatementNode:
                _stringBuilder.AppendLine("While Statement");
                PrintNode(whileStatementNode.Condition);
                PrintNode(whileStatementNode.DoBlock);
                break;
            case PrintStatementNode printStatementNode:
                _stringBuilder.Append($"Print ");
                PrintNode(printStatementNode.Expression);
                _stringBuilder.AppendLine();
                break;
            case ExpressionNode expressionNode:
                _stringBuilder.Append($"Expression '{expressionNode.Operator}'");
                PrintNode(expressionNode.Left);
                PrintNode(expressionNode.Right);
                break;
            case TermNode termNode:
                _stringBuilder.Append($"Term '{termNode.Operator}'");
                PrintNode(termNode.Left);
                PrintNode(termNode.Right);
                break;
            case FactorNode factorNode:
                if (factorNode.Identifier != null)
                {
                    _stringBuilder.Append($"Factor Identifier '{factorNode.Identifier.Value}'");
                    _stringBuilder.AppendLine();
                }
                else if (factorNode.Number != null)
                {
                    _stringBuilder.Append($"Factor Number '{factorNode.Number.Value}'");
                    _stringBuilder.AppendLine();
                }
                else if (factorNode.Expression != null)
                {
                    _stringBuilder.Append("Factor Expression ");
                    PrintNode(factorNode.Expression);
                }
                break;
            case IdentifierNode identifierNode:
                _stringBuilder.Append($"Identifier '{identifierNode.Value}'");
                _stringBuilder.AppendLine();
                break;
            case NumberNode numberNode:
                _stringBuilder.Append($"Number '{numberNode.Value}'");
                _stringBuilder.AppendLine();
                break;
            default:
                _stringBuilder.AppendLine("Unknown Node Type");
                break;
        }

    }

    private void Indent()
    {
        for (int i = 0; i < _indentLevel; i++)
        {
            _stringBuilder.Append("  ");
        }
    }
}