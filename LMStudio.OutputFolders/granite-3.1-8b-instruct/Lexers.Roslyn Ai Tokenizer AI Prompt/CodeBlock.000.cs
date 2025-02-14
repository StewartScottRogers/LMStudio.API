public class CodeAnalyzer 
    {
        // ...

        public Tuple<AstNode, List<DiagnosticMessage>> AnalyzeCode(string code) 
        {
            // Use Roslyn to create an AST from the code
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // ...

            return new Tuple<AstNode, List<DiagnosticMessage>>(root, diagnosticMessages);
        }
    }