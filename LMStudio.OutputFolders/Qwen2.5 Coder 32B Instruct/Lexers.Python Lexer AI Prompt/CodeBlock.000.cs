using System.Collections.Generic;

namespace PythonLexer.Lexers
{
    public interface ILexer
    {
        IEnumerable<Nodes.INode> Tokenize(string source);
    }
}