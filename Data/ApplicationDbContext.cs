using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Lazy loading pode prejudicar o desempenho do sistema
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50);

            modelBuilder.Entity<Solicitation>().HasKey(p => p.Number);

            modelBuilder.Entity<Solicitation>().Property(p => p.Date).HasDefaultValueSql("getdate()");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Solicitation> Solicitations { get; set; }
    }
}