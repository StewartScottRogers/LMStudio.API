// File: AstPrinter.cs
using System.Text;

namespace PascaleLexer
{
    public class AstPrinter
    {
        private readonly StringBuilder _builder = new();

        public void Print(AstNode ast)
        {
            PrintAst(ast, 0);
            Console.WriteLine(_builder.ToString());
        }

        private void PrintAst(AstNode node, int indentLevel)
        {
            var indent = new string(' ', indentLevel * 4);

            switch (node)
            {
                case ProgramNode programNode:
                    _builder.AppendLine($"{indent}Program {programNode.Identifier.Value} {{");
                    PrintAst(programNode.Block, indentLevel + 1);
                    _builder.AppendLine($"{indent}}}");
                    break;
                // Handle other node types...
            }
        }
    }
}