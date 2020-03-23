using NUnit.Framework;
using System; 
using System.Collections.Generic; 

namespace UniqueList
{

    public class UniqueListTests
    {
        private UniqueList<int> uniqueList;

        [SetUp]
        public void Setup()
        {
            uniqueList = new UniqueList<int>();
        }

        [Test]
        public void DoubleAddElementTest()
        {
            uniqueList.Add(1);
            Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Add(1));
        }

        [Test]
        public void RemoveNotAddedElementTest()
        {
            Assert.Throws<ElementDoesNotExistException>(() => uniqueList.Remove(1));
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(uniqueList.IsEmpty());
        }

        [Test]
        public void InsertDataByOutOfRangeIndexTest()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uniqueList.Insert(10, 1));
        }

        [Test]
        public void RemoveElementByDoesNotExistIndexTest()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uniqueList.RemoveDataByIndex(1));
        }
    }
}