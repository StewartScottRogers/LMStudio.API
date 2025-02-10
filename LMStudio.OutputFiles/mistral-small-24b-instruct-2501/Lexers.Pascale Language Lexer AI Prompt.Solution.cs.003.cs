using System.Text;

namespace PascalLexerClassLibrary
{
    public class AstPrettyPrinter
    {
        private readonly StringBuilder builder = new();

        public string Print(AstNode node)
        {
            builder.Clear();
            Visit(node);
            return builder.ToString();
        }

        private void Visit(AstNode node)
        {
            if (node is ProgramNode programNode)
            {
                VisitProgramNode(programNode);
            }
            // Implement other visit methods for different AST nodes
        }

        private void VisitProgramNode(ProgramNode node)
        {
            builder.AppendLine($"program {node.Identifier} ;");
            builder.AppendLine(node.Block.ToString());
            builder.Append(".");
        }

        // Define other visit methods for different AST nodes
    }
}