using System;
using System.Text;

public readonly record class AssignmentStatementNode(NodeTuple ReturnTuple): AstNode
{
    private readonly ExpressionNode LeftHandSide { get; }
    private readonly ExpressionNode RightHandSide { get; }

    public AssignmentStatementNode(ExpressionNode left, ExpressionNode right)
    {
        this.LeftHandSide = left;
        this.RightHandSide = right;
    }

    // Pretty print the AST node
    public void PrintAst(StreamWriter writer)
    {
        writer.WriteLine("Assignment:");
        writer.Write("  Left Hand Side: ");
        writer.WriteLine(GetLeftHandSide());

        writer.Write("  Right Hand Side: ");
        var rightHandSide = GetRightHandSide();
        if (rightHandSide != null)
        {
            writer.WriteLine(rightHandSide);
        }
    }

    #region Properties

    /// <summary>
    /// Gets the left hand side of the assignment.
    /// </summary>
    public readonly var LeftHandSideTuple { get; } = default;

    /// <summary>
    /// Gets the right hand side of the assignment, if any.
    /// </summary>
    public readonly var RightHandSideTuple { get; } = default;
}