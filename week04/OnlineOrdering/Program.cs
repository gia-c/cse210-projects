using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA");

        Customer customer1 = new Customer(
            "Bryan Etchen",
            address1);

        Product product1 = new Product(
            "Bounty Paper x40",
            "P001",
            43.49,
            1);

        Product product2 = new Product(
            "Dawn Dish Soap",
            "D002",
            6.87,
            2);

        Product product3 = new Product(
            "Kitchen Scale",
            "K003",
            8.81,
            1);

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // Order 2
        Address address2 = new Address(
            "Av. Arequipa 123",
            "Lima",
            "Lima",
            "Peru");

        Customer customer2 = new Customer(
            "Gisela Casas",
            address2);

        Product product4 = new Product(
            "Amazon Kindle",
            "A004",
            199.99,
            1);

        Product product5 = new Product(
            "Beats Studio Headphones",
            "U005",
            156.26,
            3);

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order1.GetTotalCost():F2}");

        Console.WriteLine("\n---------------------------\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order2.GetTotalCost():F2}");
    }
}