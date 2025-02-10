using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Parsing;
using static Microsoft.CodeAnalysis.CSharp.Parsing.ParseOptions;

namespace Lexers.TinyLanguage
{
    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public enum TokenType
    {
        Program,
        Assign,
        If,
        While,
        Print,
        Number,
        Id,
        Plus,
        Minus,
        Multiply,
        Divide,
        Lparen,
        Rparen,
        Colon,
        End,
        Semicolon
    }

    public class TokensCollection : List<Token>
    {
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
    }

    public class Lexer
    {
        private readonly TokensCollection _tokens;
        private int _currentLine = 1;

        public Lexer(string source)
        {
            using (var reader = new StringReader(source))
            {
                while (reader.Read())
                {
                    char c = (char)reader.Value;
                    switch (c)
                    {
                        case ' ':
                            continue;
                        case '\t':
                            _currentLine++;
                            break;
                        case '\n':
                            _currentLine++;
                            _tokens.Add(new Token(TokenType.Semicolon, string.Empty));
                            break;
                        default:
                            HandleCharacter(c);
                            break;
                    }
                }
            }
        }

        private void HandleCharacter(char c)
        {
            switch (c)
            {
                case 'a' to 'z':
                case 'A' to 'Z':
                    StartIdentifier();
                    break;
                case '0' to '9':
                    StartNumber();
                    break;
                case '+':
                    AddToken(TokenType.Plus, "+");
                    break;
                case '-':
                    AddToken(TokenType.Minus, "-");
                    break;
                case '*':
                    AddToken(TokenType.Multiply, "*");
                    break;
                case '/':
                    AddToken(TokenType.Divide, "/");
                    break;
                case '(':
                    AddToken(TokenType.Lparen, "(");
                    break;
                case ')':
                    AddToken(TokenType.Rparen, ")");
                    break;
                case ':':
                    AddToken(TokenType.Colon, ":");
                    break;
                case 'end':
                    AddToken(TokenType.End, "end");
                    break;
                case ';':
                    AddToken(TokenType.Semicolon, ";");
                    break;
            }
        }

        private void StartIdentifier()
        {
            string identifier = string.Empty;
            while (true)
            {
                if (!char.IsLetterOrDigit((char)Peek()))
                    break;
                identifier += NextChar().ToString();
            }
            AddToken(TokenType.Id, identifier);
        }

        private void StartNumber()
        {
            string number = string.Empty;
            while (true)
            {
                if (!char.IsDigit((char)Peek()))
                    break;
                number += NextChar().ToString();
            }
            AddToken(TokenType.Number, number);
        }

        public TokensCollection Tokenize(string source)
        {
            _tokens = new TokensCollection { LineNumber = 1, ColumnNumber = 1 };
            LexerImpl(source);
            return _tokens;
        }

        private void LexerImpl(string source)
        {
            source = source ?? string.Empty;
            using (var reader = new StringReader(source))
            {
                while (!reader.EndOfStream)
                {
                    char c = reader.Read().Value;
                    switch (c)
                    {
                        case '\r':
                            _currentLine++;
                            break;
                        case ' ':
                            continue;
                        default:
                            HandleCharacter(c);
                            break;
                    }
                }
            }
        }

        private void AddToken(TokenType type, string value)
        {
            _tokens.Add(new Token(type, value))
                  { LineNumber = _currentLine, ColumnNumber = _tokens.Count * 2 };
        }

        private char NextChar()
        {
            if ( !_tokens.Collection.IsDefault && _tokens.Collection.Last().ColumnNumber > 0 )
                _currentLine += 1;
            
            return char.ReadChar();
        }

        private char Peek()
        {
            if (_tokens.Collection.Count > 0)
                return _tokens[_tokens.Count - 1].Value[0];
            return '\0';
        }
    }

    public class Parser
    {
        private readonly TokensCollection _tokens;

        public Parser(TokensCollection tokens)
        {
            _tokens = tokens;
        }

        public T Parse<T>(int position) where T : INode
        {
            try
            {
                int next = position + 1;
                return ParseInternal(next, typeof(T));
            }
            catch (SyntaxException)
            {
                throw new InvalidOperationException("Parse error at line " + _tokens.LineNumber);
            }
        }

        private Node ParseInternal(int position, Type expectedType)
        {
            if (position >= _tokens.Count)
                throw new SyntaxException("Unexpected end of input");

            Token token = _tokens[position];
            if (token.Type != typeof(T).Cast<EnumToken>())
                throw new SyntaxException("Unexpected token: " + token);

            switch (expectedType)
            {
                case typeof(ProgramNode):
                    return ParseProgram(position);
                case typeof(IfStatement):
                    return ParseIfStmt(position);
                case typeof(WhileStatement):
                    return ParseWhileStmt(position);
                case typeof(AssignStatement):
                    return ParseAssignStmt(position);
                case typeof(PrintStatement):
                    return ParsePrintStmt(position);
                case typeof(ExpressionNode):
                    return ParseExpression(position);
                default:
                    throw new SyntaxException("Unexpected type: " + expectedType);
            }
        }

        private ProgramNode ParseProgram(int position)
        {
            var stmtList = new StmtList { Parent = new ProgramNode };
            while (position < _tokens.Count && _tokens[position].Value != "end" && _tokens[position].Value != ";")
            {
                if (_tokens[position].Type == typeof(EndToken))
                    break;

                int nextPos = position + 1;
                stmtList.Add(ParseStatement(position));
                if (_tokens[position + 1].Value == ";")
                    nextPos++;
                else
                    nextPos++;

                position = nextPos;
            }
            return new ProgramNode { Statements = stmtList };
        }

        private Stmt ParseStatement(int position)
        {
            switch (_tokens[position].Type)
            {
                case typeof(AssignToken):
                    return ParseAssignStmt(position);
                case typeof(IfToken):
                    return ParseIfStmt(position);
                case typeof(WhileToken):
                    return ParseWhileStmt(position);
                case typeof(PrintToken):
                    return ParsePrintStmt(position);
                default:
                    throw new SyntaxException("Unexpected statement type");
            }
        }

        private IfStatement ParseIfStmt(int position)
        {
            if (_tokens[position].Value != "if")
                throw new SyntaxException("Expected 'if'");

            position++;
            ExpressionNode expr = ParseExpression(position);
            if (expr == null)
                throw new SyntaxException("Missing expression after if");

            if (_tokens[position].Value != "then")
                throw new SyntaxException("Expected 'then'");

            position++;
            StmtList stmts = ParseStmtList(position);
            if (stmts == null)
                throw new SyntaxException("Missing statements after if then");

            if (_tokens[position].Value != "end")
                throw new SyntaxException("Expected 'end'");
            
            position++;
            return new IfStatement { Condition = expr, Body = stmts };
        }

        private WhileStatement ParseWhileStmt(int position)
        {
            if (_tokens[position].Value != "while")
                throw new SyntaxException("Expected 'while'");

            position++;
            ExpressionNode expr = ParseExpression(position);
            if (expr == null)
                throw new SyntaxException("Missing condition after while");

            if (_tokens[position].Value != "do")
                throw new SyntaxException("Expected 'do'");
            
            position++;
            StmtList stmts = ParseStmtList(position);
            if (stmts == null)
                throw new SyntaxException("Missing statements after do");
            
            if (_tokens[position].Value != "end")
                throw new SyntaxException("Expected 'end'");
            
            position++;
            return new WhileStatement { LoopCondition = expr, Body = stmts };
        }

        private AssignStatement ParseAssignStmt(int position)
        {
            if (_tokens[position].Value != "id" && _tokens[position].Type != typeof(IdToken))
                throw new SyntaxException("Expected identifier");

            string id = _tokens[position].Value;
            position++;
            if (position >= _tokens.Count || _tokens[position].Value != ":=")
                throw new SyntaxException("Expected assignment operator ':='");
            
            position++;
            ExpressionNode expr = ParseExpression(position);
            if (expr == null)
                throw new SyntaxException("Missing expression after assignment");
            
            return new AssignStatement { LeftHandSide = id, Value = expr };
        }

        private PrintStatement ParsePrintStmt(int position)
        {
            if (_tokens[position].Value != "print")
                throw new SyntaxException("Expected 'print'");
            
            position++;
            ExpressionNode expr = ParseExpression(position);
            if (expr == null)
                throw new SyntaxException("Missing expression after print");
            
            return new PrintStatement { Expression = expr };
        }

        private StmtList ParseStmtList(int position)
        {
            var stmts = new StmtList();
            while (position < _tokens.Count && _tokens[position].Value != "end" && _tokens[position].Value != ";")
            {
                if (_tokens[position].Type == typeof(EndToken))
                    break;

                int nextPos = ParseStatement(position);
                if (nextPos >= _tokens.Count)
                    break;
                
                Stmt stmt = new Stmt();
                stmts.Add(stmt);

                if (_tokens[nextPos + 1].Value == ";")
                    position = nextPos + 2;
                else
                    position = nextPos + 1;
            }
            return stmts;
        }

        private ExpressionNode ParseExpression(int position)
        {
            var term = ParseTerm(position);
            if (term == null)
                return null;

            ExpressionNode leftExpr = term;
            while (position < _tokens.Count && _tokens[position].Value == "+" || _tokens[position].Value == "-")
            {
                string op = _tokens[position].Value;
                position++;
                var rightExpr = ParseTerm(position);
                if (rightExpr == null)
                    return null;

                if (op == "+")
                    leftExpr = new BinaryOperation { Left = leftExpr, Operator = "+", Right = rightExpr };
                else
                    leftExpr = new BinaryOperation { Left = leftExpr, Operator = "-", Right = rightExpr };

                term = rightExpr;
            }
            return term;
        }

        private TermNode ParseTerm(int position)
        {
            var factor = ParseFactor(position);
            if (factor == null)
                return null;

            while (position < _tokens.Count && _tokens[position].Value == "*" || _tokens[position].Value == "/")
            {
                string op = _tokens[position].Value;
                position++;
                var rightFactor = ParseFactor(position);
                if (rightFactor == null)
                    return null;

                if (op == "*")
                    factor = new BinaryOperation { Left = factor, Operator = "*", Right = rightFactor };
                else
                    factor = new BinaryOperation { Left = factor, Operator = "/", Right = rightFactor };

            }
            return factor;
        }

        private FactorNode ParseFactor(int position)
        {
            char c = _tokens[position].Value[0];
            if (char.IsLetter(c))
                return new IdentifierNode { Name = c.ToString() };
            
            if (char.IsDigit(c))
                return new NumberNode { Value = _tokens[position].Value };

            if (_tokens[position].Value == "(")
                return ParseExpression(position + 1);

            throw new SyntaxException("Unexpected factor: " + c);
        }
    }

    public interface INode
    {
        int LineNumber { get; set; }
        int ColumnNumber { get; set; }
        string ToString();
    }

    public class Node : INode
    {
        public override string ToString()
        {
            return $"{GetType().Name} { Value }";
        }

        protected virtual void SetValue(string value)
        {
            Value = value;
        }
    }

    public class ProgramNode : Node
    {
        public ProgramNode(List<Stmt> statements)
        {
            SetValue("Program");
            Statements = new List<Stmt>(statements);
        }

        public List<Stmt> Statements { get; set; }
    }

    public abstract class Stmt : Node
    {
        public abstract List<Stmt> Body { get; set; }
    }

    public class AssignStatement : Stmt
    {
        public string LeftHandSide { get; set; }
        public ExpressionNode Value { get; set; }

        public AssignStatement(string lhs, ExpressionNode value)
        {
            SetValue("Assign");
            LeftHandSide = lhs;
            Value = value;
        }
    }

    public class IfStatement : Stmt
    {
        public ExpressionNode Condition { get; set; }
        public List<Stmt> Body { get; set; }

        public IfStatement(ExpressionNode condition, List<Stmt> body)
        {
            SetValue("If");
            Condition = condition;
            Body = body;
        }
    }

    public class WhileStatement : Stmt
    {
        public ExpressionNode LoopCondition { get; set; }
        public List<Stmt> Body { get; set; }

        public WhileStatement(ExpressionNode loopCondition, List<Stmt> body)
        {
            SetValue("While");
            LoopCondition = loopCondition;
            Body = body;
        }
    }

    public class PrintStatement : Stmt
    {
        public ExpressionNode Expression { get; set; }

        public PrintStatement(ExpressionNode expression)
        {
            SetValue("Print");
            Expression = expression;
        }
    }

    public abstract class ExpressionNode : Node
    {
        public abstract List<ExpressionNode> Children { get; set; }
    }

    public class BinaryOperation : ExpressionNode
    {
        public override void SetValue(string value)
        {
            base.SetValue(value);
        }

        public BinaryOperation Left { get; set; }
        public string Operator { get; set; }
        public BinaryOperation Right { get; set; }

        public BinaryOperation(BinaryOperation left, string op, BinaryOperation right)
        {
            Left = left;
            Operator = op;
            Right = right;
            SetValue($"{left.Value} {op} {right.Value}");
        }
    }

    public class IdentifierNode : ExpressionNode
    {
        public string Name { get; set; }

        public IdentifierNode(string name)
        {
            SetValue(name);
        }
    }

    public class NumberNode : ExpressionNode
    {
        public override void SetValue(string value)
        {
            base.SetValue(value);
        }

        public double Value { get; set; }

        public NumberNode(double number)
        {
            SetValue($"{number}");
            Value = number;
        }
    }

    public abstract class StmtList : List<Stmt>
    {
        public StmtList Parent { get; set; } = null;
    }

    public class PrettyPrinter
    {
        private readonly INode _node;

        public PrettyPrinter(INode node)
        {
            _node = node;
        }

        public string Print()
        {
            return _node.ToString();
        }
    }
}

public class LexerImpl : Lexer
{
    public LexerImpl(string source) : base(source) {}
}

public abstract class Parser<T> : Parser where T : INode
{
    private List<Node> _nodes;

    public Parser(TokensCollection tokens)
    {
        _tokens = tokens;
        _currentPosition = 0;
        _nodes = new List<Node>();
    }

    private int _currentPosition;

    public ProgramNode Parse()
    {
        var program = (ProgramNode)Parse(typeof(ProgramNode));
        return program;
    }

    protected override Node ParseInternal(int position, Type expectedType)
    {
        if (_tokens[position].Value != "end" && _tokens[position].Value != ";")
            throw new SyntaxException("Unexpected token");

        ProgramNode program = base.ParseInternal(position + 1, typeof(ProgramNode));
        return program;
    }
}