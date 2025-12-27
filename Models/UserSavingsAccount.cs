using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatrimoineAPI.Models
{
    [Table("UserSavingsAccounts")]
    public class UserSavingsAccount
    {
        [Key]
        public int Id { get; set; }

        [Column("Balance")]
        public decimal Balance { get; set; } = 0;

        [Column("InterestAccrued")]
        public decimal InterestAccrued { get; set; } = 0;

        // ======================
        // Clé étrangère vers SavingsAccount
        // ======================
        [ForeignKey("SavingsAccount")]      // Nom de la navigation property
        public int SavingsAccountId { get; set; }

        // Navigation property
        public SavingsAccount SavingsAccount { get; set; } = null!;

        // ======================
        // Clé étrangère vers User
        // ======================
        [ForeignKey("User")]      // Nom de la navigation property
        public int UserId { get; set; }

        // Navigation property
        public User User { get; set; } = null!;
    }
}
