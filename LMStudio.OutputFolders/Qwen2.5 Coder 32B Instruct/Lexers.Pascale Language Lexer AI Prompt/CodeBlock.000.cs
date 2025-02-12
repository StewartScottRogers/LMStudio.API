namespace PascaleLexer.Lexer
{
    public enum TokenTypes
    {
        Program, Identifier, Semicolon, Block, LabelDeclarationPart,
        ConstantDefinitionPart, TypeDefinitionPart, VariableDeclarationPart,
        ProcedureAndFunctionDeclarationPart, StatementPart, Empty, UnsignedInteger,
        UnsignedReal, StringLiteral, SignedNumber, Symbol, Keyword, Eof, Error
    }
}