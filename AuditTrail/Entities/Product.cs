using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditTrail.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public Product()
        {
            Uuid = Guid.NewGuid().ToString();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
