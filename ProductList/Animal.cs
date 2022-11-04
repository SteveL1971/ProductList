using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    internal class Animal
    {
        public Animal(string category, string productName, decimal price)
        {
            Category = category;
            ProductName = productName;
            Price = price;

            Random rnd = new Random();
            if(rnd.Next(2) == 1)
            {
                Sex = "Male";
            }
            else
            {
                Sex = "Female";
            }

            Age = rnd.Next(15);
        }

        public int Age { get; set; }
        public string Sex { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }


}
