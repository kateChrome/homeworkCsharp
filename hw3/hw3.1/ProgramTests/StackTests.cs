using System;
using NUnit.Framework;

namespace Program.Services.Tests
{
    [TestFixture]
    public class StackTests
    {
        static object[] PushArrayStackCases =
        {
                new object[] { new ArrayStack(), 0 },
                new object[] { new ArrayStack(), -1 },
                new object[] { new ArrayStack(), 1 }
        };

        static object[] PushListStackCases =
        {
                new object[] { new ListStack(), 0 },
                new object[] { new ListStack(), -1 },
                new object[] { new ListStack(), 1 }
        };

        [TestCaseSource(nameof(PushArrayStackCases))]
        [TestCaseSource(nameof(PushListStackCases))]
        public void PushPushValueTest(IStack stack, int value)
        {
            stack.Push(value);
            Assert.IsFalse(stack.IsEmpty());
        }

        static object[] PopArrayStackCases =
        {
                new object[] { new ListStack() }
        };

        static object[] PopListStackCases =
        {
                new object[] { new ListStack() }
        };

        [TestCaseSource(nameof(PopListStackCases))]
        [TestCaseSource(nameof(PopArrayStackCases))]
        public void PopPopEmptyStackTest(IStack stack)
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

        static object[] PushAndPopArrayStackCases =
        {
                new object[] { new ListStack(), -1 },
                new object[] { new ListStack(), 0 },
                new object[] { new ListStack(), 1 }
        };

        static object[] PushAndPopListStackCases =
        {
                new object[] { new ListStack(), -1 },
                new object[] { new ListStack(), 0 },
                new object[] { new ListStack(), 1 }
        };

        [TestCaseSource(nameof(PushAndPopArrayStackCases))]
        [TestCaseSource(nameof(PushAndPopListStackCases))]
        public void PopPopAfterPushTest(IStack stack, int value)
        {
            try
            {
                stack.Push(value);
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "stack is empty now");
            }
        }

        [TestCaseSource(nameof(PushAndPopArrayStackCases))]
        [TestCaseSource(nameof(PushAndPopListStackCases))]
        public void PopDoublePopAfterPushTest(IStack stack, int value)
        {
            try
            {
                stack.Push(value);
                stack.Pop();
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "stack is empty now");
            }
        }

        [TestCaseSource(nameof(PushAndPopArrayStackCases))]
        [TestCaseSource(nameof(PushAndPopListStackCases))]
        public void PopPushAfterPopAfterPushTest(IStack stack, int value)
        {
            stack.Push(value);
            stack.Pop();
            stack.Push(value);
            double top = stack.Pop();
            Assert.AreEqual(value, top);
        }
    }
}
