using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer
{
    /// <summary>
    /// Extension methods for SyntaxNode to provide additional functionality.
    /// </summary>
    public static class SyntaxNodeExtensions
    {
        /// <summary>
        /// Gets the full name of a syntax node including its containing types.
        /// </summary>
        /// <param name="node">The syntax node</param>
        /// <returns>The full name of the node</returns>
        public static string GetFullName(this SyntaxNode node)
        {
            if (node == null) return string.Empty;
            
            var fullName = new System.Text.StringBuilder();
            var current = node.Parent;
            
            // Navigate up the tree to build the full path
            while (current != null)
            {
                if (current is Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax classDecl)
                {
                    fullName.Insert(0, $"{classDecl.Identifier.ValueText}.");
                }
                else if (current is Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax namespaceDecl)
                {
                    fullName.Insert(0, $"{namespaceDecl.Name}.{fullName}");
                }
                
                current = current.Parent;
            }
            
            return fullName.ToString();
        }
        
        /// <summary>
        /// Checks if the node represents a class declaration.
        /// </summary>
        /// <param name="node">The syntax node to check</param>
        /// <returns>True if it's a class declaration, false otherwise</returns>
        public static bool IsClassDeclaration(this SyntaxNode node)
        {
            return node is Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax;
        }
        
        /// <summary>
        /// Checks if the node represents a method declaration.
        /// </summary>
        /// <param name="node">The syntax node to check</param>
        /// <returns>True if it's a method declaration, false otherwise</returns>
        public static bool IsMethodDeclaration(this SyntaxNode node)
        {
            return node is Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax;
        }
    }
}