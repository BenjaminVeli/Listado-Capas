using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Product
    {
        public int product_id { get; set; }
        public String name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public Boolean active { get; set; }
    }
}
