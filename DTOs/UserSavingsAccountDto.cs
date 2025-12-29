namespace PatrimoineAPI.DTOs
{
    public class UserSavingsAccountDto
    {
        public string BankName { get; set; } = "";
        public string AccountName { get; set; } = "";
        public decimal Balance { get; set; }
        public decimal InterestAccrued { get; set; }
    }
}
