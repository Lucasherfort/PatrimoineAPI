public class CreateUserSavingsAccountDto
{
    public int UserId { get; set; }
    public int SavingsAccountId { get; set; }
    public decimal Balance { get; set; } = 0;
    public decimal InterestAccrued { get; set; } = 0;
}
