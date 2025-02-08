public class AstPrinter
{
    public void Print(Node node)
    {
        if (node is ProgramNode programNode) 
            Console.WriteLine($"Program({Print(programNode.Block)})");
        
        // Implement other node types.
    }
}