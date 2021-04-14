using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngular.Models
{
    public class OrderItemList
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
