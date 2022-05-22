using ServiceLayer.DTOs.Category;
using ServiceLayer.DTOs.Hall;
using System;

namespace ServiceLayer.DTOs.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] BackImage { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public CategoryDto Category { get; set; }
        public HallDto Hall { get; set; }

    }
}
