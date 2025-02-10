using System;

public class Program
{
    public static void Main(string[] args)
    {
        var sourceCode = @"namespace Example { public class HelloWorld { public static void Main() { Console.WriteLine(""Hello, World!""); } } }";
        var lexer = new RoslynLexer(sourceCode);
        var syntaxTree = lexer.GenerateSyntaxTree();
        var root = syntaxTree.GetRoot();

        var prettyPrinter = new AstPrettyPrinter(root);
        Console.WriteLine(prettyPrinter.PrettyPrint());

        var reflowGenerator = new AstReflowGenerator(root);
        Console.WriteLine(reflowGenerator.GenerateCode());
    }
}