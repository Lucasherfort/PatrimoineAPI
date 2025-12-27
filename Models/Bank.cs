using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatrimoineAPI.Models
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; } = "";

        // Navigation inverse
        public ICollection<SavingsAccount> SavingsAccounts { get; set; } = new List<SavingsAccount>();
    }
}
