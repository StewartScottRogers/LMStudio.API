using System.Collections.Generic;

namespace PascaleLexer.AST
{
    public readonly record struct BlockNode(
        IEnumerable<LabelDeclarationNode> LabelDeclarations,
        IEnumerable<ConstantDefinitionNode> ConstantDefinitions,
        IEnumerable<TypeDefinitionNode> TypeDefinitions,
        IEnumerable<VariableDeclarationNode> VariableDeclarations,
        IEnumerable<ProcedureOrFunctionDeclarationNode> ProcedureAndFunctionDeclarations,
        StatementNode Statement, int Position);
}