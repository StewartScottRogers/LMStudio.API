using System.Text;

namespace LexerLibrary
{
    public class AstPrettyPrinter
    {
        private readonly StringBuilder builder = new();

        public string Print(AstNode root)
        {
            PrintNode(root);
            return builder.ToString();
        }

        private void PrintNode(AstNode node, int depth = 0)
        {
            var indent = new string(' ', depth * 2);
            if (node is ProgramNode) { builder.AppendLine($"{indent}Program"); }
            else if (node is StmtListNode) { builder.AppendLine($"{indent}StmtList"); }
            else if (node is AssignStmtNode assignStmt)
            {
                builder.AppendLine($"{indent}AssignStmt");
                PrintNode(assignStmt.IdToken, depth + 1);
                PrintNode(assignStmt.ExprToken, depth + 1);
            }
            else if (node is IfStmtNode ifStmt)
            {
                builder.AppendLine($"{indent}IfStmt");
                PrintNode(ifStmt.CondToken, depth + 1);
                PrintNode(ifStmt.ThenBody, depth + 1);
            }
            else if (node is WhileStmtNode whileStmt)
            {
                builder.AppendLine($"{indent}WhileStmt");
                PrintNode(whileStmt.CondToken, depth + 1);
                PrintNode(whileStmt.DoBody, depth + 1);
            }
            else if (node is PrintStmtNode printStmt)
            {
                builder.AppendLine($"{indent}PrintStmt");
                PrintNode(printStmt.ExprToken, depth + 1);
            }
            // Add more node types as needed

            foreach (var child in node.GetChildren())
            {
                PrintNode(child, depth + 1);
            }
        }

        private void PrintNode(Token token, int depth)
        {
            var indent = new string(' ', depth * 2);
            builder.AppendLine($"{indent}{token.Type} {token.Value}");
        }
    }
}