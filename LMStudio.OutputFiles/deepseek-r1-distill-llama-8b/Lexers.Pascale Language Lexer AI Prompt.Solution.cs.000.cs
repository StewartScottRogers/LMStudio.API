using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SyntaxTreeParser
{
    public class Token
    {
        public enum TokenType { Identifier, Number, String, Keyword, Operator, Parenthesis, Separator };

        private string _value;
        private TokenType _type;

        public Token(string value, TokenType type)
        {
            _value = value;
            _type = type;
        }

        public override string ToString() => $"{_type} '{_value}'";
    }

    public class SyntaxTreeLexer
    {
        List<Token> tokens;
        ASTBuilder astBuilder;

        public SyntaxTreeLexer(string input)
        {
            tokens = Tokenize(input);
            astBuilder = new ASTBuilder(tokens);
        }

        public List<Token> Tokens => tokens;

        private List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();
            int i = 0;
            int length = input.Length;

            while (i < length)
            {
                if (input[i] == '<' && i + 1 < length && input[i+1] == '>')
                    tokens.Add(new Token("@<>", TokenType.Operator));
                else if (input[i] == '<' && IsDigitOrLetter(input, i) &&
                        (i + 2 < length && (input[i+1] == '.' || input[i+1] == 'E')) ||
                        (i + 1 < length && input[i+1] == '>'))
                    tokens.Add(new Token(input.Substring(i), TokenType.Number));
                else if ("()<>&".Contains(input[i]))
                    tokens.Add(new Token(input[i].ToString(), TokenType.Operator));
                else if (IsLetterOrDigit(input[i]))
                    tokens.Add(new Token(input[i].ToString(), TokenType.Identifier));
                else if (input[i] == ';' || input[i] == '.' || input[i] == ',')
                    tokens.Add(new Token(input[i].ToString(), TokenType_SEPARATOR));

                i++;
            }

            return tokens;
        }

        private bool IsLetterOrDigit(char c) => char.IsLetterOrDigit(c);

        private bool IsDigitOrLetter(char c) => (c >= '0' && c <= '9') || IsLetterOrDigit(c);

        public AST BuildAST()
        {
            astBuilder.Build(tokens);
            return astBuilder.AST;
        }
    }

    public class ASTBuilder
    {
        List<Token> tokens;

        public ASTNode Program { get; set; }

        public ASTBuilder(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        public void Build(List<Token> tokens)
        {
            ParseProgram(tokens);
        }

        private void ParseProgram(List<Token> tokens)
        {
            if (tokens.Count < 4) throw new SyntaxErrorException("Incomplete program");

            string id1 = tokens[0].Value;
            string id2 = tokens[1].Value;

            ProgramNode program = new ProgramNode();
            program.AddChild(new IdentifierNode(id1));
            program.AddChild(new BlockNode());
            program.AddChild(new IdentifierNode(id2));

            // Continue parsing blocks and other nodes as needed
        }

        public ASTNode GetAST() => Program;
    }

    public class TreeNode
    {
        public enum NodeType { Program, Function, Block };

        protected string _name;
        private NodeList _children;

        public TreeNode(string name)
        {
            _name = name;
            _children = new NodeList();
        }

        public override ToString()
        {
            return $"{GetType().Name} '{_name}'";
        }
    }

    public class PrettyPrinter
    {
        public string PrintAST(ASTNode root)
        {
            return root.Visit(new PrinterVisitor());
        }

        private class PrinterVisitor : ASTVisitor
        {
            StringBuilder sb;

            public PrinterVisitor()
            {
                sb = new StringBuilder();
            }

            public override string VisitProgram(ProgramNode node)
            {
                sb.Append("program ").Append(node.Name);
                if (node.Children.Count > 0) sb.Append("; ");
                foreach (var child in node.Children)
                    child.Visit(this);

                if (!sb.ToString().EndsWith(";")) sb.Append(";");

                return sb.ToString();
            }

            // Implement Visit methods for all node types
        }
    }

    public class ASTNode : TreeNode
    {
        public override NodeType Type => NodeType.Program;

        public override string Name { get; set; }

        public override NodeList Children { get; protected set; }
    }

    public class ProgramNode : ASTNode
    {
        public override NodeType Type => NodeType.Program;
    }

    public class BlockNode : ASTNode
    {
        public override NodeType Type => NodeType.Block;
    }

    public class IdentifierNode : ASTNode
    {
        public override NodeType Type => NodeType.Identifier;

        public string Value { get; set; }
    }

    // Continue implementing other node types as needed

    [TestClass]
    public class SyntaxTreeTests
    {
        private readonly SyntaxTreeLexer _lexer;
        private readonly ASTBuilder _builder;

        public SyntaxTreeTests()
        {
            _lexer = new SyntaxTreeLexer("program ident ; block");
            _builder = new ASTBuilder(_lexer.Tokens);
        }

        [TestMethod]
        public void TestTokenization()
        {
            var tokens = _lexer.Tokens;
            Assert.AreEqual(4, tokens.Count);

            foreach (var token in tokens)
                Assert.AreNotEqual(Token.TypeOperator, token.Type);
            Assert.IsTrue(tokens[3].Type == Token.TypeIdentifier);
        }

        [TestMethod]
        public void TestASTBuilding()
        {
            var ast = _builder.GetAST();
            Assert.IsNotInstanceOf(typeofNull, ast);
            Assert.IsInstanceOf(typeofProgramNode, ast);
        }
    }
}