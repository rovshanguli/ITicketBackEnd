using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Event
{
    public class EventDto
    {
        public string Name { get; set; }
        public byte[] BackImage { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int HallId { get; set; }
     
    }
}
