Creating a full .NET 9.0 solution as per your specifications would be quite extensive and, at the time of writing (August 2023), .NET 9.0 has not been released yet. However, I can create a .NET 6.0 solution that meets your requirements, which you can then upgrade to .NET 9.0 once it's available.

Below is an example of how you might structure the project:

### File System Structure

```
Solution/
│
├── LexerLibrary/
│   ├── LexerLibrary.csproj
│   ├── Lexer.cs
│   ├── TokenKind.cs
│   ├── Token.cs
│   ├── ASTNode.cs
│   ├── AssignStmt.cs
│   ├── IfStmt.cs
│   ├── WhileStmt.cs
│   ├── PrintStmt.cs
│   ├── Expr.cs
│   ├── Term.cs
│   ├── Factor.cs
│   ├── Id.cs
│   ├── Number.cs
│   └── PrettyPrinter.cs
├── LexerTests/
│   ├── LexerTests.csproj
│   ├── AssignStmtTests.cs
│   ├── IfStmtTests.cs
│   ├── WhileStmtTests.cs
│   ├── PrintStmtTests.cs
│   ├── ExprTests.cs
│   ├── TermTests.cs
│   ├── FactorTests.cs
│   └── IdNumberTests.cs
└── Solution.sln
```

### LexerLibrary Project Files

#### LexerLibrary.csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

</Project>
```

#### TokenKind.cs
```csharp
namespace LexerLibrary
{
    public enum TokenKind
    {
        EndOfFile,
        Id,
        Number,
        Assign,
        Plus,
        Minus,
        Star,
        Slash,
        LeftParen,
        RightParen,
        If,
        Then,
        While,
        Do,
        Print,
        Semicolon
    }
}
```

#### Token.cs
```csharp
namespace LexerLibrary
{
    public record Token(TokenKind Kind, string Value);
}
```

#### Lexer.cs
```csharp
using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private char currentChar;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.currentChar = input[position];
        }

        private void Advance()
        {
            position++;
            if (position >= input.Length)
            {
                currentChar = '\0'; // End of file
            }
            else
            {
                currentChar = input[position];
            }
        }

        private void SkipWhitespace()
        {
            while (currentChar != '\0' && char.IsWhiteSpace(currentChar))
            {
                Advance();
            }
        }

        private Token Number()
        {
            var value = "";
            while (currentChar != '\0' && char.IsDigit(currentChar))
            {
                value += currentChar;
                Advance();
            }
            return new Token(TokenKind.Number, value);
        }

        private bool IsLetter(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        private Token Id()
        {
            var value = "";
            while (currentChar != '\0' && (IsLetter(currentChar) || char.IsDigit(currentChar)))
            {
                value += currentChar;
                Advance();
            }

            if (value == "if")
                return new Token(TokenKind.If, value);
            else if (value == "then")
                return new Token(TokenKind.Then, value);
            else if (value == "while")
                return new Token(TokenKind.While, value);
            else if (value == "do")
                return new Token(TokenKind.Do, value);
            else if (value == "print")
                return new Token(TokenKind.Print, value);

            return new Token(TokenKind.Id, value);
        }

        public Token GetNextToken()
        {
            while (currentChar != '\0')
            {
                if (char.IsWhiteSpace(currentChar))
                {
                    SkipWhitespace();
                    continue;
                }
                else if (IsLetter(currentChar))
                {
                    return Id();
                }
                else if (char.IsDigit(currentChar))
                {
                    return Number();
                }

                var tokenKind = currentChar switch
                {
                    ':'
                        when Peek() == '=' =>
                    {
                        Advance();
                        Advance(); // skip :=
                        yield return new Token(TokenKind.Assign, ":=");
                    },
                    '+' => TokenKind.Plus,
                    '-' => TokenKind.Minus,
                    '*' => TokenKind.Star,
                    '/' => TokenKind.Slash,
                    '(' => TokenKind.LeftParen,
                    ')' => TokenKind.RightParen,
                    ';' => TokenKind.Semicolon,
                    _ => throw new InvalidOperationException($"Unknown character {currentChar}")
                };

                Advance();
                return new Token(tokenKind, currentChar.ToString());
            }

            return new Token(TokenKind.EndOfFile, "");
        }

        private char Peek() => position + 1 < input.Length ? input[position + 1] : '\0';
    }
}
```

#### ASTNode.cs
```csharp
namespace LexerLibrary
{
    public abstract record ASTNode;
}
```

#### AssignStmt.cs
```csharp
namespace LexerLibrary
{
    public record AssignStmt(string Identifier, Expr Expression) : ASTNode;
}
```

#### IfStmt.cs
```csharp
namespace LexerLibrary
{
    public record IfStmt(Expr Condition, List<ASTNode> Statements) : ASTNode;
}
```

#### WhileStmt.cs
```csharp
namespace LexerLibrary
{
    public record WhileStmt(Expr Condition, List<ASTNode> Statements) : ASTNode;
}
```

#### PrintStmt.cs
```csharp
namespace LexerLibrary
{
    public record PrintStmt(Expr Expression) : ASTNode;
}
```

#### Expr.cs
```csharp
namespace LexerLibrary
{
    public abstract record Expr : ASTNode;
}
```

#### Term.cs
```csharp
namespace LexerLibrary
{
    public abstract record Term : Expr;
}
```

#### Factor.cs
```csharp
namespace LexerLibrary
{
    public abstract record Factor : Term;
}
```

#### Id.cs
```csharp
namespace LexerLibrary
{
    public record Id(string Name) : Factor;
}
```

#### Number.cs
```csharp
namespace LexerLibrary
{
    public record Number(int Value) : Factor;
}
```

#### PrettyPrinter.cs
```csharp
using System.Text;

namespace LexerLibrary
{
    public class PrettyPrinter
    {
        private readonly StringBuilder output = new();

        public string Print(ASTNode node)
        {
            switch (node)
            {
                case AssignStmt assign:
                    output.Append($"{assign.Identifier} := {Print(assign.Expression)}");
                    break;
                case IfStmt ifStmt:
                    output.Append($"if {Print(ifStmt.Condition)} then\n");
                    foreach (var stmt in ifStmt.Statements) Print(stmt);
                    output.Append("end\n");
                    break;
                case WhileStmt whileStmt:
                    output.Append($"while {Print(whileStmt.Condition)} do\n");
                    foreach (var stmt in whileStmt.Statements) Print(stmt);
                    output.Append("end\n");
                    break;
                case PrintStmt printStmt:
                    output.Append($"print {Print(printStmt.Expression)}\n");
                    break;
                case Number number:
                    output.Append(number.Value.ToString());
                    break;
                case Id id:
                    output.Append(id.Name);
                    break;
            }

            return output.ToString();
        }
    }
}
```

### LexerTests Project Files

#### LexerTests.csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest.TestFramework" Version="2.2.8" />
    <PackageReference Include="MSTest.TestAdapter" Version="2.2.7" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\LexerLibrary\LexerLibrary.csproj" />
  </ItemGroup>

</Project>
```

#### AssignStmtTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class AssignStmtTests
    {
        [TestMethod]
        public void TestAssignStmt()
        {
            var lexer = new Lexer("x := 10");
            var assignToken = lexer.GetNextToken(); // id
            var colonEqualsToken = lexer.GetNextToken(); // :=
            var numberToken = lexer.GetNextToken(); // number

            Assert.AreEqual(TokenKind.Id, assignToken.Kind);
            Assert.AreEqual(TokenKind.Assign, colonEqualsToken.Kind);
            Assert.AreEqual(TokenKind.Number, numberToken.Kind);

            var astNode = new AssignStmt(assignToken.Value, new Number(int.Parse(numberToken.Value)));
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("x := 10", result);
        }
    }
}
```

#### IfStmtTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class IfStmtTests
    {
        [TestMethod]
        public void TestIfStmt()
        {
            var lexer = new Lexer("if x > y then x := 10 end");
            var ifToken = lexer.GetNextToken(); // if
            var idToken = lexer.GetNextToken(); // id
            var greaterThanToken = lexer.GetNextToken(); // >
            var yIdToken = lexer.GetNextToken(); // id
            var thenToken = lexer.GetNextToken(); // then
            var assignToken = lexer.GetNextToken(); // id
            var colonEqualsToken = lexer.GetNextToken(); // :=
            var numberToken = lexer.GetNextToken(); // number
            var endToken = lexer.GetNextToken(); // end

            Assert.AreEqual(TokenKind.If, ifToken.Kind);
            Assert.AreEqual(TokenKind.Id, idToken.Kind);
            Assert.AreEqual(">", greaterThanToken.Value);
            Assert.AreEqual(TokenKind.Id, yIdToken.Kind);
            Assert.AreEqual(TokenKind.Then, thenToken.Kind);

            var astNode = new IfStmt(
                new Term(), // Placeholder for actual expression logic
                new List<ASTNode>
                {
                    new AssignStmt(assignToken.Value, new Number(int.Parse(numberToken.Value)))
                }
            );
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.IsTrue(result.Contains("if"));
            Assert.IsTrue(result.Contains("then"));
            Assert.IsTrue(result.Contains("end"));
        }
    }
}
```

#### WhileStmtTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class WhileStmtTests
    {
        [TestMethod]
        public void TestWhileStmt()
        {
            var lexer = new Lexer("while x < 10 do x := x + 1 end");
            var whileToken = lexer.GetNextToken(); // while
            var idToken = lexer.GetNextToken(); // id
            var lessThanToken = lexer.GetNextToken(); // <
            var numberToken = lexer.GetNextToken(); // number
            var doToken = lexer.GetNextToken(); // do
            var assignIdToken = lexer.GetNextToken(); // id
            var colonEqualsToken = lexer.GetNextToken(); // :=
            var exprIdToken = lexer.GetNextToken(); // id
            var plusToken = lexer.GetNextToken(); // +
            var oneNumberToken = lexer.GetNextToken(); // number
            var endToken = lexer.GetNextToken(); // end

            Assert.AreEqual(TokenKind.While, whileToken.Kind);
            Assert.AreEqual(TokenKind.Id, idToken.Kind);
            Assert.AreEqual("<", lessThanToken.Value);
            Assert.AreEqual(TokenKind.Number, numberToken.Kind);
            Assert.AreEqual(TokenKind.Do, doToken.Kind);

            var astNode = new WhileStmt(
                new Term(), // Placeholder for actual expression logic
                new List<ASTNode>
                {
                    new AssignStmt(assignIdToken.Value, 
                        new Expr()) // Placeholder for actual expression logic
                }
            );
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.IsTrue(result.Contains("while"));
            Assert.IsTrue(result.Contains("do"));
            Assert.IsTrue(result.Contains("end"));
        }
    }
}
```

#### PrintStmtTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class PrintStmtTests
    {
        [TestMethod]
        public void TestPrintStmt()
        {
            var lexer = new Lexer("print x");
            var printToken = lexer.GetNextToken(); // print
            var idToken = lexer.GetNextToken(); // id

            Assert.AreEqual(TokenKind.Print, printToken.Kind);
            Assert.AreEqual(TokenKind.Id, idToken.Kind);

            var astNode = new PrintStmt(new Id(idToken.Value));
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("print x\n", result);
        }
    }
}
```

#### ExprTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class ExprTests
    {
        // Add tests for expression parsing logic here.
        // This will involve testing the recursive descent parser methods.
    }
}
```

#### TermTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class TermTests
    {
        // Add tests for term parsing logic here.
        // This will involve testing the recursive descent parser methods.
    }
}
```

#### FactorTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class FactorTests
    {
        // Add tests for factor parsing logic here.
        // This will involve testing the recursive descent parser methods.
    }
}
```

#### IdNumberTests.cs
```csharp
using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void TestId()
        {
            var lexer = new Lexer("x");
            var idToken = lexer.GetNextToken(); // id

            Assert.AreEqual(TokenKind.Id, idToken.Kind);

            var astNode = new Id(idToken.Value);
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("x", result);
        }

        [TestMethod]
        public void TestNumber()
        {
            var lexer = new Lexer("123");
            var numberToken = lexer.GetNextToken(); // number

            Assert.AreEqual(TokenKind.Number, numberToken.Kind);

            var astNode = new Number(int.Parse(numberToken.Value));
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("123", result);
        }
    }
}
```

### Solution File (Solution.sln)
```plaintext
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.33506.458
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "LexerLibrary", "LexerLibrary\LexerLibrary.csproj", "{5AECC48D-E6A7-4421-A69A-CDB8CFB2AEEA}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "LexerTests", "LexerTests\LexerTests.csproj", "{C65CB768-CF9E-453A-A122-ECCAEADFF18F}"
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {5AECC48D-E6A7-4421-A69A-CDB8CFB2AEEA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {5AECC48D-E6A7-4421-A69A-CDB8CFB2AEEA}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {5AECC48D-E6A7-4421-A69A-CDB8CFB2AEEA}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {5AECC48D-E6A7-4421-A69A-CDB8CFB2AEEA}.Release|Any CPU.Build.0 = Release|Any CPU
        {C65CB768-CF9E-453A-A122-ECCAEADFF18F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {C65CB768-CF9E-453A-A122-ECCAEADFF18F}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {C65CB768-CF9E-453A-A122-ECCAEADFF18F}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {C65CB768-CF9E-453A-A122-ECCAEADFF18F}.Release|Any CPU.Build.0 = Release|Any CPU
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
EndGlobal
```

### Notes:
- The `Lexer` class provided is a basic lexer that can tokenize the input string according to the grammar rules. It currently does not implement the full parsing logic for expressions, terms, and factors.
- The `Expr`, `Term`, and `Factor` records are placeholders for the actual expression parsing logic which should be implemented as per your grammar.
- Unit tests are created using MSTest and cover basic scenarios. You will need to expand upon these tests to ensure all bounding conditions are covered.

This structure provides a solid foundation that can be extended to fully implement the lexer, parser, and pretty printer for your specified grammar. Once .NET 9.0 is available, you can upgrade this project by modifying the `TargetFramework` in the `.csproj` files to `net9.0`.