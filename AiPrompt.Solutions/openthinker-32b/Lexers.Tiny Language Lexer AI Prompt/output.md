Creating a .NET 9.0 solution with the specified requirements involves generating several files and ensuring they all follow the provided coding standards. Below is an outline of how to set this up along with sample code for the lexer, abstract syntax tree (AST), pretty printer, and unit tests.

### Step-by-Step Guide

1. **Create a new .NET Class Library Project in Visual Studio 2022:**
   - Open Visual Studio 2022.
   - Click on "Create New Project".
   - Select "Class Library (.NET)" and click "Next".
   - Name the project `LexerGrammar` and choose a location to save it, then click "Create".

2. **Add Necessary Files:**

#### Lexer.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Lexer
{
    private readonly string sourceCode;
    private int current = 0;
    private List<Token> tokens = new List<Token>();

    public Lexer(string source)
    {
        sourceCode = source;
    }

    public List<Token> ScanTokens()
    {
        while (!IsAtEnd())
        {
            char character = Advance();
            switch (character)
            {
                case ';':
                    AddToken(TokenType.Semicolon);
                    break;
                case '(':
                    AddToken(TokenType.LeftParenthesis);
                    break;
                case ')':
                    AddToken(TokenType.RightParenthesis);
                    break;
                case '+':
                    AddToken(TokenType.Plus);
                    break;
                case '-':
                    AddToken(TokenType.Minus);
                    break;
                case '*':
                    AddToken(TokenType.Star);
                    break;
                case '/':
                    AddToken(TokenType.Slash);
                    break;
                case 'i' when Match("f"):
                    AddToken(TokenType.If);
                    break;
                case 't' when Match("hen"):
                    AddToken(TokenType.Then);
                    break;
                case 'e' when Match("nd"):
                    AddToken(TokenType.End);
                    break;
                case 'w' when Match("hile"):
                    AddToken(TokenType.While);
                    break;
                case 'd' when Match("o"):
                    AddToken(TokenType.Do);
                    break;
                case 'p' when Match("rint"):
                    AddToken(TokenType.Print);
                    break;
                case char c when IsAlpha(c):
                    string identifier = Identifier();
                    switch (identifier)
                    {
                        // Handle more keywords if needed
                    }
                    AddToken(TokenType.Identifier, identifier);
                    break;
                case char d when IsDigit(d):
                    number = Number();
                    AddToken(TokenType.Number, number);
                    break;
                default:
                    Console.WriteLine($"Unexpected character: {character}");
                    break;
            }

            SkipWhitespace();
        }

        tokens.Add(new Token(TokenType.Eof, string.Empty));
        return tokens;
    }

    private char Advance()
    {
        current++;
        return sourceCode[current - 1];
    }

    private void AddToken(TokenType type)
    {
        var text = sourceCode.Substring(current - 1, 1);
        tokens.Add(new Token(type, text));
    }

    private void AddToken(TokenType type, string literal)
    {
        var text = sourceCode.Substring(current - literal.Length, literal.Length);
        tokens.Add(new Token(type, text, literal));
    }

    private bool IsAtEnd() => current >= sourceCode.Length;

    private char Peek()
    {
        if (IsAtEnd()) return '\0';
        return sourceCode[current];
    }

    private char PeekNext()
    {
        if (current + 1 >= sourceCode.Length) return '\0';
        return sourceCode[current + 1];
    }

    private bool Match(char expected)
    {
        if (IsAtEnd() || sourceCode[current] != expected) return false;
        current++;
        return true;
    }

    private void SkipWhitespace()
    {
        while (!IsAtEnd())
        {
            char c = Peek();
            switch (c)
            {
                case ' ':
                case '\r':
                case '\t':
                    Advance();
                    break;
                case '\n':
                    Advance();
                    break;
                default:
                    return;
            }
        }
    }

    private string Identifier()
    {
        while (IsAlphaNumeric(Peek())) Advance();
        return sourceCode.Substring(current - 1, current - (current - 1));
    }

    private string Number()
    {
        while (IsDigit(Peek())) Advance();

        if (Peek() == '.' && IsDigit(PeekNext()))
        {
            Advance();
            while (IsDigit(Peek())) Advance();
        }
        return sourceCode.Substring(current - 1, current - (current - 1));
    }

    private bool IsAlpha(char c) => char.IsLetter(c);
    private bool IsDigit(char c) => char.IsDigit(c);
    private bool IsAlphaNumeric(char c) => IsAlpha(c) || IsDigit(c);

    private readonly string number;
}
```

#### Token.cs
```csharp
public class Token
{
    public TokenType Type { get; }
    public string Lexeme { get; }
    public object Literal { get; }

    public Token(TokenType type, string lexeme)
    {
        Type = type;
        Lexeme = lexeme;
        Literal = null;
    }

    public Token(TokenType type, string lexeme, object literal)
    {
        Type = type;
        Lexeme = lexeme;
        Literal = literal;
    }
}
```

#### TokenType.cs (Enumeration)
```csharp
public enum TokenType
{
    Semicolon,
    LeftParenthesis,
    RightParenthesis,
    Plus,
    Minus,
    Star,
    Slash,
    If,
    Then,
    End,
    While,
    Do,
    Print,
    Identifier,
    Number,

    Eof
}
```

#### ASTNode.cs (Interface)
```csharp
public interface ASTNode
{
    void Accept(IVisitor visitor);
}
```

#### Visitor.cs (Interface)
```csharp
public interface IVisitor
{
    void VisitProgram(Program program);
    void VisitStatementList(StatementList statementList);
    void VisitAssignmentStatement(AssignmentStatement assignmentStatement);
    void VisitIfStatement(IfStatement ifStatement);
    void VisitWhileStatement(WhileStatement whileStatement);
    void VisitPrintStatement(PrintStatement printStatement);
    void VisitExpression(Expression expression);
    void VisitTerm(Term term);
    void VisitFactor(Factor factor);
}
```

#### Program.cs (Record)
```csharp
public record Program : ASTNode
{
    public StatementList Statements { get; }

    public Program(StatementList statements)
    {
        Statements = statements;
    }

    public void Accept(IVisitor visitor) => visitor.VisitProgram(this);
}
```

#### StatementList.cs (Record)
```csharp
public record StatementList : ASTNode
{
    public List<ASTNode> Statements { get; }

    public StatementList(List<ASTNode> statements)
    {
        Statements = statements;
    }

    public void Accept(IVisitor visitor) => visitor.VisitStatementList(this);
}
```

#### AssignmentStatement.cs (Record)
```csharp
public record AssignmentStatement : ASTNode
{
    public string Identifier { get; }
    public Expression Expression { get; }

    public AssignmentStatement(string identifier, Expression expression)
    {
        Identifier = identifier;
        Expression = expression;
    }

    public void Accept(IVisitor visitor) => visitor.VisitAssignmentStatement(this);
}
```

#### IfStatement.cs (Record)
```csharp
public record IfStatement : ASTNode
{
    public Expression Condition { get; }
    public StatementList Body { get; }

    public IfStatement(Expression condition, StatementList body)
    {
        Condition = condition;
        Body = body;
    }

    public void Accept(IVisitor visitor) => visitor.VisitIfStatement(this);
}
```

#### WhileStatement.cs (Record)
```csharp
public record WhileStatement : ASTNode
{
    public Expression Condition { get; }
    public StatementList Body { get; }

    public WhileStatement(Expression condition, StatementList body)
    {
        Condition = condition;
        Body = body;
    }

    public void Accept(IVisitor visitor) => visitor.VisitWhileStatement(this);
}
```

#### PrintStatement.cs (Record)
```csharp
public record PrintStatement : ASTNode
{
    public Expression Expression { get; }

    public PrintStatement(Expression expression)
    {
        Expression = expression;
    }

    public void Accept(IVisitor visitor) => visitor.VisitPrintStatement(this);
}
```

#### Expression.cs (Record)
```csharp
public record Expression : ASTNode
{
    public Term Left { get; }
    public Token Operator { get; }
    public Expression Right { get; }

    public Expression(Term left, Token @operator, Expression right)
    {
        Left = left;
        Operator = @operator;
        Right = right;
    }

    public Expression(Term term) // For unary expressions or single terms
    {
        Left = term;
        Operator = null;
        Right = null;
    }

    public void Accept(IVisitor visitor) => visitor.VisitExpression(this);
}
```

#### Term.cs (Record)
```csharp
public record Term : ASTNode
{
    public Factor Left { get; }
    public Token Operator { get; }
    public Term Right { get; }

    public Term(Factor left, Token @operator, Term right)
    {
        Left = left;
        Operator = @operator;
        Right = right;
    }

    public Term(Factor factor) // For unary terms or single factors
    {
        Left = factor;
        Operator = null;
        Right = null;
    }

    public void Accept(IVisitor visitor) => visitor.VisitTerm(this);
}
```

#### Factor.cs (Record)
```csharp
public record Factor : ASTNode
{
    public Token Value { get; }
    public Expression Expression { get; } // For parenthesized expressions

    public Factor(Token value)
    {
        Value = value;
        Expression = null;
    }

    public Factor(Expression expression) // For parenthesized expressions
    {
        Value = null;
        Expression = expression;
    }

    public void Accept(IVisitor visitor) => visitor.VisitFactor(this);
}
```

#### PrettyPrinter.cs
```csharp
using System.Text;

public class PrettyPrinter : IVisitor
{
    private StringBuilder output = new StringBuilder();

    public string GetResult() => output.ToString();

    public void VisitProgram(Program program)
    {
        VisitStatementList(program.Statements);
    }

    public void VisitStatementList(StatementList statementList)
    {
        foreach (var statement in statementList.Statements)
            statement.Accept(this);

        output.AppendLine();
    }

    public void VisitAssignmentStatement(AssignmentStatement assignmentStatement)
    {
        output.Append($"{assignmentStatement.Identifier} := ");
        VisitExpression(assignmentStatement.Expression);
        output.AppendLine(";");
    }

    public void VisitIfStatement(IfStatement ifStatement)
    {
        output.Append("if ");
        VisitExpression(ifStatement.Condition);
        output.Append(" then");
        VisitStatementList(ifStatement.Body);
        output.AppendLine("end;");
    }

    public void VisitWhileStatement(WhileStatement whileStatement)
    {
        output.Append("while ");
        VisitExpression(whileStatement.Condition);
        output.Append(" do");
        VisitStatementList(whileStatement.Body);
        output.AppendLine("end;");
    }

    public void VisitPrintStatement(PrintStatement printStatement)
    {
        output.Append("print ");
        VisitExpression(printStatement.Expression);
        output.AppendLine(";");
    }

    private void VisitExpression(Expression expression)
    {
        if (expression.Right == null && expression.Operator == null)
            VisitTerm(expression.Left);
        else
        {
            VisitTerm(expression.Left);
            output.Append($" {expression.Operator.Lexeme} ");
            VisitExpression(expression.Right);
        }
    }

    private void VisitTerm(Term term)
    {
        if (term.Right == null && term.Operator == null)
            VisitFactor(term.Left);
        else
        {
            VisitFactor(term.Left);
            output.Append($" {term.Operator.Lexeme} ");
            VisitTerm(term.Right);
        }
    }

    private void VisitFactor(Factor factor)
    {
        if (factor.Expression != null)
        {
            output.Append("(");
            VisitExpression(factor.Expression);
            output.Append(")");
        }
        else
            output.Append(factor.Value.Literal);
    }
}
```

#### LexerTests.cs (Unit Tests with MSTest Framework)

1. **Add Microsoft Unit Test Project:**
   - Right-click on the solution.
   - Add > New Project...
   - Select "MSTest Test Project (.NET Core)" and name it `LexerGrammar.Tests`.

2. **Create Unit Test Code:**

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestAssignmentStatement()
    {
        var source = "x := 10;";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(4, tokens.Count);

        Assert.AreEqual(TokenType.Identifier, tokens[0].Type);
        Assert.AreEqual("x", tokens[0].Literal);

        Assert.AreEqual(TokenType.ColonEquals, tokens[1].Type);
        
        Assert.AreEqual(TokenType.Number, tokens[2].Type);
        Assert.AreEqual("10", tokens[2].Literal);

        Assert.AreEqual(TokenType.Semicolon, tokens[3].Type);
    }

    [TestMethod]
    public void TestIfStatement()
    {
        var source = "if x > 5 then print x; end";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(8, tokens.Count);

        Assert.AreEqual(TokenType.If, tokens[0].Type);
        
        Assert.AreEqual(TokenType.Identifier, tokens[1].Type);
        Assert.AreEqual("x", tokens[1].Literal);
        
        // Additional tokens testing...
    }

    [TestMethod]
    public void TestWhileStatement()
    {
        var source = "while x < 10 do print x; end";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(9, tokens.Count);

        Assert.AreEqual(TokenType.While, tokens[0].Type);
        
        Assert.AreEqual(TokenType.Identifier, tokens[1].Type);
        Assert.AreEqual("x", tokens[1].Literal);
        
        // Additional tokens testing...
    }

    [TestMethod]
    public void TestPrintStatement()
    {
        var source = "print x;";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(3, tokens.Count);

        Assert.AreEqual(TokenType.Print, tokens[0].Type);
        
        Assert.AreEqual(TokenType.Identifier, tokens[1].Type);
        Assert.AreEqual("x", tokens[1].Literal);

        Assert.AreEqual(TokenType.Semicolon, tokens[2].Type);
    }

    [TestMethod]
    public void TestExpression()
    {
        var source = "x + 5 * (y - 3)";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        // Complex expression testing...
    }
    
    // Additional tests for other grammar rules.
}
```

### Notes:
- The `LexerTests` class contains placeholder tests. You should expand these to cover all bounding conditions and grammar rules.
- Ensure that the `Lexer` correctly handles various token sequences as per the provided grammar.
- The `PrettyPrinter` class is a simple visitor pattern implementation for printing an AST in a readable format.

This setup provides a base for your .NET 9.0 solution with the specified requirements, including lexer, AST nodes, pretty printer, and unit tests. You should expand on this code to cover all grammar rules fully and ensure robustness through comprehensive testing.