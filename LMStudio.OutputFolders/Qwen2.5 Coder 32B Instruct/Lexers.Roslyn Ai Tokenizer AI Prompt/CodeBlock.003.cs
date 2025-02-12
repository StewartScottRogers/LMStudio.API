var astService = new AbstractSyntaxTreeService();
string code = "class Program { static void Main() {} }";
CompilationUnitSyntax ast = astService.GenerateAstFromString(code);