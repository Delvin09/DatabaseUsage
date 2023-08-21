using CoolShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolShop.DAL
{
    public class CoolShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CoolShopContext(/*DbContextOptions dbContextOptions*/)
            //: base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q2BKQOF\\SQLEXPRESS;Initial Catalog=CoolShop;Integrated Security=True;TrustServerCertificate=True")
                .LogTo(Console.WriteLine);

            base.OnConfiguring(optionsBuilder);
        }
    }
}