using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PatrimoineAPI.Services;

namespace PatrimoineAPI.Controllers
{
    [ApiController]
    [Route("api/banks")]
    public class BankController : ControllerBase
    {
        private readonly BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                var banks = await _bankService.GetBanksAsync();
                return Ok(banks);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{bankId}/savingsAccounts")]
        public async Task<IActionResult> GetAvailableSavingsAccounts(int bankId)
        {
            var accounts = await _bankService.GetAccountsByBankId(bankId);
            return Ok(accounts);
        }
    }
}
