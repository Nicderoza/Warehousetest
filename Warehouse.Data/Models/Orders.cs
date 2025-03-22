using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }  // ✅ AGGIUNTO CAMPO QUANTITY
        public decimal Price { get; set; }

        public Users User { get; set; }
        public int ProductID { get; set; }
        public Products Product { get; set; }
    }
}
