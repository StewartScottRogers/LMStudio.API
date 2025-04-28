// Lexer.cs
using System;
using System.Collections.Generic;

namespace LexerAstCore
{
	public class Lexer
	{
		private readonly string sourceCode;
		private int currentPosition;

		public Lexer(string code)
		{
			sourceCode = code;
			currentPosition = 0;
		}

		public (TokenTuple, bool) GetNextToken()
		{
			// Skip whitespace
			while (currentPosition < sourceCode.Length && char.IsWhiteSpace(sourceCode[currentPosition]))
			{
				currentPosition++;
			}

			if (currentPosition >= sourceCode.Length)
			{
				return (new TokenTuple(TokenType.EndOfFile, ""), false);
			}

			char currentChar = sourceCode[currentPosition];

			if (char.IsLetter(currentChar))
			{
				string identifier = ReadIdentifier();
				return (new TokenTuple(TokenType.Identifier, identifier), true);
			}
			else if (char.IsDigit(currentChar))
			{
				string number = ReadNumber();
				return (new TokenTuple(TokenType.Number, number), true);
			}

			switch (currentChar)
			{
				case '+': return (new TokenTuple(TokenType.Plus, "+"), true);
				case '-': return (new TokenTuple(TokenType.Minus, "-"), true);
				case '*': return (new TokenTuple(TokenType.Multiply, "*"), true);
				case '/': return (new TokenTuple(TokenType.Divide, "/"), true);
				case ':':
					if (currentPosition + 1 < sourceCode.Length && sourceCode[currentPosition + 1] == '=')
					{
						currentPosition += 2;
						return (new TokenTuple(TokenType.Assign, ":="), true);
					}
					else
					{
						throw new Exception("Invalid character sequence."); // Or handle as an error token
					}
				case '(': return (new TokenTuple(TokenType.LeftParen, "("), true);
				case ')': return (new TokenTuple(TokenType.RightParen, ")"), true);
				case ';': return (new TokenTuple(TokenType.Semicolon, ";"), true);
				default: throw new Exception("Invalid character."); // Or handle as an error token
			}
		}

		private string ReadIdentifier()
		{
			string identifier = "";
			while (currentPosition < sourceCode.Length && (char.IsLetter(sourceCode[currentPosition]) || char.IsDigit(sourceCode[currentPosition])))
			{
				identifier += sourceCode[currentPosition];
				currentPosition++;
			}
			return identifier;
		}

		private string ReadNumber()
		{
			string number = "";
			while (currentPosition < sourceCode.Length && char.IsDigit(sourceCode[currentPosition]))
			{
				number += sourceCode[currentPosition];
				currentPosition++;
			}
			return number;
		}
	}
}