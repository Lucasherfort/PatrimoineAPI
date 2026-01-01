using PatrimoineAPI.DTOs;

public interface IUserSavingsAccountService
{
    Task<IEnumerable<UserSavingsAccountListDto>> GetUserSavingsAccountsAsync(int userId);
    Task<UserSavingsAccountDetailDto?> GetUserSavingsAccountDetailAsync(int id);
    Task<bool> UpdateUserSavingsAccountAsync(int id, UpdateUserSavingsAccountDto dto);
    Task<UserSavingsAccountDetailDto> CreateUserSavingsAccountAsync(CreateUserSavingsAccountDto dto);
    Task<bool> DeleteUserSavingsAccountAsync(int id);
}

public interface ISavingsAccountService
{
    Task<IEnumerable<SavingsAccountOptionDto>> GetSavingsAccountsByBankAsync(int bankId);
}
