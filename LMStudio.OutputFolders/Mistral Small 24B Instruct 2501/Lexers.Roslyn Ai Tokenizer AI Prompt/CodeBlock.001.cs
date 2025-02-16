using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstPrinter
{
    public static class AstReflowGenerator
    {
        /// <summary>
        /// Generates refactored code from the Abstract Syntax Tree.
        /// </summary>
        /// <param name="root">The root of the AST.</param>
        /// <returns>A string containing the generated code.</returns>
        public static string GenerateCode(SyntaxNode root)
        {
            var code = root.ToString();
            return code;
        }
    }
}