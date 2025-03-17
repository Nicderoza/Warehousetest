namespace Warehouse.Data.Models
{
    public class Cities
    {
        public int IDCity { get; set; }
        public string Name { get; set; }

        public ICollection<Suppliers> Suppliers { get; set; }
    }
}

