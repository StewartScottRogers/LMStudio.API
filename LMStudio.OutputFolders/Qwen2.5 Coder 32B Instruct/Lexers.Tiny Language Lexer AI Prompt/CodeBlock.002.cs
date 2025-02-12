public interface ILexer
{
    IEnumerable<Token> Lex(string input);
}