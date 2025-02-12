using System.Collections.Generic;
using System.Linq;

namespace PythonLexer.Lexers
{
    using Nodes.Statements;
    using Nodes.Expressions;
    using Tokenizer.Tokens;
    using Tokenizer;

    public class PythonLexer : ILexer
    {
        private readonly PythonTokenizer tokenizer;
        private Token currentToken;

        public PythonLexer(string source)
        {
            this.tokenizer = new PythonTokenizer(source);
            this.currentToken = this.tokenizer.GetTokens().FirstOrDefault();
        }

        public IEnumerable<INode> Tokenize(string source)
        {
            List<INode> nodes = new List<INode>();
            while (currentToken != Token.EOF)
            {
                switch (currentToken.Kind)
                {
                    case TokenKind.KeywordReturn:
                        nodes.Add(ParseReturnStatement());
                        break;
                    default:
                        nodes.Add(ParseExpressionStatement());
                        break;
                }
            }

            return nodes;
        }

        private INode ParseReturnStatement()
        {
            Consume(TokenKind.KeywordReturn);
            if (currentToken != Token.EOF && currentToken.Kind != TokenKind.EndOfFile)
            {
                var expression = ParseExpression();
                return new ReturnStatementNode(expression);
            }

            return new ReturnStatementNode(null);
        }

        private INode ParseExpressionStatement()
        {
            var expression = ParseExpression();
            Consume(TokenKind.EndOfFile);
            return new ExpressionStatementNode(expression);
        }

        private INode ParseExpression()
        {
            // Simple implementation for demonstration
            switch (currentToken.Kind)
            {
                case TokenKind.NumberLiteral:
                    return new LiteralExpressionNode(currentToken);

                case TokenKind.Identifier:
                    return new VariableExpressionNode(currentToken.Value);

                default:
                    throw new InvalidOperationException($"Unexpected token: {currentToken}");
            }
        }

        private void Consume(TokenKind kind)
        {
            if (currentToken.Kind == kind)
            {
                currentToken = tokenizer.GetTokens().SkipWhile(t => t != Token.EOF).FirstOrDefault();
            }
            else
            {
                throw new InvalidOperationException($"Expected token of kind {kind}, but got {currentToken.Kind}");
            }
        }
    }
}