using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShop.DAL.Models
{
    public class Customer
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
    }
}
