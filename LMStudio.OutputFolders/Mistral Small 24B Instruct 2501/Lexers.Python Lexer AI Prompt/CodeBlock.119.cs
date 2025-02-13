using System;
    using System.Collections.Generic;

    namespace LexerGrammarAST.Nodes.Expressions
    {
        public class LambdaDefNode : ExpressionNode
        {
            public readonly LambdaParametersNode Parameters;
            public readonly ExpressionNode Body;

            public LambdaDefNode(ExpressionNode body, LambdaParametersNode parameters)
            {
                this.Body = body;
                this.Parameters = parameters;
            }
        }

        public class LambdaParametersNode
        {
            public readonly List<LambdaParameter> Parameters;
            public readonly bool HasStarArgs;
            public readonly bool HasDoubleStarKwargs;

            public LambdaParametersNode(List<LambdaParameter> parameters, bool hasStarArgs, bool hasDoubleStarKwargs)
            {
                this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
                this.HasStarArgs = hasStarArgs;
                this.HasDoubleStarKwargs = hasDoubleStarKwargs;
            }
        }

    public class Lexer
    {
        private readonly string Input;
        private int Position;

        public Lexer(string input)
        {
            Input = input;
            Position = 0;
        }

        public void Lex()
        {
            while (Position < Input.Length)
            {
                // Tokenize the input and handle each token
                var token = GetNextToken();
                if (token == null)
                {
                    break;
                }
                ProcessToken(token);
            }
        }
    }

### File: `Lexer.cs`