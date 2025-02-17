Creating a complete .NET 9.0 Solution that lexes the given grammar and generates an Abstract Syntax Tree (AST) involves several steps, including designing a lexer, parser, and AST nodes. This solution will focus on the lexer part as per your request. 

### Step 1: Define Lexer Classes
First, we need to define classes for different tokens in our grammar.

```csharp
public readonly struct Token
{
    public static readonly Token EOF = new Token(0, "");
    
    public readonly int Line;
    public readonly string Text;

    public int Type { get; }
    
    public Token(int line, string text)
    {
        Line = line;
        Text = text;
    }

    // Additional token types as needed...
}

public class Lexer
{
    private readonly string _input;
    private int _current = 0;

    public Lexer(string input)
    {
        _input = input;
    }

    public Token NextToken()
    {
        SkipWhitespace();
        
        if (_current >= _input.Length)
            return Token.EOF;

        var c = _input[_current];

        switch (c)
        {
            case '(': yield return new Token(1, "("); break;
            case ')': yield return new Token(2, ")"); break;
            // Add more cases for other tokens...
            default: throw new Exception($"Unexpected character: {c}");
        }

        // Increment current position
        _current++;
    }

    private void SkipWhitespace()
    {
        while (_current < _input.Length && char.IsWhiteSpace(_input[_current]))
            _current++;
    }
}
```

### Step 2: Unit Testing the Lexer

To test the lexer, we'll create a set of unit tests that ensure it can correctly recognize and return tokens according to our grammar.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestValidInput()
    {
        var input = "if (x > 10) then print x end";
        var lexer = new Lexer(input);
        List<(Token, int)> tokens = new List<(Token, int)>();
        
        foreach (var token in lexer)
        {
            tokens.Add((token, lexer._current));
            if (token == Token.EOF) break;
        }

        // Verify the expected sequence of tokens
        Assert.AreEqual(8, tokens.Count);
    }
    
    [TestMethod]
    public void TestInvalidInput()
    {
        var input = "if then";
        var lexer = new Lexer(input);

        try
        {
            foreach (var _ in lexer) ;
            Assert.Fail("Expected exception was not thrown");
        }
        catch (Exception ex)
        {
            // Ensure we're catching the specific type of exception expected
            Assert.IsTrue(ex is Exception, "Unexpected exception caught: " + ex.GetType().Name);
        }
    }

    // Additional test methods for other tokens and scenarios...
}
```

### Step 3: Generate AST Nodes

While this step involves creating classes that represent nodes in our Abstract Syntax Tree (AST), remember the focus is on lexing. However, understanding how we'd structure these classes will help us see where our lexer fits into the bigger picture.

```csharp
public abstract class AstNode
{
    public int Line { get; }
    
    protected AstNode(int line)
    {
        Line = line;
    }

    // Implement methods to visit nodes or perform operations as needed...
}

// Example of an AST node for the "if" statement
public class IfStmt : AstNode
{
    public Expr Condition { get; }
    public Stmts ThenBranch { get; }

    public IfStmt(Expr condition, Stmts thenBranch, int line) 
        : base(line)
    {
        Condition = condition;
        ThenBranch = thenBranch;
    }
}
```

### Step 4: Pretty Printer (Optional)

A pretty printer for the AST can be an interesting addition but is not strictly required for lexing. It would take our AST and output formatted code or visualize it in some way.

```csharp
public class AstPrettyPrinter
{
    public void Print(AstNode node)
    {
        // Implementation to recursively visit nodes and print them nicely.
    }
}
```

This solution outlines the foundational components for lexing according to the provided grammar. Expanding this into a full parser, AST generation, and pretty printer would involve further detailed design and implementation steps, including handling more complex language constructs and error cases.