using Loan.Domain.Entities;
using Loan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loan.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [Route("Customer-loans")]
        public IActionResult CustomerLoans([FromBody] LoanRequest loanRequest)
        {
            var possibleLoans = _loanService.EvaluatePossibleLoans(loanRequest);

            return Ok(possibleLoans);
        }
    }
}
