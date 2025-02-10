using System;
using System.Collections.Generic;
using System.Text;

// Token Types
public enum TokenType {
    Keyword,
    Identifier,
    Number,
    String,
    Operator,
    Symbol,
    Newline,
    Indent,
    Dedent
}

public record Token {
    public required TokenType Type { get; }
    public required string Value { get; }
    public int LineNumber { get; set; } = 0;
    public int ColumnNumber { get; set; } = 0;
}

// Tokenizer
public class Tokenizer {
    private readonly string input;
    
    public Tokenizer(string input) {
        this.input = input;
    }

    public IEnumerable<Token> Tokenize() {
        var tokens = new List<Token>();
        int index = 0;

        while (index < input.Length) {
            switch (input[index]) {
                case '<':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "<=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "<", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '>':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = ">= ", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = ">", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '=':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "== ", LineNumber: currentIndexLine });
                        index++;
                    } else if (index + 1 <= input.Length && input[index+1] == ' ') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected '='");
                    }
                    continue;
                case '+':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "+=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "+", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '-':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "-=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "-", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '*':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "*=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "*", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '/':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "/=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "/", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '&':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "&=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "&", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '|':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "|=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "|", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '^':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "^=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "^", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '<':
                    if (index + 1 <= input.Length && input[index+1] == '>') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "<> ", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected '<' not part of '>>' or similar");
                    }
                    continue;
                case '{':
                    if (index + 1 <= input.Length && (input[index+1] == '}' || input[index+1] == ',')) {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = "{", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected '{'");
                    }
                    continue;
                case '}':
                    if (index + 1 <= input.Length && input[index+1] == '}') {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = "}", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected '}'");
                    }
                    continue;
                case '(':
                    if (index + 1 <= input.Length && (input[index+1] == ')' || input[index+1] == ',')) {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = "(", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected '('");
                    }
                    continue;
                case ')':
                    if (index + 1 <= input.Length && input[index+1] == ')') {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = ")", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected ')'");
                    }
                    continue;
                case '[':
                    if (index + 1 <= input.Length && (input[index+1] == ']' || input[index+1] == ',')) {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = "[", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected '['");
                    }
                    continue;
                case ']':
                    if (index + 1 <= input.Length && input[index+1] == ']') {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = "]", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        throw new SyntaxError("Unexpected ']'");
                    }
                    continue;
                case '@':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "@=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = "@", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case ':':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = ":=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = ":", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case ';':
                    tokens.Add(new Token { Type = TokenType.Symbol, Value = ";", LineNumber: currentIndexLine });
                    index++;
                    continue;
                case ',':
                    if (index + 1 <= input.Length && input[index+1] == '=') {
                        tokens.Add(new Token { Type = TokenType.Operator, Value = ",=", LineNumber: currentIndexLine });
                        index++;
                    } else {
                        tokens.Add(new Token { Type = TokenType.Symbol, Value = ",", LineNumber: currentIndexLine });
                        index++;
                    }
                    continue;
                case '~':
                    tokens.Add(new Token { Type = TokenType.Operator, Value = "~", LineNumber: currentIndexLine });
                    index++;
                    continue;
                case '_':
                    throw new SyntaxError("Invalid character '_' in Python 2 syntax");
                default:
                    if (char.IsLetter(input[index])) {
                        // Handle keywords and identifiers
                        var keywordCheck = false;
                        string word = GetWord(index);
                        if (word == "def") keywordCheck = true;
                        else if (word == "import") keywordCheck = true;
                        else if (word == "class") keywordCheck = true;
                        else if (word == "if" || word == "elif" || word == "else") keywordCheck = true;
                        else if (word == "for" || word == "while") keywordCheck = true;
                        else if (word == "break" || word == "continue") keywordCheck = true;
                        else if (word == "global" || word == "nonlocal") keywordCheck = true;
                        else if (word == "raise") keywordCheck = true;
                        else if (word == "assert") keywordCheck = true;
                        else if (word == "del") keywordCheck = true;
                        else if (word == "yield") keywordCheck = true;
                        else if (word == "import" || word == "from") keywordCheck = true;

                        if (keywordCheck) {
                            tokens.Add(new Token { Type = TokenType.Keyword, Value = word, LineNumber: currentIndexLine });
                            index += word.Length - 1;
                        } else {
                            tokens.Add(new Token { Type = TokenType.Identifier, Value = word, LineNumber: currentIndexLine });
                            index++;
                        }
                    } else if (char.IsDigit(input[index])) {
                        // Handle numbers
                        string numberStr = GetWord(index);
                        if (numberStr.StartsWith("0x") || numberStr.StartsWith("0X")) {
                            int value = int.Parse(numberStr, 16);
                            tokens.Add(new Token { Type = TokenType.Number, Value = numberStr, LineNumber: currentIndexLine });
                            index += numberStr.Length;
                        } else {
                            int value = int.Parse(numberStr);
                            tokens.Add(new Token { Type = TokenType.Number, Value = numberStr, LineNumber: currentIndexLine });
                            index += numberStr.Length;
                        }
                    } else if (input[index] == '"') {
                        string str = ReadString(index);
                        tokens.Add(new Token { Type = TokenType.String, Value = str, LineNumber: currentIndexLine });
                        index += str.Length - 1;
                    } else if (input[index] == "'") {
                        string str = ReadString(index);
                        tokens.Add(new Token { Type = TokenType.String, Value = str, LineNumber: currentIndexLine });
                        index += str.Length - 1;
                    } else {
                        throw new SyntaxError("Unexpected character");
                    }
            }
        }

        return tokens;
    }

    private int currentIndexLine {
        get => (input.Length - index + 1) / (lineLength ? lineLength : 1);
    }

    private string GetWord(int start) {
        if (start >= input.Length) return "";
        int end = start + 1;
        while (end < input.Length && IsLetterOrNumber(input[end])) end++;
        return input[start..end].ToLower();
    }

    private bool IsLetterOrNumber(char c) => char.IsLetter(c) || char.IsDigit(c);

    private string ReadString(int start) {
        if (start >= input.Length) return "";
        int end = start + 1;
        while (end < input.Length && input[end] != '"' && input[end] != "'") end++;
        if (end > start) {
            string str = input[start..end];
            index = end + 1;
            return str;
        } else {
            return "";
        }
    }
}

public class SyntaxError : Exception { }

// Parser
public abstract class Parser {
    protected readonly IEnumerable<Token> tokens;
    protected int currentTokenIndex = 0;

    public Parser(IEnumerable<Token> tokens) {
        this.tokens = tokens;
    }

    protected Token CurrentToken => tokens[currentTokenIndex];
    protected Token PeekToken(int offset = 1) => 
        (offset >= tokens.Count) ? null : tokens[offset];

    protected void ConsumeToken() {
        currentTokenIndex++;
    }
}

public abstract class ASTNode {
    public required string Name { get; set; };
    public required Dictionary<string, object> Attributes { get; set; } = new();
    public readonly List<ASTNode> Children { get; set; } = new();
}

[Record]
public class Program : ASTNode {
    public required List<FunctionDef> Functions { get; set; } = new();
}

[Record]
public class FunctionDef : ASTNode {
    public required string Name { get; set; };
    public required List<Parameter> Parameters { get; set; } = new();
    public required TypeNode ReturnType { get; set; };
    public required string FunctionTypeComment { get; set; };
    public required List<Statement> Body { get; set; } = new();
}

[Record]
public class Statement : ASTNode {
    public required StatementKind Kind { get; set; };
    public required List<ASTNode> Children { get; set; } = new();
}

// Continue with other AST node definitions...

// Implement parsing functions here

// Pretty Printer
public abstract class PrettyPrinter {
    protected readonly List<string> OutputLines { get; set; } = new();

    public override string ToString() => string.Join("\n", OutputLines);
}

[Record]
public class PrettyPrintOptions {
    public required bool Indentation { get; set; };
    public required bool LineNumbers { get; set; };
}