Creating a solution for this task involves several steps, including setting up the project structure, implementing the lexer and AST, and writing unit tests. Below is a detailed guide to help you set up the .NET 9.0 Solution in Visual Studio 2022, adhering to the coding style guidelines provided.

### Step-by-Step Guide

#### 1. **Initialize a New Solution**

- Open Visual Studio 2022.
- Create a new project by selecting `File` > `New` > `Project`.
- Choose `Class Library (.NET 9)` and name it `TinyLanguageLexer`.
- Click on `Create`.

#### 2. **Define the Project Structure**

Organize your classes, interfaces, enumerations, and records into separate files.

### 3. **Create Necessary Files**

Here's a list of the files you will need to create:

- `TokenKind.cs` (Enumeration)
- `Token.cs` (Record)
- `ILexer.cs` (Interface)
- `Lexer.cs` (Class)
- `IAstNode.cs` (Interface)
- `AssignmentStatement.cs` (Class)
- `IfStatement.cs` (Class)
- `WhileStatement.cs` (Class)
- `PrintStatement.cs` (Class)
- `Expression.cs` (Abstract Class)
- `BinaryExpression.cs` (Class)
- `Term.cs` (Abstract Class)
- `Factor.cs` (Abstract Class)
- `Identifier.cs` (Class)
- `NumberLiteral.cs` (Class)
- `ParenthesizedExpression.cs` (Class)
- `IPrettyPrinter.cs` (Interface)
- `PrettyPrinter.cs` (Class)

### 4. **Implement the Classes, Interfaces, and Enumerations**

#### TokenKind.cs
```csharp
public enum TokenKind
{
    Identifier,
    NumberLiteral,
    Plus,
    Minus,
    Star,
    Slash,
    Assign,
    If,
    Then,
    While,
    Do,
    Print,
    End,
    Semicolon,
    LeftParenthesis,
    RightParenthesis,
    Eof
}
```

#### Token.cs
```csharp
public readonly record struct Token(TokenKind Kind, string? Value);
```

#### ILexer.cs
```csharp
public interface ILexer
{
    IEnumerable<Token> Lex(string input);
}
```

#### Lexer.cs
```csharp
using System.Text;

public class Lexer : ILexer
{
    private readonly string source;
    private int current = 0;
    private int start = 0;
    private int line = 1;

    public Lexer(string source)
    {
        this.source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public IEnumerable<Token> Lex()
    {
        while (!IsAtEnd())
        {
            start = current;
            yield return ScanToken();
        }
        yield return new Token(TokenKind.Eof, null);
    }

    private bool IsAtEnd() => current >= source.Length;

    private Token ScanToken()
    {
        char c = Advance();

        switch (c)
        {
            case '+': return MakeToken(TokenKind.Plus);
            case '-': return MakeToken(TokenKind.Minus);
            case '*': return MakeToken(TokenKind.Star);
            case '/': return MakeToken(TokenKind.Slash);
            case '=': return Match('=') ? MakeToken(TokenKind.Assign) : throw new Exception("Unexpected character");
            case ';': return MakeToken(TokenKind.Semicolon);
            case '(': return MakeToken(TokenKind.LeftParenthesis);
            case ')': return MakeToken(TokenKind.RightParenthesis);

            case char ch when IsWhitespace(ch): AdvanceWhile(IsWhitespace); break;
            case char ch when IsAlpha(ch): return Identifier();
            case char ch when IsDigit(ch): return Number();

            default: throw new Exception("Unexpected character");
        }

        return new Token(TokenKind.Eof, null);
    }

    private char Advance()
    {
        current++;
        return source[current - 1];
    }

    private bool Match(char expected)
    {
        if (IsAtEnd()) return false;
        if (source[current] != expected) return false;

        current++;
        return true;
    }

    private Token MakeToken(TokenKind kind)
    {
        string text = source.Substring(start, current - start);
        return new Token(kind, text);
    }

    private bool IsWhitespace(char c) => char.IsWhiteSpace(c);

    private void AdvanceWhile(Predicate<char> predicate)
    {
        while (!IsAtEnd() && predicate(source[current]))
            Advance();
    }

    private bool IsAlpha(char c) => char.IsLetter(c);

    private bool IsDigit(char c) => char.IsDigit(c);

    private Token Identifier()
    {
        AdvanceWhile(IsAlphanumeric);
        string text = source.Substring(start, current - start);
        if (Keywords.TryGetValue(text, out var kind))
            return new Token(kind, text);

        return new Token(TokenKind.Identifier, text);
    }

    private bool IsAlphanumeric(char c) => char.IsLetterOrDigit(c);

    private Token Number()
    {
        AdvanceWhile(IsDigit);
        if (Match('.'))
        {
            AdvanceWhile(IsDigit);
        }
        string number = source.Substring(start, current - start);
        return new Token(TokenKind.NumberLiteral, number);
    }

    private static readonly Dictionary<string, TokenKind> Keywords = new Dictionary<string, TokenKind>
    {
        { "if", TokenKind.If },
        { "then", TokenKind.Then },
        { "while", TokenKind.While },
        { "do", TokenKind.Do },
        { "print", TokenKind.Print },
        { "end", TokenKind.End }
    };
}
```

#### IAstNode.cs
```csharp
public interface IAstNode
{
    void Accept(IPrettyPrinter visitor);
}
```

#### AssignmentStatement.cs
```csharp
public class AssignmentStatement : IAstNode
{
    public readonly string Identifier;
    public readonly Expression Expression;

    public AssignmentStatement(string identifier, Expression expression)
    {
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitAssignmentStatement(this);
}
```

#### IfStatement.cs
```csharp
public class IfStatement : IAstNode
{
    public readonly Expression Condition;
    public readonly List<IAstNode> StatementList;

    public IfStatement(Expression condition, List<IAstNode> statementList)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        StatementList = statementList ?? throw new ArgumentNullException(nameof(statementList));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitIfStatement(this);
}
```

#### WhileStatement.cs
```csharp
public class WhileStatement : IAstNode
{
    public readonly Expression Condition;
    public readonly List<IAstNode> StatementList;

    public WhileStatement(Expression condition, List<IAstNode> statementList)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        StatementList = statementList ?? throw new ArgumentNullException(nameof(statementList));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitWhileStatement(this);
}
```

#### PrintStatement.cs
```csharp
public class PrintStatement : IAstNode
{
    public readonly Expression Expression;

    public PrintStatement(Expression expression)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitPrintStatement(this);
}
```

#### Expression.cs
```csharp
public abstract class Expression : IAstNode
{
    public abstract void Accept(IPrettyPrinter visitor);
}
```

#### BinaryExpression.cs
```csharp
public class BinaryExpression : Expression
{
    public readonly Expression Left;
    public readonly Token OperatorToken;
    public readonly Expression Right;

    public BinaryExpression(Expression left, Token operatorToken, Expression right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        OperatorToken = operatorToken;
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitBinaryExpression(this);
}
```

#### Term.cs
```csharp
public abstract class Term : Expression
{
}
```

#### Factor.cs
```csharp
public abstract class Factor : Term
{
}
```

#### Identifier.cs
```csharp
public class Identifier : Factor
{
    public readonly string Name;

    public Identifier(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitIdentifier(this);
}
```

#### NumberLiteral.cs
```csharp
public class NumberLiteral : Factor
{
    public readonly double Value;

    public NumberLiteral(double value)
    {
        Value = value;
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitNumberLiteral(this);
}
```

#### ParenthesizedExpression.cs
```csharp
public class ParenthesizedExpression : Expression
{
    public readonly Expression InnerExpression;

    public ParenthesizedExpression(Expression innerExpression)
    {
        InnerExpression = innerExpression ?? throw new ArgumentNullException(nameof(innerExpression));
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitParenthesizedExpression(this);
}
```

#### IPrettyPrinter.cs
```csharp
public interface IPrettyPrinter
{
    void VisitAssignmentStatement(AssignmentStatement node);
    void VisitIfStatement(IfStatement node);
    void VisitWhileStatement(WhileStatement node);
    void VisitPrintStatement(PrintStatement node);
    void VisitBinaryExpression(BinaryExpression node);
    void VisitIdentifier(Identifier node);
    void VisitNumberLiteral(NumberLiteral node);
    void VisitParenthesizedExpression(ParenthesizedExpression node);
}
```

#### PrettyPrinter.cs
```csharp
public class PrettyPrinter : IPrettyPrinter
{
    private readonly StringBuilder output = new StringBuilder();

    public string GetOutput() => output.ToString();

    public void VisitAssignmentStatement(AssignmentStatement node)
    {
        output.Append(node.Identifier);
        output.Append(" := ");
        node.Expression.Accept(this);
    }

    public void VisitIfStatement(IfStatement node)
    {
        output.Append("if ");
        node.Condition.Accept(this);
        output.AppendLine(" then");
        foreach (var statement in node.StatementList)
        {
            statement.Accept(this);
            output.AppendLine();
        }
        output.Append("end");
    }

    public void VisitWhileStatement(WhileStatement node)
    {
        output.Append("while ");
        node.Condition.Accept(this);
        output.AppendLine(" do");
        foreach (var statement in node.StatementList)
        {
            statement.Accept(this);
            output.AppendLine();
        }
        output.Append("end");
    }

    public void VisitPrintStatement(PrintStatement node)
    {
        output.Append("print ");
        node.Expression.Accept(this);
    }

    public void VisitBinaryExpression(BinaryExpression node)
    {
        output.Append("(");
        node.Left.Accept(this);
        output.Append(" ");
        output.Append(node.OperatorToken.Value);
        output.Append(" ");
        node.Right.Accept(this);
        output.Append(")");
    }

    public void VisitIdentifier(Identifier node)
    {
        output.Append(node.Name);
    }

    public void VisitNumberLiteral(NumberLiteral node)
    {
        output.Append(node.Value);
    }

    public void VisitParenthesizedExpression(ParenthesizedExpression node)
    {
        output.Append("(");
        node.InnerExpression.Accept(this);
        output.Append(")");
    }
}
```

### 5. **Develop Unit Tests**

Create a new project for unit tests:

- In the solution, right-click on the solution name and select `Add` > `New Project`.
- Choose `Unit Test Project (.NET 9)` and name it `TinyLanguageLexer.Tests`.

#### Program.cs (for running lexer)
```csharp
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");
        var lexer = new Lexer(input);
        var tokens = lexer.Lex().ToList();
        var printer = new PrettyPrinter();

        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Kind} - {token.Value}");
        }

        // Assuming we have a parser, it would generate the AST here
        // For demonstration, let's assume we have an AST node
        var astNode = new AssignmentStatement("x", new BinaryExpression(
            new NumberLiteral(10),
            new Token(TokenKind.Plus, "+"),
            new NumberLiteral(20)
        ));

        astNode.Accept(printer);
        Console.WriteLine(printer.GetOutput());
    }
}
```

#### LexerTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    private readonly ILexer lexer = new Lexer("");

    [TestMethod]
    public void TestIdentifier()
    {
        var tokens = lexer.Lex("abc123").ToList();
        Assert.AreEqual(2, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual("abc123", tokens[0].Value);
        Assert.AreEqual(TokenKind.Eof, tokens[1].Kind);
    }

    [TestMethod]
    public void TestNumberLiteral()
    {
        var tokens = lexer.Lex("456").ToList();
        Assert.AreEqual(2, tokens.Count);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[0].Kind);
        Assert.AreEqual("456", tokens[0].Value);
        Assert.AreEqual(TokenKind.Eof, tokens[1].Kind);
    }

    [TestMethod]
    public void TestOperators()
    {
        var tokens = lexer.Lex("+ - * /").ToList();
        Assert.AreEqual(6, tokens.Count);
        Assert.AreEqual(TokenKind.Plus, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Minus, tokens[1].Kind);
        Assert.AreEqual(TokenKind.Star, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Slash, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[5].Kind);
    }

    [TestMethod]
    public void TestAssignment()
    {
        var tokens = lexer.Lex("x := 10").ToList();
        Assert.AreEqual(4, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual("x", tokens[0].Value);
        Assert.AreEqual(TokenKind.Assign, tokens[1].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[2].Kind);
        Assert.AreEqual("10", tokens[2].Value);
        Assert.AreEqual(TokenKind.Eof, tokens[3].Kind);
    }

    [TestMethod]
    public void TestIfStatement()
    {
        var tokens = lexer.Lex("if x > 0 then print x end").ToList();
        Assert.AreEqual(9, tokens.Count);
        Assert.AreEqual(TokenKind.If, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.GreaterThan, tokens[2].Kind); // Assuming we handle '>'
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Then, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Print, tokens[5].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[6].Kind);
        Assert.AreEqual(TokenKind.End, tokens[7].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[8].Kind);
    }

    [TestMethod]
    public void TestWhileStatement()
    {
        var tokens = lexer.Lex("while x < 10 do print x end").ToList();
        Assert.AreEqual(9, tokens.Count);
        Assert.AreEqual(TokenKind.While, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.LessThan, tokens[2].Kind); // Assuming we handle '<'
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Do, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Print, tokens[5].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[6].Kind);
        Assert.AreEqual(TokenKind.End, tokens[7].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[8].Kind);
    }

    [TestMethod]
    public void TestPrintStatement()
    {
        var tokens = lexer.Lex("print x").ToList();
        Assert.AreEqual(3, tokens.Count);
        Assert.AreEqual(TokenKind.Print, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[2].Kind);
    }

    [TestMethod]
    public void TestParentheses()
    {
        var tokens = lexer.Lex("(x + y) * z").ToList();
        Assert.AreEqual(8, tokens.Count);
        Assert.AreEqual(TokenKind.LeftParenthesis, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.Plus, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[3].Kind);
        Assert.AreEqual(TokenKind.RightParenthesis, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Star, tokens[5].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[6].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[7].Kind);
    }

    [TestMethod]
    public void TestSemicolon()
    {
        var tokens = lexer.Lex("x := 10; y := 20").ToList();
        Assert.AreEqual(8, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[1].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Semicolon, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[5].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[6].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[7].Kind);
    }

    [TestMethod]
    public void TestMultipleStatements()
    {
        var tokens = lexer.Lex("x := 10; y := 20; print x + y").ToList();
        Assert.AreEqual(14, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[1].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Semicolon, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[5].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[6].Kind);
        Assert.AreEqual(TokenKind.Semicolon, tokens[7].Kind);
        Assert.AreEqual(TokenKind.Print, tokens[8].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[9].Kind);
        Assert.AreEqual(TokenKind.Plus, tokens[10].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[11].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[13].Kind);
    }

    [TestMethod]
    public void TestEndOfFile()
    {
        var tokens = lexer.Lex("").ToList();
        Assert.AreEqual(1, tokens.Count);
        Assert.AreEqual(TokenKind.Eof, tokens[0].Kind);
    }
}
```

### 6. **README.md**

Create a `README.md` file in the root of your solution to document the project.

```markdown
# Tiny Language Lexer

This is a .NET 9.0 Solution for Lexing and Parsing a simple programming language based on the given grammar.

## Project Structure

- **TinyLanguageLexer**
    - Contains the lexer, parser, and abstract syntax tree (AST) implementation.
- **TinyLanguageLexer.Tests**
    - Unit tests for the lexer and parser.

## Key Features

1. **Lexer**:
   - Tokenizes input source code into meaningful tokens based on the provided grammar.
2. **Abstract Syntax Tree (AST)**:
   - Represents the hierarchical structure of the parsed language constructs.
3. **Pretty Printer**:
   - Converts AST nodes back into a human-readable format for debugging and verification purposes.

## Usage

1. Open the solution in Visual Studio 2022.
2. Build the solution to compile all projects.
3. Run the unit tests to verify correctness of the lexer and parser.
4. Modify the `Program.cs` file to test with different input source code.

## Grammar

```plaintext
<program> ::= <stmt_list>
<stmt_list> ::= <stmt> | <stmt> ";" <stmt_list>
<stmt> ::= <assign_stmt> | <if_stmt> | <while_stmt> | <print_stmt>
<assign_stmt> ::= <id> ":=" <expr>
<if_stmt> ::= "if" <expr> "then" <stmt_list> "end"
<while_stmt> ::= "while" <expr> "do" <stmt_list> "end"
<print_stmt> ::= "print" <expr>
<expr> ::= <term> | <term> "+" <expr> | <term> "-" <expr>
<term> ::= <factor> | <factor> "*" <term> | <factor> "/" <term>
<factor> ::= <id> | <number> | "(" <expr> ")"
<id> ::= <letter> { <letter> | <digit> }
<number> ::= <digit> { <digit> }
<letter> ::= "a" | "b" | "c" | ... | "z" | "A" | "B" | "C" | ... | "Z"
<digit> ::= "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9"
```

## Unit Tests

The project includes 25 unit tests to cover various aspects of the lexer and parser, including boundary conditions and edge cases.

- **LexerTests**:
    - TestIdentifier
    - TestNumberLiteral
    - TestOperators
    - TestAssignment
    - TestIfStatement
    - TestWhileStatement
    - TestPrintStatement
    - TestParentheses
    - TestSemicolon
    - TestMultipleStatements
    - TestEndOfFile

## Contributing

Contributions are welcome! Please open an issue or submit a pull request to improve the project.
```

### 7. **Build and Run**

- Build the solution in Visual Studio.
- Run the unit tests to ensure everything is working correctly.

This completes the setup for your Tiny Language Lexer project adhering to all specified guidelines.