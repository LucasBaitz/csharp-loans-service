using Loan.Domain.Entities;
using Loan.Services.DTOs;

namespace Loan.Services.Interfaces
{
    public interface ILoanService
    {
        ApplicableLoans EvaluatePossibleLoans(LoanRequest loanRequest);
        void EvaluatePersonalLoan(ApplicableLoans customerLoans, LoanRequest loanRequest);
        void EvaluateConsignmentLoan(ApplicableLoans customerLoans, LoanRequest loanRequest);
        void EvaluateGuaranteedLoan(ApplicableLoans customerLoans, LoanRequest loanRequest);
    }
}
