using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer
{
    /// <summary>
    /// Provides functionality to reflow and regenerate C# code from an AST.
    /// </summary>
    public static class AstReflowGenerator
    {
        /// <summary>
        /// Reflows the syntax tree into formatted C# code.
        /// </summary>
        /// <param name="root">The root node of the syntax tree</param>
        /// <returns>Formatted C# code string</returns>
        public static string Reflow(SyntaxNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
                
            return root.ToFullString();
        }
        
        /// <summary>
        /// Generates a simplified version of the code from an AST.
        /// </summary>
        /// <param name="root">The root node to reflow</param>
        /// <returns>A simplified code representation</returns>
        public static string GenerateSimplifiedCode(SyntaxNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
                
            // For demonstration, we'll extract class names and method names
            var sb = new System.Text.StringBuilder();
            
            foreach (var classDeclaration in root.DescendantNodes().OfType<CSharpSyntaxNode>())
            {
                if (classDeclaration is Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax classDecl)
                {
                    sb.AppendLine($"Class: {classDecl.Identifier.ValueText}");
                    
                    foreach (var method in classDecl.Members.OfType<Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax>())
                    {
                        sb.AppendLine($"  Method: {method.Identifier.ValueText}");
                    }
                }
            }
            
            return sb.ToString();
        }
    }
}