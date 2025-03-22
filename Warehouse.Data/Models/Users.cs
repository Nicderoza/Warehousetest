using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Data.Models
{
    public class Users 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Indica che UserID è auto-incrementale
        public int UserID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
