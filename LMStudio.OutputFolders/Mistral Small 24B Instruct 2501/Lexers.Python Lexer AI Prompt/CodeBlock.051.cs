using System;
using System.IO;

namespace LexerLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.txt";
            string outputPath = "output.txt";

            if (File.Exists(inputPath))
            {
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    string content = reader.ReadToEnd();
                    var lexerResultTuple = Lexer.Lex(content);
                    if (!lexerResultTuple.Success)
                    {
                        Console.WriteLine("Lexing failed: " + lexerResultTuple.ErrorMessage);
                        return;
                    }

                    // Pretty print the AST
                    var prettyPrinter = new AstPrettyPrinter();
                    string astString = prettyPrinter.PrettyPrint(ast);
                    Console.WriteLine(astString);

To create a .NET 9.0 Solution that includes a Class Library for Lexing the provided Grammar, generating an Abstract Syntax Tree (AST), and creating a Pretty Printer for the AST, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure ensuring each class, interface, enumeration, and record is in its own file.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project and key points of logic for easy comprehension.**

Let's break down the solution into manageable steps:

### Step 1: Initialize a New Solution
1. Open Visual Studio 2022.
2. Create a new solution named `PythonLexer`.
3. Add a new Class Library Project to the solution.

### File Structure