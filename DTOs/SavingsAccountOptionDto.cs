namespace PatrimoineAPI.DTOs
{
    // Panel création - Liste des comptes d'une banque
    public class SavingsAccountOptionDto
    {
        public int Id { get; set; } // SavingsAccount.Id
        public string Name { get; set; } = "";
        public int Cap { get; set; }
    }
}
