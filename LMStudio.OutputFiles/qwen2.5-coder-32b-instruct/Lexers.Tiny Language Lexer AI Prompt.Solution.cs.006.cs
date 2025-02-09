// PrettyPrinter.cs
using System;
using System.Collections.Generic;

namespace TinyLanguageParser
{
    public readonly struct PrettyPrinter
    {
        private readonly Node rootNode;

        public PrettyPrinter(Node rootNode)
        {
            this.rootNode = rootNode ?? throw new ArgumentNullException(nameof(rootNode));
        }

        public void Print()
        {
            PrintNode(rootNode);
        }

        private int indentationLevel;

        private void PrintIndented(string text)
        {
            Console.Write(new string(' ', 4 * indentationLevel) + text);
        }

        private void PrintNode(Node node)
        {
            switch (node)
            {
                case AssignStmtNode assignStmt:
                    PrintIndented($"Assign {assignStmt.Identifier} :=\n");
                    indentationLevel++;
                    PrintExpr(assignStmt.Expression);
                    break;

                case IfStmtNode ifStmt:
                    PrintIndented("If:\n");
                    indentationLevel++;
                    PrintExpr(ifStmt.Condition);
                    PrintIndented("Then:\n");
                    indentationLevel++;
                    PrintStmtList(ifStmt.TrueBranch.Statements);
                    break;

                case WhileStmtNode whileStmt:
                    PrintIndented("While:\n");
                    indentationLevel++;
                    PrintExpr(whileStmt.Condition);
                    PrintIndented("Do:\n");
                    indentationLevel++;
                    PrintStmtList(whileStmt.Body.Statements);
                    break;

                case PrintStmtNode printStmt:
                    PrintIndented($"Print:\n");
                    indentationLevel++;
                    PrintExpr(printStmt.Expression);
                    break;

                case StmtListNode stmtListNode:
                    foreach (var statement in stmtListNode.Statements)
                        PrintNode(statement);
                    break;
            }
        }

        private void PrintExpr(ExprNode expr)
        {
            switch (expr)
            {
                case BinaryExprNode binaryExpr:
                    PrintIndented($"{binaryExpr.Operator}:\n");
                    indentationLevel++;
                    PrintExpr(binaryExpr.Left);
                    PrintExpr(binaryExpr.Right);
                    break;

                case UnaryExprNode unaryExpr:
                    PrintIndented($"{unaryExpr.Operator}:\n");
                    indentationLevel++;
                    PrintExpr(unaryExpr.Operand);
                    break;

                case IdentifierExprNode identifierExpr:
                    PrintIndented($"Identifier: {identifierExpr.Identifier}\n");
                    break;

                case NumberExprNode numberExpr:
                    PrintIndented($"Number: {numberExpr.Value}\n");
                    break;
            }
        }

        private void PrintStmtList(Node[] statements)
        {
            foreach (var statement in statements)
                PrintNode(statement);
        }
    }
}