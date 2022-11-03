using ProductList;

List<Furniture> furnitures = new List<Furniture>();
List<Animal> animals = new List<Animal>();
List<Car> cars = new List<Car>();

categoryMenu:

while (true) 
{
    
    string category = "";
    bool chosenCategory = false;
    while (!chosenCategory)
    {
        Console.Clear();
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Choose a category or quit with 'q'\n");
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Categories:\n");
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
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Enter a product name or quit with 'q'\n");
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Chosen Category -- " + category + "\n");
        Console.Write("Enter Product: ");
        productName = Console.ReadLine().Trim();
    }
    if (productName == "q") break;

    bool isDecimal = false;
    while(!isDecimal)
    {
        Console.Clear();
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Enter a price or quit with 'q'\n");
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Chosen Category/Name -- " + category + "/" + productName + "\n");
        //Console.WriteLine("Submitted Product: " + productName + "\n");
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

            switch(category) 
            {
                case "Animals":
                    Animal animal = new Animal(category, productName, price);
                    animals.Add(animal);
                    break;
                case "Cars":
                    Car car = new Car(category, productName, price);
                    cars.Add(car);
                    break;
                case "Furniture":
                    Furniture furniture = new Furniture(category, productName, price);
                    furnitures.Add(furniture);
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nProduct added!");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

animalList("");
carList("");
furnitureList("");

Console.WriteLine("'q' to quit | 'n' new product | 's' to search ");

bool keepLooping = true;
while(keepLooping == true)
{
    string choice = Console.ReadLine().Trim().ToLower();
    switch (choice)
    {
        case "q":
            Console.WriteLine("choice q");
            keepLooping = false;
            break;
        case "n":
            Console.WriteLine("choice n");
            goto categoryMenu;
        case "s":
            Console.Clear();
            Console.Write("Enter product to search for: ");
            string searchString = Console.ReadLine();
            animalList(searchString);
            carList(searchString);
            furnitureList(searchString);
            keepLooping = false;
            break;
        default:
            keepLooping = false;
            break;
    }
    
}

void animalList(string searchString)
{
    if (animals.Count > 0)
    {
        if (searchString == "")
        {
            Console.WriteLine("\nAnimals sorted by product name");
        }
        Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Price".PadRight(10));
        decimal sum = animals.Sum(animal => animal.Price);
        List<Animal> sortedAnimalsByName = animals.OrderBy(animal => animal.ProductName).ToList();
        foreach (Animal animal in sortedAnimalsByName)
        {
            if (searchString != "")
            {
                if (animal.ProductName.Contains(searchString))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(animal.Category.PadRight(15) + animal.ProductName.PadRight(15) + animal.Price.ToString("0.00").PadRight(10));
                    Console.ResetColor();
                }

            }
            else
            {
                Console.WriteLine(animal.Category.PadRight(15) + animal.ProductName.PadRight(15) + animal.Price.ToString("0.00").PadRight(10));
            }
        }

        if (searchString == "")
        {
            Console.WriteLine("\nTotal price of all animals:  " + sum.ToString("0.00"));
        }
        
    }
}

void carList(string searchString)
{
    if (cars.Count > 0)
    {
        Console.WriteLine("\nCars sorted by product name");
        Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Price".PadRight(10));
        decimal sum = cars.Sum(car => car.Price);
        List<Car> sortedCarsByName = cars.OrderBy(car => car.ProductName).ToList();
        foreach (Car car in sortedCarsByName)
        {
            if (car.ProductName == searchString)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine(car.Category.PadRight(15) + car.ProductName.PadRight(15) + car.Price.ToString("0.00").PadRight(10));
            Console.ResetColor();
        }
        Console.WriteLine("\nTotal price of all cars:  " + sum.ToString("0.00"));
    }
}

void furnitureList (string searchString)
{
    if (furnitures.Count > 0)
    {
        Console.WriteLine("\nFurniture sorted by product name");
        Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Price".PadRight(10));
        decimal sum = furnitures.Sum(furniture => furniture.Price);
        List<Furniture> sortedProductsByName = furnitures.OrderBy(furniture => furniture.ProductName).ToList();
        foreach (Furniture furniture in sortedProductsByName)
        {
            if (furniture.ProductName == searchString)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine(furniture.Category.PadRight(15) + furniture.ProductName.PadRight(15) + furniture.Price.ToString("0.00").PadRight(10));
            Console.ResetColor();
        }
        Console.WriteLine("\nTotal price of all furniture:  " + sum.ToString("0.00"));
    }
}





