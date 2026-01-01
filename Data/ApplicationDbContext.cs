using Microsoft.EntityFrameworkCore;
using PatrimoineAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationPatrimoine.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Bank> Banks => Set<Bank>();
        public DbSet<SavingsAccount> SavingsAccounts => Set<SavingsAccount>();
        public DbSet<UserSavingsAccount> UserSavingsAccounts => Set<UserSavingsAccount>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== Seed User =====
            var hasher = new PasswordHasher<string>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = hasher.HashPassword(null!, "admin")
                }
            );


            // ===== Seed Banks =====
            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, Name = "BoursoBank" }
            );

            // ===== Seed SavingsAccounts =====
            modelBuilder.Entity<SavingsAccount>().HasData(
                new SavingsAccount { Id = 1, Name = "Livret A", InterestRate = 0.024M, Cap = 22950, BankId = 1 },
                new SavingsAccount { Id = 2, Name = "LDDS", InterestRate = 0.024M, Cap = 12000, BankId = 1 }
            );
        }
    }
}
