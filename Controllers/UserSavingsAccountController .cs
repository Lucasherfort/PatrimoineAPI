using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user-savings-accounts")]
public class UserSavingsAccountController : ControllerBase
{
    private readonly UserSavingsAccountService _service;

    public UserSavingsAccountController(UserSavingsAccountService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserSavingsAccountRequest request)
    {
        var result = await _service.CreateAsync(
            request.UserId,
            request.SavingsAccountId,
            request.InitialBalance
        );

        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var accounts = await _service.GetByUserIdAsync(userId);
        return Ok(accounts);
    }
}