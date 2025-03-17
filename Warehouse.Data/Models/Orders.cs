namespace Warehouse.Data.Models
{
    public class Orders
    {
        public int IDOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int? IDClient { get; set; }
        public int? IDCourier { get; set; }
        public string Status { get; set; }

        public Users? Client { get; set; }  // Assuming Client is a navigation property
        public int IdUser { get; set; }
        public Users User { get; set; }  // Navigation property to Users

        public int IdProduct { get; set; }
        public Products Product { get; set; }  // Navigation property to Products
    }
}
