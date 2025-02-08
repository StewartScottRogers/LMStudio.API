using System.Collections.Generic;
using System.Text;

public class Parser
{
    private readonly List<Token> tokens;
    private int currentTokenIndex = 0;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    public T Parse<T>(Func<TypedParser<T> parser, string type) where T : ASTNode
    {
        return parser.Parse(tokens, currentTokenIndex);
    }

    public T ParseExpression()
    {
        return Parse<Ast.Expression>();
    }
}