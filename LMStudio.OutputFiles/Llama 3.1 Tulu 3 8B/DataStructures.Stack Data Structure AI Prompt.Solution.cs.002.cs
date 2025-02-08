using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MyStackSolution; // Assume this namespace.

  [TestClass]
  public class StackTests
  {
      [TestMethod]
      public void TestPushAndPop()
      {
          var stack = new Stack<int>();
          stack.Push(1);
          Assert.AreEqual(1, stack.Pop());
          Assert.IsTrue(stack.IsEmpty);
      }

      [TestMethod]
      public void TestPeek()
      {
          var stack = new Stack<int>();
          stack.Push(5);
          Assert.AreEqual(5, stack.Peek());
          Assert.IsFalse(stack.IsEmpty);
      }

      // More tests here for boundary conditions and error handling...
  }