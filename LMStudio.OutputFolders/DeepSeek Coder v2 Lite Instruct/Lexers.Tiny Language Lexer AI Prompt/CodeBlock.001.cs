namespace LexerProject.AST
{
    public abstract class Statement { }

    public class AssignStatement : Statement
    {
        public string Identifier { get; }
        public Expression Expression { get; }

        public AssignStatement(string identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
    }

    // Define other statement and expression classes similarly
}