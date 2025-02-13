using System.Collections.Generic;
using System.Text;

namespace Lexer {
    public class Token {
        public enum TokenType {
            // Add your token types here
            UNKNOWN,
            STRING,
            NUMBER,
            IDENTIFIER,
            KEYWORD,
            OP,
            NEWLINE,
            COMMENT,
        }

        public TokenType Type { get; set; }
        public string Value { get; set; }
    }

    public class Lexer {
        private readonly Tokenizer tokenizer;
        private readonly StringBuilder input;

        public Lexer(string source) {
            this.input = new StringBuilder(source);
            tokenizer = new Tokenizer(input);
        }

        public List<Token> Lex() {
            List<Token> tokens = new List<Token>();
            int index = 0;
            while (index < input.Length) {
                if (tokenizer.State == TokenizerState.None) {
                    char c = input[index];
                    switch (c) {
                        case '"':
                            index++;
                            if (index >= input.Length) throw new InvalidOperationException("Unclosed string");
                            tokens.Add(new Token { Type = Token.TokenType.STRING, Value = GetString() });
                            break;
                        case '\'':
                            index++;
                            if (index >= input.Length) throw new InvalidOperationException("Unclosed string");
                            tokens.Add(new Token { Type = Token.TokenType.STRING, Value = GetString() });
                            break;
                        case '(':
                        case ')':
                        case '{':
                        case '}':
                        case '[':
                        case ']':
                            index++;
                            tokens.Add(new Token { Type = Token.TokenType.UNKNOWN, Value = c.ToString() });
                            break;
                        case '#':
                            // Handle comment
                            index++;
                            while (index < input.Length && input[index] != '\n') {
                                index++;
                            }
                            tokens.Add(new Token { Type = Token.TokenType.COMMENT, Value = GetComment() });
                            break;
                        case ' ':
                            index++;
                            continue;
                        default:
                            // Check if it's a keyword or operator
                            if (tokenizer.GetToken(index)) {
                                Token token = tokenizer.Token;
                                tokens.Add(token);
                                index = token.Value.Length + token.Index;
                                continue;
                            }
                            throw new InvalidOperationException("Unexpected character: " + c);
                    }
                } else {
                    // Handle multi-character tokens in states
                    while (index < input.Length) {
                        char c = input[index];
                        switch (tokenizer.State) {
                            case TokenizerState.StringEscaped:
                                if (c == '\\') {
                                    tokenizer.State = TokenizerState.None;
                                } else {
                                    throw new InvalidOperationException("Unclosed string escape");
                                }
                                index++;
                                continue;
                            default:
                                throw new InvalidOperationException("Unexpected state: " + tokenizer.State);
                        }
                    }
                }
            }
            return tokens;
        }

        private string GetString() {
            StringBuilder sb = new StringBuilder();
            bool isEscaped = false;
            while (index < input.Length) {
                char c = input[index];
                if (c == '"' || c == '\'') {
                    index++;
                    break;
                } else if (c == '\\' && !isEscaped) {
                    isEscaped = true;
                    sb.Append('\\');
                    index++;
                } else {
                    if (isEscaped) {
                        isEscaped = false;
                    }
                    sb.Append(c);
                    index++;
                }
            }
            return sb.ToString();
        }

        private string GetComment() {
            StringBuilder sb = new StringBuilder();
            while (index < input.Length && input[index] != '\n') {
                if (input[index] == '\\') {
                    // Only escape for the comment, just treat it as literal
                    sb.Append(input[index]);
                    index++;
                } else {
                    sb.Append(input[index]);
                    index++;
                }
            }
            return sb.ToString();
        }

        public List<Token> Parse(string source) {
            Lexer lexer = new Lexer(source);
            return lexer.Lex();
        }
    }
}