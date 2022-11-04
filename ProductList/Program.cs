using ProductList;
using System.Runtime.InteropServices;

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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("To enter a new product - choose a category | Quit with 'q'\n");
        Console.ResetColor();
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nEnter a product name | Quit with 'q'\n");
        Console.ResetColor();
        Console.WriteLine("Category: " + category + "\n");
        Console.Write("Enter Product: ");
        productName = Console.ReadLine().Trim();
    }
    if (productName == "q") break;

    bool isDecimal = false;
    while(!isDecimal)
    {
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
                    //Car car = new Car(category, productName, price);
                    var car = new Car
                    {
                        Category = category,
                        ProductName = productName,
                        Price = price,
                        Color = randomColour(),
                        TopSpeed = randomTopSpeed()
                    };
                    cars.Add(car);
                    break;
                case "Furniture":
                    Furniture furniture = new Furniture(category, productName, price);
                    furnitures.Add(furniture);
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe product was successfully added!");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

animalList("");
carList("");
furnitureList("");

selectMenu:

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n'q' to quit | 'n' new product | 's' to search ");
Console.ResetColor();

bool keepLooping = true;
while(keepLooping == true)
{
    string choice = Console.ReadLine().Trim().ToLower();
    switch (choice)
    {
        case "q":
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
            goto selectMenu;
        default:
            keepLooping = true;
            break;
    }
}

string randomColour(){
    Random rnd = new Random();
    switch (rnd.Next(10))
    {
        case 1:
            return "red";
        case 2:
            return "yellow";
        case 3:
            return "pink";
        case 4:
            return "green";
        case 5:
            return "purple";
        case 6:
            return "orange";
        case 7:
            return "blue";
        case 8:
            return "black";
        case 9:
            return "white";
        default:
            return "brown";
    }
}

int randomTopSpeed()
{
    Random rnd = new Random();
    switch (rnd.Next(10))
    {
        case 1:
            return 200;
        case 2:
            return 210;
        case 3:
            return 225;
        case 4:
            return 240;
        case 5:
            return 250;
        case 6:
            return 255;
        case 7:
            return 260;
        case 8:
            return 265;
        case 9:
            return 270;
        default:
            return 180;
    }
}

void animalList(string searchString)
{
    if (animals.Count > 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Age".PadRight(10) + "Sex".PadRight(10) + "Price".PadRight(10));
        Console.ResetColor();
        decimal sum = animals.Sum(animal => animal.Price);
        List<Animal> sortedAnimalsByName = animals.OrderBy(animal => animal.Price).ToList();
        foreach (Animal animal in sortedAnimalsByName)
        {
            if (searchString != "")
            {
                if (animal.ProductName.ToLower().Contains(searchString)|| animal.Category.ToLower().Contains(searchString))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(animal.Category.PadRight(15) + animal.ProductName.PadRight(15) + animal.Age.ToString().PadRight(10) + animal.Sex.PadRight(10) + animal.Price.ToString("0.00").PadRight(10));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(animal.Category.PadRight(15) + animal.ProductName.PadRight(15) + animal.Age.ToString().PadRight(10) + animal.Sex.PadRight(10) + animal.Price.ToString("0.00").PadRight(10));
                }
            }
            else
            {
                Console.WriteLine(animal.Category.PadRight(15) + animal.ProductName.PadRight(15) + animal.Age.ToString().PadRight(10) + animal.Sex.PadRight(10) + animal.Price.ToString("0.00").PadRight(10));
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
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Color".PadRight(15) + "Top Speed".PadRight(15) + "Price".PadRight(10));
        Console.ResetColor();
        decimal sum = cars.Sum(car => car.Price);
        List<Car> sortedcarsByName = cars.OrderBy(car => car.Price).ToList();
        foreach (Car car in sortedcarsByName)
        {
            if (searchString != "")
            {
                if (car.ProductName.ToLower().Contains(searchString)|| car.Category.ToLower().Contains(searchString))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(car.Category.PadRight(15) + car.ProductName.PadRight(15) + car.Color.PadRight(15) + car.TopSpeed.ToString().PadRight(15) + car.Price.ToString("0.00").PadRight(10));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(car.Category.PadRight(15) + car.ProductName.PadRight(15) + car.Color.PadRight(15) + car.TopSpeed.ToString().PadRight(15) + car.Price.ToString("0.00").PadRight(10));
                }
            }
            else
            {
                Console.WriteLine(car.Category.PadRight(15) + car.ProductName.PadRight(15) + car.Color.PadRight(15) + car.TopSpeed.ToString().PadRight(15) + car.Price.ToString("0.00").PadRight(10));
            }
        }

        if (searchString == "")
        {
            Console.WriteLine("\nTotal price of all cars:  " + sum.ToString("0.00"));
        }     
    }
}

void furnitureList (string searchString)
{
    if (furnitures.Count > 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n" + "Category".PadRight(15) + "Name".PadRight(15) + "Colour".PadRight(15) + "Price".PadRight(10));
        Console.ResetColor();
        decimal sum = furnitures.Sum(furniture => furniture.Price);
        List<Furniture> sortedProductsByName = furnitures.OrderBy(furniture => furniture.Price).ToList();
        foreach (Furniture furniture in sortedProductsByName)
        {
            if (searchString != "")
            {
                if (furniture.ProductName.ToLower().Contains(searchString)|| furniture.Category.ToLower().Contains(searchString))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(furniture.Category.PadRight(15) + furniture.ProductName.PadRight(15) + furniture.Colour.PadRight(15) + furniture.Price.ToString("0.00").PadRight(10));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(furniture.Category.PadRight(15) + furniture.ProductName.PadRight(15) + furniture.Colour.PadRight(15) + furniture.Price.ToString("0.00").PadRight(10));
                }
            }
            else
            {
                Console.WriteLine(furniture.Category.PadRight(15) + furniture.ProductName.PadRight(15) + furniture.Colour.PadRight(15) + furniture.Price.ToString("0.00").PadRight(10));
            }
        }

        if (searchString == "")
        {
            Console.WriteLine("\nTotal price of all furniture:  " + sum.ToString("0.00"));
        }
    }
}





