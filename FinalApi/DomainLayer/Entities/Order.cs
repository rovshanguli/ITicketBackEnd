namespace DomainLayer.Entities
{
    public class Order
    {
        public Event Event { get; set; }
        public int? EventId { get; set; }
        public Seans Seans { get; set; }
        public int? SeansId { get; set; }

    }
}
