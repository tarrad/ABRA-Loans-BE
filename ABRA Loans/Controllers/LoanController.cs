using ABRA_Loans.Models;
using ABRA_Loans.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABRA_Loans.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
       
        private readonly LoanCalculationService _loanCalculationService;
        public LoanController(LoanCalculationService loanCalculationService)
        {
            _loanCalculationService = loanCalculationService;
        }

        [HttpPost(Name = "CalculateLoanRequest")]
        public ActionResult<LoanResponse> CalculateLoanRequest(LoanRequest request)
        {

            try
            {
                // Perform the loan calculation
                var response =  _loanCalculationService.CalculateTotalAmountForLoan(request);

                // Return the calculated value with a 200 OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // If something goes wrong, return a 500 Internal Server Error
                return StatusCode(500, "שגיאה בחישוב ההלואה");
            }

            
        }
    }
}
