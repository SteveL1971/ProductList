using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    //internal class Car
    //{
    //    public Car(string category, string productName, decimal price)
    //    {
    //        Category = category;
    //        ProductName = productName;
    //        Price = price;
    //    }

    //    public string Category { get; set; }
    //    public string ProductName { get; set; }
    //    public decimal Price { get; set; }
    //}

    class Vehicle
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description => $"{Category} - {ProductName} - {Price}";
    }

    class Car : Vehicle
    {
        public string Color { get; set; }
        public int TopSpeed { get; set; }
    }
}
