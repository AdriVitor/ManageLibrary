using ManageLibrary_Application.DTOs.Loan;
using ManageLibrary_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManageLibrary_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService) {
            _loanService = loanService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadLoanDTO>> GetLoanById([FromRoute] int id) {
            try {
                var customer = await _loanService.GetLoanById(id);
                return Ok(customer);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostLoan([FromBody] CreateLoanDTO createLoan) {
            try {
                await _loanService.AddLoan(createLoan);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutLoan([FromBody] CreateLoanDTO createLoan) {
            try {
                await _loanService.UpdateLoan(createLoan);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan([FromRoute] int id) {
            try {
                await _loanService.DeleteLoan(id);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
