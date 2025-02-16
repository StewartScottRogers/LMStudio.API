using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstGenerator.Models
{
    public record AstNodeRecord(
        SyntaxKind Kind,
        string Text,
        int SpanStart,
        int SpanEnd,
        int FullSpanStart,
        int FullSpanEnd);
}