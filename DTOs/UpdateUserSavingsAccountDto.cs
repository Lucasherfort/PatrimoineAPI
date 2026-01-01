namespace PatrimoineAPI.DTOs
{
    // Pour la mise à jour
    public class UpdateUserSavingsAccountDto
    {
        public decimal Balance { get; set; }
        public decimal InterestAccrued { get; set; }
    }
}
