namespace LexerProject
{
    public interface ILexer
    {
        readonly string Input;
        void Initialize();
        bool HasMoreTokens();
        Token GetNextToken();
    }
}