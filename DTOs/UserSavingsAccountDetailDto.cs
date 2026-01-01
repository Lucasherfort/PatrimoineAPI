namespace PatrimoineAPI.DTOs
{
    // Page détail - Informations complètes
    public class UserSavingsAccountDetailDto
    {
        public int Id { get; set; } // UserSavingsAccount.Id
        public string BankName { get; set; } = "";
        public string AccountName { get; set; } = "";
        public decimal InterestRate { get; set; }
        public int Cap { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestAccrued { get; set; }
    }
}
