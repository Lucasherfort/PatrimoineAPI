using Microsoft.EntityFrameworkCore;
using PatrimoineAPI.Models;

namespace WebApplicationPatrimoine.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Bank> Banks => Set<Bank>();
        public DbSet<SavingsAccount> SavingsAccounts => Set<SavingsAccount>();
        public DbSet<UserSavingsAccount> UserSavingsAccounts => Set<UserSavingsAccount>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== Seed Banks =====
            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, Name = "BoursoBank" },
                new Bank { Id = 2, Name = "BNP Paribas" }
            );

            // ===== Seed SavingsAccounts =====
            modelBuilder.Entity<SavingsAccount>().HasData(
                new SavingsAccount { Id = 1, Name = "Livret A", InterestRate = 0.024M, Cap = 22950, BankId = 1 },
                new SavingsAccount { Id = 2, Name = "LDDS", InterestRate = 0.024M, Cap = 12000, BankId = 1 },
                new SavingsAccount { Id = 3, Name = "PEL", InterestRate = 0.03M, Cap = 61200, BankId = 2 }
            );
        }
    }
}
