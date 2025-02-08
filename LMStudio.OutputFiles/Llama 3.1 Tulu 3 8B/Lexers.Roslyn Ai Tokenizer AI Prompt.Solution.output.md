Alright, let's break down the task and implement it step by step.

### Step 1: Initialize a New Solution

**Solution Structure**

- **LexerProject**: Contains the tokenizer logic using Roslyn.
- **AstPrettyPrinterProject**: Contains the Abstract Syntax Tree (AST) pretty printer.
- **AstReflowGeneratorProject**: Contains code reflow generator from AST to executable C# code.
- **UnitTestProject**: Contains unit tests for lexer and other components.

### Step 2: Coding Style Compliance

Let's set up a `CodeStyle.cs` file that contains our coding conventions as constants or static classes for reference:

```csharp
// CodeStyle.cs

public static class CodeStyle
{
    public const string ClassNameFormat = "UpperCamelCase";
    public const string PropertyFormat = "UpperCamelCase";
    public const string MethodFormat = "UpperCamelCase";
    // ... other style guidelines ...
}
```

### Step 3: Lexing with Roslyn

**Tokenizer.cs**

```csharp
// Tokenizer.cs

public class Tokenizer
{
    private static readonly HashSet<char> _whitespaceChars = new() { ' ', '\t', '\r', '\n' };
    // ... other token definitions ...

    public IEnumerable<Token> Tokenize(string sourceCode)
    {
        var tokens = new List<Token>();
        int position = 0;

        while (position < sourceCode.Length)
        {
            if (_whitespaceChars.Contains(sourceCode[position]))
            {
                // Consume whitespace
                while (position < sourceCode.Length && _whitespaceChars.Contains(sourceCode[position]))
                    position++;
                tokens.Add(new Token(TokenType.Whitespace, sourceCode.Substring(position), position));
            }
            else
            {
                // Handle other token types
                // ... implementation ...
            }

            position++;
        }

        return tokens;
    }
}

public class Token
{
    public TokenType Type { get; private set; }
    public string Value { get; private set; }
    public int Position { get; private set; }

    // Constructor and other methods...
}
```

### Step 4: Abstract Syntax Tree (AST) Pretty Printer

**AstPrettyPrinter.cs**

```csharp
// AstPrettyPrinter.cs

public class AstPrettyPrinter
{
    public string Print(SyntaxTree tree)
    {
        // Implementation to pretty print the AST.
        // ... implementation ...
    }
}
```

### Step 5: Abstract Syntax Tree (AST) Reflow Generator

**AstReflowGenerator.cs**

```csharp
// AstReflowGenerator.cs

public class AstReflowGenerator
{
    public string GenerateCode(SyntaxTree tree)
    {
        // Implementation to generate C# code from AST.
        // ... implementation ...
    }
}
```

### Step 6: Unit Test Project

**UnitTest1.cs**

```csharp
// UnitTest1.cs (Example)

using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerProject; // Adjust namespace as needed.

[TestClass]
public class TokenizerTests
{
    [TestMethod]
    public void SimpleWhitespaceTokenization()
    {
        var tokenizer = new Tokenizer();
        string sourceCode = "   This is a test   ";
        var tokens = tokenizer.Tokenize(sourceCode);

        Assert.AreEqual(5, tokens.Count, "Incorrect number of whitespace tokens");
    }

    // Add more tests...
}
```

### Step 7: README / Documentation

**README.md**

```markdown
# Roslyn Lexer and AST Tools

This project is structured into multiple components:

- **LexerProject**: Contains the tokenization logic using Roslyn.
- **AstPrettyPrinterProject**: A utility to pretty-print Abstract Syntax Trees.
- **AstReflowGeneratorProject**: Converts an AST back into executable C# code.
- **UnitTestProject**: Contains unit tests for all the components.

### Coding Style

The project adheres strictly to .NET coding standards and best practices:

* Class, method, variable names follow a consistent naming convention (CamelCase).

### Unit Tests

Unit tests are provided to ensure the correctness of tokenization logic among other functionalities. 

## How to run unit tests

1. Open the solution in Visual Studio 2022.
2. Set the startup project to `UnitTestProject`.
3. Run all tests.

**For more detailed documentation, refer to individual class comments and method headers within each source file.**

```

### Final Notes

Remember, this outline provides a basic structure for your solution. Each component will require additional implementation based on your exact requirements. Ensure you follow the coding style consistently throughout the project.

This process involves significant development work, so don't hesitate to break tasks into smaller steps and iteratively develop each part of the system. Always test thoroughly and ensure that every piece fits together correctly before moving forward.

**Key Takeaways:**

- **Adhere strictly** to the defined coding standards.
- **Separate concerns** within different projects for maintainability.
- **Write comprehensive unit tests**, especially for lexer/tokenizer parts, ensuring robustness against edge cases.
- **Document thoroughly** each component's logic and usage for future maintenance and clarity.

Now you have a comprehensive plan to tackle this challenge. Start with initializing the solution structure in Visual Studio and gradually implement each step, focusing on quality and readability at every stage.