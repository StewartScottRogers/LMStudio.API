using System;
using System.Collections.Generic;

public record Node 
{
    public enum NodeType { Program, Statement, FunctionDeclaration };
}

public class ASTBuilder : IDisposable
{
    private readonly Tokenizer tokenizer;
    private int currentLine;
    
    public ASTBuilder(Tokenizer tokenizer) => this.tokenizer = tokenizer;

    public List<Node> Nodes { get; } = new List<Node>();

    public void Build(ASTGrammar grammar)
    {
        ParseProgram(grammar);
    }

    private void ParseProgram(ASTGrammar grammar)
    {
        var programToken = tokenizer.Tokens.OfType<Token<Identifier>>()
            .FirstOrDefault(t => t.Value.Text == "program");
        
        if (programToken is not null && grammar.ProgramRule.TryParse(programToken))
            AddNode(new ProgramNode(programToken));
    }

    // ... other parsing methods
}