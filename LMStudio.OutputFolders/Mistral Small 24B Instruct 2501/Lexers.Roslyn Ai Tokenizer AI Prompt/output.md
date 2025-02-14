Creating a complete .NET 9.0 solution with the specified requirements involves several steps, including setting up the project structure, writing the necessary code, and creating unit tests. However, note that as of my last update, there is no .NET 9.0 version released yet; .NET 6 and .NET 7 are the latest versions available. Assuming you are working on a future version or targeting .NET 6/7 with forward compatibility in mind, I will proceed to create a solution following your requirements.

### Step-by-Step Solution

#### 1. Set up the Solution
We need to set up a new .NET project that includes:
- A Console Application Project.
- A Unit Test Project using Microsoft's Unit Testing framework (MSTest).

Let’s begin by creating the projects in Visual Studio 2022.

#### 2. Create the Console Application

1. **Create a new C# Console Application** named `AstGenerator`.
   - Open Visual Studio 2022.
   - Select "Create a new project".
   - Choose "Console App (.NET Core)" or ".NET" if .NET 6/7 is available as the target framework.
   - Name your project `AstGenerator` and click “Create”.

2. **Adjust Project Settings**
   - Ensure that Implicit Usings are disabled in the `.csproj` file by removing or commenting out `<ImplicitUsings>enable</ImplicitUsings>`.

#### 3. Create Necessary Files for Classes, Interfaces, Enums, Records

- **AbstractSyntaxTree.cs**:
```csharp
public record AbstractSyntaxTree
{
    public string RootNode { get; init; }
    // Add more properties as needed
}
```

- **IAstPrinter.cs**: Interface for printing AST.
```csharp
public interface IAstPrinter
{
    void Print(AbstractSyntaxTree ast);
}
```

- **AstPrettyPrinter.cs**:
```csharp
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

public class AstPrettyPrinter : IAstPrinter
{
    public void Print(AbstractSyntaxTree ast)
    {
        // Implement the pretty printing logic here
        Console.WriteLine($"Root Node: {ast.RootNode}");
        // Add more detailed AST printing as needed.
    }
}
```

- **IAstReflowGenerator.cs**: Interface for generating code from AST.
```csharp
public interface IAstReflowGenerator
{
    string GenerateCode(AbstractSyntaxTree ast);
}
```

- **AstReflowGenerator.cs**:
```csharp
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

public class AstReflowGenerator : IAstReflowGenerator
{
    public string GenerateCode(AbstractSyntaxTree ast)
    {
        // Implement the code generation logic here
        var root = SyntaxFactory.ParseSyntaxTree($"class {ast.RootNode} {{}}");
        return root.GetText().ToString();
    }
}
```

#### 4. Main Program to Execute AST Operations

- **Program.cs**:
```csharp
using System;

namespace AstGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var ast = new AbstractSyntaxTree { RootNode = "TestClass" };
            
            IAstPrinter printer = new AstPrettyPrinter();
            printer.Print(ast);
            
            IAstReflowGenerator reflowGenerator = new AstReflowGenerator();
            string code = reflowGenerator.GenerateCode(ast);

            Console.WriteLine("Generated Code:");
            Console.WriteLine(code);
        }
    }
}
```

#### 5. Create the Unit Test Project

1. **Create a new MSTest Unit Test Project** named `AstTests`.
   - Select "Create a new project".
   - Choose "Unit Test App (.NET Core)" or ".NET" if .NET 6/7 is available as the target framework.
   - Name your project `AstTests` and click “Create”.

2. **Adjust Project Settings**
   - Ensure that Implicit Usings are disabled in the `.csproj` file by removing or commenting out `<ImplicitUsings>enable</ImplicitUsings>`.

#### 6. Write Unit Tests

- **TestAstPrettyPrinter.cs**:
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator;

namespace AstTests
{
    [TestClass]
    public class TestAstPrettyPrinter
    {
        [TestMethod]
        public void TestPrint()
        {
            var ast = new AbstractSyntaxTree { RootNode = "TestClass" };
            IAstPrinter printer = new AstPrettyPrinter();
            
            // Redirect console output to capture it for testing.
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                printer.Print(ast);
                
                string expectedOutput = $"Root Node: {ast.RootNode}" + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
```

- **TestAstReflowGenerator.cs**:
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator;

namespace AstTests
{
    [TestClass]
    public class TestAstReflowGenerator
    {
        [TestMethod]
        public void TestGenerateCode()
        {
            var ast = new AbstractSyntaxTree { RootNode = "TestClass" };
            IAstReflowGenerator generator = new AstReflowGenerator();
            
            string expectedOutput = $"class {ast.RootNode} {{}}" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, generator.GenerateCode(ast));
        }
    }
}
```

#### 7. Adding More Unit Tests

You should add more tests for boundary conditions and different scenarios, ensuring thorough coverage of the Abstract Syntax Tree operations.

### Conclusion
This setup provides a basic structure to get you started on creating an application that generates an Abstract Syntax Tree (AST), prints it, and reflows it back into executable code using C# Roslyn. You can expand upon this by adding more features, such as parsing actual source code into ASTs, and handling more complex structures.

### Notes
- For .NET 9.0 specifics, you would need to wait for the release of .NET 9.0 or use the latest available version (.NET 6/7) with forward compatibility considerations.
- The provided code assumes a very basic structure and logic. You should replace placeholders and expand upon them as needed.
- Ensure that all new classes and interfaces are created in separate files, adhering to the specified file system structure.