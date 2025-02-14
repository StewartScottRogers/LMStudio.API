using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

public class AstReflowGenerator : IAstReflowGenerator
{
    public string GenerateCode(AbstractSyntaxTree ast)
    {
        // Implement the code generation logic here
        var root = SyntaxFactory.ParseSyntaxTree($"class {ast.RootNode} {{}}");
        return root.GetText().ToString();
    }
}