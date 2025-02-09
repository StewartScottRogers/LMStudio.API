Based on the provided specifications and prompts, let's create a project structure and begin coding.

### Project Structure

**Solution: `Lexers`**

- **Projects:**
  - `LexerCore`: Contains lexer and AST classes.
  - `ASTPrettyPrinter`: Contains logic to print ASTs nicely.
  - `Tests`: Contains unit tests for the lexer and AST generation.

### Step-by-step Implementation

#### 1. Solution Initialization (`Visual Studio 2022`)

- **Open Visual Studio 2022**
- **Create a New Project:**
  - Select `Class Library (.NET Framework)`, name it `LexerCore`.
  - Repeat for `ASTPrettyPrinter` and `Tests`.

#### 2. Lexer Core (`LexerCore` project)

**File: `Lexer.cs`**

```csharp
using System;
using System.Collections.Generic;

public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }

    enum TokenType
    {
        Identifier,
        Number,
        Plus,
        Minus,
        Star,
        Slash,
        LParen,
        RParen,
        ColonEqual,
        If,
        Then,
        End,
        While,
        Do,
        Print,
        // Add more token types as needed
    }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}

public class Lexer
{
    private readonly string _source;
    private int _currentPosition;

    public Lexer(string source)
    {
        _source = source;
        _currentPosition = 0;
    }

    public IEnumerable<Token> Lex()
    {
        while (_currentPosition < _source.Length)
        {
            // Implement tokenization logic here
            var c = _source[_currentPosition];
            
            if (Char.IsLetter(c))
            {
                var identifier = ScanIdentifier();
                yield return new Token(TokenType.Identifier, identifier);
            }
            else if (Char.IsDigit(c))
            {
                var number = ScanNumber();
                yield return new Token(TokenType.Number, number);
            }
            else if ("+ - * / ()".Contains(c.ToString()))
            {
                // Process operators and parentheses
                yield return new Token(Enum.Parse<TokenType>(c.ToString()), c.ToString());
            }
            // Continue for other tokens like ":", "if", "then", etc.

            _currentPosition++;
        }
    }

    private string ScanIdentifier()
    {
        var builder = new StringBuilder();
        while (_currentPosition < _source.Length && Char.IsLetterOrDigit(_source[_currentPosition]))
        {
            builder.Append(_source[_currentPosition]);
            _currentPosition++;
        }
        return builder.ToString();
    }

    private string ScanNumber()
    {
        var numberBuilder = new StringBuilder();
        while (_currentPosition < _source.Length && Char.IsDigit(_source[_currentPosition]))
        {
            numberBuilder.Append(_source[_currentPosition]);
            _currentPosition++;
        }
        return numberBuilder.ToString();
    }
}
```

#### 3. Abstract Syntax Tree (AST) Nodes (`LexerCore` project)

**Example:**

- `ASTNode.cs`
```csharp
public abstract class ASTNode
{
    public abstract void Accept(IVisitor visitor);
}

public interface IVisitor
{
    void Visit(ASTNode node);
    void Visit(IdentifierNode node);
    void Visit(NumberLiteralNode node);
    // Add more visit methods as needed for other AST nodes.
}

public class IdentifierNode : ASTNode
{
    public string Value { get; }

    public IdentifierNode(string value)
    {
        Value = value;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
// Similarly, define NumberLiteralNode and other AST node classes.
```

#### 4. Abstract Syntax Tree Pretty Printer (`ASTPrettyPrinter` project)

**File: `AstPrettyPrinter.cs`**

```csharp
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
```

#### 5. Unit Testing (`Tests` project)

**File: `LexerTests.cs`**

```csharp
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestLexingIdentifiers()
    {
        var lexer = new Lexer("a b c");
        IEnumerable<Token> tokens = lexer.Lex();
        
        Assert.AreEqual(3, tokens.Count());
        CollectionAssert.Contains(tokens, new Token(TokenType.Identifier, "a"));
        CollectionAssert.Contains(tokens, new Token(TokenType.Identifier, "b"));
        CollectionAssert.Contains(tokens, new Token(TokenType.Identifier, "c"));
    }

    [TestMethod]
    public void TestLexingNumbers()
    {
        var lexer = new Lexer("123 456");
        IEnumerable<Token> tokens = lexer.Lex();

        Assert.AreEqual(2, tokens.Count());
        CollectionAssert.Contains(tokens, new Token(TokenType.Number, "123"));
        CollectionAssert.Contains(tokens, new Token(TokenType.Number, "456"));
    }

    // Write other unit tests as required for the lexer and AST generation.

    [TestMethod]
    public void TestAstPrinting()
    {
        // Set up an example AST and verify its pretty-printing
    }

    // ... Add more test methods here.
}
```

### Important Notes:

- **Lexer**: Implement missing token handling logic (e.g., `ColonEqual`, `If`, etc.) based on the grammar provided.
- **AST Nodes & Pretty Printer**: Complete the definition of AST node types and visitor interface accordingly.
- **Unit Tests**: Ensure thorough coverage including edge cases, invalid inputs, and all possible grammar rules.

This outline provides a starting point for implementing the lexer and related components according to the specified guidelines. Further development will involve completing each component based on the outlined structures and extending unit tests as necessary.

**Reminder:** Always ensure your solution adheres strictly to .NET 9.0 and Visual Studio 2022 specificities, including using explicit types, following coding style guidelines meticulously, and ensuring all components are thoroughly tested before concluding development.

### Final Steps

- Review and refactor code for clarity and correctness.
- Ensure unit tests pass and adequately cover the functionality.
- Document your work, especially in areas of complex logic or potential pitfalls.

With this approach, you'll create a fully functional lexer with an abstract syntax tree generator, a pretty-printer for ASTs, and comprehensive unit testing.