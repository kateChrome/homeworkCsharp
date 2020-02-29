using System;
using NUnit.Framework;

namespace HwTwoDotThree.Tests
{
    public class ArrayStackTest
    {
        private ArrayStack stack;

        [SetUp]
        public void Setup()
        {
            stack = new ArrayStack();
        }

        [Test]
        public void TestEmptyStackOnEmptiness()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void TestUnemptyStackOnUnemptiness()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void TestEmptyStackOnEmptinessAfterPushAndPop()
        {
            stack.Push(1);
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void TestDoublePush()
        {
            stack.Push(1);
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void TestPopWithoutPush()
        {
            try
            {
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "stack is empty now");
            }
        }

        [Test]
        public void TestDoublePopAfterOnePop()
        {
            try
            {
                stack.Push(1);
                stack.Pop();
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "stack is empty now");
            }
        }
    }
}