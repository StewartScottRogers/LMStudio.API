// Classes/AbstractSyntaxTreeService.cs
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

public class AbstractSyntaxTreeService : IAbstractSyntaxTreeService
{
    public CompilationUnitSyntax GenerateAstFromString(string code)
    {
        return CSharpSyntaxTree.ParseText(code).GetRoot() as CompilationUnitSyntax;
    }

    public string PrettyPrint(CompilationUnitSyntax ast)
    {
        var writer = new StringWriter();
        ast.WriteTo(writer);
        return writer.ToString();
    }

    public string ReflowCode(CompilationUnitSyntax ast)
    {
        using (var workspace = new AdhocWorkspace())
        {
            var project = workspace.AddProject("GeneratedProject", LanguageNames.CSharp);
            var document = project.AddDocument("GeneratedFile.cs", ast.ToFullString());

            // Get the formatted code
            var formattedDocument = Formatter.FormatAsync(document).Result;
            return formattedDocument.GetTextAsync().Result.ToString();
        }
    }
}