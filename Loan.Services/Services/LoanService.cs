using Loan.Domain.Entities;
using Loan.Services.DTOs;
using Loan.Services.Interfaces;

namespace Loan.Services.Services
{
    public class LoanService : ILoanService
    {
        public ApplicableLoans EvaluatePossibleLoans(LoanRequest loanRequest)
        {
            var customerLoans = new ApplicableLoans()
            {
                Customer = loanRequest.Name,
                Loans = new List<LoanInfo>()
            };

            EvaluatePersonalLoan(customerLoans, loanRequest);
            EvaluateConsignmentLoan(customerLoans, loanRequest);
            EvaluateGuaranteedLoan(customerLoans, loanRequest);

            return customerLoans;
        }

        public void EvaluatePersonalLoan(ApplicableLoans customerLoans, LoanRequest loanRequest)
        {
            if (loanRequest.Income <= 3000)
            {
                customerLoans.Loans.Add(new LoanInfo { Type = LoanType.Personal.ToString(), InterestRate = (int)LoanType.Personal });
            }
        }

        public void EvaluateConsignmentLoan(ApplicableLoans customerLoans, LoanRequest loanRequest)
        {
            if (loanRequest.Income >= 3000 && loanRequest.Income <= 5000 && loanRequest.Location == "SP")
            {
                customerLoans.Loans.Add(new LoanInfo { Type = LoanType.Consignment.ToString(), InterestRate = (int)LoanType.Consignment });
            }
        }

        public void EvaluateGuaranteedLoan(ApplicableLoans customerLoans, LoanRequest loanRequest)
        {
            if (loanRequest.Income <= 3000 || (loanRequest.Income >= 3000 && loanRequest.Income <= 5000 && loanRequest.Age < 30 && loanRequest.Location == "SP"))
            {
                customerLoans.Loans.Add(new LoanInfo { Type = LoanType.Guaranteed.ToString(), InterestRate = (int)LoanType.Guaranteed });
            }
        }
    }
}
