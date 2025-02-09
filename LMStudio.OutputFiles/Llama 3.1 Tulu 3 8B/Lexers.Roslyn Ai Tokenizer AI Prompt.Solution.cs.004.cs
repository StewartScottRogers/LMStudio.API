public AbstractSyntaxTree LexInput(string sourceCode)
{
    // Parse source code using Roslyn's APIs.
    var compilation = CSharpCompilation.Create("Test")
        .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
        .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
        .AddSource("Main", SourceText.From(sourceCode));

    var syntaxTree = compilation.GetSyntaxRootAsync().Result;
    
    // Convert the Roslyn Syntax Tree to our Abstract Syntax Tree representation.
    // This step involves traversing the syntax tree and converting it into a custom AST format.

    return ...;  // Implementation detail omitted
}