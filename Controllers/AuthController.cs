using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatrimoineAPI.DTOs;
using PatrimoineAPI.Services;
using WebApplicationPatrimoine.Data;

namespace PatrimoineAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly PasswordService _passwordService;

        public AuthController(AppDbContext db, PasswordService passwordService)
        {
            _db = db;
            _passwordService = passwordService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
                return Unauthorized(new LoginResponse
                {
                    Success = false,
                    Message = "Utilisateur introuvable",
                    UserId = null
                });

            if (!_passwordService.Verify(user.PasswordHash, request.Password))
                return Unauthorized(new LoginResponse
                {
                    Success = false,
                    Message = "Mot de passe incorrect",
                    UserId = null
                });

            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Connexion réussie",
                UserId = user.Id.ToString() // Renvoyer l'ID de l'utilisateur
            });
        }
    }
}
