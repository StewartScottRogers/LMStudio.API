using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer.Tests
{
    /// <summary>
    /// Unit tests for the AstPrettyPrinter class.
    /// </summary>
    [TestClass]
    public class AstPrettyPrinterTests
    {
        /// <summary>
        /// Tests printing a simple class declaration.
        /// </summary>
        [TestMethod]
        public void Print_SimpleClass_PrintsCorrectly()
        {
            // Arrange
            string code = "class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act & Assert - This should not throw
            AstPrettyPrinter.Print(root);
        }
        
        /// <summary>
        /// Tests printing a class with methods.
        /// </summary>
        [TestMethod]
        public void Print_ClassWithMethods_PrintsCorrectly()
        {
            // Arrange
            string code = "class Test { void Method() { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act & Assert - This should not throw
            AstPrettyPrinter.Print(root);
        }
        
        /// <summary>
        /// Tests printing complex nested structure.
        /// </summary>
        [TestMethod]
        public void Print_ComplexStructure_PrintsCorrectly()
        {
            // Arrange
            string code = @"
                namespace NS 
                { 
                    class Test 
                    { 
                        void Method() 
                        { 
                            if(true) { } 
                        } 
                    } 
                }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act & Assert - This should not throw
            AstPrettyPrinter.Print(root);
        }
        
        /// <summary>
        /// Tests detailed string conversion.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_ValidNode_ReturnsString()
        {
            // Arrange
            string code = "class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with null node.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_NullNode_ReturnsEmptyString()
        {
            // Act
            string result = AstPrettyPrinter.ToDetailedString(null);
            
            // Assert
            Assert.AreEqual(string.Empty, result);
        }
        
        /// <summary>
        /// Tests detailed string conversion with complex node.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_ComplexNode_ReturnsNonEmptyString()
        {
            // Arrange
            string code = @"
                namespace TestNS 
                { 
                    class TestClass 
                    { 
                        int Value; 
                        
                        void Method(int param) 
                        { 
                            var local = 42; 
                        } 
                    } 
                }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with method overloads.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_MethodOverloads_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { void Method1() { } void Method2(int x) { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with inheritance.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Inheritance_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Base { } class Derived : Base { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with generics.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Generics_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test<T> { T Value; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with nested classes.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_NestedClasses_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Outer { class Inner { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with interfaces.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Interfaces_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "interface ITest { void Method(); }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with attributes.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Attributes_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "[Serializable] class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with properties.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Properties_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { int Value { get; set; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with events.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Events_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { event EventHandler MyEvent; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with delegates.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_Delegates_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { delegate void MyDelegate(); }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with anonymous types.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_AnonymousTypes_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { void Method() { var x = new { Name = \"Test\" }; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with LINQ expressions.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_LinqExpressions_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { void Method() { var result = from x in new int[0] select x; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with array declarations.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_ArrayDeclarations_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { int[] Values; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with multidimensional arrays.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_MultidimensionalArrays_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { int[,] Values; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with jagged arrays.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_JaggedArrays_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { int[][] Values; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with foreach statements.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_ForeachStatements_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { void Method() { foreach(var x in new int[0]) { } } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with try-catch blocks.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_TryCatchBlocks_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { void Method() { try { } catch(Exception e) { } } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests detailed string conversion with using statements.
        /// </summary>
        [TestMethod]
        public void ToDetailedString_UsingStatements_ReturnsNonEmptyString()
        {
            // Arrange
            string code = "class Test { void Method() { using(var x = new System.IO.MemoryStream()) { } } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstPrettyPrinter.ToDetailedString(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}