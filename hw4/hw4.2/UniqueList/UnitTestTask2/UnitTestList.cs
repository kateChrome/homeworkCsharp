using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace UnitTestTask2
{
    [TestClass]
    public class UnitTestList
    {
        public void AddTestHelper<T>()
        {
            var list = new List<T>();
            list.Add(default);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        public void DoubleAddTestHelper<T>()
        {
            var list = new List<T>();
            list.Add(default);
            list.Add(default);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void DoubleAddTest()
        {
            DoubleAddTestHelper<GenericParameterHelper>();
        }

        public void ClearTestHelper<T>()
        {
            var list = new List<T>();
            list.Add(default);
            list.Add(default);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        public void DoubleClearTestHelper<T>()
        {
            var list = new List<T>();
            list.Add(default);
            list.Add(default);
            list.Clear();
            list.Add(default);
            list.Add(default);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DoubleClearTest()
        {
            DoubleClearTestHelper<GenericParameterHelper>();
        }

        public void ExistsTestHelper<T>(T item)
        {
            var list = new List<T>();
            list.Add(item);
            Assert.IsTrue(list.Exists(item));
        }

        [TestMethod]
        public void ExistsTest()
        {
            ExistsTestHelper<int>(1);
            ExistsTestHelper<double>(1.0);
            ExistsTestHelper<char>('a');
            ExistsTestHelper<string>("a");
        }

        public void FindIndexTestHelper<T>(int index, T item, T aggregate)
        {
            var list = new List<T>();
            for (var i = 0; i < index; i++)
            {
                list.Add(aggregate);
            }
            list.Add(item);
            Assert.AreEqual(index, list.FindIndex(item));
        }

        [TestMethod]
        public void FindIndexTest()
        {
            FindIndexTestHelper<int>(2, 1, 90);
            FindIndexTestHelper<double>(3, 1.0, 90.0);
            FindIndexTestHelper<char>(4, '1', '9');
            FindIndexTestHelper<string>(5, "1", "90");
        }

        public void FindIndexDoesNotAddTestHelper<T>()
        {
            var list = new List<T>();
            Assert.AreEqual(-1, list.FindIndex(default));
        }

        [TestMethod]
        public void FindIndexDoesNotAddTest()
        {
            FindIndexDoesNotAddTestHelper<GenericParameterHelper>();
        }

        public void InsertTestHelper<T>(int index, T item, T aggregate)
        {
            var list = new List<T>();
            for (var i = 0; i < index * 10; i++)
            {
                list.Add(aggregate);
            }
            list.Insert(index, item);
            Assert.AreEqual(index, list.FindIndex(item));
        }

        [TestMethod]
        public void InsertTest()
        {
            InsertTestHelper<int>(2, 1, 90);
            InsertTestHelper<double>(3, 1.0, 90.0);
            InsertTestHelper<char>(4, '1', '9');
            InsertTestHelper<string>(5, "1", "90");
        }

        public void InsertOutOfRangePlusTestHelper<T>(int size, T item, T aggregate)
        {
            var list = new List<T>();
            for (var i = 0; i < size; i++)
            {
                list.Add(aggregate);
            }
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(size * 10, item));
        }

        [TestMethod]
        public void InsertOutOfRangePlusTest()
        {
            InsertOutOfRangePlusTestHelper<int>(2, 1, 90);
            InsertOutOfRangePlusTestHelper<double>(3, 1.0, 90.0);
            InsertOutOfRangePlusTestHelper<char>(4, '1', '9');
            InsertOutOfRangePlusTestHelper<string>(5, "1", "90");
        }

        public void InsertOutOfRangeMinusTestHelper<T>(int size, T item, T aggregate)
        {
            var list = new List<T>();
            for (var i = 0; i < size; i++)
            {
                list.Add(aggregate);
            }
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(size * -10, item));
        }

        [TestMethod]
        public void InsertOutOfRangeMinusTest()
        {
            InsertOutOfRangePlusTestHelper<int>(2, 1, 90);
            InsertOutOfRangePlusTestHelper<double>(3, 1.0, 90.0);
            InsertOutOfRangePlusTestHelper<char>(4, '1', '9');
            InsertOutOfRangePlusTestHelper<string>(5, "1", "90");
        }

        public void RemoveTestHelper<T>(T item, int index, int size, T aggregate)
        {
            var list = new List<T>();
            for (var i = 0; i < size; i++)
            {
                list.Add(aggregate);
            }
            list.Insert(index, item);

            list.Remove(item);
            Assert.AreEqual(-1, list.FindIndex(item));
        }

        [TestMethod]
        public void RemoveTest()
        {
            RemoveTestHelper<int>(1, 3,10,90);
            RemoveTestHelper<double>(1.0, 5,11,90.0);
            RemoveTestHelper<char>('1', 7,12,'9');
            RemoveTestHelper<string>("1", 10,13,"90");
        }

        public void RemoveAtTestHelper<T>(T item, int index, int size, T aggregate)
        {
            var list = new List<T>();
            for (var i = 0; i < index; i++)
            {
                list.Add(aggregate);
            }
            list.Add(item);
            for (var i = index + 1; i < size; i++)
            {
                list.Add(aggregate);
            }

            list.RemoveAt(index);
            Assert.AreEqual(-1, list.FindIndex(item));
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            RemoveAtTestHelper<int>(1, 3, 10, 90);
            RemoveAtTestHelper<double>(1.0, 5, 11, 90.0);
            RemoveAtTestHelper<char>('1', 7, 12, '9');
            RemoveAtTestHelper<string>("1", 10, 13, "90");
        }
    }
}
