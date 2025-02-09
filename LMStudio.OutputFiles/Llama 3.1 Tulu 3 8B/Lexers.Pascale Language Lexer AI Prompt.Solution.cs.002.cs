public abstract class AstNode { /* ... */ }
public class ProgramNode : AstNode { public List<DeclarationNode> Declarations; /* ... */ }
// Define other node classes corresponding to grammar rules