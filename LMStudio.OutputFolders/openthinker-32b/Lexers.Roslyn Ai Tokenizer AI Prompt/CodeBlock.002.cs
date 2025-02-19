public static void ExecuteGeneratedCode(string code)
{
    var assembly = CSharpScript.EvaluateAsync(code).Result.GetAssembly();
}