using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedListSolution.LinkedList<int> _linkedList;

        [TestInitialize]
        public void Initialize()
        {
            _linkedList = new LinkedListSolution.LinkedList<int>();
        }

        [TestMethod]
        public void InsertAtBeginning_ShouldInsertElementAtHead()
        {
            _linkedList.InsertAtBeginning(5);

            var (found, value) = _linkedList.FindElement(5);
            Assert.IsTrue(found);
            Assert.AreEqual(5, value);
        }

        [TestMethod]
        public void FindElement_ShouldReturnFalseForNonExistingValue()
        {
            var (found, _) = _linkedList.FindElement(10);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void DeleteElement_ShouldDeleteExistingElement()
        {
            _linkedList.InsertAtBeginning(3);

            var deletionResult = _linkedList.DeleteElement(3);
            Assert.IsTrue(deletionResult);

            var (found, _) = _linkedList.FindElement(3);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void DeleteElement_ShouldReturnFalseForNonExistingValue()
        {
            var deletionResult = _linkedList.DeleteElement(20);
            Assert.IsFalse(deletionResult);
        }
    }
}