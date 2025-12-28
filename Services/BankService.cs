using WebApplicationPatrimoine.Data;
using PatrimoineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PatrimoineAPI.Services
{
    public class BankService
    {
        private readonly AppDbContext _db;

        public BankService(AppDbContext db)
        {
            _db = db;
        }

        // Récupérer toutes les banques
        public async Task<List<Bank>> GetBanksAsync()
        {
            return await _db.Banks.ToListAsync();
        }

        // Récupérer les comptes d'une banque
        public async Task<List<SavingsAccount>> GetAccountsByBankId(int bankId)
        {
            return await _db.SavingsAccounts
                .Where(sa => sa.BankId == bankId)
                .ToListAsync();
        }
    }
}
