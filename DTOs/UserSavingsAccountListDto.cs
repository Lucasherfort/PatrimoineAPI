namespace PatrimoineAPI.DTOs
{
    public class UserSavingsAccountListDto
    {
        public int Id { get; set; } // UserSavingsAccount.Id
        public string BankName { get; set; } = "";
        public string AccountName { get; set; } = "";
        public decimal Balance { get; set; }
        public decimal InterestAccrued { get; set; }
    }
}
