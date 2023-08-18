using Microsoft.Data.SqlClient;

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public DateTime CreationDate { get; set; }

    public override string ToString()
    {
        return $"{Id}, Name: {Name}, Age: {Age}, Create: {CreationDate}";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var customers = new List<Customer>();

        using var connection = new SqlConnection("Data Source=DESKTOP-Q2BKQOF\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;TrustServerCertificate=True");

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM [dbo].[Custumers]";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var customer = new Customer();
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