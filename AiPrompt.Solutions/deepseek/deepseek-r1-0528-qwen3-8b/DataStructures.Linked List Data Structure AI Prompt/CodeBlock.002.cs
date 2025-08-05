// File: Program.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListApp.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestInsertAtBeginning()
        {
            var list = new LinkedList<int>();
            list.InsertAtBeginning(5);
            Assert.AreEqual(list.Count(), 1);
            list.InsertAtBeginning(3);
            Assert.AreEqual(list.Count(), 2);
            
            // Verify order by traversing
            int[] expected = [3,5];
            int index = -1;
            foreach (var item in list)
            {
                if (!EqualityComparer<int>.Default.Equals(item, expected[++index]))
                    Assert.Fail("Incorrect element");
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var list = new LinkedList<int>();
            list.InsertAtBeginning(5);
            list.Delete(5);
            // Verify deletion by checking count or traversal
            if (list.Count() > 0)
                Assert.Fail("Element not deleted");
            
            // Try deleting from empty list should throw exception
            try
            {
                list.Delete(10);
                Assert.Fail("Expected InvalidOperationException for empty list");
            }
            catch (InvalidOperationException ex) when (ex.Message == "List is empty")
            {
                
            }

        }
    }
}