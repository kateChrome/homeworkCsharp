using System;
using System.Collections;
using NUnit.Framework;

namespace Queue
{
    public class Tests
    {

        private Queue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new Queue<int>(0, 0);
        }

        [Test]
        public void TestQueueAddOneElement()
        {
            queue.Enqueue(1, 1);
            Assert.AreEqual(queue.GetSize(), 2);
        }

        [Test]
        public void TestQueueAdd10Element()
        {
            for (int i = 0; i < 10; i ++)
            {
                queue.Enqueue(i, i);
            }
            Assert.AreEqual(queue.GetSize(), 11);
        }

        [Test]
        public void TestDoubleGetFromSetupQueue()
        {
            try
            {
                queue.Dequeue();
                queue.Dequeue();
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Queue is empty", exception.Message);
            }
        }

        [Test]
        public void TestEnqueueAndDequeueCheckValue()
        {
            int element = 10;
            queue.Enqueue(element, 19);
            Assert.AreEqual(element, queue.Dequeue());
        }

        


    }
}