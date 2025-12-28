using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatrimoineAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("Username")]
        public string Username { get; set; } = "";

        [Column("PasswordHash")]
        public string PasswordHash { get; set; } = "";
    }
}
