using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace UnitTestTask2
{
    [TestClass]
    public class UnitTestUniqueList
    {
        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistException))]
        public void AddOnlyUniqueItemsTest()
        {
            var list = new UniqueList<string>();
            list.Add("1");
            list.Add("1");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistException))]
        public void AddUniqueItemsTest()
        {
            var list = new UniqueList<string>();
            list.Add("1");
            list.Add("2");
            list.Add("1");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistException))]
        public void InsertOnlyUniqueItemsTest()
        {
            var list = new UniqueList<string>();
            list.Insert(0, "1");
            list.Insert(1, "1");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistException))]
        public void InsertUniqueItemsTest()
        {
            var list = new UniqueList<string>();
            list.Insert(0, "1");
            list.Insert(0, "2");
            list.Insert(0, "1");
        }
    }
}
