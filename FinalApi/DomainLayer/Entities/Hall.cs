using DomainLayer.Common;
using System.Collections.Generic;

namespace DomainLayer.Entities
{
    public class Hall : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Place { get; set; }
        public List<Event> Events { get; set; }
    }
}
