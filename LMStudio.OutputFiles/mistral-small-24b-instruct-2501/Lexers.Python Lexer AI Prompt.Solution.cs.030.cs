namespace LexerLib.AST.Nodes
{
    public readonly record AssignmentNode(string Name, string Expression, string AnnotatedRhs)
    {
        public AssignmentNode(string name, string expression, string annotatedRhs)
        {
            Name = name;
            Expression = expression;
            AnnotatedRhs = annotatedRhs;
        }
    }
}

# Lexer for the Abstract Syntax Tree

Create a separate file named `Lexer.cs` with the following content: