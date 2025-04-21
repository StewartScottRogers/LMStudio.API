Okay, here's a complete .NET 9.0 solution for the Lexer and Abstract Syntax Tree (AST) generation based on your provided grammar, adhering to all specified coding standards and requirements.  This includes classes, interfaces, records, enums, unit tests, and documentation.

**Solution Structure:**

The solution will contain the following projects:

*   **LexerLibrary**: The core library containing the lexer and AST definitions.
*   **LexerTests**: A project for unit testing the lexer.

**1. LexerLibrary Project**

This project contains all the code related to the grammar, tokenization, AST nodes, and pretty printing.

**File: `TokenTypes.cs`**

```csharp
namespace LexerLibrary;

public enum TokenType
{
    Identifier,
    Number,
    Plus,
    Minus,
    Multiply,
    Divide,
    Assign,
    IfKeyword,
    ThenKeyword,
    EndKeyword,
    WhileKeyword,
    DoKeyword,
    PrintKeyword,
    LeftParen,
    RightParen,
    Semicolon,
    EndOfFile
}
```

**File: `Token.cs`**

```csharp
namespace LexerLibrary;

public record Token(TokenType Type, string Value)
{
    public override string ToString()
    {
        return $"({Type}, {Value})";
    }
}
```

**File: `Lexer.cs`**

```csharp
using System;
using System.Collections.Generic;

namespace LexerLibrary;

public class Lexer
{
    private readonly string _inputString;
    private int _position;

    public Lexer(string inputString)
    {
        _inputString = inputString;
        _position = 0;
    }

    public (Token Token, string RemainingInput) GetNextToken()
    {
        if (_position >= _inputString.Length)
        {
            return (new Token(TokenType.EndOfFile, ""), "");
        }

        char currentChar = _inputString[_position];

        // Skip whitespace
        while (char.IsWhiteSpace(currentChar))
        {
            _position++;
            if (_position >= _inputString.Length)
            {
                return (new Token(TokenType.EndOfFile, ""), "");
            }
            currentChar = _inputString[_position];
        }

        if (char.IsLetter(currentChar))
        {
            string identifier = ReadIdentifier();
            return (new Token(TokenType.Identifier, identifier), RemainingInput);
        }
        else if (char.IsDigit(currentChar))
        {
            string number = ReadNumber();
            return (new Token(TokenType.Number, number), RemainingInput);
        }

        switch (currentChar)
        {
            case '+':
                _position++;
                return (new Token(TokenType.Plus, "+"), RemainingInput);
            case '-':
                _position++;
                return (new Token(TokenType.Minus, "-"), RemainingInput);
            case '*':
                _position++;
                return (new Token(TokenType.Multiply, "*"), RemainingInput);
            case '/':
                _position++;
                return (new Token(TokenType.Divide, "/"), RemainingInput);
            case ':':
                if (_position + 1 < _inputString.Length && _inputString[_position + 1] == '=')
                {
                    _position += 2;
                    return (new Token(TokenType.Assign, ":="), RemainingInput);
                }
                else
                {
                    // Handle single ':' as an error or unexpected character
                    throw new ArgumentException($"Unexpected character ':'.");
                }
            case ';':
                _position++;
                return (new Token(TokenType.Semicolon, ";"), RemainingInput);
            case '(':
                _position++;
                return (new Token(TokenType.LeftParen, "("), RemainingInput);
            case ')':
                _position++;
                return (new Token(TokenType.RightParen, ")"), RemainingInput);
            default:
                throw new ArgumentException($"Unexpected character '{currentChar}'.");
        }
    }

    private string ReadIdentifier()
    {
        int startPosition = _position;
        while (_position < _inputString.Length && (char.IsLetter(_inputString[_position]) || char.IsDigit(_inputString[_position])))
        {
            _position++;
        }
        return _inputString.Substring(startPosition, _position - startPosition);
    }

    private string ReadNumber()
    {
        int startPosition = _position;
        while (_position < _inputString.Length && char.IsDigit(_inputString[_position]))
        {
            _position++;
        }
        return _inputString.Substring(startPosition, _position - startPosition);
    }

    public string RemainingInput => _inputString.Substring(_position);
}
```

**File: `AstNodeTypes.cs`**

```csharp
namespace LexerLibrary;

public enum AstNodeType
{
    Program,
    StatementList,
    AssignStatement,
    IfStatement,
    WhileStatement,
    PrintStatement,
    Expression,
    Term,
    Factor,
    Identifier,
    Number
}
```

**File: `AstNode.cs`**

```csharp
using System.Collections.Generic;

namespace LexerLibrary;

public abstract class AstNode
{
    public AstNodeType NodeType { get; set; }
}
```

**File: `ProgramNode.cs`**

```csharp
using System.Collections.Generic;

namespace LexerLibrary;

public class ProgramNode : AstNode
{
    public List<AstNode> Statements { get; set; } = new List<AstNode>();

    public ProgramNode()
    {
        NodeType = AstNodeType.Program;
    }
}
```

**File: `AssignStatementNode.cs`**

```csharp
namespace LexerLibrary;

public class AssignStatementNode : AstNode
{
    public string Identifier { get; set; }
    public ExpressionNode Expression { get; set; }

    public AssignStatementNode()
    {
        NodeType = AstNodeType.AssignStatement;
    }
}
```

**File: `IfStatementNode.cs`**

```csharp
using System.Collections.Generic;

namespace LexerLibrary;

public class IfStatementNode : AstNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode ThenBlock { get; set; }

    public IfStatementNode()
    {
        NodeType = AstNodeType.IfStatement;
    }
}
```

**File: `WhileStatementNode.cs`**

```csharp
using System.Collections.Generic;

namespace LexerLibrary;

public class WhileStatementNode : AstNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode DoBlock { get; set; }

    public WhileStatementNode()
    {
        NodeType = AstNodeType.WhileStatement;
    }
}
```

**File: `PrintStatementNode.cs`**

```csharp
namespace LexerLibrary;

public class PrintStatementNode : AstNode
{
    public ExpressionNode Expression { get; set; }

    public PrintStatementNode()
    {
        NodeType = AstNodeType.PrintStatement;
    }
}
```

**File: `ExpressionNode.cs`**

```csharp
namespace LexerLibrary;

public class ExpressionNode : AstNode
{
    public TermNode Left { get; set; }
    public string Operator { get; set; }
    public ExpressionNode Right { get; set; }

    public ExpressionNode()
    {
        NodeType = AstNodeType.Expression;
    }
}
```

**File: `TermNode.cs`**

```csharp
namespace LexerLibrary;

public class TermNode : AstNode
{
    public FactorNode Left { get; set; }
    public string Operator { get; set; }
    public TermNode Right { get; set; }

    public TermNode()
    {
        NodeType = AstNodeType.Term;
    }
}
```

**File: `FactorNode.cs`**

```csharp
namespace LexerLibrary;

public class FactorNode : AstNode
{
    public IdentifierNode Identifier { get; set; }
    public NumberNode Number { get; set; }
    public ExpressionNode Expression { get; set; }

    public FactorNode()
    {
        NodeType = AstNodeType.Factor;
    }
}
```

**File: `IdentifierNode.cs`**

```csharp
namespace LexerLibrary;

public class IdentifierNode : AstNode
{
    public string Value { get; set; }

    public IdentifierNode()
    {
        NodeType = AstNodeType.Identifier;
    }
}
```

**File: `NumberNode.cs`**

```csharp
namespace LexerLibrary;

public class NumberNode : AstNode
{
    public string Value { get; set; }

    public NumberNode()
    {
        NodeType = AstNodeType.Number;
    }
}
```

**File: `StatementListNode.cs`**

```csharp
using System.Collections.Generic;

namespace LexerLibrary;

public class StatementListNode : AstNode
{
    public List<AstNode> Statements { get; set; } = new List<AstNode>();

    public StatementListNode()
    {
        NodeType = AstNodeType.StatementList;
    }
}
```

**File: `Parser.cs`**

```csharp
using System;
using System.Collections.Generic;

namespace LexerLibrary;

public class Parser
{
    private readonly Lexer _lexer;
    private (Token Token, string RemainingInput) _currentToken;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _currentToken = _lexer.GetNextToken();
    }

    public ProgramNode ParseProgram()
    {
        var programNode = new ProgramNode();
        programNode.Statements = ParseStatementList();
        return programNode;
    }

    private List<AstNode> ParseStatementList()
    {
        var statements = new List<AstNode>();
        statements.Add(ParseStatement());

        while (_currentToken.Token.Type == TokenType.Semicolon)
        {
            ConsumeToken(); // Consume the semicolon
            if (_currentToken.Token.Type != TokenType.EndOfFile)
            {
                statements.Add(ParseStatement());
            }
        }

        return statements;
    }

    private AstNode ParseStatement()
    {
        switch (_currentToken.Token.Type)
        {
            case TokenType.Identifier:
                return ParseAssignStatement();
            case TokenType.IfKeyword:
                return ParseIfStatement();
            case TokenType.WhileKeyword:
                return ParseWhileStatement();
            case TokenType.PrintKeyword:
                return ParsePrintStatement();
            default:
                throw new ArgumentException($"Unexpected token '{_currentToken.Token}'.");
        }
    }

    private AssignStatementNode ParseAssignStatement()
    {
        var assignStatementNode = new AssignStatementNode();
        assignStatementNode.Identifier = _currentToken.Token.Value;
        ConsumeToken(); // Consume identifier

        if (_currentToken.Token.Type != TokenType.Assign)
        {
            throw new ArgumentException($"Expected ':=' token.");
        }
        ConsumeToken(); // Consume assignment operator

        assignStatementNode.Expression = ParseExpression();
        return assignStatementNode;
    }

    private IfStatementNode ParseIfStatement()
    {
        var ifStatementNode = new IfStatementNode();
        ConsumeToken(); // Consume "if" keyword

        ifStatementNode.Condition = ParseExpression();

        if (_currentToken.Token.Type != TokenType.ThenKeyword)
        {
            throw new ArgumentException($"Expected 'then' token.");
        }
        ConsumeToken(); // Consume "then" keyword

        ifStatementNode.ThenBlock = ParseStatementList();

        if (_currentToken.Token.Type != TokenType.EndKeyword)
        {
            throw new ArgumentException($"Expected 'end' token.");
        }
        ConsumeToken(); // Consume "end" keyword

        return ifStatementNode;
    }

    private WhileStatementNode ParseWhileStatement()
    {
        var whileStatementNode = new WhileStatementNode();
        ConsumeToken(); // Consume "while" keyword

        whileStatementNode.Condition = ParseExpression();

        if (_currentToken.Token.Type != TokenType.DoKeyword)
        {
            throw new ArgumentException($"Expected 'do' token.");
        }
        ConsumeToken(); // Consume "do" keyword

        whileStatementNode.DoBlock = ParseStatementList();

        if (_currentToken.Token.Type != TokenType.EndKeyword)
        {
            throw new ArgumentException($"Expected 'end' token.");
        }
        ConsumeToken(); // Consume "end" keyword

        return whileStatementNode;
    }

    private PrintStatementNode ParsePrintStatement()
    {
        var printStatementNode = new PrintStatementNode();
        ConsumeToken(); // Consume "print" keyword

        printStatementNode.Expression = ParseExpression();
        return printStatementNode;
    }

    private ExpressionNode ParseExpression()
    {
        var expressionNode = new ExpressionNode();
        expressionNode.Left = ParseTerm();

        while (_currentToken.Token.Type == TokenType.Plus || _currentToken.Token.Type == TokenType.Minus)
        {
            expressionNode.Operator = _currentToken.Token.Value;
            ConsumeToken(); // Consume operator
            expressionNode.Right = ParseTerm();
        }

        return expressionNode;
    }

    private TermNode ParseTerm()
    {
        var termNode = new TermNode();
        termNode.Left = ParseFactor();

        while (_currentToken.Token.Type == TokenType.Multiply || _currentToken.Token.Token.Type == TokenType.Divide)
        {
            termNode.Operator = _currentToken.Token.Value;
            ConsumeToken(); // Consume operator
            termNode.Right = ParseFactor();
        }

        return termNode;
    }

    private FactorNode ParseFactor()
    {
        var factorNode = new FactorNode();

        switch (_currentToken.Token.Type)
        {
            case TokenType.Identifier:
                factorNode.Identifier = new IdentifierNode { Value = _currentToken.Token.Value };
                ConsumeToken(); // Consume identifier
                return factorNode;
            case TokenType.Number:
                factorNode.Number = new NumberNode { Value = _currentToken.Token.Value };
                ConsumeToken(); // Consume number
                return factorNode;
            case TokenType.LeftParen:
                ConsumeToken(); // Consume "("
                factorNode.Expression = ParseExpression();
                if (_currentToken.Token.Type != TokenType.RightParen)
                {
                    throw new ArgumentException($"Expected ')' token.");
                }
                ConsumeToken(); // Consume ")"
                return factorNode;
            default:
                throw new ArgumentException($"Unexpected token '{_currentToken.Token}'.");
        }
    }

    private void ConsumeToken()
    {
        _currentToken = _lexer.GetNextToken();
    }
}
```

**File: `AstPrettyPrinter.cs`**

```csharp
using System;
using System.Text;

namespace LexerLibrary;

public class AstPrettyPrinter
{
    private readonly StringBuilder _stringBuilder = new StringBuilder();
    private int _indentLevel = 0;

    public string Print(AstNode node)
    {
        _stringBuilder.Clear();
        PrintNode(node);
        return _stringBuilder.ToString();
    }

    private void PrintNode(AstNode node, bool isLast = true)
    {
        Indent();
        _stringBuilder.Append($"{node.NodeType}: ");

        switch (node)
        {
            case ProgramNode programNode:
                _stringBuilder.AppendLine("Program");
                foreach (var statement in programNode.Statements)
                {
                    PrintNode(statement);
                }
                break;
            case StatementListNode statementListNode:
                _stringBuilder.AppendLine("Statement List");
                foreach (var statement in statementListNode.Statements)
                {
                    PrintNode(statement);
                }
                break;
            case AssignStatementNode assignStatementNode:
                _stringBuilder.Append($"Assign '{assignStatementNode.Identifier}' = ");
                PrintNode(assignStatementNode.Expression);
                _stringBuilder.AppendLine();
                break;
            case IfStatementNode ifStatementNode:
                _stringBuilder.AppendLine("If Statement");
                PrintNode(ifStatementNode.Condition);
                PrintNode(ifStatementNode.ThenBlock);
                break;
            case WhileStatementNode whileStatementNode:
                _stringBuilder.AppendLine("While Statement");
                PrintNode(whileStatementNode.Condition);
                PrintNode(whileStatementNode.DoBlock);
                break;
            case PrintStatementNode printStatementNode:
                _stringBuilder.Append($"Print ");
                PrintNode(printStatementNode.Expression);
                _stringBuilder.AppendLine();
                break;
            case ExpressionNode expressionNode:
                _stringBuilder.Append($"Expression '{expressionNode.Operator}'");
                PrintNode(expressionNode.Left);
                PrintNode(expressionNode.Right);
                break;
            case TermNode termNode:
                _stringBuilder.Append($"Term '{termNode.Operator}'");
                PrintNode(termNode.Left);
                PrintNode(termNode.Right);
                break;
            case FactorNode factorNode:
                if (factorNode.Identifier != null)
                {
                    _stringBuilder.Append($"Factor Identifier '{factorNode.Identifier.Value}'");
                    _stringBuilder.AppendLine();
                }
                else if (factorNode.Number != null)
                {
                    _stringBuilder.Append($"Factor Number '{factorNode.Number.Value}'");
                    _stringBuilder.AppendLine();
                }
                else if (factorNode.Expression != null)
                {
                    _stringBuilder.Append("Factor Expression ");
                    PrintNode(factorNode.Expression);
                }
                break;
            case IdentifierNode identifierNode:
                _stringBuilder.Append($"Identifier '{identifierNode.Value}'");
                _stringBuilder.AppendLine();
                break;
            case NumberNode numberNode:
                _stringBuilder.Append($"Number '{numberNode.Value}'");
                _stringBuilder.AppendLine();
                break;
            default:
                _stringBuilder.AppendLine("Unknown Node Type");
                break;
        }

    }

    private void Indent()
    {
        for (int i = 0; i < _indentLevel; i++)
        {
            _stringBuilder.Append("  ");
        }
    }
}
```

**2. LexerTests Project**

This project contains unit tests for the lexer.

**File: `LexerTests.cs`**

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerLibrary;

namespace LexerTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestIdentifier()
        {
            var lexer = new Lexer("abc");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Type);
            Assert.AreEqual("abc", token.Value);
        }

        [TestMethod]
        public void TestNumber()
        {
            var lexer = new Lexer("123");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Number, token.Type);
            Assert.AreEqual("123", token.Value);
        }

        [TestMethod]
        public void TestPlus()
        {
            var lexer = new Lexer("+");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Plus, token.Type);
            Assert.AreEqual("+", token.Value);
        }

        [TestMethod]
        public void TestMinus()
        {
            var lexer = new Lexer("-");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Minus, token.Type);
            Assert.AreEqual("-", token.Value);
        }

        [TestMethod]
        public void TestMultiply()
        {
            var lexer = new Lexer("*");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Multiply, token.Type);
            Assert.AreEqual("*", token.Value);
        }

        [TestMethod]
        public void TestDivide()
        {
            var lexer = new Lexer("/");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Divide, token.Type);
            Assert.AreEqual("/", token.Value);
        }

        [TestMethod]
        public void TestAssign()
        {
            var lexer = new Lexer(":=");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Assign, token.Type);
            Assert.AreEqual(":=", token.Value);
        }

        [TestMethod]
        public void TestIfKeyword()
        {
            var lexer = new Lexer("if");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.IfKeyword, token.Type);
            Assert.AreEqual("if", token.Value);
        }

        [TestMethod]
        public void TestThenKeyword()
        {
            var lexer = new Lexer("then");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.ThenKeyword, token.Type);
            Assert.AreEqual("then", token.Value);
        }

        [TestMethod]
        public void TestEndKeyword()
        {
            var lexer = new Lexer("end");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.EndKeyword, token.Type);
            Assert.AreEqual("end", token.Value);
        }

        [TestMethod]
        public void TestWhileKeyword()
        {
            var lexer = new Lexer("while");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.WhileKeyword, token.Type);
            Assert.AreEqual("while", token.Value);
        }

        [TestMethod]
        public void TestDoKeyword()
        {
            var lexer = new Lexer("do");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.DoKeyword, token.Type);
            Assert.AreEqual("do", token.Value);
        }

        [TestMethod]
        public void TestPrintKeyword()
        {
            var lexer = new Lexer("print");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.PrintKeyword, token.Type);
            Assert.AreEqual("print", token.Value);
        }

        [TestMethod]
        public void TestLeftParen()
        {
            var lexer = new Lexer("(");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.LeftParen, token.Type);
            Assert.AreEqual("(", token.Value);
        }

        [TestMethod]
        public void TestRightParen()
        {
            var lexer = new Lexer(")");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.RightParen, token.Type);
            Assert.AreEqual(")", token.Value);
        }

        [TestMethod]
        public void TestSemicolon()
        {
            var lexer = new Lexer(";");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Semicolon, token.Type);
            Assert.AreEqual(";", token.Value);
        }

        [TestMethod]
        public void TestWhitespace()
        {
            var lexer = new Lexer("  abc");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Type);
            Assert.AreEqual("abc", token.Value);
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            var lexer = new Lexer("a + b * c");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();
            (Token token4, _) = lexer.GetNextToken();
            (Token token5, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.Identifier, token1.Type);
            Assert.AreEqual(TokenType.Plus, token2.Type);
            Assert.AreEqual(TokenType.Identifier, token3.Type);
            Assert.AreEqual(TokenType.Multiply, token4.Type);
            Assert.AreEqual(TokenType.Identifier, token5.Type);
        }

        [TestMethod]
        public void TestAssignStatement()
        {
            var lexer = new Lexer("x := 10");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.Identifier, token1.Type);
            Assert.AreEqual(TokenType.Assign, token2.Type);
            Assert.AreEqual(TokenType.Number, token3.Type);
        }

        [TestMethod]
        public void TestIfStatement()
        {
            var lexer = new Lexer("if a then end");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.IfKeyword, token1.Type);
            Assert.AreEqual(TokenType.Identifier, token2.Type);
            Assert.AreEqual(TokenType.ThenKeyword, token3.Type);
        }

        [TestMethod]
        public void TestWhileStatement()
        {
            var lexer = new Lexer("while a do end");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.WhileKeyword, token1.Type);
            Assert.AreEqual(TokenType.Identifier, token2.Type);
            Assert.AreEqual(TokenType.DoKeyword, token3.Type);
        }

        [TestMethod]
        public void TestPrintStatement()
        {
            var lexer = new Lexer("print a");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.PrintKeyword, token1.Type);
            Assert.AreEqual(TokenType.Identifier, token2.Type);
        }

    }
}
```

**Important Considerations:**

*   **Error Handling**:  The `Lexer` and `Parser` classes include basic error handling (throwing exceptions for unexpected characters). In a production environment, you'd want more robust error reporting with line numbers and context.
*   **AST Construction**: The parser is responsible for building the AST based on the grammar rules.
*   **Unit Tests**:  The unit tests cover various token types and simple expressions. You should add more comprehensive tests to cover all possible scenarios, including complex nested expressions, different operator precedence, and error conditions.
*   **Tuple Usage:** The `GetNextToken` method returns a tuple containing the token and remaining input string.

This provides a solid foundation for your lexer and AST generator.  You can expand upon this by adding more features, such as symbol tables, semantic analysis, code generation, etc. Let me know if you'd like help with any specific aspect of the implementation!
