using Microsoft.EntityFrameworkCore;
using PatrimoineAPI.DTOs;
using PatrimoineAPI.Models;
using WebApplicationPatrimoine.Data;

public class UserSavingsAccountService
{
    private readonly AppDbContext _db;

    public UserSavingsAccountService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UserSavingsAccount> CreateAsync(
        int userId,
        int savingsAccountId,
        decimal initialBalance)
    {
        var account = new UserSavingsAccount
        {
            UserId = userId,
            SavingsAccountId = savingsAccountId,
            Balance = initialBalance,
            //CreatedAt = DateTime.UtcNow
        };

        _db.UserSavingsAccounts.Add(account);
        await _db.SaveChangesAsync();

        return account;
    }
    public async Task<List<UserSavingsAccountDto>> GetByUserIdAsync(int userId)
    {
        return await _db.UserSavingsAccounts
            .Where(usa => usa.UserId == userId)
            .Select(usa => new UserSavingsAccountDto
            {
                BankName = usa.SavingsAccount.Bank.Name,
                AccountName = usa.SavingsAccount.Name,
                Balance = usa.Balance,
                InterestAccrued = usa.InterestAccrued
            })
            .AsNoTracking()
            .ToListAsync();
    }
}
