using System;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace ASTGenerator
{
    public record AstNode(
        string Value,
        IReadOnlyCollection<AstNode> Children = null)
    {
        public static AstNode CreateChild(string childValue, AstNode parent) =>
            new AstNode(childValue, parent.Children ?? new List<AstNode>());
    }

    public record ProgramNode(AstNode Function, AstNode Class, AstNode GlobalVariables) 
        : AstNode("program", Function, Class, new[] { "using System;" });

    public record IdentifierNode(string Name, AstNode? Type)
        : AstNode(Name, Type);

    public record LiteralNode(object Value)
        : AstNode("literal", (Value != null ? new List<AstNode> { new LiteralNode(Value) } 
            : Array.Empty<AstNode>()));

    public class SyntaxParser
    {
        private readonly string Input;

        public SyntaxParser(string input)
        {
            Input = input;
        }

        public ProgramNode Parse()
        {
            // Parsing logic here
            throw new NotImplementedException();
        }
    }

    enum Tokens
    {
        Identifier,
        Literal,
        FunctionDefinition,
        ClassDefinition,
        GlobalVariable,
        UsingStatement
    }
}