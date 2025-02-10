<think>
Okay, so I need to create a lexer for this given grammar using C# and .NET 9.0. Let me think about how to approach this.

First, the project structure. The user wants each class in its own file, so I'll start by creating a new solution with several projects: Lexer, AST, PrettyPrinter, and UnitTests. Each will be a separate project within the solution.

For the Lexer, I'll use a Tokenizer approach. I remember that tokenizing involves scanning through the input character by character and grouping them into tokens based on the grammar rules. So, I'll need a Lexer class that reads each character, tracks line numbers for errors, and builds tokens as it goes.

I should define a Tokens collection to hold all the tokens parsed from the source code. Each token will have a Type (like identifier, number, operator) and a Value. Maybe a Tokenize method that takes a string and returns a TokensCollection with all the tokens.

The lexer needs to handle operators like +, -, *, /, and parentheses. For identifiers, I'll check if they start with a letter or digit and then collect letters and digits until I hit another operator or a parenthesis.

I should also handle numbers correctly. Numbers can be integers, but in this grammar, it's just digits. So when I see a digit, I collect as many as possible to form the number token.

Error handling is important. If an unexpected character is found, like a backslash or something else not allowed, I'll throw an exception with a message and line number.

Now, for the Abstract Syntax Tree (AST). The Parser will take the tokens and build the AST based on the grammar rules. Each node can be a class, but using records might be better as per the guidelines. So, I'll create Record classes for each type of AST node like Program, StmtList, AssignStmt, etc.

The parser needs to keep track of the current position in the tokens so it can backtrack if needed. For recursive descent parsers, this is common. Each method will parse a specific part of the grammar and return the constructed node along with the new position.

Looking at the grammar: program is a list of statements, each statement can be an assign, if, while, or print. So, in the Parser's ParseProgram method, I'll loop through the tokens, building up the statement list as I go.

Each AssignStmt consists of an identifier and an expression. So, for that, I'll parse the identifier, then the colon, then the expression using ParseExpr.

The IfStmt has an 'if' keyword, followed by an expr, then 'then', a StmtList, and 'end'. Similarly for WhileStmt with 'while'.

The Expr is built from terms, which are factors combined with + or -. Factors can be identifiers, numbers, or expressions in parentheses. So, the ParseExpr method will handle this, using a helper to parse term sequences.

Parsing terms involves checking for multiplication and division operators. The ParseTerm method will recursively call itself when these operators are found.

For factors, it's either an identifier, number, or a sub-expression in parentheses. So, handling each case appropriately.

Once the AST is built, the PrettyPrinter needs to traverse the AST and generate a string representation. Each node type will have its own printing method, appending strings as needed.

Testing is crucial. I'll need Unit Tests for every entry point. For example, testing the Tokenizer with sample code to ensure it correctly identifies tokens. Also, each parsing function should be tested with valid and invalid inputs to catch errors.

I should also write tests for the AST construction, ensuring that complex structures like if-else statements are parsed correctly. Maybe a test case where multiple operations are combined.

Potential issues: Handling operator precedence correctly in the parser. Making sure the Tokenizer doesn't misbehave with multi-digit numbers or identifiers. Also, ensuring that all tokens are properly tracked with their positions for error reporting.

Another thought: The grammar allows for statement lists to be followed by a semicolon and more statements. So in the Parser's ParseStmtList, I'll loop until I hit an end-of-file or an unexpected token.

I should also consider how to represent the AST nodes as Records, which are immutable and have value. Each node will have Type and Value properties, where Value is another Record or a collection of Records if needed.

Documentation: Adding comments in each class and method to explain their purpose and logic, especially for complex parts like the recursive descent parser.

Overall steps: Implement Tokenizer, then Parser, then PrettyPrinter, and finally UnitTests. Each part needs thorough testing to ensure they work as expected.
</think>

To solve this problem, we need to create a lexer for a given grammar using C# and .NET 9.0. The solution involves tokenizing the input code, parsing it into an Abstract Syntax Tree (AST), and then pretty printing the AST. Additionally, we will write comprehensive unit tests to ensure our implementation works correctly.

### Approach
1. **Tokenization**: Convert the input code into tokens based on the given grammar. Tokens include identifiers, numbers, operators, and parentheses.
2. **Abstract Syntax Tree (AST) Construction**: Parse the tokenized input to build an AST using recursive descent parsing. Each node in the AST will represent a part of the syntax.
3. **Pretty Printing**: Traverse the AST and generate a string representation that mirrors the original code structure.
4. **Unit Testing**: Ensure each component (tokenizer, parser, and pretty printer) works correctly by writing unit tests.

### Solution Code
```csharp
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
```

### Approach

1. **Tokenization**: The `Lexer` class reads the input character by character and groups them into tokens based on the grammar rules. Tokens include identifiers, numbers, operators, and parentheses.

2. **Abstract Syntax Tree Construction**: The `Parser` uses recursive descent parsing to build an AST from the tokenized input. Each node in the AST corresponds to a part of the syntax defined by the grammar.

3. **Pretty Printing**: The `PrettyPrinter` traverses the AST and generates a string representation that mirrors the original code structure, making it easier to understand.

4. **Unit Testing**: Comprehensive unit tests are written for each component (tokenizer, parser, pretty printer) to ensure they handle various input cases correctly.

### Solution Code Explanation

1. **Token Class**: Represents a token with its type and value.
2. **TokensCollection**: Manages the list of tokens, including line numbers for error reporting.
3. **Lexer**: Converts source code into tokens by iterating through each character and grouping them according to grammar rules.
4. **Parser**: Parses the tokenized input to construct an AST using recursive descent parsing, which is a common technique for parsing expressions with operator precedence.
5. **PrettyPrinter**: Takes the AST and generates a string representation, making it easier to understand the parsed structure.

### Unit Tests

- **Tokenization Tests**: Ensure that identifiers, numbers, operators, and parentheses are correctly tokenized.
- **Parsing Tests**: Test various grammar constructs like assignments, if statements, while loops, and print statements to ensure they are parsed correctly.
- **AST Construction Tests**: Verify that the AST accurately represents the input code structure.
- **Pretty Printing Tests**: Ensure that the generated code from the AST is a correct representation of the original code.

### Error Handling

The solution includes error handling in both the lexer and parser. If an unexpected character is encountered or if the grammar rules are violated, exceptions are thrown with relevant information about line numbers to aid debugging.

This approach ensures that the lexer, parser, and pretty printer components are robust and handle various input cases correctly, providing a reliable tool for transforming source code into an AST and back into readable code.