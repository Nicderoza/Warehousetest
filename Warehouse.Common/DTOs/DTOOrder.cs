﻿namespace Warehouse.Common.DTOs
{
    public class DTOOrder
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }  
    }
}