using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Models
{
    public class Categories
    {
        [Key]  // Indica che CategoryID è la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Autoincremento
        public int CategoryID { get; set; }

        public string? CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
