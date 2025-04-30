using System.Text;

namespace LexerLibrary
{
    public class PrettyPrinter
    {
        private readonly StringBuilder output = new();

        public string Print(ASTNode node)
        {
            switch (node)
            {
                case AssignStmt assign:
                    output.Append($"{assign.Identifier} := {Print(assign.Expression)}");
                    break;
                case IfStmt ifStmt:
                    output.Append($"if {Print(ifStmt.Condition)} then\n");
                    foreach (var stmt in ifStmt.Statements) Print(stmt);
                    output.Append("end\n");
                    break;
                case WhileStmt whileStmt:
                    output.Append($"while {Print(whileStmt.Condition)} do\n");
                    foreach (var stmt in whileStmt.Statements) Print(stmt);
                    output.Append("end\n");
                    break;
                case PrintStmt printStmt:
                    output.Append($"print {Print(printStmt.Expression)}\n");
                    break;
                case Number number:
                    output.Append(number.Value.ToString());
                    break;
                case Id id:
                    output.Append(id.Name);
                    break;
            }

            return output.ToString();
        }
    }
}