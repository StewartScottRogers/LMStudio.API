// Parser.cs
using System;
using System.Collections.Generic;

namespace LexerAstCore
{
	public class Parser
	{
		private readonly Lexer lexer;
		private TokenTuple currentToken;

		public Parser(Lexer lexer)
		{
			this.lexer = lexer;
			var result = lexer.GetNextToken();
			currentToken = result.Item1;
		}

		public ProgramNode ParseProgram()
		{
			List<AstNode> statements = new List<AstNode>();
			while (currentToken.Type != TokenType.EndOfFile)
			{
				statements.Add(ParseStatement());
			}
			return new ProgramNode(statements);
		}

		private AstNode ParseStatement()
		{
			if (currentToken.Type == TokenType.Identifier)
			{
				return ParseAssignStmt();
			}
			else
			{
				throw new Exception("Unexpected token in statement.");
			}
		}

		private AssignStmtNode ParseAssignStmt()
		{
			string identifier = currentToken.Value;
			Consume(TokenType.Identifier);

			if (currentToken.Type == TokenType.Assign)
			{
				Consume(TokenType.Assign);
				AstNode expression = ParseExpression();
				return new AssignStmtNode(identifier, expression);
			}
			else
			{
				throw new Exception("Expected ':=' in assignment statement.");
			}
		}

		private AstNode ParseExpression()
		{
			// Very basic expression parsing for now.  Expand as needed.
			if (currentToken.Type == TokenType.Number)
			{
				string number = currentToken.Value;
				Consume(TokenType.Number);
				return new NumberNode(int.Parse(number)); // Assuming integer numbers
			}
			else if (currentToken.Type == TokenType.Identifier)
			{
				string identifier = currentToken.Value;
				Consume(TokenType.Identifier);
				return new IdentifierNode(identifier);
			}
			else
			{
				throw new Exception("Unexpected token in expression.");
			}
		}

		private void Consume(TokenType expectedType)
		{
			if (currentToken.Type == expectedType)
			{
				var result = lexer.GetNextToken();
				currentToken = result.Item1;
			}
			else
			{
				throw new Exception($"Expected token of type {expectedType}, but found {currentToken.Type}.");
			}
		}
	}

    public class NumberNode : AstNode
    {
        public readonly int Value;

        public NumberNode(int value)
        {
            Value = value;
        }

        public override void Print(int indent)
        {
            Console.WriteLine($"{new string(' ', indent)}Number: {Value}");
        }
    }

    public class IdentifierNode : AstNode
    {
        public readonly string Name;

        public IdentifierNode(string name)
        {
            Name = name;
        }

        public override void Print(int indent)
        {
            Console.WriteLine($"{new string(' ', indent)}Identifier: {Name}");
        }
    }
}