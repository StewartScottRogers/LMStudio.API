using System;
using System.Collections.Generic;
using System.IO;

public class Lexer
{
    private readonly string input;
    private int position;
    private char currentChar;

    public List<Tuple> Tokens { get; } = new();

    public Lexer(string input)
    {
        this.input = input;
        this.position = 0;
        this.currentChar = input[position];
    }

    public void Advance()
    {
        position++;
        if (position >= input.Length)
        {
            currentChar = '\0';
        }
        else
        {
            currentChar = input[position];
        }
    }

    private bool IsAtEnd() => currentChar == '\0';

    private char Peek() => currentChar;

    public interface ILexer
    {
        void Lex(string code);
    }

    public class AbstractSyntaxTreeNode
    {

    }

    public record StatementTuple(StatementTupleType Type, string Content)
    {
        public enum StatementTupleType
        {
            Compound,
            Simple,
            Newline,
            EndMarker
        }
    }

    public record StatementsTuple(string[] Statements, int StartIndex, int EndIndex)
    {

    }

    public record TokenTuple(TokenKind Kind, string Value, int StartIndex, int EndIndex)
    {
        public enum TokenKind
        {
            CompoundStatement,
            SimpleStatement,
            Assignment,
            TypeAlias,
            StarExpressions,
            ReturnStatement,
            ImportStatement,
            RaiseStatement,
            Pass,
            DelStatement,
            YieldStatement,
            AssertStatement,
            Break,
            Continue,
            GlobalStatement,
            NonlocalStatement,
            FunctionDefinition,
            IfStatement,
            ClassDefinition,
            WithStatement,
            ForStatement,
            TryStatement,
            WhileStatement,
            MatchStatement

# Lexer Library Project Structure