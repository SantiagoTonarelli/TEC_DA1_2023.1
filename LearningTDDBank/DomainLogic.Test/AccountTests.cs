using DomainLogic;
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
        public void CreateAccountTest()
        {
            Console.WriteLine("TestMethod");
            //Arrange
            string userName = "Juan";
            string pass = "A123456";
            BankManager aBank = new BankManager();
            Account anAccount = new Account()
            {
                UserName = userName,
                Pass = pass,
            };

            //Act
            aBank.AddAccount(anAccount);

            //Assert
            Assert.AreEqual(1, aBank.Accounts.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Index was outside the bounds of the array6.")]
        public void MyTestMethod()
        {
            // Arrange
            int[] numbers = { 1, 2, 3 };

            // Act
            var number = numbers[3]; // This line will throw an IndexOutOfRangeException
        }
    }
}
