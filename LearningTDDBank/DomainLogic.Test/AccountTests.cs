using Logic;
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
            aBank.addAccount(anAccount);

            //Assert
            Assert.AreEqual(1, aBank.Accounts.Count);
        }
    }
}
