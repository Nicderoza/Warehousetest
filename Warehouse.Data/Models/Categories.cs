using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Data.Models
{
    public class Categories
    {
        public int IDCategory { get; set; }
        public string? CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}

