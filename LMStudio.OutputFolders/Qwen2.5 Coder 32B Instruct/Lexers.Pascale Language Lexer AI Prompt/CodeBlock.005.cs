using System.Collections.Generic;

namespace PascaleLexer.AST
{
    public readonly record struct LabelDeclarationNode(IEnumerable<int> Labels, int Position);
}