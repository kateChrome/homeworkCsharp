using NUnit.Framework;

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
            uniqueList.AddData(1);
            Assert.Throws<ElementAlreadyExistException>(() => uniqueList.AddData(1));
        }

        [Test]
        public void RemoveNotAddedElementTest()
        {
            Assert.Throws<ElementDoesNotExistException>(() => uniqueList.RemoveData(1));        
        }

        [Test]
        public void GetSizeOfListTest()
        {
            uniqueList.AddData(1);
            Assert.AreEqual(1, uniqueList.GetSizeOfList());
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(uniqueList.IsEmpty());
        }

        [Test]
        public void InsertDataByOutOfRangeIndexTest()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uniqueList.InsertData(10, 1));
        }

        [Test]
        public void RemoveElementByDoesNotExistIndexTest()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uniqueList.RemoveDataByIndex(1));
        }

    }
}