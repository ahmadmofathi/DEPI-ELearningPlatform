using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_LearningPlatform.Context
{
    public class AccountDbContext : IdentityDbContext<Account>
    {
        public AccountDbContext() { }

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

       


    }
}