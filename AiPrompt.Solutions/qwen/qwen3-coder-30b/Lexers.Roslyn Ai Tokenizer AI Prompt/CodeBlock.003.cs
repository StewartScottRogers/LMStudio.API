using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer
{
    /// <summary>
    /// Provides functionality to pretty print the Abstract Syntax Tree.
    /// </summary>
    public static class AstPrettyPrinter
    {
        /// <summary>
        /// Prints the syntax tree in a readable format with indentation.
        /// </summary>
        /// <param name="node">The root node of the syntax tree</param>
        /// <param name="indentLevel">The current indentation level</param>
        public static void Print(SyntaxNode node, int indentLevel = 0)
        {
            if (node == null) return;
            
            // Create indentation string
            var indent = new string(' ', indentLevel * 2);
            
            // Print node information
            Console.WriteLine($"{indent}{node.Kind()}");
            
            // Print children recursively
            foreach (var child in node.ChildNodes())
            {
                Print(child, indentLevel + 1);
            }
        }
        
        /// <summary>
        /// Generates a detailed string representation of the AST.
        /// </summary>
        /// <param name="node">The root node to convert to string</param>
        /// <returns>A formatted string representation of the AST</returns>
        public static string ToDetailedString(SyntaxNode node)
        {
            if (node == null) return string.Empty;
            
            var sb = new StringBuilder();
            AppendNodeDetails(sb, node, 0);
            return sb.ToString();
        }
        
        /// <summary>
        /// Helper method to recursively append node details.
        /// </summary>
        /// <param name="sb">The string builder to append to</param>
        /// <param name="node">The current node</param>
        /// <param name="indentLevel">Current indentation level</param>
        private static void AppendNodeDetails(StringBuilder sb, SyntaxNode node, int indentLevel)
        {
            var indent = new string(' ', indentLevel * 2);
            
            // Add node details
            sb.AppendLine($"{indent}{node.Kind()}");
            
            // Get children count and add information if available
            var childCount = node.ChildNodes().Count();
            if (childCount > 0)
            {
                sb.AppendLine($"{indent}  Children: {childCount}");
            }
            
            // Recursively process children
            foreach (var child in node.ChildNodes())
            {
                AppendNodeDetails(sb, child, indentLevel + 1);
            }
        }
    }
}