using DomainLayer.Common;
using System;

namespace DomainLayer.Entities
{
    public class Order : BaseEntity
    {
        public Event Event { get; set; }
        public int EventId { get; set; }
        public string SeatId { get; set; }
        public DateTime Date { get; set; }

    }
}
