using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatrimoineAPI.Models
{
    [Table("SavingsAccounts")]
    public class SavingsAccount
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; } = "";

        [Column("InterestRate")]
        public decimal InterestRate { get; set; } = 0;

        [Column("Cap")]
        public int Cap { get; set; } = 0;

        // ======================
        // Clé étrangère vers Bank
        // ======================
        [ForeignKey("Bank")]      // Nom de la navigation property
        public int BankId { get; set; }

        // Navigation property
        public Bank Bank { get; set; } = null!;
    }
}
