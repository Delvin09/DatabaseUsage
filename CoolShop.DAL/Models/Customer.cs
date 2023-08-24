using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShop.DAL.Models
{
    public class Person { }
    public class Student : Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Curse> Curses { get; set; }
    }

    public class Curse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Customer> Customers { get; set; }
    }

    [Table("Customers")]
    public class Customer : Person
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Region { get; set; }
        [MaxLength(100)]
        public string? PostalCode { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string? PhoneNumber { get; set; }

        public DateTime? BithDate { get; set; }

        public int Age { get; set; }

        public int CompanyId { get; set; }

        public virtual Company? Company { get; set; }

        public virtual List<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
