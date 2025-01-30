using System;
using System.Collections.Generic;

class Product
{ 
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime LastUpdated { get; set; }

    public Product(string name, decimal price, int quantity) {
        Name = name;
        Price = price;
        Quantity = quantity;
        LastUpdated = DateTime.Now;
    }
}

class InventoryManager
{ 
    private List<Product> products;

    public InventoryManager() 
    { 
        products = new List<Product>(); 
    }

    public void ShowMenu() 
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Inventory Managment System");
            Console.WriteLine("1. View products");
            Console.WriteLine("2. Add new product");
            Console.WriteLine("3. Update stock");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nSelect an option");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayProducts();
                    break;
                case "2":
                    AddProduct();
                    break;
                case "3":
                    UpdateStock();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option, press any key to continue");
                    Console.ReadLine();
                    break;

            }
        }
    }

    private void DisplayProducts() 
    { 
        Console.Clear ();
        Console.WriteLine("Current inventory");

        if (products.Count == 0)
        {
            Console.WriteLine("No products are in inventory");
        }
        else
        {
            foreach(var product in products )
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($" Last updated: {product.LastUpdated}");
                Console.WriteLine("---------------------------------------");
            }
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadLine ();
    }

    private void AddProduct() 
    {
        Console.Clear();
        Console.WriteLine("Add new product");

        Console.WriteLine("Enter product name: ");
        string name = Console.ReadLine();

        if(products.Exists(p => p.Name.Equals(name,StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("\n Product with this name already exists");
            Console.WriteLine("Press any key to contiune");
            Console.ReadLine() ;
            return;
        }

        decimal price = 0;
        while(true)
        {
            Console.WriteLine("Enter product price: ");
            if(decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
                break;
            Console.WriteLine("Enter valid price");

        }

        int quantity = 0;
        while (true)
        {
            Console.WriteLine("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                break;
            Console.WriteLine("Enter valid quantity");
        }
        products.Add(new Product(name, price, quantity));
        Console.WriteLine("Product added successfully");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }
    private void UpdateStock() 
    {
        Console.Clear ();
        Console.WriteLine("Update Stock");

        if(products.Count == 0)
        {
            Console.WriteLine("No products are in inventory");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            return;
        }
        Console.WriteLine("Enter product name: ");
        string name = Console.ReadLine();

        var product = products.Find(p  => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if(product == null)
        {
            Console.WriteLine("\nNo product found");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Curent quantity {product.Quantity}");
        int newQuantity = 0;
        while (true)
        {
            Console.WriteLine("Enter new quantity");
            if ((int.TryParse(Console.ReadLine(), out newQuantity)) && newQuantity >= 0)
                break;
            Console.WriteLine("Enter valid quantity");
        }

        product.Quantity=newQuantity;
        product.LastUpdated = DateTime.Now;
        

        Console.WriteLine("\n Stock updated successfully");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void RemoveProduct() 
    { 
        Console.Clear();
        Console.WriteLine("Remove product");

        if(products.Count == 0) 
        {
            Console.WriteLine("No products are in inventory");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Enter product name: ");
        string name = Console.ReadLine();

        var product = products.Find(p => p.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            Console.WriteLine("\nNo product found");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Are you sure you want to remove this product? (y/n)");
        if (Console.ReadLine().ToLower() == "y")
        {
            products.Remove(product);
            Console.WriteLine("Product removed");
        }
        else 
        {
            Console.WriteLine("Operation cancelled");
        }

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
}

class Program 
{ 
    static void Main(string[] args)
    {
        var inventoryManager = new InventoryManager();
        inventoryManager.ShowMenu();
    }
}
