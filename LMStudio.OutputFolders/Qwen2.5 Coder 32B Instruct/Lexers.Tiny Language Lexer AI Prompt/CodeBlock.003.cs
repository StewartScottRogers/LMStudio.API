using System;
using System.Text;

namespace GrammarParser
{
    public class PrettyPrinter
    {
        private readonly Node RootNode;

        public PrettyPrinter(Node rootNode)
        {
            RootNode = rootNode ?? throw new ArgumentNullException(nameof(rootNode));
        }

        public string Print()
        {
            var sb = new StringBuilder();
            PrettyPrint(RootNode, 0, ref sb);
            return sb.ToString();
        }

        private void PrettyPrint(Node node, int indentLevel, ref StringBuilder sb)
        {
            Indent(indentLevel, ref sb);

            if (node is EmptyNode)
            {
                sb.AppendLine("Empty");
                return;
            }
            else if (node is StmtListNode stmtListNode)
            {
                sb.AppendLine("StmtList:");
                PrettyPrint(stmtListNode.Stmt, indentLevel + 1, ref sb);
                PrettyPrint(stmtListNode.NextStmtList, indentLevel + 1, ref sb);
            }
            else if (node is AssignNode assignNode)
            {
                sb.AppendLine($"Assign: {assignNode.Identifier}");
                PrettyPrint(assignNode.Expression, indentLevel + 1, ref sb);
            }
            else if (node is IfNode ifNode)
            {
                sb.AppendLine("If:");
                Indent(indentLevel + 1, ref sb);
                sb.AppendLine("Condition:");
                PrettyPrint(ifNode.Condition, indentLevel + 2, ref sb);

                Indent(indentLevel + 1, ref sb);
                sb.AppendLine("Then Part:");
                PrettyPrint(ifNode.ThenPart, indentLevel + 2, ref sb);
            }
            else if (node is WhileNode whileNode)
            {
                sb.AppendLine("While:");
                Indent(indentLevel + 1, ref sb);
                sb.AppendLine("Condition:");
                PrettyPrint(whileNode.Condition, indentLevel + 2, ref sb);

                Indent(indentLevel + 1, ref sb);
                sb.AppendLine("Body:");
                PrettyPrint(whileNode.Body, indentLevel + 2, ref sb);
            }
            else if (node is PrintNode printNode)
            {
                sb.AppendLine("Print:");
                PrettyPrint(printNode.Expression, indentLevel + 1, ref sb);
            }

            // Expressions
            else if (node is BinaryOpNode binaryOpNode)
            {
                var op = binaryOpNode.Operator switch
                {
                    TokenType.Plus => "+",
                    TokenType.Minus => "-",
                    TokenType.Multiply => "*",
                    TokenType.Divide => "/",
                    _ => throw new InvalidOperationException($"Unexpected operator: {binaryOpNode.Operator}")
                };

                sb.AppendLine($"BinaryOp: {op}");
                PrettyPrint(binaryOpNode.Left, indentLevel + 1, ref sb);
                PrettyPrint(binaryOpNode.Right, indentLevel + 1, ref sb);
            }
            else if (node is NumberNode numberNode)
            {
                sb.AppendLine($"Number: {numberNode.Value}");
            }
            else if (node is IdentifierNode identifierNode)
            {
                sb.AppendLine($"Identifier: {identifierNode.Name}");
            }
        }

        private void Indent(int indentLevel, ref StringBuilder sb)
        {
            for (int i = 0; i < indentLevel; i++)
                sb.Append("    ");
        }
    }
}