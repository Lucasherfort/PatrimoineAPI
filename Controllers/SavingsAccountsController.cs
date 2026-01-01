using Microsoft.AspNetCore.Mvc;
using PatrimoineAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SavingsAccountsController : ControllerBase
{
    private readonly ISavingsAccountService _service;

    public SavingsAccountsController(ISavingsAccountService service)
    {
        _service = service;
    }

    /// <summary>
    /// GET: api/savingsaccounts/bank/{bankId}
    /// Récupère la liste des comptes d'épargne d'une banque (panel création)
    /// </summary>
    [HttpGet("bank/{bankId}")]
    public async Task<ActionResult<IEnumerable<SavingsAccountOptionDto>>> GetSavingsAccountsByBank(int bankId)
    {
        var accounts = await _service.GetSavingsAccountsByBankAsync(bankId);
        return Ok(accounts);
    }
}