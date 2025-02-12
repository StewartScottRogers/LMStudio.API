namespace Lexer
{
    public enum TokenType
    {
        // Keywords
        Program, Const, Type, Var, Procedure, Function, Begin, End, If, Then, Else, While, Do, Repeat, For, To, Downto, Case, Of, With, Goto, Not, And, Or, Div, Mod, In, Array, Record, Set, File, Of, Nil
        
        // Identifiers and literals
        Identifier, Number, StringLiteral, BooleanLiteral
    }

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
}