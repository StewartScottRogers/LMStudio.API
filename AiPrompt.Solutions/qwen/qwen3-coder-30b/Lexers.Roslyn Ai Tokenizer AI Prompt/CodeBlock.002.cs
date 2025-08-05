using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer
{
    /// <summary>
    /// Main class for exploring the Abstract Syntax Tree (AST).
    /// Provides functionality to parse C# code and extract metadata.
    /// </summary>
    public static class AstExplorer
    {
        /// <summary>
        /// Parses C# source code into a syntax tree and extracts metadata.
        /// </summary>
        /// <param name="sourceCode">The C# source code to parse</param>
        /// <returns>A tuple containing the syntax tree and metadata information</returns>
        public static (SyntaxTree SyntaxTree, string Metadata) ParseCode(string sourceCode)
        {
            // Parse the source code into a syntax tree
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            
            // Extract basic metadata from the syntax tree
            var root = syntaxTree.GetRoot();
            string metadata = $"Syntax Tree: {syntaxTree.FilePath ?? "Anonymous"}\n" +
                              $"Node Count: {root.DescendantNodes().Count()}\n" +
                              $"Root Kind: {root.Kind()}\n" +
                              $"Has Diagnostics: {syntaxTree.GetDiagnostics().Any()}";
            
            return (syntaxTree, metadata);
        }
        
        /// <summary>
        /// Gets detailed information about a syntax node.
        /// </summary>
        /// <param name="node">The syntax node to analyze</param>
        /// <returns>A tuple containing the node type and its children count</returns>
        public static (string NodeType, int ChildCount) GetNodeInfo(SyntaxNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
                
            return (node.Kind().ToString(), node.ChildNodes().Count());
        }
    }
}