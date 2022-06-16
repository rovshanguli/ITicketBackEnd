using System;

namespace ServiceLayer.DTOs.Event
{
    public class EventEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] BackImage { get; set; }
        public byte[] Image { get; set; }
        public byte[] DetailImage { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public int HallId { get; set; }
    }
}
