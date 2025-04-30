public class AstPrinter
{
    public void Print(Node node)
    {
        if (node is ProgramNode programNode)
        {
            Console.WriteLine("Program:");
            VisitStmtList(programNode.StmtList, 1);
        }
    }

    private void VisitStmtList(StmtListNode stmtListNode, int indentLevel)
    {
        var current = stmtListNode;
        while (current != null)
        {
            PrintIndent(indentLevel);
            if (current.Statement is AssignStmtNode assignStmtNode)
                Console.WriteLine($"Assignment: {assignStmtNode.Identifier.IdentifierToken.Value}");
            else if (current.Statement is IfStmtNode ifStmtNode)
                Console.WriteLine("If:");
            else if (current.Statement is WhileStmtNode whileStmtNode)
                Console.WriteLine("While:");
            else if (current.Statement is PrintStmtNode printStmtNode)
                Console.WriteLine("Print:");

            current = current.Next;
        }
    }

    private void PrintIndent(int indentLevel)
    {
        for (int i = 0; i < indentLevel; i++)
            Console.Write("\t");
    }
}