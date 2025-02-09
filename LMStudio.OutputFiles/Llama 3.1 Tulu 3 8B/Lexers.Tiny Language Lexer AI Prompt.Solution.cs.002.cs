using System;

public class AstPrettyPrinter : IVisitor
{
    public void Visit(ASTNode node)
    {
        Console.Write(node.GetType().Name);
        if (node is IdentifierNode identifierNode)
            Console.WriteLine($" ({identifierNode.Value})");
        else if (node is NumberLiteralNode numberLiteralNode)
            Console.WriteLine($" {numberLiteralNode.Value}");
        // Handle other AST nodes
    }

    // Define Visit methods for each specific AST node type.
}

// Example usage:
var printer = new AstPrettyPrinter();
astRoot.Accept(printer);