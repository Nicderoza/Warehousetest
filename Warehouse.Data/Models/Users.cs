using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Data.Models
{
    public class Users
    {
        public int IDUser { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Orders> Orders { get; set; }

    }
}

