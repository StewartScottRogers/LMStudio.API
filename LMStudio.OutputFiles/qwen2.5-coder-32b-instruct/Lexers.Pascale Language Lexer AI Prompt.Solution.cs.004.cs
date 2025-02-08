public class Parser
{
    private readonly Lexer Lexer;
    private Token CurrentToken;

    public Parser(Lexer lexer)
    {
        Lexer = lexer;
        CurrentToken = Lexer.GetNextToken();
    }

    private void Eat(TokenType tokenType)
    {
        if (CurrentToken.Type == tokenType) 
            CurrentToken = Lexer.GetNextToken();
        else 
            throw new InvalidOperationException($"Expected {tokenType} found {CurrentToken.Type}");
    }
    
    public Node Parse()
    {
        // Start parsing from the 'program' keyword
        Eat(TokenType.Program);
        
        var programName = (IdentifierNode)ProgramName();
        Eat(TokenType.Semicolon);

        var block = Block();

        Eat(TokenType.Dot);

        return new ProgramNode(block);
    }

    private Node Block() 
    {
        // Implement the logic to parse a block.
        throw new NotImplementedException();
    }

    private Node ProgramName()
    {
        // Implement the logic to parse program name.
        throw new NotImplementedException();
    }
}