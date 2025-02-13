namespace LexerLibrary
{
    public class PrettyPrinter
    {
        public string Print(AstNode node)
        {
            if (node is ProgramNode programNode)
            {
                return PrintProgram(programNode);
            }

            throw new InvalidOperationException("Unknown AST node type");
        }

        private string PrintProgram(ProgramNode node)
        {
            // Implement program printing logic
        }
    }
}