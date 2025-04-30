using System;
using RoslynAstLibrary;

namespace RoslynAstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCase = new LexingTestCases(LexingTestCases.TestCase.SimpleClass);
            var astBuilderTests = new AstBuilderTests(testCase);

            Console.WriteLine("Running AST Tests...");
            astBuilderTests.RunAllTests();
            Console.WriteLine("AST Tests Completed.");
        }
    }
}