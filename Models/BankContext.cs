using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BankContext : DbContext
    {
        public DbSet<BankBranches> BankBranches { get; set; }

        public BankContext(DbContextOptions<BankContext> options) : base(options) { 
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Employee>().HasIndex(r => r.CivilID).IsUnique();
            modelBuilder.Entity<BankBranches>().Property(r => r.LocationName).IsRequired();


            // modelBuilder.Entity<BankBranches>().ToTable("MyBranches");           *************************
            // modelBuilder.Entity<BankBranches>().HasKey(r => r.Branchmanger);
            // modelBuilder.Entity<BankBranches>().Property(r => r.LocationName).HasDefaultValue(1);
            // modelBuilder.Entity<BankBranches>().Property(r => r.Email).HasMaxLenght(50);
            // modelBuilder.Entity<BankBranches>().Property(r => r.Salary).HasPrecisiom(18,3);
            // required for the database and the form is over the model to view in the code  >     
            // modelBuilder.Entity<BankBranches>().Property(r => r.Email).Required();


        }
    }

}
