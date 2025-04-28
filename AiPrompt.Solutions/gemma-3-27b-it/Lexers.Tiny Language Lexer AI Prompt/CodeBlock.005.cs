// AssignStmtNode.cs
namespace LexerAstCore
{
    public class AssignStmtNode : AstNode
    {
        public readonly string Identifier;
        public readonly AstNode Expression;

        public AssignStmtNode(string identifier, AstNode expression)
        {
            Identifier = identifier;
            Expression = expression;
        }

        public override void Print(int indent)
        {
            Console.WriteLine($"{new string(' ', indent)}Assign Statement: {Identifier} := ");
            Expression.Print(indent + 4);
        }
    }
}