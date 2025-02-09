public interface IParser
{
    ProgramNode Parse(IEnumerable<Token> tokens);
}

public class Parser : IParser
{
    public ProgramNode Parse(IEnumerable<Token> tokens)
    {
        // Logic to parse tokens and build AST
    }
}

public abstract class ASTNode { /* ... */ }

public class ProgramNode : ASTNode
{
    public IdentifierNode Identifier { get; }
    public BlockNode Block { get; }

    public ProgramNode(IdentifierNode identifier, BlockNode block)
    {
        Identifier = identifier;
        Block = block;
    }
}