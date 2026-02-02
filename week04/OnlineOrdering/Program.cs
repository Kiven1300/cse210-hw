using System;

namespace OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("789 Oak Street", "Miami", "FL", "USA");
        Customer customer1 = new Customer("Emma Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("T-Shirt", "TS-101", 12.99, 2));
        order1.AddProduct(new Product("Cap", "CP-202", 9.50, 1));
        order1.AddProduct(new Product("Water Bottle", "WB-303", 15.00, 1));

        Address address2 = new Address("Av. Insurgentes Sur 1234", "Ciudad de México", "CDMX", "Mexico");
        Customer customer2 = new Customer("Kevin González", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "NB-010", 4.25, 4));
        order2.AddProduct(new Product("Pen Pack", "PP-777", 6.80, 2));

        DisplayOrder(order1);
        Console.WriteLine("\n====================================\n");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost():0.00}");
    }
}
