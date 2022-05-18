using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Order
    {
        public Event Event { get; set; }
        public int? EventId { get; set; }
        public Seans SeansId{ get; set; }
        public int MyProperty { get; set; }

    }
}
