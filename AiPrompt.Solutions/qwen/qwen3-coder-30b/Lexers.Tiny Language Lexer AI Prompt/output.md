# Solution Structure

Here's the complete solution for a lexer and AST parser with 25 unit tests, following all your requirements:

## File: LexerSolution.sln
```
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "LexerLibrary", "LexerLibrary\LexerLibrary.csproj", "{45396A37-3397-4319-829F-3C4137444D14}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "LexerTests", "LexerTests\LexerTests.csproj", "{45396A37-3397-4319-829F-3C4137444D15}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{45396A37-3397-4319-829F-3C4137444D14}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{45396A37-3397-4319-829F-3C4137444D14}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{45396A37-3397-4319-829F-3C4137444D14}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{45396A37-3397-4319-829F-3C4137444D14}.Release|Any CPU.Build.0 = Release|Any CPU
		{45396A37-3397-4319-829F-3C4137444D15}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{45396A37-3397-4319-829F-3C4137444D15}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{45396A37-3397-4319-829F-3C4137444D15}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{45396A37-3397-4319-829F-3C4137444D15}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
```

## File: LexerLibrary/LexerLibrary.csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

</Project>
```

## File: LexerLibrary/Token.cs
```csharp
namespace LexerLibrary
{
    /// <summary>
    /// Represents a token in the source code with its type and value.
    /// </summary>
    public record Token(TokenType TokenType, string Value);
}
```

## File: LexerLibrary/TokenType.cs
```csharp
namespace LexerLibrary
{
    /// <summary>
    /// Enumeration of all possible token types in our grammar.
    /// </summary>
    public enum TokenType
    {
        // Keywords
        If,
        Then,
        End,
        While,
        Do,
        Print,

        // Operators and punctuation
        Assign,
        Plus,
        Minus,
        Multiply,
        Divide,
        LeftParen,
        RightParen,
        Semicolon,

        // Identifiers and literals
        Identifier,
        Number,

        // Special tokens
        Eof,
        Unknown
    }
}
```

## File: LexerLibrary/Lexer.cs
```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace LexerLibrary
{
    /// <summary>
    /// Lexical analyzer that converts source code into tokens.
    /// </summary>
    public class Lexer
    {
        private readonly string SourceCode;
        private int CurrentPosition;
        private readonly int SourceLength;

        /// <summary>
        /// Initializes a new instance of the Lexer class with the given source code.
        /// </summary>
        /// <param name="sourceCode">The source code to lex.</param>
        public Lexer(string sourceCode)
        {
            SourceCode = sourceCode;
            CurrentPosition = 0;
            SourceLength = sourceCode.Length;
        }

        /// <summary>
        /// Gets the next token from the source code.
        /// </summary>
        /// <returns>A tuple containing the token type and value.</returns>
        public (TokenType TokenType, string Value) NextTokenTuple()
        {
            // Skip whitespace
            while (CurrentPosition < SourceLength && char.IsWhiteSpace(SourceCode[CurrentPosition]))
            {
                CurrentPosition++;
            }

            // Check for end of file
            if (CurrentPosition >= SourceLength)
            {
                return (TokenType.Eof, string.Empty);
            }

            char currentChar = SourceCode[CurrentPosition];

            // Handle different token types
            return currentChar switch
            {
                ':' when CurrentPosition + 1 < SourceLength && SourceCode[CurrentPosition + 1] == '=' =>
                    AdvanceAndReturnToken(TokenType.Assign, 2),
                '+' => AdvanceAndReturnToken(TokenType.Plus, 1),
                '-' => AdvanceAndReturnToken(TokenType.Minus, 1),
                '*' => AdvanceAndReturnToken(TokenType.Multiply, 1),
                '/' => AdvanceAndReturnToken(TokenType.Divide, 1),
                '(' => AdvanceAndReturnToken(TokenType.LeftParen, 1),
                ')' => AdvanceAndReturnToken(TokenType.RightParen, 1),
                ';' => AdvanceAndReturnToken(TokenType.Semicolon, 1),
                _ when char.IsLetter(currentChar) => ReadIdentifierTuple(),
                _ when char.IsDigit(currentChar) => ReadNumberTuple(),
                _ => (TokenType.Unknown, currentChar.ToString())
            };
        }

        /// <summary>
        /// Reads an identifier from the source code.
        /// </summary>
        /// <returns>A tuple containing the token type and value for the identifier.</returns>
        private (TokenType TokenType, string Value) ReadIdentifierTuple()
        {
            var identifierBuilder = new StringBuilder();
            
            while (CurrentPosition < SourceLength && 
                   (char.IsLetter(SourceCode[CurrentPosition]) || char.IsDigit(SourceCode[CurrentPosition])))
            {
                identifierBuilder.Append(SourceCode[CurrentPosition]);
                CurrentPosition++;
            }
            
            string identifierValue = identifierBuilder.ToString();
            
            // Check for reserved keywords
            return identifierValue.ToLower() switch
            {
                "if" => (TokenType.If, identifierValue),
                "then" => (TokenType.Then, identifierValue),
                "end" => (TokenType.End, identifierValue),
                "while" => (TokenType.While, identifierValue),
                "do" => (TokenType.Do, identifierValue),
                "print" => (TokenType.Print, identifierValue),
                _ => (TokenType.Identifier, identifierValue)
            };
        }

        /// <summary>
        /// Reads a number from the source code.
        /// </summary>
        /// <returns>A tuple containing the token type and value for the number.</returns>
        private (TokenType TokenType, string Value) ReadNumberTuple()
        {
            var numberBuilder = new StringBuilder();
            
            while (CurrentPosition < SourceLength && char.IsDigit(SourceCode[CurrentPosition]))
            {
                numberBuilder.Append(SourceCode[CurrentPosition]);
                CurrentPosition++;
            }
            
            return (TokenType.Number, numberBuilder.ToString());
        }

        /// <summary>
        /// Advances the current position and returns a token.
        /// </summary>
        /// <param name="tokenType">The type of token to return.</param>
        /// <param name="advanceCount">Number of characters to advance.</param>
        /// <returns>A tuple containing the specified token type and value.</returns>
        private (TokenType TokenType, string Value) AdvanceAndReturnToken(TokenType tokenType, int advanceCount)
        {
            CurrentPosition += advanceCount;
            return (tokenType, tokenType.ToString());
        }
    }
}
```

## File: LexerLibrary/ASTNode.cs
```csharp
using System.Collections.Generic;

namespace LexerLibrary
{
    /// <summary>
    /// Base abstract class for all AST nodes.
    /// </summary>
    public abstract record AstNode
    {
        /// <summary>
        /// Gets the line number where this node appears in the source code.
        /// </summary>
        public int LineNumber { get; init; }

        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public abstract string PrettyPrint();
    }
}
```

## File: LexerLibrary/ProgramNode.cs
```csharp
using System.Collections.Generic;
using System.Linq;

namespace LexerLibrary
{
    /// <summary>
    /// Represents the root program node in an AST.
    /// </summary>
    public record ProgramNode(List<AstNode> StatementList) : AstNode
    {
        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public override string PrettyPrint()
        {
            var builder = new System.Text.StringBuilder();
            builder.AppendLine("Program:");
            
            foreach (var statement in StatementList)
            {
                builder.Append(statement.PrettyPrint());
            }
            
            return builder.ToString();
        }
    }
}
```

## File: LexerLibrary/StatementNode.cs
```csharp
namespace LexerLibrary
{
    /// <summary>
    /// Represents a statement node in an AST.
    /// </summary>
    public record StatementNode : AstNode
    {
        /// <summary>
        /// Gets or sets the type of statement.
        /// </summary>
        public StatementType StatementType { get; init; }

        /// <summary>
        /// Gets or sets the expression associated with this statement (for assignments, conditions).
        /// </summary>
        public AstNode Expression { get; init; }

        /// <summary>
        /// Gets or sets the list of statements for control structures.
        /// </summary>
        public List<AstNode> StatementList { get; init; }

        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public override string PrettyPrint()
        {
            return StatementType switch
            {
                StatementType.Assign => $"  Assign: {Expression.PrettyPrint()}\n",
                StatementType.If => $"  If: {Expression.PrettyPrint()}\n    Then:\n{string.Join("", StatementList.Select(s => s.PrettyPrint()))}",
                StatementType.While => $"  While: {Expression.PrettyPrint()}\n    Do:\n{string.Join("", StatementList.Select(s => s.PrettyPrint()))}",
                StatementType.Print => $"  Print: {Expression.PrettyPrint()}\n",
                _ => string.Empty
            };
        }
    }

    /// <summary>
    /// Enumeration of statement types.
    /// </summary>
    public enum StatementType
    {
        Assign,
        If,
        While,
        Print
    }
}
```

## File: LexerLibrary/ExpressionNode.cs
```csharp
using System.Collections.Generic;

namespace LexerLibrary
{
    /// <summary>
    /// Represents an expression node in an AST.
    /// </summary>
    public record ExpressionNode : AstNode
    {
        /// <summary>
        /// Gets or sets the type of expression.
        /// </summary>
        public ExpressionType ExpressionType { get; init; }

        /// <summary>
        /// Gets or sets the left operand for binary operations.
        /// </summary>
        public AstNode LeftOperand { get; init; }

        /// <summary>
        /// Gets or sets the right operand for binary operations.
        /// </summary>
        public AstNode RightOperand { get; init; }

        /// <summary>
        /// Gets or sets the value for terminal nodes (identifiers, numbers).
        /// </summary>
        public string Value { get; init; }

        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public override string PrettyPrint()
        {
            return ExpressionType switch
            {
                ExpressionType.Terminal => Value,
                ExpressionType.Addition => $"{LeftOperand.PrettyPrint()} + {RightOperand.PrettyPrint()}",
                ExpressionType.Subtraction => $"{LeftOperand.PrettyPrint()} - {RightOperand.PrettyPrint()}",
                ExpressionType.Multiplication => $"{LeftOperand.PrettyPrint()} * {RightOperand.PrettyPrint()}",
                ExpressionType.Division => $"{LeftOperand.PrettyPrint()} / {RightOperand.PrettyPrint()}",
                _ => string.Empty
            };
        }
    }

    /// <summary>
    /// Enumeration of expression types.
    /// </summary>
    public enum ExpressionType
    {
        Terminal,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
```

## File: LexerLibrary/Parser.cs
```csharp
using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    /// <summary>
    /// Recursive descent parser for the given grammar.
    /// </summary>
    public class Parser
    {
        private readonly Lexer Lexer;
        private (TokenType TokenType, string Value) CurrentTokenTuple;

        /// <summary>
        /// Initializes a new instance of the Parser class with the given lexer.
        /// </summary>
        /// <param name="lexer">The lexer to use for tokenizing input.</param>
        public Parser(Lexer lexer)
        {
            Lexer = lexer;
            CurrentTokenTuple = lexer.NextTokenTuple();
        }

        /// <summary>
        /// Parses a program and returns the root AST node.
        /// </summary>
        /// <returns>The root ProgramNode of the parsed AST.</returns>
        public ProgramNode ParseProgram()
        {
            var statementList = ParseStatementList();
            return new ProgramNode(statementList);
        }

        /// <summary>
        /// Parses a list of statements.
        /// </summary>
        /// <returns>A list of AST nodes representing statements.</returns>
        private List<AstNode> ParseStatementList()
        {
            var statements = new List<AstNode>();
            
            while (CurrentTokenTuple.TokenType != TokenType.Eof && 
                   CurrentTokenTuple.TokenType != TokenType.End)
            {
                var statement = ParseStatement();
                statements.Add(statement);
                
                // Check for semicolon separator
                if (CurrentTokenTuple.TokenType == TokenType.Semicolon)
                {
                    CurrentTokenTuple = Lexer.NextTokenTuple();
                }
                else
                {
                    break;
                }
            }
            
            return statements;
        }

        /// <summary>
        /// Parses a single statement.
        /// </summary>
        /// <returns>An AST node representing the statement.</returns>
        private AstNode ParseStatement()
        {
            return CurrentTokenTuple.TokenType switch
            {
                TokenType.Identifier => ParseAssignmentStatement(),
                TokenType.If => ParseIfStatement(),
                TokenType.While => ParseWhileStatement(),
                TokenType.Print => ParsePrintStatement(),
                _ => throw new InvalidOperationException($"Unexpected token: {CurrentTokenTuple.TokenType}")
            };
        }

        /// <summary>
        /// Parses an assignment statement.
        /// </summary>
        /// <returns>An AST node representing the assignment.</returns>
        private AstNode ParseAssignmentStatement()
        {
            var identifier = CurrentTokenTuple.Value;
            CurrentTokenTuple = Lexer.NextTokenTuple();
            
            if (CurrentTokenTuple.TokenType != TokenType.Assign)
            {
                throw new InvalidOperationException("Expected := in assignment statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple();
            var expression = ParseExpression();
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.Assign,
                Expression = expression
            };
        }

        /// <summary>
        /// Parses an if statement.
        /// </summary>
        /// <returns>An AST node representing the if statement.</returns>
        private AstNode ParseIfStatement()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "if"
            var condition = ParseExpression();
            
            if (CurrentTokenTuple.TokenType != TokenType.Then)
            {
                throw new InvalidOperationException("Expected 'then' in if statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple();
            var statements = ParseStatementList();
            
            if (CurrentTokenTuple.TokenType != TokenType.End)
            {
                throw new InvalidOperationException("Expected 'end' in if statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "end"
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.If,
                Expression = condition,
                StatementList = statements
            };
        }

        /// <summary>
        /// Parses a while statement.
        /// </summary>
        /// <returns>An AST node representing the while statement.</returns>
        private AstNode ParseWhileStatement()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "while"
            var condition = ParseExpression();
            
            if (CurrentTokenTuple.TokenType != TokenType.Do)
            {
                throw new InvalidOperationException("Expected 'do' in while statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple();
            var statements = ParseStatementList();
            
            if (CurrentTokenTuple.TokenType != TokenType.End)
            {
                throw new InvalidOperationException("Expected 'end' in while statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "end"
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.While,
                Expression = condition,
                StatementList = statements
            };
        }

        /// <summary>
        /// Parses a print statement.
        /// </summary>
        /// <returns>An AST node representing the print statement.</returns>
        private AstNode ParsePrintStatement()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "print"
            var expression = ParseExpression();
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.Print,
                Expression = expression
            };
        }

        /// <summary>
        /// Parses an expression.
        /// </summary>
        /// <returns>An AST node representing the expression.</returns>
        private AstNode ParseExpression()
        {
            var left = ParseTerm();
            
            if (CurrentTokenTuple.TokenType == TokenType.Plus || 
                CurrentTokenTuple.TokenType == TokenType.Minus)
            {
                var op = CurrentTokenTuple.TokenType;
                CurrentTokenTuple = Lexer.NextTokenTuple();
                var right = ParseExpression();
                
                return new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = op == TokenType.Plus ? ExpressionType.Addition : ExpressionType.Subtraction,
                    LeftOperand = left,
                    RightOperand = right
                };
            }
            
            return left;
        }

        /// <summary>
        /// Parses a term.
        /// </summary>
        /// <returns>An AST node representing the term.</returns>
        private AstNode ParseTerm()
        {
            var left = ParseFactor();
            
            if (CurrentTokenTuple.TokenType == TokenType.Multiply || 
                CurrentTokenTuple.TokenType == TokenType.Divide)
            {
                var op = CurrentTokenTuple.TokenType;
                CurrentTokenTuple = Lexer.NextTokenTuple();
                var right = ParseTerm();
                
                return new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = op == TokenType.Multiply ? ExpressionType.Multiplication : ExpressionType.Division,
                    LeftOperand = left,
                    RightOperand = right
                };
            }
            
            return left;
        }

        /// <summary>
        /// Parses a factor.
        /// </summary>
        /// <returns>An AST node representing the factor.</returns>
        private AstNode ParseFactor()
        {
            return CurrentTokenTuple.TokenType switch
            {
                TokenType.Identifier => new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = ExpressionType.Terminal,
                    Value = CurrentTokenTuple.Value
                },
                TokenType.Number => new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = ExpressionType.Terminal,
                    Value = CurrentTokenTuple.Value
                },
                TokenType.LeftParen => ParseParenthesizedExpression(),
                _ => throw new InvalidOperationException($"Unexpected token in factor: {CurrentTokenTuple.TokenType}")
            };
        }

        /// <summary>
        /// Parses a parenthesized expression.
        /// </summary>
        /// <returns>An AST node representing the parenthesized expression.</returns>
        private AstNode ParseParenthesizedExpression()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip '('
            var expression = ParseExpression();
            
            if (CurrentTokenTuple.TokenType != TokenType.RightParen)
            {
                throw new InvalidOperationException("Expected ')' in parenthesized expression");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip ')'
            
            return expression;
        }
    }
}
```

## File: LexerTests/LexerTests.csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.1.1" />
    <PackageReference Include="MSTest.TestFramework" Version="3.1.1" />
    <PackageReference Include="coverlet.collector" Version="6.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\LexerLibrary\LexerLibrary.csproj" />
  </ItemGroup>

</Project>
```

## File: LexerTests/UnitTest1.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerLibrary;

namespace LexerTests
{
    [TestClass]
    public class LexerTests
    {
        /// <summary>
        /// Test that the lexer correctly identifies a single identifier.
        /// </summary>
        [TestMethod]
        public void TestSingleIdentifier()
        {
            var lexer = new Lexer("x");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a single number.
        /// </summary>
        [TestMethod]
        public void TestSingleNumber()
        {
            var lexer = new Lexer("42");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("42", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple assignment.
        /// </summary>
        [TestMethod]
        public void TestAssignment()
        {
            var lexer = new Lexer("x := 5");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple if statement.
        /// </summary>
        [TestMethod]
        public void TestIfStatement()
        {
            var lexer = new Lexer("if x then end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.If, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Then, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple while statement.
        /// </summary>
        [TestMethod]
        public void TestWhileStatement()
        {
            var lexer = new Lexer("while x do end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.While, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Do, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple print statement.
        /// </summary>
        [TestMethod]
        public void TestPrintStatement()
        {
            var lexer = new Lexer("print x");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Print, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple addition.
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            var lexer = new Lexer("x + y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple subtraction.
        /// </summary>
        [TestMethod]
        public void TestSubtraction()
        {
            var lexer = new Lexer("x - y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Minus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple multiplication.
        /// </summary>
        [TestMethod]
        public void TestMultiplication()
        {
            var lexer = new Lexer("x * y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple division.
        /// </summary>
        [TestMethod]
        public void TestDivision()
        {
            var lexer = new Lexer("x / y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Divide, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies parentheses.
        /// </summary>
        [TestMethod]
        public void TestParentheses()
        {
            var lexer = new Lexer("(x)");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.LeftParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.RightParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a semicolon.
        /// </summary>
        [TestMethod]
        public void TestSemicolon()
        {
            var lexer = new Lexer("x;");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex expression.
        /// </summary>
        [TestMethod]
        public void TestComplexExpression()
        {
            var lexer = new Lexer("x + y * z");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex assignment.
        /// </summary>
        [TestMethod]
        public void TestComplexAssignment()
        {
            var lexer = new Lexer("x := y + z");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex if statement.
        /// </summary>
        [TestMethod]
        public void TestComplexIfStatement()
        {
            var lexer = new Lexer("if x + y then z := 5; end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.If, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Then, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex while statement.
        /// </summary>
        [TestMethod]
        public void TestComplexWhileStatement()
        {
            var lexer = new Lexer("while x * y do z := 5; end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.While, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Do, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex print statement.
        /// </summary>
        [TestMethod]
        public void TestComplexPrintStatement()
        {
            var lexer = new Lexer("print x + y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Print, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a multi-character identifier.
        /// </summary>
        [TestMethod]
        public void TestMultiCharacterIdentifier()
        {
            var lexer = new Lexer("variable123");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("variable123", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a multi-digit number.
        /// </summary>
        [TestMethod]
        public void TestMultiDigitNumber()
        {
            var lexer = new Lexer("12345");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("12345", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies whitespace handling.
        /// </summary>
        [TestMethod]
        public void TestWhitespaceHandling()
        {
            var lexer = new Lexer("  x   :=   5  ");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies keywords.
        /// </summary>
        [TestMethod]
        public void TestKeywords()
        {
            var lexer = new Lexer("if then end while do print");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.If, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Then, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.While, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Do, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Print, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies an empty input.
        /// </summary>
        [TestMethod]
        public void TestEmptyInput()
        {
            var lexer = new Lexer("");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex nested expression.
        /// </summary>
        [TestMethod]
        public void TestNestedExpression()
        {
            var lexer = new Lexer("(x + y) * z");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.LeftParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.RightParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies an expression with multiple operators.
        /// </summary>
        [TestMethod]
        public void TestMultipleOperators()
        {
            var lexer = new Lexer("x + y - z * w");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Minus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("w", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a statement with multiple semicolons.
        /// </summary>
        [TestMethod]
        public void TestMultipleSemicolons()
        {
            var lexer = new Lexer("x := 1; y := 2;");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("1", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("2", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly handles mixed case identifiers.
        /// </summary>
        [TestMethod]
        public void TestMixedCaseIdentifiers()
        {
            var lexer = new Lexer("VariableName");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("VariableName", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }
    }
}
```