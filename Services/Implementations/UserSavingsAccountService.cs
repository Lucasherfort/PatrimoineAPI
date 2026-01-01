using Microsoft.EntityFrameworkCore;
using PatrimoineAPI.DTOs;
using PatrimoineAPI.Models;
using WebApplicationPatrimoine.Data;

public class UserSavingsAccountService : IUserSavingsAccountService
{
    private readonly ApplicationDbContext _db;

    public UserSavingsAccountService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<UserSavingsAccountListDto>> GetUserSavingsAccountsAsync(int userId)
    {
        return await _db.UserSavingsAccounts
            .Where(usa => usa.UserId == userId)
            .Select(usa => new UserSavingsAccountListDto
            {
                Id = usa.Id,
                BankName = usa.SavingsAccount.Bank.Name,
                AccountName = usa.SavingsAccount.Name,
                Balance = usa.Balance,
                InterestAccrued = usa.InterestAccrued
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<UserSavingsAccountDetailDto?> GetUserSavingsAccountDetailAsync(int id)
    {
        return await _db.UserSavingsAccounts
            .Where(usa => usa.Id == id)
            .Select(usa => new UserSavingsAccountDetailDto
            {
                Id = usa.Id,
                BankName = usa.SavingsAccount.Bank.Name,
                AccountName = usa.SavingsAccount.Name,
                InterestRate = usa.SavingsAccount.InterestRate,
                Cap = usa.SavingsAccount.Cap,
                Balance = usa.Balance,
                InterestAccrued = usa.InterestAccrued
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateUserSavingsAccountAsync(int id, UpdateUserSavingsAccountDto dto)
    {
        var account = await _db.UserSavingsAccounts.FindAsync(id);

        if (account == null)
            return false;

        account.Balance = dto.Balance;
        account.InterestAccrued = dto.InterestAccrued;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<UserSavingsAccountDetailDto> CreateUserSavingsAccountAsync(CreateUserSavingsAccountDto dto)
    {
        var userSavingsAccount = new UserSavingsAccount
        {
            UserId = dto.UserId,
            SavingsAccountId = dto.SavingsAccountId,
            Balance = dto.Balance,
            InterestAccrued = dto.InterestAccrued
        };

        _db.UserSavingsAccounts.Add(userSavingsAccount);
        await _db.SaveChangesAsync();

        return (await GetUserSavingsAccountDetailAsync(userSavingsAccount.Id))!;
    }

    public async Task<bool> DeleteUserSavingsAccountAsync(int id)
    {
        var account = await _db.UserSavingsAccounts.FindAsync(id);

        if (account == null)
            return false;

        _db.UserSavingsAccounts.Remove(account);
        await _db.SaveChangesAsync();
        return true;
    }
}

public class SavingsAccountService : ISavingsAccountService
{
    private readonly ApplicationDbContext _db;

    public SavingsAccountService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<SavingsAccountOptionDto>> GetSavingsAccountsByBankAsync(int bankId)
    {
        return await _db.SavingsAccounts
            .Where(sa => sa.BankId == bankId)
            .Select(sa => new SavingsAccountOptionDto
            {
                Id = sa.Id,
                Name = sa.Name,
                Cap = sa.Cap
            })
            .AsNoTracking()
            .ToListAsync();
    }
}