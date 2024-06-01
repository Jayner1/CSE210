using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 4tth St", "Salt Lake City", "UT", "USA");
        Address address2 = new Address("9999 Pizza St", "Citytown", "ON", "Canada");

        Customer customer1 = new Customer("Billy Bob Thorton", address1);
        Customer customer2 = new Customer("Leia Organa", address2);

        Product product1 = new Product("Laptop", "A123", 999.99m, 1);
        Product product2 = new Product("Mouse", "B456", 25.50m, 2);
        Product product3 = new Product("Keyboard", "C789", 49.99m, 1);
        Product product4 = new Product("Monitor", "D012", 199.99m, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Price: ${order1.TotalCost()}");
        Console.WriteLine();

        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Price: ${order2.TotalCost()}");
    }
}
