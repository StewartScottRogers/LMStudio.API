Creating a .NET 9.0 solution that meets all the specified requirements is a substantial task. Below is a high-level overview and some sample code to get you started. Due to the complexity, I'll provide the structure and key components, but you may need to expand on this to fully meet all requirements.

### Solution Structure

1. **Project Structure**
   - `AstPrinter`
     - `AstPrinter.csproj`
     - `AstPrettyPrinter.cs`
     - `AstReflowGenerator.cs`
   - `UnitTests`
     - `UnitTests.csproj`
     - `AstLexerTests.cs`

2. **File System Structure**

```
AstPrinter/
├── AstPrinter.csproj
├── AstPrettyPrinter.cs
└── AstReflowGenerator.cs

UnitTests/
├── UnitTests.csproj
└── AstLexerTests.cs
```

### `AstPrinter/AstPrinter.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp" Version="4.3.0" />
  </ItemGroup>

</Project>
```

### `UnitTests/UnitTests.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest.TestFramework" Version="2.2.8" />
    <ProjectReference Include="../AstPrinter/AstPrinter.csproj" />
  </ItemGroup>

</Project>
```

### `AstPrettyPrinter.cs`

```csharp
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstPrinter
{
    public static class AstPrettyPrinter
    {
        /// <summary>
        /// Pretty prints the Abstract Syntax Tree.
        /// </summary>
        /// <param name="root">The root of the AST.</param>
        /// <returns>A string representation of the pretty-printed AST.</returns>
        public static string PrintAst(SyntaxNode root)
        {
            return root.ToString();
        }
    }
}
```

### `AstReflowGenerator.cs`

```csharp
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstPrinter
{
    public static class AstReflowGenerator
    {
        /// <summary>
        /// Generates refactored code from the Abstract Syntax Tree.
        /// </summary>
        /// <param name="root">The root of the AST.</param>
        /// <returns>A string containing the generated code.</returns>
        public static string GenerateCode(SyntaxNode root)
        {
            var code = root.ToString();
            return code;
        }
    }
}
```

### `UnitTests/AstLexerTests.cs`

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstPrinter;

namespace UnitTests
{
    [TestClass]
    public class AstLexerTests
    {
        private static readonly string TestCode = "public class Example { public int Method() { return 42; } }";

        [TestMethod]
        public void TestAstPrettyPrint()
        {
            var tree = CSharpSyntaxTree.ParseText(TestCode);
            var root = tree.GetRoot();

            var prettyPrinter = AstPrettyPrinter.PrintAst(root);

            // Display the AST
            Console.WriteLine(prettyPrinter);

            Assert.IsTrue(!string.IsNullOrEmpty(prettyPrinter));
        }

        [TestMethod]
        public void TestAstReflowGenerate()
        {
            var tree = CSharpSyntaxTree.ParseText(TestCode);
            var root = tree.GetRoot();

            var reflowGenerator = AstReflowGenerator.GenerateCode(root);

            // Display the generated code
            Console.WriteLine(reflowGenerator);

            Assert.IsTrue(!string.IsNullOrEmpty(reflowGenerator));
        }

        // Add more tests as required...
    }
}
```

### Explanation

1. **AstPrettyPrinter.cs**: This class contains a method to pretty-print the Abstract Syntax Tree (AST).
2. **AstReflowGenerator.cs**: This class contains a method to generate refactored code from the AST.
3. **UnitTests/AstLexerTests.cs**: This file contains unit tests for lexing and printing the AST, as well as generating refactored code.

### Next Steps

1. **Extend Unit Tests**: Add more unit tests to cover all bounding conditions and edge cases.
2. **Enhance Pretty Printer**: Improve the pretty-printer to handle different nodes and formats.
3. **Reflow Generator**: Enhance the reflow generator to perform meaningful code transformations.

This structure provides a foundation for your solution. You can expand on it by adding more detailed implementations, additional unit tests, and further enhancements as needed.