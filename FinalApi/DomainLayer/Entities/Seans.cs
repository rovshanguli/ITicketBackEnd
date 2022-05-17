using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Seans : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Hour { get; set; }
      
    }
}
