using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstLibrary
{
    public enum LexingTestCases
    {
        SimpleClass,
        ComplexMethod,
        InterfaceDefinition
    }

    public class TestCase : ITestCase
    {
        private readonly SyntaxNode testCaseNode;

        public SyntaxNode TestCaseNode => testCaseNode;

        public TestCase(LexingTestCases testType)
        {
            switch (testType)
            {
                case LexingTestCases.SimpleClass:
                    testCaseNode = SyntaxFactory.ClassDeclaration("SimpleClass")
                        .AddMembers(SyntaxFactory.ConstructorDeclaration("SimpleClass"));
                    break;
                case LexingTestCases.ComplexMethod:
                    // Example: Method with parameters and a return statement
                    var parameter1 = SyntaxFactory.Parameter(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxTokenList.Create(SyntaxKind.ThisKeyword),
                        SyntaxFactory.ParseTypeName("int"),
                        SyntaxFactory.Identifier("param1"),
                        null);
                    var methodDeclaration = SyntaxFactory.MethodDeclaration(
                            SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword)),
                            "ComplexMethod")
                        .AddParameterListParameters(parameter1)
                        .WithBody(SyntaxFactory.Block(
                            SyntaxFactory.ReturnStatement(
                                SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                    SyntaxFactory.Literal(42)))));
                    testCaseNode = methodDeclaration;
                    break;
                case LexingTestCases.InterfaceDefinition:
                    var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration("ITestInterface")
                        .AddMembers(SyntaxFactory.MethodDeclaration(
                            SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                            "DoSomething"));
                    testCaseNode = interfaceDeclaration;
                    break;
            }
        }
    }
}