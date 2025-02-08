using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class ParserTests
{
    [TestMethod]
    public void TestSimpleAssignStmt()
    {
        var lexer = new Lexer("x := 10;");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var assignStmt = (AssignNode)stmtListNode.Statements[0];
        Assert.AreEqual("x", assignStmt.Name);
        var literalNode = (LiteralNode)assignStmt.Expression;
        Assert.AreEqual("10", literalNode.Value);
    }

    [TestMethod]
    public void TestSimpleIfStmt()
    {
        var lexer = new Lexer("if x then print 5; end");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var ifStmt = (IfNode)stmtListNode.Statements[0];
        var variableNode = (VariableNode)ifStmt.Condition;
        Assert.AreEqual("x", variableNode.Name);

        var thenStmtList = (StatementListNode)ifStmt.ThenBranch;
        Assert.AreEqual(1, thenStmtList.Statements.Count);
        var printStmt = (PrintNode)thenStmtList.Statements[0];
        var literalNode = (LiteralNode)printStmt.Expression;
        Assert.AreEqual("5", literalNode.Value);
    }

    [TestMethod]
    public void TestSimpleWhileStmt()
    {
        var lexer = new Lexer("while x do print 10; end");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var whileStmt = (WhileNode)stmtListNode.Statements[0];
        var variableNode = (VariableNode)whileStmt.Condition;
        Assert.AreEqual("x", variableNode.Name);

        var bodyStmtList = (StatementListNode)whileStmt.Body;
        Assert.AreEqual(1, bodyStmtList.Statements.Count);
        var printStmt = (PrintNode)bodyStmtList.Statements[0];
        var literalNode = (LiteralNode)printStmt.Expression;
        Assert.AreEqual("10", literalNode.Value);
    }

    [TestMethod]
    public void TestSimplePrintStmt()
    {
        var lexer = new Lexer("print 10;");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var printStmt = (PrintNode)stmtListNode.Statements[0];
        var literalNode = (LiteralNode)printStmt.Expression;
        Assert.AreEqual("10", literalNode.Value);
    }

    [TestMethod]
    public void TestComplexExpr()
    {
        var lexer = new Lexer("x + y * z - 10 / (5 + 3)");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);

        // Further validation of AST nodes can be added here
    }

    [TestMethod]
    public void TestComplexStmtList()
    {
        var lexer = new Lexer("x := 10; print x + y;");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(2, stmtListNode.Statements.Count);

        // Further validation of AST nodes can be added here
    }

    [TestMethod]
    public void TestIfWithMultipleStmts()
    {
        var lexer = new Lexer("if x then print y; print z; end");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var ifStmt = (IfNode)stmtListNode.Statements[0];
        var variableNode = (VariableNode)ifStmt.Condition;
        Assert.AreEqual("x", variableNode.Name);

        var thenStmtList = (StatementListNode)ifStmt.ThenBranch;
        Assert.AreEqual(2, thenStmtList.Statements.Count);
    }

    [TestMethod]
    public void TestWhileWithMultipleStmts()
    {
        var lexer = new Lexer("while x do print y; print z; end");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var whileStmt = (WhileNode)stmtListNode.Statements[0];
        var variableNode = (VariableNode)whileStmt.Condition;
        Assert.AreEqual("x", variableNode.Name);

        var bodyStmtList = (StatementListNode)whileStmt.Body;
        Assert.AreEqual(2, bodyStmtList.Statements.Count);
    }

    [TestMethod]
    public void TestNestedIf()
    {
        var lexer = new Lexer("if x then if y then print z; end end");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var outerIfStmt = (IfNode)stmtListNode.Statements[0];
        var variableNodeX = (VariableNode)outerIfStmt.Condition;
        Assert.AreEqual("x", variableNodeX.Name);

        var innerIfStmt = (IfNode)outerIfStmt.ThenBranch;
        var variableNodeY = (VariableNode)innerIfStmt.Condition;
        Assert.AreEqual("y", variableNodeY.Name);

        var innerThenStmtList = (StatementListNode)innerIfStmt.ThenBranch;
        Assert.AreEqual(1, innerThenStmtList.Statements.Count);
    }

    [TestMethod]
    public void TestNestedWhile()
    {
        var lexer = new Lexer("while x do while y do print z; end end");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);
        var stmtListNode = (StatementListNode)astNode;
        Assert.AreEqual(1, stmtListNode.Statements.Count);

        var outerWhileStmt = (WhileNode)stmtListNode.Statements[0];
        var variableNodeX = (VariableNode)outerWhileStmt.Condition;
        Assert.AreEqual("x", variableNodeX.Name);

        var innerWhileStmt = (WhileNode)outerWhileStmt.Body;
        var variableNodeY = (VariableNode)innerWhileStmt.Condition;
        Assert.AreEqual("y", variableNodeY.Name);

        var innerBodyStmtList = (StatementListNode)innerWhileStmt.Body;
        Assert.AreEqual(1, innerBodyStmtList.Statements.Count);
    }

    [TestMethod]
    public void TestComplexExprWithGrouping()
    {
        var lexer = new Lexer("x + y * z - 10 / (5 + 3)");
        var parser = new Parser(lexer.Lex());
        var astNode = parser.Parse();
        Assert.IsNotNull(astNode);

        // Further validation of AST nodes can be added here
    }
}