using System;
using System.Collections.Generic;

public class TokenType
{
    public readonly string Name;
    public readonly char Symbol;

    private TokenType(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public static readonly TokenType Plus = new("Plus", '+');
    public static readonly TokenType Minus = new("Minus", '-');
    public static readonly TokenType Star = new("Star", '*');
}

# Project Structure

- Lexer
  - Token.cs
  - TokenType.cs
  - Lexer.cs
- AbstractSyntaxTree
  - AstNode.cs
  - StatementNode.cs
  - ExpressionNode.cs
  - CompoundStatementNode.cs
  - SimpleStatementNode.cs
  - PrettyPrinter.cs
- UnitTests
  - UnitTestLexer.cs

### Step-by-Step Solution

#### 1. Initialize a new Solution in Visual Studio
- Open Visual Studio 2022.
- Create a new `.NET 9.0` Solution.
- Name the solution `PythonLexer`.

#### 2. Project Structure
Create the following project structure: