var code = "return 42;";
var result = await CSharpScript.EvaluateAsync<int>(code);
Assert.AreEqual(42, result);