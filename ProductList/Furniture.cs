using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    internal class Furniture    {
        public Furniture(string category, string productName, decimal price)
        {
            Category = category;
            ProductName = productName;
            Price = price;
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
