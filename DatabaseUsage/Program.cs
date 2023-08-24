//using CoolShop.DAL;
//using CoolShop.DAL.Models;
using CoolShop.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //AdoNetUsage();

        //var configBuilder = new ConfigurationBuilder();
        //configBuilder.SetBasePath(Directory.GetCurrentDirectory());
        //configBuilder.AddJsonFile("appsettings.json");

        //var config = configBuilder.Build();

        //var optBuilder = new DbContextOptionsBuilder<CoolShopContext>();
        //optBuilder.UseSqlServer(config.GetConnectionString("Default"))
        //    .LogTo(Console.WriteLine);

        //using var context = new CoolShopContext(optBuilder.Options);

        ////context.Database.EnsureDeleted();
        ////context.Database.EnsureCreated();

        //var customers = context.Customers.ToList();

        ////var customer = new Customer
        ////{
        ////    Name = "Bob",
        ////    Address = "1, Hakivska st.",
        ////    City = "Kiev",
        ////    Country = "Ukraine",
        ////    PhoneNumber = "1234567890",
        ////    PostalCode = "1234567890",
        ////    Region = "Kievska oblast"
        ////};

        ////context.Customers.Add(customerFromOtherContext);
        //context.SaveChanges();


        using var context = new CoolShopContext();

        //context.Customers.Add(new CoolShop.DAL.Models.Customer {
        //    Name = "Name_Test",
        //    City = "City_Test",
        //    Address = "Add_Test",
        //    Region = "Region_test",
        //    Country = "COuntry_test",
        //    Company = new CoolShop.DAL.Models.Company { Name = "Comp_Test" },
        //});

        var comp = context.Companies
            .Include(comp => comp.Customers)
                .ThenInclude(cust => cust.Orders)
            .First();

        foreach (var customer in comp.Customers)
        {
            var oreders = customer.Orders;
            foreach (var oreder in oreders)
                Console.WriteLine(oreder.Name);
        }

        var q =
            from c in context.Customers
                where c.Age > 18
            select c.Name;

        var cust = context.Customers
            .Where(c => c.Age > 18)
            .Select(c => c.Name)
            .ToList();

        //SELECT NAME FROM CUSTOMERS WHERE Customers.Age > 18
        //var customers = context.Customers.ToArray();

        //foreach (var cust in customers)
        //{
        //    cust.Orders.Add(new CoolShop.DAL.Models.Order
        //    {
        //        Name = cust.Name + "_Oreder2",
        //    });
        //}


        //var comp = context.Companies.Where(c => c.Id == 2);
        //comp.Load();
        //var c = comp.First();
        //var company = context.Companies
        //    .Include(c => c.Customers)
        //    .First();
        //var customer = context.Customers.First();

        context.SaveChanges();
    }

    private static void AdoNetUsage()
    {
        var customers = new List<Customer_Ado>();
        using var connection = new SqlConnection("Data Source=DESKTOP-Q2BKQOF\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;TrustServerCertificate=True");

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM [dbo].[Custumers]";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var customer = new Customer_Ado();
            customer.Id = reader.GetInt32(reader.GetOrdinal("ID"));

            customer.Name = reader.GetString(reader.GetOrdinal("Name"));

            customer.Age = reader.GetInt32(reader.GetOrdinal("Age"));
            customer.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));

            customers.Add(customer);
        }

        foreach (var customer in customers)
            Console.WriteLine(customer);
    }
}