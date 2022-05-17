using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Hall:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Place { get; set; }
        public List<Event> Events { get; set; }
    }
}
