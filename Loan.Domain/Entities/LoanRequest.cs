namespace Loan.Domain.Entities
{
    public class LoanRequest
    {
        public int Age { get; set; }
        public string Document { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Income { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
