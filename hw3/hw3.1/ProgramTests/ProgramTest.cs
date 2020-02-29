using System;
using System.IO;
using System.Diagnostics;
using NUnit.Framework;

namespace HwTwoDotThree.Tests
{
    public class ProgramTest
    {
        [Test]
        public void TwoPlusTwoTest()
        {
            string[] args = { "0", "1 1 +" };

            double result = Program.Main(args);

            Assert.AreEqual(result, 2);
        }
    }
}