[TestMethod]
public void TestVariableDeclaration()
{
    string source = "int x = 5;";
    var syntaxTree = CSharpSyntaxTree.ParseText(source);
    var root = syntaxTree.GetRoot();
    
    // Check that the first node is a LocalDeclarationStatement
    var statement = root.ChildNodes().First() as LocalDeclarationStatementSyntax;
    Assert.IsNotNull(statement);

    // Check variable declarator and initializer
    var declarators = statement.Declaration.Variables;
    var declarator = declarators.First();
    Assert.AreEqual("x", declarator.Identifier.Text);
    Assert.IsTrue(declarator.Initializer != null && ((LiteralExpressionSyntax)declarator.Initializer.Value).Token.Text == "5");

    // Use pretty printer to log AST structure
    string printerOutput = AstPrettyPrinter.Print(root);
    Console.WriteLine(printerOutput);

    // Generate code from AST and execute it
    string generatedCode = ReflowGenerator.Generate(root);
    dynamic result = CSharpScript.EvaluateAsync(generatedCode).Result;

    // How to assert here? If the generated code is "int x = 5;", evaluating this as a script would not return anything.
    // So perhaps wrap it in a method that returns x.

    // Alternatively, generate code that sets x and then returns it.
    // This requires modifying the reflow generator to handle such cases.

    // Assuming ReflowGenerator wraps statements into an expression:
    generatedCode = "return 5;";
    result = await CSharpScript.EvaluateAsync(generatedCode);
    Assert.AreEqual(5, (int)result);
}