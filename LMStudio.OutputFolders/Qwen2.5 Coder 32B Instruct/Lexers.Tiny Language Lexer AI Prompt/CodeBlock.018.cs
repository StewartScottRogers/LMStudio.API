using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");
        var lexer = new Lexer(input);
        var tokens = lexer.Lex().ToList();
        var printer = new PrettyPrinter();

        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Kind} - {token.Value}");
        }

        // Assuming we have a parser, it would generate the AST here
        // For demonstration, let's assume we have an AST node
        var astNode = new AssignmentStatement("x", new BinaryExpression(
            new NumberLiteral(10),
            new Token(TokenKind.Plus, "+"),
            new NumberLiteral(20)
        ));

        astNode.Accept(printer);
        Console.WriteLine(printer.GetOutput());
    }
}