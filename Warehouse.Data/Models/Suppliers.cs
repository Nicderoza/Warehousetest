using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Data.Models;

public class Suppliers
{

    public int IDSupplier { get; set; }
    public string Name { get; set; }
    public int IDCity { get; set; }
    public Cities City { get; set; }

    public ICollection<Products> Products { get; set; }
}
