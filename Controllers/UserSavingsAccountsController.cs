using Microsoft.AspNetCore.Mvc;
using PatrimoineAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UserSavingsAccountsController : ControllerBase
{
    private readonly IUserSavingsAccountService _service;

    public UserSavingsAccountsController(IUserSavingsAccountService service)
    {
        _service = service;
    }

    /// <summary>
    /// GET: api/usersavingsaccounts/user/{userId}
    /// Récupère tous les comptes d'épargne d'un utilisateur (page principale)
    /// </summary>
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<UserSavingsAccountListDto>>> GetUserSavingsAccounts(int userId)
    {
        var accounts = await _service.GetUserSavingsAccountsAsync(userId);
        return Ok(accounts);
    }

    /// <summary>
    /// GET: api/usersavingsaccounts/{id}
    /// Récupère les détails complets d'un compte d'épargne (page détail)
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserSavingsAccountDetailDto>> GetUserSavingsAccountDetail(int id)
    {
        var account = await _service.GetUserSavingsAccountDetailAsync(id);

        if (account == null)
            return NotFound($"Compte d'épargne avec l'ID {id} introuvable.");

        return Ok(account);
    }

    /// <summary>
    /// PUT: api/usersavingsaccounts/{id}
    /// Met à jour le balance et l'intérêt accumulé (panel éditable)
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserSavingsAccount(int id, UpdateUserSavingsAccountDto dto)
    {
        var success = await _service.UpdateUserSavingsAccountAsync(id, dto);

        if (!success)
            return NotFound($"Compte d'épargne avec l'ID {id} introuvable.");

        return NoContent();
    }

    /// <summary>
    /// POST: api/usersavingsaccounts
    /// Crée un nouveau compte d'épargne pour un utilisateur
    /// </summary>
    [HttpPost("create")]
    public async Task<ActionResult<UserSavingsAccountDetailDto>> CreateUserSavingsAccount(
        [FromBody] CreateUserSavingsAccountDto dto)
    {
        var created = await _service.CreateUserSavingsAccountAsync(dto);
        return CreatedAtAction(nameof(GetUserSavingsAccountDetail), new { id = created.Id }, created);
    }

    /// <summary>
    /// DELETE: api/usersavingsaccounts/{id}
    /// Supprime un compte d'épargne utilisateur
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserSavingsAccount(int id)
    {
        var success = await _service.DeleteUserSavingsAccountAsync(id);

        if (!success)
            return NotFound($"Compte d'épargne avec l'ID {id} introuvable.");

        return NoContent();
    }
}
