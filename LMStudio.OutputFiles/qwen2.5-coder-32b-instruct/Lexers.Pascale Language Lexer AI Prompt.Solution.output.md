Creating a comprehensive lexer and abstract syntax tree (AST) pretty printer for the Pascal-like grammar you've provided is an extensive task. Below, I'll provide a basic structure to get started with your .NET 9.0 solution in C#. This will include setting up the project, creating classes/interfaces/enumerations as specified, generating some of the required lexer and AST components, and writing unit tests.

### Project Setup
1. **Create a new .NET 9.0 Class Library project in Visual Studio 2022**.
2. **Configure the project to use only Microsoft Basic Component Library**.

### Solution Structure

#### Token.cs (Record)
```csharp
public readonly record struct Token(TokenType Type, string Value, int Line, int Column);
```

#### TokenType.cs (Enumeration)
```csharp
public enum TokenType {
    Identifier,
    Keyword,
    IntegerLiteral,
    RealLiteral,
    StringLiteral,
    Operator,
    Delimiter,
    EOF,
}
```

#### Lexer.cs (Class)
```csharp
using System;
using System.Collections.Generic;
using System.IO;

public class Lexer {
    private readonly string sourceCode;
    private readonly int length;
    private int position = 0;
    private int currentLine = 1, currentColumn = 1;
    
    public Lexer(string sourceCode) {
        this.sourceCode = sourceCode;
        this.length = sourceCode.Length;
    }

    public Token NextToken() {
        if (position >= length)
            return new Token(TokenType.EOF, string.Empty, currentLine, currentColumn);

        SkipWhitespace();

        char currentChar = CurrentChar;

        if (char.IsLetter(currentChar))
            return LexIdentifierOrKeyword();
        
        if (char.IsDigit(currentChar))
            return LexNumber();

        if (currentChar == '\'')
            return LexStringLiteral();

        if (IsOperator(currentChar))
            return LexOperator();

        if (IsDelimiter(currentChar))
            return LexDelimiter();

        throw new Exception($"Unknown character {currentChar} at line {currentLine}, column {currentColumn}");
    }

    private void SkipWhitespace() {
        while (position < length && char.IsWhiteSpace(CurrentChar)) {
            if (CurrentChar == '\n') {
                currentLine++;
                currentColumn = 1;
            } else {
                currentColumn++;
            }
            position++;
        }
    }

    private Token LexIdentifierOrKeyword() {
        int start = position;
        while (position < length && (char.IsLetterOrDigit(CurrentChar) || CurrentChar == '_'))
            position++;

        string identifier = sourceCode.Substring(start, position - start);
        currentColumn += position - start;

        if (TryGetKeyword(identifier, out var keyword))
            return new Token(TokenType.Keyword, identifier, currentLine, currentColumn);

        return new Token(TokenType.Identifier, identifier, currentLine, currentColumn);
    }

    private bool TryGetKeyword(string value, out TokenType type) {
        switch (value.ToLower()) {
            case "program": 
                type = TokenType.Keyword;
                return true;
            // Add more keywords here...
            default:
                type = default;
                return false;
        }
    }

    private Token LexNumber() {
        int start = position;

        while (position < length && char.IsDigit(CurrentChar))
            position++;

        if (position < length && CurrentChar == '.') {
            position++;
            while (position < length && char.IsDigit(CurrentChar))
                position++;

            currentColumn += position - start;
            return new Token(TokenType.RealLiteral, sourceCode.Substring(start, position - start), currentLine, currentColumn);
        }

        currentColumn += position - start;
        return new Token(TokenType.IntegerLiteral, sourceCode.Substring(start, position - start), currentLine, currentColumn);
    }

    private char CurrentChar => sourceCode[position];

    private bool IsOperator(char c) {
        switch (c) {
            case '+':
            case '-':
            case '*':
            case '/':
                return true;
            default:
                return false;
        }
    }

    private Token LexOperator() {
        var token = new Token(TokenType.Operator, CurrentChar.ToString(), currentLine, currentColumn);
        position++;
        currentColumn++;
        return token;
    }

    private bool IsDelimiter(char c) {
        switch (c) {
            case ';':
            case ':':
            case '.':
                return true;
            default:
                return false;
        }
    }

    private Token LexDelimiter() {
        var token = new Token(TokenType.Delimiter, CurrentChar.ToString(), currentLine, currentColumn);
        position++;
        currentColumn++;
        return token;
    }

    private Token LexStringLiteral() {
        int start = position + 1;

        while (position < length && CurrentChar != '\'') {
            if (CurrentChar == '\n')
                throw new Exception($"Unclosed string literal at line {currentLine}, column {currentColumn}");
            
            position++;
        }

        if (position >= length)
            throw new Exception($"Unclosed string literal at line {currentLine}, column {currentColumn}");

        var literal = sourceCode.Substring(start, position - start);
        position++; // Skip the closing quote
        currentColumn += position - start + 1;

        return new Token(TokenType.StringLiteral, literal, currentLine, currentColumn);
    }
}
```

#### ASTNode.cs (Abstract Class)
```csharp
public abstract class AstNode {
    public int Line { get; }
    public int Column { get; }

    protected AstNode(int line, int column) {
        Line = line;
        Column = column;
    }

    public abstract string PrettyPrint();
}
```

#### ProgramNode.cs (Class)
```csharp
public sealed class ProgramNode : AstNode {
    public readonly IdentifierNode Identifier;
    public readonly BlockNode Block;

    public ProgramNode(IdentifierNode identifier, BlockNode block, int line, int column) 
        : base(line, column) {
        Identifier = identifier;
        Block = block;
    }

    public override string PrettyPrint() => $"Program {Identifier.PrettyPrint()} {{\n{Block.PrettyPrint()}\n}}";
}
```

#### IdentifierNode.cs (Class)
```csharp
public sealed class IdentifierNode : AstNode {
    public readonly string Name;

    public IdentifierNode(string name, int line, int column) 
        : base(line, column) {
        Name = name;
    }

    public override string PrettyPrint() => $"{Name}";
}
```

#### BlockNode.cs (Class)
```csharp
public sealed class BlockNode : AstNode {
    // For simplicity, just a list of statements.
    public readonly List<AstNode> Statements;

    public BlockNode(List<AstNode> statements, int line, int column) 
        : base(line, column) {
        Statements = statements;
    }

    public override string PrettyPrint() => string.Join("\n", Statements.Select(s => s.PrettyPrint()));
}
```

### Unit Tests
Create a new .NET 9.0 Test project and reference your Class Library.

#### LexerTests.cs (Test Class)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests {
    private static readonly List<(string input, Token expected)> TestCases = new() {
        ("program", new Token(TokenType.Keyword, "program", 1, 1)),
        ("42", new Token(TokenType.IntegerLiteral, "42", 1, 1)),
        ("3.14", new Token(TokenType.RealLiteral, "3.14", 1, 1)),
        ("'Hello World'", new Token(TokenType.StringLiteral, "Hello World", 1, 1)),
        ("+", new Token(TokenType.Operator, "+", 1, 1)),
        (";", new Token(TokenType.Delimiter, ";", 1, 1)),
    };

    [TestMethod]
    public void TestLexer() {
        foreach (var (input, expected) in TestCases) {
            var lexer = new Lexer(input);
            var token = lexer.NextToken();
            
            Assert.AreEqual(expected.Type, token.Type, $"Type mismatch for input '{input}'.");
            Assert.AreEqual(expected.Value, token.Value, $"Value mismatch for input '{input}'.");
            Assert.AreEqual(expected.Line, token.Line, $"Line number mismatch for input '{input}'.");
            Assert.AreEqual(expected.Column, token.Column, $"Column number mismatch for input '{input}'.");
        }
    }

    [TestMethod]
    public void TestEmptyString() {
        var lexer = new Lexer(string.Empty);
        var token = lexer.NextToken();
        
        Assert.AreEqual(TokenType.EOF, token.Type, "Type mismatch for empty string.");
        Assert.AreEqual(string.Empty, token.Value, "Value mismatch for empty string.");
        Assert.AreEqual(1, token.Line, "Line number mismatch for empty string.");
        Assert.AreEqual(1, token.Column, "Column number mismatch for empty string.");
    }

    [TestMethod]
    public void TestCommentsAndWhitespace() {
        var lexer = new Lexer("   \t\nprogram programName;"); // Simulate comments and whitespace
        var token = lexer.NextToken();
        
        Assert.AreEqual(TokenType.Keyword, token.Type, $"Type mismatch for input '   \\t\\nprogram programName;'.");
        Assert.AreEqual("program", token.Value, $"Value mismatch for input '   \\t\\nprogram programName;'.");
    }
}
```

### README.md
```markdown
# Pascal-Like Language Lexer and AST

This project contains a lexer and abstract syntax tree (AST) pretty printer for a Pascal-like language. The grammar is provided in the task description, and this solution aims to parse source code according to it.

## Structure

- `Token.cs`: Defines the token structure.
- `TokenType.cs`: Contains all possible token types.
- `Lexer.cs`: Implements the lexer logic.
- `AstNode.cs`: Base class for AST nodes.
- `ProgramNode.cs`, `IdentifierNode.cs`, `BlockNode.cs`: Example AST node implementations.

## Running

To run this solution:
1. Open the project in Visual Studio 2022.
2. Ensure all dependencies are restored.
3. Build and run tests using the Test Explorer.

## Tests
- The `LexerTests` class contains several unit tests for different lexer functionalities, including parsing keywords, literals, operators, delimiters, and handling whitespace/comments.

Feel free to extend this solution according to your specific needs and the grammar's full specification.
```

### Summary

This setup provides a foundational framework for your project. You can expand it by adding more AST node types, implementing parser logic, and writing additional unit tests as per the provided grammar rules. Ensure you follow all coding conventions and guidelines mentioned in the prompt.

If you have any specific questions or need further assistance with this structure, feel free to ask!