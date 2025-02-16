using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GrammarParser.Tests
{
    [TestClass]
    public class ParserTests
    {
        private static List<Lexer.Token> Lex(string source)
        {
            var lexer = new Lexer(source);
            lexer.Lex();
            return lexer.Tokens;
        }

        [TestMethod]
        public void TestSimpleAssignStmt()
        {
            var tokens = Lex("a := 1");
            var parser = new Parser(tokens);
            var rootNode = parser.Parse();

            Assert.IsInstanceOfType(rootNode, typeof(AssignNode));
            var assignNode = (AssignNode)rootNode;
            Assert.AreEqual("a", assignNode.Identifier);

            Assert.IsInstanceOfType(assignNode.Expression, typeof(NumberNode));
            var numberNode = (NumberNode)assignNode.Expression;
            Assert.AreEqual(1, numberNode.Value);
        }

        [TestMethod]
        public void TestIfStmt()
        {
            var tokens = Lex("if a then b := 2 end");
            var parser = new Parser(tokens);
            var rootNode = parser.Parse();

            Assert.IsInstanceOfType(rootNode, typeof(IfNode));
            var ifNode = (IfNode)rootNode;

            Assert.IsInstanceOfType(ifNode.Condition, typeof(IdentifierNode));
            var conditionIdNode = (IdentifierNode)ifNode.Condition;
            Assert.AreEqual("a", conditionIdNode.Name);

            Assert.IsInstanceOfType(ifNode.ThenPart, typeof(AssignNode));
            var thenAssignNode = (AssignNode)ifNode.ThenPart;
            Assert.AreEqual("b", thenAssignNode.Identifier);

            Assert.IsInstanceOfType(thenAssignNode.Expression, typeof(NumberNode));
            var numberNode = (NumberNode)thenAssignNode.Expression;
            Assert.AreEqual(2, numberNode.Value);
        }

        [TestMethod]
        public void TestWhileStmt()
        {
            var tokens = Lex("while a do b := 3 end");
            var parser = new Parser(tokens);
            var rootNode = parser.Parse();

            Assert.IsInstanceOfType(rootNode, typeof(WhileNode));
            var whileNode = (WhileNode)rootNode;

            Assert.IsInstanceOfType(whileNode.Condition, typeof(IdentifierNode));
            var conditionIdNode = (IdentifierNode)whileNode.Condition;
            Assert.AreEqual("a", conditionIdNode.Name);

            Assert.IsInstanceOfType(whileNode.Body, typeof(AssignNode));
            var bodyAssignNode = (AssignNode)whileNode.Body;
            Assert.AreEqual("b", bodyAssignNode.Identifier);

            Assert.IsInstanceOfType(bodyAssignNode.Expression, typeof(NumberNode));
            var numberNode = (NumberNode)bodyAssignNode.Expression;
            Assert.AreEqual(3, numberNode.Value);
        }

        [TestMethod]
        public void TestPrintStmt()
        {
            var tokens = Lex("print a");
            var parser = new Parser(tokens);
            var rootNode = parser.Parse();

            Assert.IsInstanceOfType(rootNode, typeof(PrintNode));
            var printNode = (PrintNode)rootNode;

            Assert.IsInstanceOfType(printNode.Expression, typeof(IdentifierNode));
            var idNode = (IdentifierNode)printNode.Expression;
            Assert.AreEqual("a", idNode.Name);
        }

        [TestMethod]
        public void TestExprWithBinaryOps()
        {
            var tokens = Lex("(a + b) * (c - 3)");
            var parser = new Parser(tokens);
            var rootNode = parser.Parse();

            Assert.IsInstanceOfType(rootNode, typeof(BinaryOpNode));
            var rootBinOpNode = (BinaryOpNode)rootNode;
            Assert.AreEqual(Lexer.TokenType.Multiply, rootBinOpNode.Operator);

            // Left side: (a + b)
            Assert.IsInstanceOfType(rootBinOpNode.Left, typeof(BinaryOpNode));
            var leftBinOpNode = (BinaryOpNode)rootBinOpNode.Left;
            Assert.AreEqual(Lexer.TokenType.Plus, leftBinOpNode.Operator);

            Assert.IsInstanceOfType(leftBinOpNode.Left, typeof(IdentifierNode));
            var leftIdNode = (IdentifierNode)leftBinOpNode.Left;
            Assert.AreEqual("a", leftIdNode.Name);

            Assert.IsInstanceOfType(leftBinOpNode.Right, typeof(IdentifierNode));
            var rightIdNode = (IdentifierNode)leftBinOpNode.Right;
            Assert.AreEqual("b", rightIdNode.Name);

            // Right side: (c - 3)
            Assert.IsInstanceOfType(rootBinOpNode.Right, typeof(BinaryOpNode));
            var rightBinOpNode = (BinaryOpNode)rootBinOpNode.Right;
            Assert.AreEqual(Lexer.TokenType.Minus, rightBinOpNode.Operator);

            Assert.IsInstanceOfType(rightBinOpNode.Left, typeof(IdentifierNode));
            var cIdNode = (IdentifierNode)rightBinOpNode.Left;
            Assert.AreEqual("c", cIdNode.Name);

            Assert.IsInstanceOfType(rightBinOpNode.Right, typeof(NumberNode));
            var threeNumberNode = (NumberNode)rightBinOpNode.Right;
            Assert.AreEqual(3, threeNumberNode.Value);
        }

        [TestMethod]
        public void TestStmtList()
        {
            var tokens = Lex("a := 1; b := 2");
            var parser = new Parser(tokens);
            var rootNode = parser.Parse();

            Assert.IsInstanceOfType(rootNode, typeof(StmtListNode));
            var stmtListNode = (StmtListNode)rootNode;

            // First statement: a := 1
            Assert.IsInstanceOfType(stmtListNode.Stmt, typeof(AssignNode));
            var firstAssignNode = (AssignNode)stmtListNode.Stmt;
            Assert.AreEqual("a", firstAssignNode.Identifier);

            Assert.IsInstanceOfType(firstAssignNode.Expression, typeof(NumberNode));
            var oneNumberNode = (NumberNode)firstAssignNode.Expression;
            Assert.AreEqual(1, oneNumberNode.Value);

            // Second statement: b := 2
            Assert.IsInstanceOfType(stmtListNode.NextStmtList, typeof(StmtListNode));
            var nextStmtListNode = (StmtListNode)stmtListNode.NextStmtList;

            Assert.IsInstanceOfType(nextStmtListNode.Stmt, typeof(AssignNode));
            var secondAssignNode = (AssignNode)nextStmtListNode.Stmt;
            Assert.AreEqual("b", secondAssignNode.Identifier);

            Assert.IsInstanceOfType(secondAssignNode.Expression, typeof(NumberNode));
            var twoNumberNode = (NumberNode)secondAssignNode.Expression;
            Assert.AreEqual(2, twoNumberNode.Value);

            // No more statements
            Assert.IsInstanceOfType(nextStmtListNode.NextStmtList, typeof(EmptyNode));
        }
    }
}