// ProgramNode.cs
using System.Collections.Generic;

namespace LexerAstCore
{
    public class ProgramNode : AstNode
    {
        public readonly List<AstNode> Statements;

        public ProgramNode(List<AstNode> statements)
        {
            Statements = statements;
        }

        public override void Print(int indent)
        {
            Console.WriteLine($"{new string(' ', indent)}Program");
            foreach (var statement in Statements)
            {
                statement.Print(indent + 4);
            }
        }
    }
}