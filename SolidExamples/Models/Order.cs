using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Models {
    public class OrderItem {
        public string SKU { get; set; }
        public decimal Quantity { get; set; }
    }

    public class Order {

        public string EmailAddress { get; set; }
        public bool IsDelivery { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
