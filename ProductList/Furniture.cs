using System;
using System.Collections.Generic;
using System.Globalization;
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

            Random rnd = new Random();
            
            switch (rnd.Next(10)){
                case 1:
                    Colour = "red";
                    break;  
                case 2:
                    Colour = "yellow";
                    break;
                case 3:
                    Colour = "pink";
                    break;
                case 4:
                    Colour = "green";
                    break;
                case 5:
                    Colour = "purple";
                    break;
                case 6:
                    Colour = "orange";
                    break;
                case 7:
                    Colour = "blue";
                    break;
                case 8:
                    Colour = "black";
                    break;
                case 9:
                    Colour = "white";
                    break;
                default:
                    Colour = "brown";
                    break;
            } 
        }

        public string Category { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
    }
}
