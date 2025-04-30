using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LexerTest
{
    [TestMethod]
    public void TestIdentifier()
    {
        var lexer = new Lexer("a b c d e f g h i j k l m n o p q r s t u v w x y z");
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestNumber()
    {
        var lexer = new Lexer("12345 67890");
        Assert.AreEqual(TokenType.Number, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Number, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestAssign()
    {
        var lexer = new Lexer(":=");
        Assert.AreEqual(TokenType.Assign, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestIfThenEnd()
    {
        var lexer = new Lexer("if then end");
        Assert.AreEqual(TokenType.If, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Then, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.End, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestWhileDoEnd()
    {
        var lexer = new Lexer("while do end");
        Assert.AreEqual(TokenType.While, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Do, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.End, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestPrint()
    {
        var lexer = new Lexer("print");
        Assert.AreEqual(TokenType.Print, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestOperators()
    {
        var lexer = new Lexer("+ - * / ( ) ;");
        Assert.AreEqual(TokenType.Plus, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Minus, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Asterisk, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Slash, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.LeftParen, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.RightParen, lexer.NextToken().Type);
        Assert.AreEqual(TokenType.Semicolon, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestComplexExpression()
    {
        var lexer = new Lexer("a := 1 + 2 * (3 - 4)");
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type); // a
        Assert.AreEqual(TokenType.Assign, lexer.NextToken().Type);     // :=
        Assert.AreEqual(TokenType.Number, lexer.NextToken().Type);    // 1
        Assert.AreEqual(TokenType.Plus, lexer.NextToken().Type);      // +
        Assert.AreEqual(TokenType.Number, lexer.NextToken().Type);    // 2
        Assert.AreEqual(TokenType.Asterisk, lexer.NextToken().Type);  // *
        Assert.AreEqual(TokenType.LeftParen, lexer.NextToken().Type);   // (
        Assert.AreEqual(TokenType.Number, lexer.NextToken().Type);    // 3
        Assert.AreEqual(TokenType.Minus, lexer.NextToken().Type);     // -
        Assert.AreEqual(TokenType.Number, lexer.NextToken().Type);    // 4
        Assert.AreEqual(TokenType.RightParen, lexer.NextToken().Type);  // )
        Assert.AreEqual(TokenType.Eof, lexer.NextToken().Type);
    }

    [TestMethod]
    public void TestIfStatement()
    {
        var lexer = new Lexer("if a > b then print a end");
        Assert.AreEqual(TokenType.If, lexer.NextToken().Type);         // if
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // a
        Assert.AreEqual(TokenType.GreaterThan, lexer.NextToken().Type);// >
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // b
        Assert.AreEqual(TokenType.Then, lexer.NextToken().Type);       // then
        Assert.AreEqual(TokenType.Print, lexer.NextToken().Type);      // print
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // a
        Assert.AreEqual(TokenType.End, lexer.NextToken().Type);         // end
    }

    [TestMethod]
    public void TestWhileStatement()
    {
        var lexer = new Lexer("while a < b do print a end");
        Assert.AreEqual(TokenType.While, lexer.NextToken().Type);       // while
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // a
        Assert.AreEqual(TokenType.LessThan, lexer.NextToken().Type);    // <
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // b
        Assert.AreEqual(TokenType.Do, lexer.NextToken().Type);          // do
        Assert.AreEqual(TokenType.Print, lexer.NextToken().Type);       // print
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // a
        Assert.AreEqual(TokenType.End, lexer.NextToken().Type);         // end
    }

    [TestMethod]
    public void TestPrintStatement()
    {
        var lexer = new Lexer("print a + b");
        Assert.AreEqual(TokenType.Print, lexer.NextToken().Type);       // print
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // a
        Assert.AreEqual(TokenType.Plus, lexer.NextToken().Type);        // +
        Assert.AreEqual(TokenType.Identifier, lexer.NextToken().Type);   // b
    }

    [TestMethod]
    public void TestProgram()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    print a + b;
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithNestedIf()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        print a + b;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithNestedWhile()
    {
        var source = @"
a := 10;
b := 20;
while a < b do
    while b > a do
        print a + b;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithIfWhile()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    while a < b do
        print a + b;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithWhileIf()
    {
        var source = @"
a := 10;
b := 20;
while a < b do
    if a > 5 then
        print a + b;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithMultipleStatements()
    {
        var source = @"
a := 10;
b := 20;
print a + b;
if a < b then
    print a + b;
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithMultipleStatementsAndBlocks()
    {
        var source = @"
a := 10;
b := 20;
print a + b;
if a < b then
    print a + b;
end
while a < b do
    print a + b;
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithMultipleBlocks()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        print a + b;
    end
end
while a < b do
    if a > 5 then
        print a + b;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithNestedBlocks()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        if a == 10 then
            print a + b;
        end
    end
end
while a < b do
    if a > 5 then
        while b > a do
            print a + b;
        end
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithComplexExpression()
    {
        var source = @"
a := 10;
b := 20;
print a + b * c - d / e;";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithComplexStatements()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        print a + b * c - d / e;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithComplexStatementsAndBlocks()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        print a + b * c - d / e;
    end
end
while a < b do
    if a > 5 then
        print a + b * c - d / e;
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithComplexNestedBlocks()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        if a == 10 then
            print a + b * c - d / e;
        end
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [TestMethod]
    public void TestProgramWithComplexNestedBlocksAndWhile()
    {
        var source = @"
a := 10;
b := 20;
if a < b then
    if a > 5 then
        if a == 10 then
            print a + b * c - d / e;
        end
    end
end
while a < b do
    if a > 5 then
        while b > a do
            print a + b * c - d / e;
        end
    end
end";

        var lexer = new Lexer(source);
        var parser = new Parser(lexer);

        try
        {
            var programNode = parser.Parse();
            var printer = new AstPrinter();
            printer.Print(programNode);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}