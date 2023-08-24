using CoolShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace CoolShop.DAL
{
    public class CoolShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Curse> Curses { get; set; }

        public CoolShopContext(/*DbContextOptions dbContextOptions*/)
            //: base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q2BKQOF\\SQLEXPRESS;Initial Catalog=CoolShop;Integrated Security=True;TrustServerCertificate=True")
                .LogTo(Console.WriteLine)
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
            //    .HasOne(c => c.Company)
            //    .WithMany(comp => comp.Customers);

            //modelBuilder.Entity<Company>().HasMany(comp => comp.Customers).WithOne(cust => cust.Company);

            base.OnModelCreating(modelBuilder);
        }
    }
}