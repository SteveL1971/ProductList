using ProductList;

List<Furniture> furnitures = new List<Furniture>();
List<Animal> animals = new List<Animal>();
List<Car> cars = new List<Car>();

while (true) 
{
    string category = "";
    bool chosenCategory = false;
    while (!chosenCategory)
    {
        Console.Clear();
        Console.WriteLine("Please fill in the information! OR quit with 'q'\n");
        Console.WriteLine("Categories: ");
        Console.WriteLine("[1] Animals");
        Console.WriteLine("[2] Cars: ");
        Console.WriteLine("[3] Furniture: ");
        Console.Write("\nChoose a category: ");
        category = Console.ReadLine().Trim().ToLower();
        switch (category) {
            case "1":
                category = "Animals";
                chosenCategory = true;
                break;
            case "2":
                category = "Cars";
                chosenCategory = true;
                break;
            case "3":
                category = "Furniture";
                chosenCategory = true;
                break;
            default:
                break;
        }
        if (category == "q") break;
    }
    if (category == "q") break;

    string productName = "";
    while (productName.Length == 0)
    {
        Console.Clear();
        Console.WriteLine("Please fill in the information! OR quit with 'q'\n");
        Console.WriteLine("Enter Category: " + category);
        Console.Write("Enter Product: ");
        productName = Console.ReadLine().Trim();
    }
    if (productName == "q") break;

    bool isDecimal = false;
    while(!isDecimal)
    {
        Console.Clear();
        Console.WriteLine("Please provide product information or quit with 'q'\n");
        Console.WriteLine("Enter Category: " + category);
        Console.WriteLine("Enter Product: " + productName);
        Console.Write("Enter Price: ");
        string data = Console.ReadLine().Trim();
        if (data.ToLower() == "q") break;
        isDecimal = decimal.TryParse(data, out decimal price);
        if (isDecimal)
        {
            string priceString = price.ToString();
            int dot = priceString.IndexOf(".");
            int comma = priceString.IndexOf(",");
            if (dot > 0)
            {
                priceString = priceString.Substring(0, dot+3);
            }
            else if (comma > 0) 
            {
                priceString = priceString.Substring(0, comma+3);
            }
            Console.WriteLine(priceString);

            switch(category) 
            {
                case "Cars":
                    Car car = new Car(category, productName, price);
                    cars.Add(car);
                    break;
                case "Animals":
                    Animal animal = new Animal(category, productName, price);
                    animals.Add(animal);
                    break;
                case "Furniture":
                    Furniture furniture = new Furniture(category, productName, price);
                    furnitures.Add(furniture);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Product added!\n\nPress a key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

if(furnitures.Count >0)
{
    Console.WriteLine("\nFurniture sorted by product name");
    Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Price".PadRight(10));
    decimal sum = furnitures.Sum(furniture => furniture.Price);
    List<Furniture> sortedProductsByName = furnitures.OrderBy(furniture => furniture.ProductName).ToList();
    foreach (Furniture furniture in sortedProductsByName)
    {
        Console.WriteLine(furniture.Category.PadRight(15) + furniture.ProductName.PadRight(15) + furniture.Price.ToString("0.00").PadRight(10));
    }
    Console.WriteLine("\nTotal price of all furniture:  " + sum.ToString("0.00"));
}

if (cars.Count > 0)
{
    Console.WriteLine("\nCars sorted by product name");
    Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Price".PadRight(10));
    decimal sum = cars.Sum(car => car.Price);
    List<Car> sortedCarsByName = cars.OrderBy(car => car.ProductName).ToList();
    foreach (Car car in sortedCarsByName)
    {
        Console.WriteLine(car.Category.PadRight(15) + car.ProductName.PadRight(15) + car.Price.ToString("0.00").PadRight(10));
    }
    Console.WriteLine("\nTotal price of all cars:  " + sum.ToString("0.00"));
}

if (animals.Count > 0)
{
    Console.WriteLine("\nAnimals sorted by product name");
    Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Price".PadRight(10));
    decimal sum = animals.Sum(animal => animal.Price);
    List<Animal> sortedAnimalsByName = animals.OrderBy(animal => animal.ProductName).ToList();
    foreach (Animal animal in sortedAnimalsByName)
    {
        Console.WriteLine(animal.Category.PadRight(15) + animal.ProductName.PadRight(15) + animal.Price.ToString("0.00").PadRight(10));
    }
    Console.WriteLine("\nTotal price of all animals:  " + sum.ToString("0.00"));
}

Console.ReadLine();




