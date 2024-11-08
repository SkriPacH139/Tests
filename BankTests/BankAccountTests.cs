using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]  
        public void Credit_WhenAmountIsPositive_ShouldIncreaseBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            double expectedBalance = beginningBalance + creditAmount;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, 0.001, "Account balance was not credited correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WhenAmountIsNegative_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert is handled by ExpectedException
        }


    }
}
