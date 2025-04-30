Creating a complete .NET 9.0 solution with the specified requirements involves several steps, especially considering that as of my last update, .NET 9.0 has not been released yet. However, I'll proceed based on current practices and assume hypothetical changes for .NET 9.0.

Below is how you can structure such a solution using Visual Studio 2022 and C#:

### Project Structure
We will create a solution with the following projects:
- RoslynAstGenerator (Console Application)
- RoslynAstTests (Unit Test project)

#### Solution File: `RoslynAst.sln`
This file ties together all the projects in the solution.

#### Project Files:
1. **RoslynAstGenerator**:
   - Contains classes, interfaces, enums, records for generating and processing the Abstract Syntax Tree.
   
2. **RoslynAstTests**:
   - Unit tests to test the functionality of `RoslynAstGenerator`.

### File System Structure
- **RoslynAstGenerator**
  - Program.cs: Entry point of the application.
  - AstGenerator.cs: Contains logic to generate and process the Abstract Syntax Tree.
  - AstPrettyPrinter.cs: Prints the AST.
  - AstReflowGenerator.cs: Reflows the AST to executable code.
  - ICodeGenerator.cs: Interface for code generation.
  
- **RoslynAstTests**
  - LexingTests.cs: Contains unit tests.

### Implementation Details

#### RoslynAstGenerator/Program.cs
```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var code = "class Sample { public int Id { get; set; } }";
            var astGenerator = new AstGenerator();
            
            var syntaxTree = astGenerator.GenerateAst(code);
            var prettyPrintedAst = astGenerator.PrettyPrint(syntaxTree);

            Console.WriteLine("Pretty Printed AST:");
            Console.WriteLine(prettyPrintedAst);
            
            // Reflow the code and execute
            var executableCode = astGenerator.ReflowToExecutableCode(syntaxTree);
            Console.WriteLine("Reflowed Executable Code:");
            Console.WriteLine(executableCode);
        }
    }
}
```

#### RoslynAstGenerator/AstGenerator.cs
```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    public class AstGenerator : ICodeGenerator
    {
        public SyntaxTree GenerateAst(string code)
        {
            return CSharpSyntaxTree.ParseText(code);
        }

        public string PrettyPrint(SyntaxTree syntaxTree)
        {
            var prettyPrinter = new AstPrettyPrinter();
            return prettyPrinter.Print(syntaxTree.GetRoot());
        }

        public string ReflowToExecutableCode(SyntaxTree syntaxTree)
        {
            var reflowGenerator = new AstReflowGenerator();
            return reflowGenerator.Reflow(syntaxTree.GetRoot());
        }
    }
}
```

#### RoslynAstGenerator/ICodeGenerator.cs
```csharp
using Microsoft.CodeAnalysis;

namespace RoslynAstGenerator
{
    public interface ICodeGenerator
    {
        SyntaxTree GenerateAst(string code);
        
        string PrettyPrint(SyntaxTree syntaxTree);
        
        string ReflowToExecutableCode(SyntaxTree syntaxTree);
    }
}
```

#### RoslynAstGenerator/AstPrettyPrinter.cs
```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    public class AstPrettyPrinter
    {
        public string Print(SyntaxNode node)
        {
            var printer = new System.Text.StringBuilder();
            
            // Simple example of pretty printing, expand as needed
            foreach (var child in node.ChildNodes())
            {
                printer.Append(child.ToFullString());
            }

            return printer.ToString();
        }
    }
}
```

#### RoslynAstGenerator/AstReflowGenerator.cs
```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    public class AstReflowGenerator
    {
        public string Reflow(SyntaxNode node)
        {
            // Simple example of reflowing, expand as needed
            return node.ToFullString();
        }
    }
}
```

#### RoslynAstTests/LexingTests.cs
```csharp
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoslynAstTests
{
    [TestClass]
    public class LexingTests
    {
        private readonly ICodeGenerator astGenerator = new AstGenerator();

        [TestMethod]
        public void TestSimpleClass()
        {
            var code = "class Sample { public int Id { get; set; } }";
            var syntaxTree = astGenerator.GenerateAst(code);
            
            Assert.IsNotNull(syntaxTree);
        }

        // Add more tests as required
    }
}
```

### Compilation and Execution
- Open Visual Studio 2022.
- Create a new solution with the above structure.
- Add the necessary project references (e.g., `Microsoft.CodeAnalysis.CSharp` for Roslyn).
- Compile and run the application.

This is a basic starting point that adheres to the guidelines you've provided. You can expand on this by implementing more detailed AST processing, pretty printing, and unit tests as required.