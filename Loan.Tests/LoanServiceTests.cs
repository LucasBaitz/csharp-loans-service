using Loan.Domain.Entities;
using Loan.Services.Services;

namespace Loan.Services.Tests
{
    [TestFixture]
    public class LoanServiceTests
    {
        [Test]
        public void EvaluatePossibleLoans_ReturnsCorrectLoans_ForIncomeBelow3000()
        {
            // Arrange
            var loanRequest = new LoanRequest
            {
                Name = "John",
                Income = 2500,
                Location = "SP",
                Age = 25
            };
            var loanService = new LoanService();

            // Act
            var result = loanService.EvaluatePossibleLoans(loanRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.Customer);
            Assert.IsTrue(result.Loans.Count == 2);
            Assert.IsTrue(result.Loans.Exists(loan => loan.Type == "Personal"));
            Assert.IsTrue(result.Loans.Exists(loan => loan.Type == "Guaranteed"));
        }

        [Test]
        public void EvaluatePossibleLoans_ReturnsCorrectLoans_ForIncomeBetween3000And5000AndLocationSP()
        {
            // Arrange
            var loanRequest = new LoanRequest
            {
                Name = "Alice",
                Income = 4000,
                Location = "SP",
                Age = 30
            };
            var loanService = new LoanService();

            // Act
            var result = loanService.EvaluatePossibleLoans(loanRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Alice", result.Customer);
            Assert.IsTrue(result.Loans.Count == 1);
            Assert.IsTrue(result.Loans.Exists(loan => loan.Type == "Consignment"));
        }

        [Test]
        public void EvaluatePossibleLoans_ReturnsCorrectLoans_ForIncomeAbove5000()
        {
            // Arrange
            var loanRequest = new LoanRequest
            {
                Name = "Bob",
                Income = 6000,
                Location = "NY",
                Age = 35
            };
            var loanService = new LoanService();

            // Act
            var result = loanService.EvaluatePossibleLoans(loanRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Bob", result.Customer);
            Assert.IsTrue(result.Loans.Count == 0);
        }
    }
}
