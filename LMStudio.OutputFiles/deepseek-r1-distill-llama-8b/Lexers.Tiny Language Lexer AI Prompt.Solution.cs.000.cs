using System;
using System.Collections.Generic;
using System.Text;

public class Lexer
{
    public enum TokenType
    {
        Lparen = '(', Rparen = ')',
        Oper = '+', Minus = '-', Multiply = '*', Divide = '/',
        Assign = ':=',
        If = "if",
        While = "while",
        Print = "print",
        ID = [A-Za-z0-9]+,
        None
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value ?? "";
        }
    }

    private readonly List<State> _states = new();
    private string _currentToken = "";
    private TokenType _currentTokenType = TokenType.None;
    private int _position;

    public Lexer()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        State initial = new()
        {
            Transitions = new Dictionary<char, object>()
        };

        // Initial state
        initial.Transitions.Add('i', 1);
        initial.Transitions.Add('w', 4);
        initial.Transitions.Add('p', 6);
        initial.Transitions.Add('+', typeof(TokenType.Oper));
        initial.Transitions.Add('-', typeof(TokenType.Oper));
        initial.Transitions.Add('*', typeof(TokenType.Oper));
        initial.Transitions.Add('/', typeof(TokenType.Oper));
        initial.Transitions.Add('(', typeof(TokenType.Lparen));
        initial.Transitions.Add(')', typeof(TokenType.Rparen));

        _states.Add(initial);

        // If state 1: after 'i', expecting 'f' to complete "if"
        State ifPart1 = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        ifPart1.Transitions.Add('f', typeof(TokenType.If));
        _states.Add(ifPart1);

        // While state 4: after 'w', expecting 'h' then 'i'
        State whilePart1 = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        whilePart1.Transitions.Add('h', 5);
        _states.Add(whilePart1);

        State whilePart2 = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        whilePart2.Transitions.Add('i', typeof(TokenType.While));
        _states.Add(whilePart2);

        // Print state 6: after 'p', expecting 'r' then 'i' then 'n'
        State printPart1 = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        printPart1.Transitions.Add('r', 7);
        _states.Add(printPart1);

        State printPart2 = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        printPart2.Transitions.Add('i', 8);
        _states.Add(printPart2);

        State printPart3 = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        printPart3.Transitions.Add('n', typeof(TokenType.Print));
        _states.Add(printPart3);

        // ID collecting state
        State idCollecting = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        idCollecting.Transitions.Add((char)char.ToUpperInvariant('A'), idCollecting); // A-Z
        idCollecting.Transitions.Add((char)char.ToLowerInvariant('a'), idCollecting); // a-z
        idCollecting.Transitions.Add('0' to '9', idCollecting);
        _states.Add(idCollecting);

        // Assignment operator state: looking for '=>' after an ID
        State eqCollecting = new()
        {
            Transitions = new Dictionary<char, object>()
        };
        eqCollecting.Transitions.Add('=', typeof(TokenType.Assign));
        _states.Add(eqCollecting);
    }

    public List<Token> Tokenize(string input)
    {
        List<Token> tokens = new();
        _position = 0;
        _currentToken = "";
        _currentTokenType = TokenType.None;

        while (_position < input.Length)
        {
            if (TryMatchKeyword(input, ref _position))
                continue;

            char c = input[_position];

            switch (c)
            {
                case '(':
                    tokens.Add(new Token(TokenType.Lparen));
                    _position++;
                    break;
                case ')':
                    tokens.Add(new Token(TokenType.Rparen));
                    _position++;
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                    tokens.Add(new Token(TokenType.Oper));
                    _position++;
                    break;
                case '=':
                    if (_position + 1 < input.Length && input[_position + 1] == '=')
                    {
                        tokens.Add(new Token(TokenType.Assign));
                        _position += 2;
                    }
                    else
                    {
                        // Treat as regular character, but according to grammar, it's invalid.
                        // For this example, we'll ignore it and proceed.
                        _currentToken += c.ToString();
                        _currentTokenType = TokenType.Unknown;
                        _position++;
                    }
                    break;
                default:
                    if (char.IsLetterOrDigit(c))
                    {
                        _currentToken += c.ToString();
                        _currentTokenType = TokenType.ID;
                        _position++;
                    }
                    else
                    {
                        // Handle error: reset current token and continue
                        if (_currentToken.Length > 0)
                        {
                            tokens.Add(new Token(TokenType.ID, _currentToken));
                            _currentToken = "";
                            _currentTokenType = TokenType.None;
                        }
                        _position++;
                    }
                    break;
            }

            // Check if we have completed an ID or keyword
            if (_currentToken.Length > 0 && _currentTokenType == TokenType.ID)
            {
                tokens.Add(new Token(TokenType.ID, _currentToken));
                _currentToken = "";
                _currentTokenType = TokenType.None;
            }
        }

        return tokens;
    }

    private bool TryMatchKeyword(string input, ref int position)
    {
        if (position + 1 >= input.Length)
            return false;

        char nextChar = input[position + 1];
        switch (input[position])
        {
            case 'i':
                if (nextChar == 'f')
                {
                    tokens.Add(new Token(TokenType.If));
                    position += 2;
                    return true;
                }
                break;
            case 'w':
                if (nextChar == 'h')
                {
                    position += 2;
                }
                else
                {
                    // Treat as ID start
                    _currentToken += input[position].ToString();
                    _currentTokenType = TokenType.ID;
                    position++;
                }
                return false;
            case 'p':
                if (nextChar == 'r')
                {
                    position += 2;
                }
                else
                {
                    // Treat as ID start
                    _currentToken += input[position].ToString();
                    _currentTokenType = TokenType.ID;
                    position++;
                }
                return false;
            default:
                return false;
        }

        return false;
    }

    public static void Main()
    {
        string input = "if x := 5 { print \"Hello\" }";
        Lexer lexer = new Lexer();
        List<Token> tokens = lexer.Tokenize(input);
        foreach (Token t in tokens)
        {
            Console.WriteLine("{0}: {1}", t.Type, t.Value ?? "<none>");
        }
    }
}

public static class Program
{
    public static int Main(string[] args)
    {
        // Example usage:
        string input = "if x := 5 { print \"Hello\" }";
        Lexer lexer = new Lexer();
        List<Token> tokens = lexer.Tokenize(input);
        foreach (Token t in tokens)
        {
            Console.WriteLine("{0}: {1}", t.Type, t.Value ?? "<none>");
        }
        return 0;
    }
}