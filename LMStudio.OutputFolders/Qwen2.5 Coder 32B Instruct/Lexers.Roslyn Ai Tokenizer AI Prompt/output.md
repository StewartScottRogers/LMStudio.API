Creating a complete .NET 9.0 Solution with all these requirements is quite extensive, but I'll provide you with the necessary starting point for your application using Roslyn to generate and manipulate an Abstract Syntax Tree (AST). This solution will include setting up the project structure, writing key classes/interfaces/records, implementing the AST operations, and creating unit tests.

## Project Setup

1. **Create a new .NET 9.0 Console Application**:
   - Open Visual Studio 2022.
   - Create a new .NET Core Console App (.NET 6 or later) as .NET 9 is not yet available (as of my last update). Name it `RoslynAstApplication`.
   
2. **Add Roslyn Package References**:
   - Install the following NuGet packages:
     - `Microsoft.CodeAnalysis.CSharp`
     - `Microsoft.CodeAnalysis.Common`

## Solution Structure

1. **Project Files and Directories**:
   - Create directories named `Classes`, `Interfaces`, `Enums`, `Records`, and `Tests` inside your project directory.

2. **Source Files**:
   - Inside the `Classes` folder, create a file for each class.
   - Inside the `Interfaces` folder, create a file for each interface.
   - Inside the `Enums` folder, create a file for each enumeration.
   - Inside the `Records` folder, create a file for each record.

3. **Main Program File**:
   - In your solution, keep the default `Program.cs`.

## Key Classes/Interfaces/Records

### Interfaces
#### IAbstractSyntaxTreeService
```csharp
// Interfaces/IAbstractSyntaxTreeService.cs
using Microsoft.CodeAnalysis.CSharp.Syntax;

public interface IAbstractSyntaxTreeService
{
    CompilationUnitSyntax GenerateAstFromString(string code);
    string PrettyPrint(CompilationUnitSyntax ast);
    string ReflowCode(CompilationUnitSyntax ast);
}
```

### Classes
#### AbstractSyntaxTreeService
```csharp
// Classes/AbstractSyntaxTreeService.cs
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

public class AbstractSyntaxTreeService : IAbstractSyntaxTreeService
{
    public CompilationUnitSyntax GenerateAstFromString(string code)
    {
        return CSharpSyntaxTree.ParseText(code).GetRoot() as CompilationUnitSyntax;
    }

    public string PrettyPrint(CompilationUnitSyntax ast)
    {
        var writer = new StringWriter();
        ast.WriteTo(writer);
        return writer.ToString();
    }

    public string ReflowCode(CompilationUnitSyntax ast)
    {
        using (var workspace = new AdhocWorkspace())
        {
            var project = workspace.AddProject("GeneratedProject", LanguageNames.CSharp);
            var document = project.AddDocument("GeneratedFile.cs", ast.ToFullString());

            // Get the formatted code
            var formattedDocument = Formatter.FormatAsync(document).Result;
            return formattedDocument.GetTextAsync().Result.ToString();
        }
    }
}
```

### Records

No records are necessary for this basic example, but you can add them as needed.

## Unit Tests

1. **Setup**:
   - Add a new project to the solution by right-clicking the solution and selecting "Add" -> "New Project".
   - Choose "Unit Test App (.NET Core)" and name it `RoslynAstApplication.Tests`.

2. **Install Microsoft.VisualStudio.TestPlatform.TestFramework**:
   - This package is typically included in unit test projects, but ensure it's referenced.

3. **Test Files**:
   - In the `Tests` folder of your test project, create a file named `AbstractSyntaxTreeServiceTests.cs`.

#### AbstractSyntaxTreeServiceTests
```csharp
// RoslynAstApplication.Tests/AbstractSyntaxTreeServiceTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoslynAstApplication.Tests
{
    [TestClass]
    public class AbstractSyntaxTreeServiceTests
    {
        private readonly IAbstractSyntaxTreeService astService = new AbstractSyntaxTreeService();

        [TestMethod]
        public void GenerateAstFromString_ShouldNotBeNull()
        {
            var code = "class Program { static void Main() {} }";
            var result = astService.GenerateAstFromString(code);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PrettyPrint_ShouldReturnStringRepresentation()
        {
            var code = "class Program { static void Main() {} }";
            var ast = astService.GenerateAstFromString(code);
            var prettyPrinted = astService.PrettyPrint(ast);

            Assert.IsFalse(string.IsNullOrEmpty(prettyPrinted));
            Assert.IsTrue(prettyPrinted.Contains("class"));
            Assert.IsTrue(prettyPrinted.Contains("Program"));
        }

        [TestMethod]
        public void ReflowCode_ShouldFormatCode()
        {
            var code = "class Program {static void Main(){} }";
            var ast = astService.GenerateAstFromString(code);
            var reflowedCode = astService.ReflowCode(ast);

            Assert.IsFalse(string.IsNullOrEmpty(reflowedCode));
            Assert.IsTrue(reflowedCode.Contains("class Program"));
            Assert.IsTrue(reflowedCode.Contains("{\n    static void Main()\n    {\n    }\n}"));
        }

        // Add more tests as needed...
    }
}
```

## README Documentation

Create a `README.md` file in the root of your solution for documentation:

```markdown
# Roslyn Abstract Syntax Tree Application

This application uses the Roslyn compiler to generate, pretty print, and reflow C# code into an Abstract Syntax Tree (AST).

## Features
- **Generate AST from String**: Converts a string containing C# source code into an AST.
- **Pretty Print**: Generates a readable string representation of the AST.
- **Reflow Code**: Formats the generated code back into nicely formatted C#.

## Usage

### Generating an AST
```csharp
var astService = new AbstractSyntaxTreeService();
string code = "class Program { static void Main() {} }";
CompilationUnitSyntax ast = astService.GenerateAstFromString(code);
```

### Pretty Printing the AST
```csharp
string prettyPrintedCode = astService.PrettyPrint(ast);
Console.WriteLine(prettyPrintedCode);
```

### Reflowing Code from AST
```csharp
string reflowedCode = astService.ReflowCode(ast);
Console.WriteLine(reflowedCode);
```

## Unit Tests

The project includes unit tests for the `AbstractSyntaxTreeService` methods to ensure correctness.

## License
MIT License
```

This setup provides a solid starting point. You can expand on this by adding more features, refining existing ones, and writing additional unit tests as needed.