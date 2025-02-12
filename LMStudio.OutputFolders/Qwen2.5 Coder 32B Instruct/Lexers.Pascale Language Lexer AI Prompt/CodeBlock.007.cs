using System.Collections.Generic;
using System.Linq;

namespace PascaleLexer.Lexer
{
    public readonly struct PascaleParser
    {
        private readonly List<Token> tokens;
        private int position;
        
        public PascaleParser(IEnumerable<Token> tokenList)
        {
            tokens = tokenList.ToList();
            position = 0;
        }

        private Token Eat(TokenTypes type)
        {
            if (tokens[position].Type == type) 
                return tokens[position++];
            
            throw new Exception($"Unexpected token {tokens[position]}");
        }
        
        // Example method to parse a program
        public PascaleLexer.AST.ProgramNode Parse()
        {
            Eat(TokenTypes.Program);
            var name = Eat(TokenTypes.Identifier).Value;
            Eat(TokenTypes.Semicolon);
            var block = Block();
            Eat(TokenTypes.Dot);
            return new PascaleLexer.AST.ProgramNode(name, block, tokens[position].Position);
        }
        
        private PascaleLexer.AST.BlockNode Block()
        {
            var labelDeclarations = LabelDeclarationPart();
            var constantDefinitions = ConstantDefinitionPart();
            var typeDefinitions = TypeDefinitionPart();
            var variableDeclarations = VariableDeclarationPart();
            var procedureOrFunctionDeclarations = ProcedureAndFunctionDeclarationPart();
            var statement = StatementPart();

            return new PascaleLexer.AST.BlockNode(
                labelDeclarations,
                constantDefinitions,
                typeDefinitions,
                variableDeclarations,
                procedureOrFunctionDeclarations,
                statement, 
                tokens[position].Position);
        }
        
        private IEnumerable<PascaleLexer.AST.LabelDeclarationNode> LabelDeclarationPart()
        {
            if (tokens[position].Type == TokenTypes.Empty) return Enumerable.Empty<PascaleLexer.AST.LabelDeclarationNode>();
            
            Eat(TokenTypes.Label);
            var labels = new List<int>();
            while (true)
            {
                labels.Add(int.Parse(Eat(TokenTypes.UnsignedInteger).Value));
                if (tokens[position].Type == TokenTypes.Comma) Eat(TokenTypes.Comma);
                else break;
            }
            
            Eat(TokenTypes.Semicolon);
            return new[] { new PascaleLexer.AST.LabelDeclarationNode(labels, tokens[position].Position) };
        }

        // Add more methods to parse other parts of the grammar

        private IEnumerable<PascaleLexer.AST.ConstantDefinitionNode> ConstantDefinitionPart()
        {
            if (tokens[position].Type == TokenTypes.Empty) return Enumerable.Empty<PascaleLexer.AST.ConstantDefinitionNode>();
            
            Eat(TokenTypes.Const);
            var definitions = new List<PascaleLexer.AST.ConstantDefinitionNode>();
            while (true)
            {
                var identifier = Eat(TokenTypes.Identifier).Value;
                Eat(TokenTypes.Equal);
                var value = ParseConstant();
                Eat(TokenTypes.Semicolon);
                definitions.Add(new PascaleLexer.AST.ConstantDefinitionNode(identifier, value, tokens[position].Position));
                
                if (tokens[position].Type != TokenTypes.Identifier) break;
            }
            
            return definitions;
        }

        private object ParseConstant()
        {
            var token = tokens[position++];
            switch (token.Type)
            {
                case TokenTypes.UnsignedInteger:
                    return int.Parse(token.Value);
                case TokenTypes.UnsignedReal:
                    return double.Parse(token.Value);
                default:
                    throw new Exception($"Unexpected constant type {token}");
            }
        }

        private IEnumerable<PascaleLexer.AST.TypeDefinitionNode> TypeDefinitionPart()
        {
            if (tokens[position].Type == TokenTypes.Empty) return Enumerable.Empty<PascaleLexer.AST.TypeDefinitionNode>();
            
            Eat(TokenTypes.Type);
            var definitions = new List<PascaleLexer.AST.TypeDefinitionNode>();
            while (true)
            {
                var identifier = Eat(TokenTypes.Identifier).Value;
                Eat(TokenTypes.Equal);
                // ParseType(); <- Implement parsing of types
                Eat(TokenTypes.Semicolon);
                
                if (tokens[position].Type != TokenTypes.Identifier) break;
            }
            
            return definitions;
        }

        private IEnumerable<PascaleLexer.AST.VariableDeclarationNode> VariableDeclarationPart()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<PascaleLexer.AST.ProcedureOrFunctionDeclarationNode> ProcedureAndFunctionDeclarationPart()
        {
            throw new NotImplementedException();
        }

        private PascaleLexer.AST.StatementNode StatementPart()
        {
            throw new NotImplementedException();
        }
    }
}