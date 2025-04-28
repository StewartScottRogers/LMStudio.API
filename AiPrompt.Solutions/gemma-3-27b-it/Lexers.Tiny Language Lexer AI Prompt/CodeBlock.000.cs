// TokenTypes.cs
namespace LexerAstCore
{
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
}