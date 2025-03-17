namespace Warehouse.Data.Models;

public class Products
{
    public int IDProduct { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int? IDCategory { get; set; }
    public int? IDSupplier { get; set; }

    public Categories? Category { get; set; }
    public Suppliers? Supplier { get; set; }

    public ICollection<Orders> Orders { get; set; }
}

