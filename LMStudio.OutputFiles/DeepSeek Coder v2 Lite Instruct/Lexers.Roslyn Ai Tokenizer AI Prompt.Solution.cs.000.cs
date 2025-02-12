using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RoslynAiTokenizer.Parser
{
    public class AstBuilder
    {
        public static SyntaxTree BuildAst(string code)
        {
            return CSharpSyntaxTree.ParseText(code);
        }

        public List<SyntaxTree> BuildAllAtsFromDirectory(string directoryPath)
        {
            var syntaxTrees = new List<SyntaxTree>();
            foreach (var filePath in Directory.GetFiles(directoryPath, "*.cs"))
            {
                var code = File.ReadAllText(filePath);
                syntaxTrees.Add(BuildAst(code));
            }
            return syntaxTrees;
        }
    }
}