namespace Loan.Services.DTOs
{
    public class ApplicableLoans
    {
        public string Customer { get; set; } = string.Empty;
        public List<LoanInfo> Loans { get; set; } = null!;
    }
}
