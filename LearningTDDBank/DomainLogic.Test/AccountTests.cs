using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainLogic.Test
{
    [TestClass]
    public class AccountTests
    {
        private int Balance { get; set; }

        [TestInitialize] 
        public void Init() {
            Balance = 0;
            Console.WriteLine("TestInitialize");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Balance = 0;
            Console.WriteLine("TestCleanup");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("TestMethod");

        }
    }
}
