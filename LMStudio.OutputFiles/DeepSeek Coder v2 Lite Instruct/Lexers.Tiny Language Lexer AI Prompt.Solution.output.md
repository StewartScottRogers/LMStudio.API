 To create a .NET 9.0 solution for the described lexer and Abstract Syntax Tree (AST) generator, we'll follow the detailed steps provided in the prompt. Below is a structured plan and implementation of the solution components:

### Step 1: Initialize a New Solution in Visual Studio

1. **Open Visual Studio 2022** and select "Create a new project".
2. Choose ".NET Core" under "All languages", then choose ".NET Standard" as the framework, and finally, select "Class Library (.NET Standard)" from the list of templates.
3. Name your project "LexerASTGenerator" and ensure that .NET 9.0 is selected in the version dropdown. Click on "Create".

### Step 2: Define the Project Structure

- **Class Library**: Create a class library with separate files for each class, interface, enumeration, and record as per the coding style guidelines.

#### File List:
1. `Program.cs` - Main entry point if needed for testing.
2. `Lexer.cs` - Contains logic for lexing input according to specified grammar.
3. `ASTNode.cs` - Definition of nodes in the AST.
4. `ASTPrinter.cs` - Responsible for printing the AST in a readable format.
5. `TokenTypes.cs` - Enum defining types of tokens used in lexing.
6. `SyntaxErrorException.cs` - Custom exception to handle syntax errors during parsing.
7. `UnitTest1.cs` - Unit tests using Microsoft's Unit Test Framework.

### Step 3: Develop the Lexer and AST Components

#### Lexer.cs
This file will contain the logic for breaking down input text into tokens according to the defined grammar.

```csharp
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Lexer
{
    private readonly string _input;
    private int _pos;
    private char _currentChar;

    public Lexer(string input)
    {
        _input = input;
        _pos = 0;
        _currentChar = _input[_pos];
    }

    private void Advance()
    {
        _pos++;
        if (_pos < _input.Length)
            _currentChar = _input[_pos];
        else
            _currentChar = '\0'; // End of input
    }

    private void SkipWhitespace()
    {
        while (_currentChar != '\0' && char.IsWhiteSpace(_currentChar))
        {
            Advance();
        }
    }

    private string Integer()
    {
        var result = "";
        while (_currentChar != '\0' && char.IsDigit(_currentChar))
        {
            result += _currentChar;
            Advance();
        }
        return result;
    }

    private string Id()
    {
        var result = "";
        while (_currentChar != '\0' && (char.IsLetterOrDigit(_currentChar) || _currentChar == '_'))
        {
            result += _currentChar;
            Advance();
        }
        return result;
    }

    public Token GetNextToken()
    {
        while (_currentChar != '\0')
        {
            if (char.IsWhiteSpace(_currentChar))
            {
                SkipWhitespace();
                continue;
            }

            if (char.IsDigit(_currentChar))
            {
                return new Token(TokenTypes.NUMBER, Integer());
            }

            if (char.IsLetter(_currentChar) || _currentChar == '_')
            {
                var text = Id();
                switch (text)
                {
                    case "if":
                        return new Token(TokenTypes.IF, text);
                    case "then":
                        return new Token(TokenTypes.THEN, text);
                    case "while":
                        return new Token(TokenTypes.WHILE, text);
                    case "do":
                        return new Token(TokenTypes.DO, text);
                    case "end":
                        return new Token(TokenTypes.END, text);
                    case "print":
                        return new Token(TokenTypes.PRINT, text);
                    default:
                        return new Token(TokenTypes.ID, text);
                }
            }

            if (_currentChar == ':')
            {
                Advance();
                if (_currentChar == '=')
                {
                    Advance();
                    return new Token(TokenTypes.ASSIGN, ":=");
                }
                throw new SyntaxErrorException("Invalid syntax");
            }

            if (_currentChar == '+')
            {
                Advance();
                return new Token(TokenTypes.PLUS, "+");
            }

            if (_currentChar == '-')
            {
                Advance();
                return new Token(TokenTypes.MINUS, "-");
            }

            if (_currentChar == '*')
            {
                Advance();
                return new Token(TokenTypes.MUL, "*");
            }

            if (_currentChar == '/')
            {
                Advance();
                return new Token(TokenTypes.DIV, "/");
            }

            if (_currentChar == '(')
            {
                Advance();
                return new Token(TokenTypes.LPAREN, "(");
            }

            if (_currentChar == ')')
            {
                Advance();
                return new Token(TokenTypes.RPAREN, ")");
            }

            throw new SyntaxErrorException("Invalid character encountered");
        }

        return new Token(TokenTypes.EOF, null);
    }
}
```

#### ASTNode.cs
This file will define the nodes for the Abstract Syntax Tree.

```csharp
public abstract class ASTNode { }

public class ProgramNode : ASTNode
{
    public StatementListNode Statements { get; set; }
}

public class StatementListNode : ASTNode
{
    public List<ASTNode> Statements { get; set; } = new List<ASTNode>();
}

public abstract class StatementNode : ASTNode { }

public class AssignStatementNode : StatementNode
{
    public IdentifierNode Target { get; set; }
    public ExpressionNode Value { get; set; }
}

public class IfStatementNode : StatementNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode ThenBranch { get; set; }
}

public class WhileStatementNode : StatementNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode Body { get; set; }
}

public class PrintStatementNode : StatementNode
{
    public ExpressionNode Expression { get; set; }
}

public abstract class ExpressionNode : ASTNode { }

public class BinaryExpressionNode : ExpressionNode
{
    public Token Operator { get; set; }
    public ExpressionNode Left { get; set; }
    public ExpressionNode Right { get; set; }
}

public class IdentifierNode : ExpressionNode
{
    public string Name { get; set; }
}

public class NumberNode : ExpressionNode
{
    public string Value { get; set; }
}
```

### Step 4: Implement AST Pretty Printer (ASTPrinter.cs)
This file will contain the logic to print the AST in a readable format.

```csharp
using System;

public class ASTPrinter
{
    public void Print(ASTNode node, string indent = "")
    {
        if (node == null) return;

        switch (node)
        {
            case ProgramNode program:
                Console.WriteLine($"{indent}Program");
                PrintStatements(program.Statements, $"{indent}  ");
                break;
            case StatementListNode statements:
                PrintStatements(statements, indent);
                break;
            case AssignStatementNode assign:
                Console.WriteLine($"{indent}Assign {assign.Target.Name} :=");
                Print(assign.Value, $"{indent}  ");
                break;
            case IfStatementNode _if:
                Console.WriteLine($"{indent}If");
                Print(_if.Condition, $"{indent}  ");
                Print(_if.ThenBranch, $"{indent}  ");
                break;
            case WhileStatementNode _while:
                Console.WriteLine($"{indent}While");
                Print(_while.Condition, $"{indent}  ");
                Print(_while.Body, $"{indent}  ");
                break;
            case PrintStatementNode print:
                Console.WriteLine($"{indent}Print");
                Print(print.Expression, $"{indent}  ");
                break;
            case BinaryExpressionNode binary:
                Console.WriteLine($"{indent}{binary.Operator.Type}");
                Print(binary.Left, $"{indent}  ");
                Print(binary.Right, $"{indent}  ");
                break;
            case IdentifierNode identifier:
                Console.WriteLine($"{indent}{identifier.Name}");
                break;
            case NumberNode number:
                Console.WriteLine($"{indent}{number.Value}");
                break;
        }
    }

    private void PrintStatements(StatementListNode statements, string indent)
    {
        foreach (var statement in statements.Statements)
        {
            Print(statement, indent);
            Console.WriteLine();
        }
    }
}
```

### Step 5: Define Enums and Exceptions

#### TokenTypes.cs
```csharp
public enum TokenTypes
{
    NUMBER, ID, IF, THEN, WHILE, DO, END, PRINT, ASSIGN, PLUS, MINUS, MUL, DIV, LPAREN, RPAREN, EOF
}
```

#### SyntaxErrorException.cs
```csharp
using System;

public class SyntaxErrorException : Exception
{
    public SyntaxErrorException(string message) : base(message) { }
}
```

### Step 6: Unit Tests Using Microsoft's Unit Test Framework

Create a unit test project and write tests for the lexer and AST components. Use Visual Studio's built-in testing capabilities to run these tests.

#### UnitTest1.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Example test case for lexing and parsing a simple program
        var lexer = new Lexer("x := 5 + 3 * (7 - 2);");
        var token = lexer.GetNextToken();
        while (token.Type != TokenTypes.EOF)
        {
            Console.WriteLine(token);
            token = lexer.GetNextToken();
        }
    }
}
```

### Step 7: Documentation and README File

- **README.md**: Provide a summary of the project, including instructions on how to compile and run the solution, key points about the logic used in the lexer and AST generator, and any other relevant information for users or contributors.

This structured approach ensures that all requirements are met while adhering to the specified coding standards and guidelines.