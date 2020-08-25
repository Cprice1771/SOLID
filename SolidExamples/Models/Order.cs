using System.Collections.Generic;

namespace SolidExamples.Models {

    public class OrderItem {
        public string SKU { get; set; }
        public decimal Quantity { get; set; }
    }

    public class Order {
        public string EmailAddress { get; set; }
        public bool IsDelivery { get; set; }

        public int? PhoneNumber { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}