using Microsoft.EntityFrameworkCore;
using WebApplicationPatrimoine.Data;
using PatrimoineAPI.DTOs;

namespace PatrimoineAPI.Services
{
    public class PatrimoineService
    {
        private readonly ApplicationDbContext _db;

        public PatrimoineService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Méthode pour obtenir le patrimoine total d'un utilisateur
        public async Task<PatrimoineResponse> GetPatrimoineAsync(int userId)
        {
            var comptes = await _db.UserSavingsAccounts
                .Where(a => a.UserId == userId)
                .ToListAsync();

            if (comptes.Count == 0)
            {
                return new PatrimoineResponse
                {
                    Success = true,
                    Message = "Aucun compte trouvé",
                    TotalPatrimoine = 0
                };
            }

            decimal total = comptes.Sum(c => c.Balance);

            return new PatrimoineResponse
            {
                Success = true,
                Message = "Patrimoine calculé avec succès",
                TotalPatrimoine = total
            };
        }
    }
}
