using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Test2;
using System.Collections.Generic;

namespace GameTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreatePayloadCount()
        {
            Assert.AreEqual(100, new MainFrom(10).CreatePayload().Count);
        }
    }
}