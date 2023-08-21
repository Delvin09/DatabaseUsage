//using CoolShop.DAL;
//using CoolShop.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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