using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstPrinter
{
    public static class AstPrettyPrinter
    {
        /// <summary>
        /// Pretty prints the Abstract Syntax Tree.
        /// </summary>
        /// <param name="root">The root of the AST.</param>
        /// <returns>A string representation of the pretty-printed AST.</returns>
        public static string PrintAst(SyntaxNode root)
        {
            return root.ToString();
        }
    }
}