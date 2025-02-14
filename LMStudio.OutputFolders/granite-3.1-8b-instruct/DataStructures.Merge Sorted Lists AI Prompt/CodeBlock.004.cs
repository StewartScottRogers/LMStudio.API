using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MergedListLibrary
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestMergeLists()
        {
            // Arrange
            var list1 = new MergedList();
            var list2 = new MergedList();
            
            list1.Add(new List<int> { 1, 3, 5 });
            list2.Add(new List<int> { 2, 4, 6 });

            var inputLists = new IMergedList<int>[] {list1, list2};

            // Act
            var result = MergeStrategy.MergeLists(inputLists);
            
            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6}, result.GetResult().ToList());
        }
    }
}