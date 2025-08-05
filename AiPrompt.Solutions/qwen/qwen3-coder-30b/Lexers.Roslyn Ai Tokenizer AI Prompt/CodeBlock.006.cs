using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer.Tests
{
    /// <summary>
    /// Unit tests for the AstExplorer class.
    /// </summary>
    [TestClass]
    public class AstExplorerTests
    {
        /// <summary>
        /// Tests parsing valid C# code into a syntax tree.
        /// </summary>
        [TestMethod]
        public void ParseCode_ValidCode_ReturnsSyntaxTreeAndMetadata()
        {
            // Arrange
            string validCode = "class Test { }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(validCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
            Assert.IsFalse(string.IsNullOrEmpty(resultTuple.Metadata));
            Assert.IsTrue(resultTuple.Metadata.Contains("Syntax Tree"));
        }
        
        /// <summary>
        /// Tests parsing invalid C# code.
        /// </summary>
        [TestMethod]
        public void ParseCode_InvalidCode_ReturnsSyntaxTree()
        {
            // Arrange
            string invalidCode = "class Test { int x; }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(invalidCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing empty code.
        /// </summary>
        [TestMethod]
        public void ParseCode_EmptyCode_ReturnsSyntaxTree()
        {
            // Arrange
            string emptyCode = "";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(emptyCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests getting node info for a valid syntax node.
        /// </summary>
        [TestMethod]
        public void GetNodeInfo_ValidNode_ReturnsNodeTypeAndChildCount()
        {
            // Arrange
            string code = "class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            var resultTuple = AstExplorer.GetNodeInfo(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(resultTuple.NodeType));
            Assert.IsTrue(resultTuple.ChildCount >= 0);
        }
        
        /// <summary>
        /// Tests getting node info with null node.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNodeInfo_NullNode_ThrowsArgumentNullException()
        {
            // Act & Assert
            AstExplorer.GetNodeInfo(null);
        }
        
        /// <summary>
        /// Tests parsing complex C# code with multiple declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_ComplexCode_ReturnsSyntaxTree()
        {
            // Arrange
            string complexCode = @"
                using System;
                namespace TestNamespace 
                {
                    class TestClass 
                    {
                        private int value;
                        
                        public TestClass(int value) 
                        {
                            this.value = value;
                        }
                        
                        public int GetValue() 
                        {
                            return value;
                        }
                    }
                }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(complexCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
            Assert.IsTrue(resultTuple.Metadata.Contains("Node Count"));
        }
        
        /// <summary>
        /// Tests parsing code with generics.
        /// </summary>
        [TestMethod]
        public void ParseCode_GenericCode_ReturnsSyntaxTree()
        {
            // Arrange
            string genericCode = "class Test<T> { }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(genericCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing code with attributes.
        /// </summary>
        [TestMethod]
        public void ParseCode_Attributes_ReturnsSyntaxTree()
        {
            // Arrange
            string attributeCode = "[Serializable] class Test { }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(attributeCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing nested class declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_NestedClasses_ReturnsSyntaxTree()
        {
            // Arrange
            string nestedCode = @"
                class Outer 
                { 
                    class Inner { } 
                }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(nestedCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing interface declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_Interface_ReturnsSyntaxTree()
        {
            // Arrange
            string interfaceCode = "interface ITest { void Method(); }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(interfaceCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing method with parameters.
        /// </summary>
        [TestMethod]
        public void ParseCode_MethodWithParameters_ReturnsSyntaxTree()
        {
            // Arrange
            string methodCode = "class Test { void Method(int param1, string param2) { } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(methodCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing anonymous methods.
        /// </summary>
        [TestMethod]
        public void ParseCode_AnonymousMethod_ReturnsSyntaxTree()
        {
            // Arrange
            string anonymousCode = "class Test { void Method() { var f = delegate(int x) { return x; }; } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(anonymousCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing lambda expressions.
        /// </summary>
        [TestMethod]
        public void ParseCode_LambdaExpression_ReturnsSyntaxTree()
        {
            // Arrange
            string lambdaCode = "class Test { void Method() { var f = (int x) => x; } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(lambdaCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing switch statements.
        /// </summary>
        [TestMethod]
        public void ParseCode_SwitchStatement_ReturnsSyntaxTree()
        {
            // Arrange
            string switchCode = "class Test { void Method() { switch(1) { case 1: break; } } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(switchCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing try-catch blocks.
        /// </summary>
        [TestMethod]
        public void ParseCode_TryCatch_ReturnsSyntaxTree()
        {
            // Arrange
            string tryCatchCode = "class Test { void Method() { try { } catch(Exception e) { } } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(tryCatchCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing foreach loops.
        /// </summary>
        [TestMethod]
        public void ParseCode_ForeachLoop_ReturnsSyntaxTree()
        {
            // Arrange
            string foreachCode = "class Test { void Method() { foreach(var x in new int[0]) { } } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(foreachCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing for loops.
        /// </summary>
        [TestMethod]
        public void ParseCode_ForLoop_ReturnsSyntaxTree()
        {
            // Arrange
            string forCode = "class Test { void Method() { for(int i = 0; i < 10; i++) { } } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(forCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing while loops.
        /// </summary>
        [TestMethod]
        public void ParseCode_WhileLoop_ReturnsSyntaxTree()
        {
            // Arrange
            string whileCode = "class Test { void Method() { while(true) { } } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(whileCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing do-while loops.
        /// </summary>
        [TestMethod]
        public void ParseCode_DoWhileLoop_ReturnsSyntaxTree()
        {
            // Arrange
            string doWhileCode = "class Test { void Method() { do { } while(true); } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(doWhileCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing using directives.
        /// </summary>
        [TestMethod]
        public void ParseCode_UsingDirectives_ReturnsSyntaxTree()
        {
            // Arrange
            string usingCode = "using System; class Test { }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(usingCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing namespace declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_NamespaceDeclaration_ReturnsSyntaxTree()
        {
            // Arrange
            string namespaceCode = "namespace TestNS { class Test { } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(namespaceCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing multiple namespaces.
        /// </summary>
        [TestMethod]
        public void ParseCode_MultipleNamespaces_ReturnsSyntaxTree()
        {
            // Arrange
            string multiNamespaceCode = @"
                namespace NS1 { class Test1 { } }
                namespace NS2 { class Test2 { } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(multiNamespaceCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing nested namespaces.
        /// </summary>
        [TestMethod]
        public void ParseCode_NestedNamespaces_ReturnsSyntaxTree()
        {
            // Arrange
            string nestedNamespaceCode = "namespace NS1.NS2 { class Test { } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(nestedNamespaceCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing enum declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_EnumDeclaration_ReturnsSyntaxTree()
        {
            // Arrange
            string enumCode = "enum Test { Value1, Value2 }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(enumCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing struct declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_StructDeclaration_ReturnsSyntaxTree()
        {
            // Arrange
            string structCode = "struct Test { int Value; }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(structCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing property declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_PropertyDeclaration_ReturnsSyntaxTree()
        {
            // Arrange
            string propertyCode = "class Test { int Value { get; set; } }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(propertyCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
        
        /// <summary>
        /// Tests parsing field declarations.
        /// </summary>
        [TestMethod]
        public void ParseCode_FieldDeclaration_ReturnsSyntaxTree()
        {
            // Arrange
            string fieldCode = "class Test { int Value; }";
            
            // Act
            var resultTuple = AstExplorer.ParseCode(fieldCode);
            
            // Assert
            Assert.IsNotNull(resultTuple.SyntaxTree);
        }
    }
}