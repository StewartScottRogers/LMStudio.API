public class PythonAstBuilder {
    private readonly Lexer _lexer;

    public PythonAstBuilder(Lexer lexer) => _lexer = lexer;

    public AstNode BuildAst() {
        var tokens = _lexer.Lex().ToList();
        // Convert tokens to AST nodes
        return ConstructProgram(tokens);
    }

    private Program ConstructProgram(List<Token> tokens) {
        var program = new Program { LineNumber = tokens[0].LineNumber };
        foreach (var token in tokens) {
            switch (token.Type) {
                case TokenType.Statement:
                    // Process statement token
                    break;
                default:
                    // Add other cases for different types of tokens
                    break;
            }
        }
        return program;
    }
}