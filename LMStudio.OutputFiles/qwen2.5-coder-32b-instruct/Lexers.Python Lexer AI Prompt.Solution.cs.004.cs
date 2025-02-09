using System.Text;

namespace PythonASTPrinter
{
    public class PrettyPrinter
    {
        private readonly StringBuilder stringBuilder = new();

        public void Print(PythonAST.Node node, int indentLevel = 0)
        {
            var indent = new string(' ', indentLevel * 2);
            if (node is PythonAST.Statement statement)
            {
                foreach (var stmt in statement.Statements)
                    Print(stmt, indentLevel + 1);
            }
            // ... handle other nodes
            stringBuilder.AppendLine();
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}