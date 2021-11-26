using System;
using System.Collections.Generic;
using BuilderGenerator.Test.Direct.Models.Enums;

namespace BuilderGenerator.Test.Direct.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Orders { get; set; } = new List<OrderItem>();
        public OrderStatus Status { get; set; }
    }
}