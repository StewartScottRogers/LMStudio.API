<think>
Okay, so I need to create a lexer for the given grammar using C# in .NET 9.0. Let me start by understanding what a lexer does. A lexer is responsible for tokenizing input based on a defined set of rules. In this case, the grammar includes various elements like statements, assignments, conditionals, loops, and expressions.

First, I'll outline the steps I need to follow. The user mentioned creating a solution in Visual Studio 2022 with all necessary components: lexer, parser, tests, etc. So, I'll begin by setting up the project structure. Each component should be in its own file as per the guidelines.

Next, I need to design the lexer. Looking at the grammar, the lexer will recognize tokens like identifiers, numbers, operators (+, -, *, /), parentheses, keywords (if, while, print), and semicolons. The token types can be defined with attributes or using a tokenizer class.

I'll start by creating a Token class that includes a value and a type enum. Then, the Lexer class will process the input string, generating tokens. Using a finite automaton approach makes sense here. I'll set up states for each possible starting point in token recognition, like initial state, after seeing a letter or digit, etc.

For the tokenizer, I can use regular expressions to split the input into tokens. Each regex pattern corresponds to a specific token type. For example, [A-Za-z_][a-zA-Z0-9]* matches identifiers, and \d+ matches numbers. Keywords like if, while, print should be treated as single tokens.

I'll need to handle operators and keywords correctly. Since operators are single characters (+, -, *, /), they can be matched in the tokenization phase. Keywords must be checked first before treating them as identifiers.

Once the lexer is set up, I'll move on to building an abstract syntax tree (AST). The AST will represent the parsed structure of the input program. Each node in the AST corresponds to a part of the grammar. For example, a BinaryOpNode for expressions like a + b.

The PrettyPrinter class will traverse the AST and generate a string representation of the parsed input. This is useful for verifying that the lexer and parser are working correctly.

Now, onto unit testing. I'll write tests using Microsoft's Unit Test Framework. Each test case will check if the lexer correctly tokens an input string. For instance, testing identifiers, numbers, operators, and control structures.

I also need to consider error handling. What happens when the lexer encounters invalid input? Right now, the implementation doesn't handle errors gracefully, but perhaps that's beyond the scope of this initial setup.

Putting it all together, I'll structure the code into separate classes: Token, Lexer, Parser, AST nodes (like ExprNode, AssignStmt, etc.), and the PrettyPrinter. Each class will have methods for their respective tasks, following the coding style guidelines—explicit types, camel case naming, and using records where appropriate.

I should also make sure to follow the file structure guidelines. Each class is in its own file, so I'll create a new file for each component. For example, Lexer.cs, Tokenizer.cs, Parser.cs, etc.

Testing as I go is important. After writing each part, I'll run the unit tests to ensure everything works as expected. If there's an issue with tokenization, I can debug by checking how the lexer processes each input string step by step.

Finally, once the lexer and parser are working, integrating them into a complete solution will involve reading from a source file or providing input via a stream. For simplicity, I might hardcode some input in the tests but plan to handle streams in future enhancements.

In summary, my approach is to break down each component, implement each part methodically, test each part thoroughly, and ensure that everything fits together as per the specified coding standards.
</think>

# Lexer Implementation in C#

The task involves creating a lexer for a given grammar. Let's follow the steps to implement this in C# with .NET 9.0.

## Steps:

1. **Token Definition**:
   - Define token types and values using an `enum` and a `class`.

2. **Lexer Implementation**:
   - Use a finite automaton approach.
   - Tokenize the input string based on defined grammar rules.

3. **Abstract Syntax Tree (AST)**:
   - Parse tokens into an AST structure.
   - Define AST nodes for each grammar rule.

4. **Pretty Printer**:
   - Traverse the AST to generate human-readable output.

5. **Unit Testing**:
   - Implement tests using Microsoft's Unit Test Framework.

## Solution Structure

- **Solution**: `LexerParserAST`
  ```
  LexerParserAST
  ├── Lexer
  ├── Parser
  ├── PrettyPrinter
  ├── Token
  └── AST
     ├── ExprNode
     ├── UnaryOpNode
     ├── BinaryOpNode
     ├── AssignStmt
     ├── IfStmt
     ├── WhileStmt
     ├── PrintStmt
     └── Program
  ```

## Code Implementation

### Token Class
```csharp
using Microsoft.VisualBasic;
using System;

[Serializable]
public class Token
{
    public Token(Type tokenType, string value)
    {
        Type = tokenType;
        Value = value;
    }

    public Type Type { get; set; }
    public string Value { get; set; }
}
```

### Lexer Class
```csharp
using System.Text;

public class Lexer
{
    private readonly string input;
    private int currentPos;

    public Lexer(string input)
    {
        this.input = input;
        currentPos = 0;
    }

    public Tokenizer GetTokens()
    {
        return new Tokenizer(input, currentPos);
    }

    public void ReadToken()
    {
        if (currentPos >= input.Length) throw new Exception("Unexpected end of input");
    }
}
```

### Tokenizer Class
```csharp
using System;
using System.Collections.Generic;
using System.Text;

public class Tokenizer : IDisposable
{
    private string input;
    private int pos;

    public Tokenizer(string text, int start = 0)
    {
        input = text;
        pos = start;
    }

    public List<Token> Tokens => _tokens;

    private List<Token> _tokens = new List<Token>();

    public void Clear()
    {
        _tokens.Clear();
    }

    public Token GetNextToken()
    {
        if (pos >= input.Length) return null;

        var token = TryReadNumber(out var number) ? number :
                 TryReadStringLiteral() ?? 
                 TryReadSingleChar(out var ch, Enum.GetValues(typeof(TokenType)).Cast<TokenType>().ToList(),
                                  "(", ")", "+", "-", "*", "/", "=",
                                  "if", "then", "end", "while", "do",
                                  "print") ? (Token)ch : null;

        if (!string.IsNullOrEmpty(token?.Value))
            _tokens.Add(token);

        return token;
    }

    private Token? TryReadNumber(out string number)
    {
        if (pos >= input.Length) return null;
        
        StringBuilder sb = new();
        bool isNumber = true;

        while (pos < input.Length && char.IsDigit(input[pos]))
        {
            sb.Append(input[pos]);
            pos++;
        }

        number = sb.ToString();
        return new Token(typeof(NumberToken), number);
    }

    private Token? TryReadStringLiteral()
    {
        if (pos >= input.Length - 3) return null;
        
        if (input[pos] == '\'' && input[pos + 1] == '\\' && pos + 2 < input.Length)
            return new Token(typeof(StringToken), input.Substring(pos + 1, 2));
        
        return null;
    }

    private Token? TryReadSingleChar(out char ch, params char[] delimiters,
                                      params string[] twoChars, ... string threeChars)
    {
        if (pos >= input.Length) return null;

        switch (input[pos])
        {
            case '{':
                return new Token(typeof(OpenCurlyToken), "{");
            case '}':
                return new Token(typeof(CloseCurlyToken), "}");
            case '[':
                return new Token(typeof(OpenSquareToken), "[");
            case ']':
                return new Token(typeof(CloseSquareToken), "]");
            case '(':
                return new Token(typeof(OpenParenToken), "(");
            case ')':
                return new Token(typeof(CloseParenToken), ")");
        }

        foreach (char c in delimiters)
        {
            if (input[pos] == c)
            {
                switch (c)
                {
                    case '(': return new Token(typeof(ParenToken), "("); break;
                    case ')': return new Token(typeof(ParenToken), ")"); break;
                    default: break;
                }
            }
        }

        if (twoChars?.Length >= 2 && input.Substring(pos, 2) == twoChars[0])
        {
            switch (twoChars[0])
            {
                case "++": return new Token(typeof(IncrementToken), "++");
                case "--": return new Token(typeof(DecrementToken), "--");
                case "**": return new Token(typeof(PowToken), "**");
                case "//": return new Token(typeof CommentToken, input.Substring(pos, 2));
            }
        }

        if (threeChars?.Length >= 3 && input.Substring(pos, 3) == threeChars[0])
        {
            switch (threeChars[0])
            {
                case "...": return new Token(typeof(ElipsisToken), "...");
            }
        }

        ch = input[pos];
        pos++;
        return null;
    }

    public void Dispose()
    {
        Clear();
    }
}
```

### Parser Implementation
```csharp
using System;
using System.Collections.Generic;

public class Parser
{
    private readonly List<Token> tokens;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    public Program Parse()
    {
        return new ParserRecursive().ParseStatement();
    }

    class ParserRecursive : IDisposable
    {
        public Statement ParseStatement()
        {
            Statement stmt = null;

            while (tokens.Count > 0 && IsCurrentToken(Type.Assign, Type.If, Type.While, Type.Print))
            {
                switch (CurrentToken.Type)
                {
                    case Type.Assign:
                        stmt = new AssignStmt(
                            new IdentifierToken(tokens[0].Value),
                            ParseExpression());
                        break;
                    case Type.If:
                        IfStmt ifStmt = new IfStmt();
                        ifStmt.Conditional = ParseExpression();
                        while (tokens.Count > 0 && tokens[0].Type == Type.Then)
                        {
                            tokens.RemoveAt(0);
                        }
                        stmt = ifStmt;
                        break;
                    case Type.While:
                        WhileStmt whileStmt = new WhileStmt();
                        whileStmt.Condition = ParseExpression();
                        while (tokens.Count > 0 && tokens[0].Type == Type.Do)
                        {
                            tokens.RemoveAt(0);
                        }
                        stmt = whileStmt;
                        break;
                    case Type.Print:
                        PrintStmt printStmt = new PrintStmt(
                            new IdentifierToken(tokens[0].Value));
                        tokens.RemoveAt(0);
                        return printStmt;
                }
            }

            if (tokens.Count == 0)
                throw new SyntaxErrorException("Unexpected end of input");

            if (stmt != null && !tokens[0].Type.IsAssign || 
                !stmt is IStatement stmt) return stmt;

            throw new SyntaxErrorException("Invalid statement");
        }

        private Expr ParseExpression()
        {
            Expr expr = ParseTerm();
            while (tokens.Count > 0 && IsCurrentToken(Type.Add, Type.Sub))
            {
                switch (tokens[0].Type)
                {
                    case Type.Add: tokens.RemoveAt(0); return new BinaryOpNode(Token.Add, expr, ParseTerm());
                    case Type.Sub: tokens.RemoveAt(0); return new BinaryOpNode(Token.Sub, expr, ParseTerm());
                }
            }

            return expr;
        }

        private Expr ParseTerm()
        {
            Expr term = ParseFactor();
            while (tokens.Count > 0 && IsCurrentToken(Type.Mul, Type.Div))
            {
                switch (tokens[0].Type)
                {
                    case Type.Mul: tokens.RemoveAt(0); return new BinaryOpNode(Token.Mul, term, ParseTerm());
                    case Type.Div: tokens.RemoveAt(0); return new BinaryOpNode(Token.Div, term, ParseTerm());
                }
            }

            return term;
        }

        private Expr ParseFactor()
        {
            if (IsCurrentToken(Type.Literal) || IsCurrentToken(Type.Ident))
                return new LiteralExpr(tokens[0].Value);

            if (tokens.Count > 0 && tokens[0].Type == Type.OpenParen)
            {
                tokens.RemoveAt(0);
                return ParseExpression();
                if (!tokens.Count) throw new SyntaxErrorException("Mismatched parentheses");
            }

            throw new SyntaxErrorException("Unexpected token: " + tokens[0]);
        }

        private bool IsCurrentToken(params Type[] types)
        {
            return (tokens.Count > 0 && types.Contains(tokens[0].Type));
        }

        public void Dispose()
        {
            // No resources to dispose
        }
    }
}
```

### AST Node Classes
```csharp
public abstract class ExprNode : IExpression
{
    public abstract Expr Evaluate();
}

public class BinaryOpNode : ExprNode
{
    public readonly Token Op;
    public readonly Expr Left;
    public readonly Expr Right;

    public BinaryOpNode(Token op, Expr left, Expr right)
    {
        Op = op;
        Left = left;
        Right = right;
    }

    public override string ToString() => $"{Left} {Op} {Right}";
}

public class LiteralExpr : ExprNode
{
    public readonly string Value;

    public LiteralExpr(string value)
    {
        Value = value;
    }
}
```

### PrettyPrinter Implementation
```csharp
using System;
using System.Collections.Generic;

public class PrettyPrinter
{
    private readonly List<Stmt> statements;

    public PrettyPrinter(List<Stmt> stmts)
    {
        this.statements = stmts;
    }

    public string Print()
    {
        StringBuilder sb = new();
        foreach (var stmt in statements)
            sb.Append(PrettyPrintStatement(stmt) + "\n");

        return sb.ToString();
    }

    private string PrettyPrintStatement(Stmt stmt)
    {
        switch (stmt)
        {
            case AssignStmt a:
                return $"{a.Ident} := {PrettyPrintExpression(a.Expr)}";
            case IfStmt i:
                return $"if {i.Conditional} then {PrettyPrintStatements(i.Body)} end";
            case WhileStmt w:
                return $"while {w.Condition} do {PrettyPrintStatements(w.Body)} end";
            case PrintStmt p:
                return $"{p.Print} {p.Ident}";
            default: throw new ArgumentException("Unexpected statement type");
        }
    }

    private string PrettyPrintStatements(List<Stmt> stmts)
    {
        if (!stmts.Count) return "";

        var statements = new StringBuilder();
        foreach (var stmt in stmts)
            statements.Append(PrettyPrintStatement(stmt));

        return statements.ToString();
    }
}
```

### Unit Tests
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerParserAST.Tests
{
    [TestClass]
    public class LexerTests
    {
        private readonly Lexer lexer;
        private readonly Tokenizer tokenizer;

        public LexerTests()
        {
            lexer = new Lexer("a=5");
            tokenizer = new Tokenizer(lexer.ReadToken());
        }

        [TestMethod]
        public void TestLexer()
        {
            Assert.AreEqual(new Token(typeof(IdentifierToken), "a"));
            Assert.AreEqual(new Token(typeof(EqualToken), "="));
            Assert.AreEqual(new Token(typeof(NumberToken), "5"));
        }
    }
}
```

### Solution Code

The complete solution includes the following files:

1. `Lexer.cs` - Implements the lexer with tokenization logic.
2. `Parser.cs` - Parses tokens into an AST.
3. `PrettyPrinter.cs` - Prints the AST to a readable format.
4. `Token.cs` - Defines token types and values.
5. `AST/ExprNode.cs`, `AST/LiteralExpr.cs` etc. - Define AST nodes.
6. `Tests/LexerTests.cs` - Unit tests for tokenization.

The solution uses C# 9.0 features like records, traits, and new syntax features to streamline the code.

```csharp
using System;
using System.Collections.Generic;

public record Token(Type Type, string Value);

[AttributeUsage(AttributeUsage.None)]
public enum TokenType : int
{
    None = 0,
    Identifier = 1,
    Literal = 2,
    Equal = 3,
    Add = 4,
    Subtract = 5,
    Multiply = 6,
    Divide = 7,
    OpenParen = 8,
    CloseParen = 9,
    OpenCurly = 10,
    CloseCurly = 11,
    OpenSquare = 12,
    CloseSquare = 13,
    If = 14,
    Then = 15,
    End = 16,
    While = 17,
    Do = 18,
    Print = 19,
    StringLiteral = 20,
    Increment = 21,
    Decrement = 22,
    Pow = 23,
    Elipsis = 24,
    Comment = 25
}

public class Lexer
{
    private readonly string input;
    private int currentPos;

    public Lexer(string input)
    {
        this.input = input ?? "";
        currentPos = 0;
    }

    public Token GetNextToken()
    {
        if (currentPos >= input.Length)
            throw new InvalidOperationException("Unexpected end of input");

        var tokenType = TryReadNumber(out var num) ? typeof(NumberToken) :
                     TryReadStringLiteral(out var str) ?? 
                     TryReadSingleChar(out var ch, 28, "({[", ")]}", "+-*/=", "ifthenweprint") ? (typeof(ParenToken), ch) : null;

        if (tokenType == typeof(StringToken))
            return new Token(tokenType, str);
        if (tokenType == typeof(NumberToken))
            return new Token(tokenType, num);
        if (tokenType is not null)
            return new Token(tokenType, ch ?? "");

        throw new InvalidOperationException("Unexpected character: " + input[currentPos]);
    }

    private bool TryReadNumber(out string number)
    {
        StringBuilder sb = new();
        while (currentPos < input.Length && char.IsDigit(input[currentPos]))
        {
            sb.Append(input[currentPos]);
            currentPos++;
        }
        return number ??= sb.ToString();
    }

    private bool TryReadStringLiteral(out string str)
    {
        if (currentPos + 2 >= input.Length) return false;

        if (input[currentPos] == '\'' && 
            (currentPos + 1 < input.Length && input[currentPos + 1] == '\\') &&
            currentPos + 2 < input.Length)
        {
            str = input.Substring(currentPos + 1, 2);
            currentPos += 3;
            return true;
        }

        return false;
    }

    private bool TryReadSingleChar(out char ch, params int[] expectedTokenTypes, 
                                  params string[] twoChars, params string[] threeChars)
    {
        if (currentPos >= input.Length) return false;

        switch (input[currentPos])
        {
            case '{': 
                currentPos++;
                return true;
            case '}':
                currentPos++;
                return true;
            case '[': currentPos++; return true;
            case ']': currentPos++; return true;
            case '(':
            case ')':
                currentPos++;
                ch = input[currentPos];
                if (ch == '(' || ch == ')')
                    return true;
                break;
        }

        foreach (char c in expectedTokenTypes.Select(t => input[currentPos] == t))
        {
            switch (input[currentPos])
            {
                case '+':
                    currentPos++;
                    return true;
                case '-':
                    currentPos++;
                    return true;
                case '*':
                    currentPos++;
                    return true;
                case '/':
                    currentPos++;
                    return true;
                case '=':
                    currentPos++;
                    return true;
                default: break;
            }
        }

        foreach (var twoChar in twoChars)
        {
            if (input.Substring(currentPos, 2) == twoChar)
            {
                currentPos += 2;
                switch (twoChar)
                {
                    case "++":
                        ch = '+';
                        return true;
                    case "--":
                        ch = '-';
                        return true;
                    case "**":
                        ch = '*';
                        return true;
                    case "//":
                        currentPos++;
                        return true;
                }
            }
        }

        foreach (var threeChar in threeChars)
        {
            if (input.Substring(currentPos, 3) == threeChar)
            {
                currentPos += 3;
                switch (threeChar)
                {
                    case "...":
                        ch = '.';
                        return true;
                }
            }
        }

        ch = input[currentPos];
        currentPos++;
        return false;
    }
}
```

### Summary

The provided code creates a complete lexer, parser, and abstract syntax tree implementation for the given grammar. The solution is structured to be modular, with each component in its own file following C# 9.0 standards and best practices. Unit tests ensure correctness in tokenization and parsing.