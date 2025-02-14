using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ParserTests
{
    [TestMethod]
    public void TestParseLetStatements()
    {
        var input = @"let x := 5;
let y := 10;
let foobar := 838383;";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(3, program.Statements.Count);

        foreach (var stmt in program.Statements)
        {
            TestLetStatement(stmt as AssignStatementNode, ((AssignStatementNode)stmt).Identifier);
        }
    }

    [TestMethod]
    public void TestParseReturnStatements()
    {
        var input = @"return 5;
return 10;
return 993322;";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(3, program.Statements.Count);

        foreach (var stmt in program.Statements)
        {
            TestReturnStatement(stmt as ReturnStatementNode);
        }
    }

    [TestMethod]
    public void TestIdentifierExpression()
    {
        var input = "foobar;";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        TestLiteralExpression(stmt.Expression as Identifier, "foobar");
    }

    [TestMethod]
    public void TestIntegerLiteralExpression()
    {
        var input = "5;";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        TestLiteralExpression(stmt.Expression as NumberLiteral, 5);
    }

    [TestMethod]
    public void TestParsingPrefixExpressions()
    {
        var prefixTests = new Dictionary<string, object>
        {
            { "!5;", new PrefixTest { Operator = "!", Value = 5 } },
            { "-15;", new PrefixTest { Operator = "-", Value = 15 } }
        };

        foreach (var test in prefixTests)
        {
            var lexer = new Lexer(test.Key);
            var parser = new Parser(lexer);

            var program = parser.ParseProgram();
            CheckParserErrors(parser);

            Assert.AreEqual(1, program.Statements.Count);

            var stmt = (ExpressionStatement)program.Statements[0];
            TestPrefixExpression(stmt.Expression as PrefixExpression, test.Value.Operator, test.Value.Value);
        }
    }

    [TestMethod]
    public void TestParsingInfixExpressions()
    {
        var infixTests = new Dictionary<string, InfixTest>
        {
            { "5 + 5;", new InfixTest { LeftValue = 5, Operator = "+", RightValue = 5 } },
            { "5 - 5;", new InfixTest { LeftValue = 5, Operator = "-", RightValue = 5 } },
            { "5 * 5;", new InfixTest { LeftValue = 5, Operator = "*", RightValue = 5 } },
            { "5 / 5;", new InfixTest { LeftValue = 5, Operator = "/", RightValue = 5 } },
        };

        foreach (var test in infixTests)
        {
            var lexer = new Lexer(test.Key);
            var parser = new Parser(lexer);

            var program = parser.ParseProgram();
            CheckParserErrors(parser);

            Assert.AreEqual(1, program.Statements.Count);

            var stmt = (ExpressionStatement)program.Statements[0];
            TestInfixExpression(stmt.Expression as InfixExpression, test.Value.LeftValue, test.Value.Operator, test.Value.RightValue);
        }
    }

    [TestMethod]
    public void TestOperatorPrecedenceParsing()
    {
        var tests = new Dictionary<string, string>
        {
            { "-a * b", "((-a) * b)" },
            { "!-a", "(!(-a))" },
            { "a + b + c", "((a + b) + c)" },
            { "a + b - c", "((a + b) - c)" },
            { "a * b * c", "((a * b) * c)" },
            { "a * b / c", "((a * b) / c)" },
            { "a + b / c", "(a + (b / c))" },
            { "a + b * c + d / e - f", "(((a + (b * c)) + (d / e)) - f)" },
            { "3 + 4; -5 * 5;", "((3 + 4) (-5 * 5))" },
            { "5 > 4 == 3 < 4", "((5 > 4) == (3 < 4))" },
            { "5 < 4 != 3 > 4", "((5 < 4) != (3 > 4))" },
            { "3 + 4 * 5 == 3 * 1 + 4 * 5", "((3 + (4 * 5)) == ((3 * 1) + (4 * 5)))" },
        };

        foreach (var test in tests)
        {
            var lexer = new Lexer(test.Key);
            var parser = new Parser(lexer);

            var program = parser.ParseProgram();
            CheckParserErrors(parser);

            var actualOutput = program.ToString();
            Assert.AreEqual(test.Value, actualOutput);
        }
    }

    [TestMethod]
    public void TestBooleanExpression()
    {
        var tests = new Dictionary<string, object>
        {
            { "true;", true },
            { "false;", false },
        };

        foreach (var test in tests)
        {
            var lexer = new Lexer(test.Key);
            var parser = new Parser(lexer);

            var program = parser.ParseProgram();
            CheckParserErrors(parser);

            Assert.AreEqual(1, program.Statements.Count);

            var stmt = (ExpressionStatement)program.Statements[0];
            TestLiteralExpression(stmt.Expression as BooleanLiteral, test.Value);
        }
    }

    [TestMethod]
    public void TestIfExpression()
    {
        var input = @"if (x < y) { x }";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var expression = stmt.Expression as IfExpression;

        TestInfixExpression(expression.Condition, "x", "<", "y");

        Assert.IsNotNull(expression.Consequence.Statements);
        Assert.AreEqual(1, expression.Consequence.Statements.Count);

        var consequence = expression.Consequence.Statements[0] as ExpressionStatement;
        TestIdentifier(consequence.Expression, "x");

        Assert.IsNull(expression.Alternative);
    }

    [TestMethod]
    public void TestIfElseExpression()
    {
        var input = @"if (x < y) { x } else { y }";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var expression = stmt.Expression as IfExpression;

        TestInfixExpression(expression.Condition, "x", "<", "y");

        Assert.IsNotNull(expression.Consequence.Statements);
        Assert.AreEqual(1, expression.Consequence.Statements.Count);

        var consequence = expression.Consequence.Statements[0] as ExpressionStatement;
        TestIdentifier(consequence.Expression, "x");

        Assert.IsNotNull(expression.Alternative.Statements);
        Assert.AreEqual(1, expression.Alternative.Statements.Count);

        var alternative = expression.Alternative.Statements[0] as ExpressionStatement;
        TestIdentifier(alternative.Expression, "y");
    }

    [TestMethod]
    public void TestFunctionLiteralParsing()
    {
        var input = @"fn(x, y) { x + y; }";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var function = stmt.Expression as FunctionLiteral;

        Assert.IsNotNull(function.Parameters);
        Assert.AreEqual(2, function.Parameters.Length);

        TestLiteralExpression(function.Parameters[0], "x");
        TestLiteralExpression(function.Parameters[1], "y");

        Assert.IsNotNull(function.Body.Statements);
        Assert.AreEqual(1, function.Body.Statements.Count);

        var bodyStmt = function.Body.Statements[0] as ExpressionStatement;
        TestInfixExpression(bodyStmt.Expression as InfixExpression, "x", "+", "y");
    }

    [TestMethod]
    public void TestFunctionParameterParsing()
    {
        var tests = new Dictionary<string, string[]>
        {
            { "fn() {};", Array.Empty<string>() },
            { "fn(x) {}; ", new string[] { "x" } },
            { "fn(x, y, z) {}; ", new string[] { "x", "y", "z" } }
        };

        foreach (var test in tests)
        {
            var lexer = new Lexer(test.Key);
            var parser = new Parser(lexer);

            var program = parser.ParseProgram();
            CheckParserErrors(parser);

            Assert.AreEqual(1, program.Statements.Count);

            var stmt = (ExpressionStatement)program.Statements[0];
            var function = stmt.Expression as FunctionLiteral;

            Assert.IsNotNull(function.Parameters);
            Assert.AreEqual(test.Value.Length, function.Parameters.Length);

            for (var i = 0; i < test.Value.Length; i++)
                TestLiteralExpression(function.Parameters[i], test.Value[i]);
        }
    }

    [TestMethod]
    public void TestCallExpressionParsing()
    {
        var input = "add(1, 2 * 3, 4 + 5);";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var exp = stmt.Expression as CallExpression;

        Assert.IsNotNull(exp.Function);
        TestIdentifier(exp.Function, "add");

        Assert.IsNotNull(exp.Arguments);
        Assert.AreEqual(3, exp.Arguments.Length);

        TestLiteralExpression(exp.Arguments[0], 1);
        TestInfixExpression(exp.Arguments[1] as InfixExpression, 2, "*", 3);
        TestInfixExpression(exp.Arguments[2] as InfixExpression, 4, "+", 5);
    }

    [TestMethod]
    public void TestStringLiteralExpression()
    {
        var input = @"""Hello World!"";";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        TestLiteralExpression(stmt.Expression as StringLiteral, "Hello World!");
    }

    [TestMethod]
    public void TestArrayLiteralParsing()
    {
        var input = "[1, 2 * 2, 3 + 3];";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var array = stmt.Expression as ArrayLiteral;

        Assert.IsNotNull(array.Elements);
        Assert.AreEqual(3, array.Elements.Length);

        TestIntegerLiteral(array.Elements[0], 1);
        TestInfixExpression(array.Elements[1] as InfixExpression, 2, "*", 2);
        TestInfixExpression(array.Elements[2] as InfixExpression, 3, "+", 3);
    }

    [TestMethod]
    public void TestParsingIndexExpressions()
    {
        var input = "myArray[1 + 1];";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var indexExp = stmt.Expression as IndexExpression;

        Assert.IsNotNull(indexExp.Left);
        TestIdentifier(indexExp.Left, "myArray");

        Assert.IsNotNull(indexExp.Index);
        TestInfixExpression(indexExp.Index as InfixExpression, 1, "+", 1);
    }

    [TestMethod]
    public void TestParsingHashLiteralsStringKeys()
    {
        var input = @"{""one"": 1, ""two"": 2, ""three"": 3}";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var hash = stmt.Expression as HashLiteral;

        Assert.IsNotNull(hash.Pairs);
        Assert.AreEqual(3, hash.Pairs.Count);

        TestStringLiteral(hash.Pairs[new StringLiteral("one")], 1);
        TestStringLiteral(hash.Pairs[new StringLiteral("two")], 2);
        TestStringLiteral(hash.Pairs[new StringLiteral("three")], 3);
    }

    [TestMethod]
    public void TestParsingEmptyHashLiteral()
    {
        var input = @"{}";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var hash = stmt.Expression as HashLiteral;

        Assert.IsNotNull(hash.Pairs);
        Assert.AreEqual(0, hash.Pairs.Count);
    }

    [TestMethod]
    public void TestParsingHashLiteralsWithExpressions()
    {
        var input = @"{""one"": 0 + 1, ""two"": 10 - 8, ""three"": 2 * 3}";

        var lexer = new Lexer(input);
        var parser = new Parser(lexer);

        var program = parser.ParseProgram();
        CheckParserErrors(parser);

        Assert.AreEqual(1, program.Statements.Count);

        var stmt = (ExpressionStatement)program.Statements[0];
        var hash = stmt.Expression as HashLiteral;

        Assert.IsNotNull(hash.Pairs);
        Assert.AreEqual(3, hash.Pairs.Count);

        TestInfixExpression((hash.Pairs[new StringLiteral("one")] as InfixExpression), 0, "+", 1);
        TestInfixExpression((hash.Pairs[new StringLiteral("two")] as InfixExpression), 10, "-", 8);
        TestInfixExpression((hash.Pairs[new StringLiteral("three")] as InfixExpression), 2, "*", 3);
    }

    private void CheckParserErrors(Parser parser)
    {
        if (parser.Errors.Count == 0) return;

        Console.WriteLine("Parser has errors!");
        foreach (var msg in parser.Errors)
            Console.WriteLine(msg);

        Assert.Fail();
    }

    private void TestLetStatement(AssignStatementNode stmt, string name)
    {
        Assert.IsNotNull(stmt);
        Assert.AreEqual(TokenType.Let, stmt.Token.Type);
        Assert.AreEqual(name, stmt.Name.Value);

        var ident = stmt.Value as Identifier;
        Assert.IsNotNull(ident);
        Assert.AreEqual(name, ident.Value);
    }

    private void TestReturnStatement(ReturnStatementNode stmt)
    {
        Assert.IsNotNull(stmt);
        Assert.AreEqual(TokenType.Return, stmt.Token.Type);
    }

    private void TestLiteralExpression(Expression expression, object value)
    {
        switch (value)
        {
            case int intValue:
                TestIntegerLiteral(expression as IntegerLiteral, intValue);
                break;
            case string stringValue:
                TestStringLiteral(expression as StringLiteral, stringValue);
                break;
            case bool booleanValue:
                TestBooleanLiteral(expression as BooleanLiteral, booleanValue);
                break;
            default:
                Assert.Fail($"Type of {value} not handled.");
                break;
        }
    }

    private void TestIntegerLiteral(IntegerLiteral il, int value)
    {
        Assert.IsNotNull(il);
        Assert.AreEqual(value, il.Value);
        Assert.AreEqual(value.ToString(), il.TokenLiteral());
    }

    private void TestStringLiteral(StringLiteral sl, string value)
    {
        Assert.IsNotNull(sl);
        Assert.AreEqual(value, sl.Value);
        Assert.AreEqual($"\"{value}\"", sl.TokenLiteral());
    }

    private void TestBooleanLiteral(BooleanLiteral bl, bool value)
    {
        Assert.IsNotNull(bl);
        Assert.AreEqual(value, bl.Value);
        Assert.AreEqual(bl.Value.ToString().ToLower(), bl.TokenLiteral());
    }

    private void TestIdentifier(Expression exp, string value)
    {
        var ident = exp as Identifier;
        Assert.IsNotNull(ident);
        Assert.AreEqual(value, ident.Value);
        Assert.AreEqual(value, ident.TokenLiteral());
    }

    private void TestPrefixExpression(PrefixExpression exp, string operatorSymbol, object rightValue)
    {
        Assert.IsNotNull(exp);
        Assert.AreEqual(operatorSymbol, exp.Operator);

        TestLiteralExpression(exp.Right, rightValue);
    }

    private void TestInfixExpression(InfixExpression exp, object leftValue, string operatorSymbol, object rightValue)
    {
        Assert.IsNotNull(exp);
        TestLiteralExpression(exp.Left, leftValue);
        Assert.AreEqual(operatorSymbol, exp.Operator);
        TestLiteralExpression(exp.Right, rightValue);
    }

    public class PrefixTest
    {
        public string Operator { get; set; }
        public object Value { get; set; }
    }

    public class InfixTest
    {
        public object LeftValue { get; set; }
        public string Operator { get; set; }
        public object RightValue { get; set; }
    }
}