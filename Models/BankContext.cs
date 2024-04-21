using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BankContext: DbContext
    {
        public DbSet<BankBranches> BankBranches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source= bank.db");     
    }
    }
