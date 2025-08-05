using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer.Tests
{
    /// <summary>
    /// Unit tests for the AstReflowGenerator class.
    /// </summary>
    [TestClass]
    public class AstReflowGeneratorTests
    {
        /// <summary>
        /// Tests reflowing simple class declaration.
        /// </summary>
        [TestMethod]
        public void Reflow_SimpleClass_ReturnsCode()
        {
            // Arrange
            string code = "class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.Reflow(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests reflowing complex class with methods.
        /// </summary>
        [TestMethod]
        public void Reflow_ComplexClass_ReturnsCode()
        {
            // Arrange
            string code = @"
                namespace TestNS 
                { 
                    class Test 
                    { 
                        int Value; 
                        
                        public Test(int value) 
                        { 
                            Value = value; 
                        } 
                        
                        public int GetValue() 
                        { 
                            return Value; 
                        } 
                    } 
                }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.Reflow(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests reflowing with null node.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Reflow_NullNode_ThrowsArgumentNullException()
        {
            // Act & Assert
            AstReflowGenerator.Reflow(null);
        }
        
        /// <summary>
        /// Tests generating simplified code from simple class.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_SimpleClass_ReturnsString()
        {
            // Arrange
            string code = "class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code from complex class.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_ComplexClass_ReturnsString()
        {
            // Arrange
            string code = @"
                namespace TestNS 
                { 
                    class Test 
                    { 
                        int Value; 
                        
                        public Test(int value) 
                        { 
                            Value = value; 
                        } 
                        
                        public int GetValue() 
                        { 
                            return Value; 
                        } 
                    } 
                }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with null node.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenerateSimplifiedCode_NullNode_ThrowsArgumentNullException()
        {
            // Act & Assert
            AstReflowGenerator.GenerateSimplifiedCode(null);
        }
        
        /// <summary>
        /// Tests generating simplified code with multiple classes.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_MultipleClasses_ReturnsString()
        {
            // Arrange
            string code = "class Test1 { } class Test2 { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with interfaces.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Interfaces_ReturnsString()
        {
            // Arrange
            string code = "interface ITest { void Method(); }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with generics.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Generics_ReturnsString()
        {
            // Arrange
            string code = "class Test<T> { T Value; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with nested classes.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_NestedClasses_ReturnsString()
        {
            // Arrange
            string code = "class Outer { class Inner { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with properties.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Properties_ReturnsString()
        {
            // Arrange
            string code = "class Test { int Value { get; set; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with events.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Events_ReturnsString()
        {
            // Arrange
            string code = "class Test { event EventHandler MyEvent; }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with delegates.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Delegates_ReturnsString()
        {
            // Arrange
            string code = "class Test { delegate void MyDelegate(); }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with attributes.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Attributes_ReturnsString()
        {
            // Arrange
            string code = "[Serializable] class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with constructor.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Constructor_ReturnsString()
        {
            // Arrange
            string code = "class Test { public Test() { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with method parameters.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_MethodParameters_ReturnsString()
        {
            // Arrange
            string code = "class Test { void Method(int param1, string param2) { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with method overloads.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_MethodOverloads_ReturnsString()
        {
            // Arrange
            string code = "class Test { void Method1() { } void Method2(int x) { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with inheritance.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_Inheritance_ReturnsString()
        {
            // Arrange
            string code = "class Base { } class Derived : Base { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with multiple inheritance.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_MultipleInheritance_ReturnsString()
        {
            // Arrange
            string code = "class Base1 { } class Base2 { } class Derived : Base1, Base2 { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with abstract class.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_AbstractClass_ReturnsString()
        {
            // Arrange
            string code = "abstract class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with static members.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_StaticMembers_ReturnsString()
        {
            // Arrange
            string code = "class Test { static int Value; static void Method() { } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with sealed class.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_SealedClass_ReturnsString()
        {
            // Arrange
            string code = "sealed class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with partial class.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_PartialClass_ReturnsString()
        {
            // Arrange
            string code = "partial class Test { }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with generic methods.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_GenericMethods_ReturnsString()
        {
            // Arrange
            string code = "class Test { T Method<T>(T value) { return value; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with lambda expressions.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_LambdaExpressions_ReturnsString()
        {
            // Arrange
            string code = "class Test { void Method() { var f = (int x) => x; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        /// <summary>
        /// Tests generating simplified code with anonymous methods.
        /// </summary>
        [TestMethod]
        public void GenerateSimplifiedCode_AnonymousMethods_ReturnsString()
        {
            // Arrange
            string code = "class Test { void Method() { var f = delegate(int x) { return x; }; } }";
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();
            
            // Act
            string result = AstReflowGenerator.GenerateSimplifiedCode(root);
            
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}