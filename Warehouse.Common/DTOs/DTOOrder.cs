namespace Warehouse.Common.DTOs
{
    public class DTOOrder
    {
        public int IDOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int? IDClient { get; set; }
        public int? IDCourier { get; set; }
        public string Status { get; set; }
        public int IdProduct { get; set; }
    }
}
