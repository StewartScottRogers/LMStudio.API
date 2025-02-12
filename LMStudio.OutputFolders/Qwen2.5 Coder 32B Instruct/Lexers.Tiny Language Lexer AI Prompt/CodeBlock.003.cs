using System.Text;

public class Lexer : ILexer
{
    private readonly string source;
    private int current = 0;
    private int start = 0;
    private int line = 1;

    public Lexer(string source)
    {
        this.source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public IEnumerable<Token> Lex()
    {
        while (!IsAtEnd())
        {
            start = current;
            yield return ScanToken();
        }
        yield return new Token(TokenKind.Eof, null);
    }

    private bool IsAtEnd() => current >= source.Length;

    private Token ScanToken()
    {
        char c = Advance();

        switch (c)
        {
            case '+': return MakeToken(TokenKind.Plus);
            case '-': return MakeToken(TokenKind.Minus);
            case '*': return MakeToken(TokenKind.Star);
            case '/': return MakeToken(TokenKind.Slash);
            case '=': return Match('=') ? MakeToken(TokenKind.Assign) : throw new Exception("Unexpected character");
            case ';': return MakeToken(TokenKind.Semicolon);
            case '(': return MakeToken(TokenKind.LeftParenthesis);
            case ')': return MakeToken(TokenKind.RightParenthesis);

            case char ch when IsWhitespace(ch): AdvanceWhile(IsWhitespace); break;
            case char ch when IsAlpha(ch): return Identifier();
            case char ch when IsDigit(ch): return Number();

            default: throw new Exception("Unexpected character");
        }

        return new Token(TokenKind.Eof, null);
    }

    private char Advance()
    {
        current++;
        return source[current - 1];
    }

    private bool Match(char expected)
    {
        if (IsAtEnd()) return false;
        if (source[current] != expected) return false;

        current++;
        return true;
    }

    private Token MakeToken(TokenKind kind)
    {
        string text = source.Substring(start, current - start);
        return new Token(kind, text);
    }

    private bool IsWhitespace(char c) => char.IsWhiteSpace(c);

    private void AdvanceWhile(Predicate<char> predicate)
    {
        while (!IsAtEnd() && predicate(source[current]))
            Advance();
    }

    private bool IsAlpha(char c) => char.IsLetter(c);

    private bool IsDigit(char c) => char.IsDigit(c);

    private Token Identifier()
    {
        AdvanceWhile(IsAlphanumeric);
        string text = source.Substring(start, current - start);
        if (Keywords.TryGetValue(text, out var kind))
            return new Token(kind, text);

        return new Token(TokenKind.Identifier, text);
    }

    private bool IsAlphanumeric(char c) => char.IsLetterOrDigit(c);

    private Token Number()
    {
        AdvanceWhile(IsDigit);
        if (Match('.'))
        {
            AdvanceWhile(IsDigit);
        }
        string number = source.Substring(start, current - start);
        return new Token(TokenKind.NumberLiteral, number);
    }

    private static readonly Dictionary<string, TokenKind> Keywords = new Dictionary<string, TokenKind>
    {
        { "if", TokenKind.If },
        { "then", TokenKind.Then },
        { "while", TokenKind.While },
        { "do", TokenKind.Do },
        { "print", TokenKind.Print },
        { "end", TokenKind.End }
    };
}