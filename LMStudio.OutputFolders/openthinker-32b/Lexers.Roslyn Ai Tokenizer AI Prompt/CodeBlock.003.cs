[TestMethod]
public void TestSimpleAddition()
{
    string source = "5 + 3;";
    var syntaxTree = CSharpSyntaxTree.ParseText(source);
    var printerOutput = AstPrettyPrinter.Print(syntaxTree.GetRoot());
    // Log the output for debugging
    Console.WriteLine(printerOutput);

    string generatedCode = ReflowGenerator.Generate(syntaxTree.GetRoot());
    dynamic result = CSharpScript.EvaluateAsync(generatedCode).Result;
    Assert.AreEqual(8, (int)result);
}