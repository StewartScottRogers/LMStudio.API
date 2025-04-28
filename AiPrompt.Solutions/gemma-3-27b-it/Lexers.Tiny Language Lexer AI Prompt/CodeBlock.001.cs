// Token.cs
namespace LexerAstCore
{
	public record TokenTuple(TokenType Type, string Value)
	{
		public readonly TokenType Type;
		public readonly string Value;
	}
}