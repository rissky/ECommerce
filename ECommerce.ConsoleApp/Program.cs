using System;
using System.Collections.Generic;
using ECommerce.Core.Data;
using ECommerce.Core.Logic;

namespace ECommerce.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------------------
            // INTENTIONALLY MESSY CODE:
            // Everything is dumped into a single Main method.
            // Students will refactor this into modular void methods.
            // ---------------------------------------------------------

            ShopingCart cart = new ShopingCart();
            CartCalculator calculator = new CartCalculator();
            bool isRunning = true;

            // Display Welcome Banner
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("           WELCOME TO THE T-LEVEL STORE           ");
            Console.WriteLine("==================================================");
            Console.WriteLine("Press any key to enter the shop...");
            Console.ReadKey();

            while (isRunning)
            {
                // Print the Main Menu
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. View Shopping Cart");
                Console.WriteLine("2. Add Item to Cart");
                Console.WriteLine("3. Checkout & Calculate Totals");
                Console.WriteLine("4. Exit Application");
                Console.Write("\nPlease select an option (1-4): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // View Cart Logic
                    Console.WriteLine("\n>>> YOUR SHOPPING CART <<<");
                    List<CartItem> currentItems = cart.GetItems();

                    if (currentItems.Count == 0)
                    {
                        Console.WriteLine("Your cart is currently empty.");
                    }
                    else
                    {
                        for (int i = 0; i < currentItems.Count; i++)
                        {
                            Console.WriteLine($"Item {i + 1}: {currentItems[i].Name} | Qty: {currentItems[i].Quantity} | Price: £{currentItems[i].Price}");
                        }
                    }
                }
                else if (choice == "2")
                {
                    // Add Item Logic
                    Console.WriteLine("\n>>> ADD NEW ITEM <<<");

                    try
                    {
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter product quantity: ");
                        int qty = int.Parse(Console.ReadLine()); 

                        Console.Write("Enter product price (£): ");
                        int price = int.Parse(Console.ReadLine());

                        // This relies on the validation built into the CartItem constructor
                        CartItem newItem = new CartItem(name, qty, price);

                        bool added = cart.AddItem(newItem);
                        if (added)
                        {
                            Console.WriteLine($"Success! {qty}x {name} added to your cart.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the item.");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        // Catches the Erroneous data guard clauses from the CartItem class
                        Console.WriteLine($"\n[VALIDATION ERROR]: {ex.Message}");
                        Console.WriteLine("Please try again with valid data.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n[ERROR]: Invalid number format entered. Please type whole numbers for price and quantity.");
                    }
                }
                else if (choice == "3")
                {
                    // Checkout Logic using the CartCalculator
                    Console.WriteLine("\n>>> CHECKOUT SUMMARY <<<");
                    List<CartItem> checkoutItems = cart.GetItems();

                    if (checkoutItems.Count == 0)
                    {
                        Console.WriteLine("You cannot checkout with an empty cart.");
                    }
                    else
                    {
                        Console.WriteLine("Calculating totals using CartCalculator...");

                        // Using the intentionally buggy calculator class
                        int totalItems = calculator.GetTotalItemCount(checkoutItems);
                        decimal subtotal = calculator.CalculateSubtotal(checkoutItems);
                        decimal discountedTotal = calculator.ApplyTenPercentDiscount(subtotal);

                        Console.WriteLine($"Total Individual Items: {totalItems}");
                        Console.WriteLine($"Subtotal: £{subtotal}");
                        Console.WriteLine($"Total to pay (after 10% discount): £{discountedTotal}");                       
                    }
                }
                else if (choice == "4")
                {
                    // Exit Logic
                    Console.WriteLine("\nThank you for shopping at the T-Level Store. Goodbye!");
                    isRunning = false;
                }
                else
                {
                    // Invalid Input Logic
                    Console.WriteLine("\n[ERROR]: Invalid selection. Please enter a number between 1 and 4.");
                }
            }
        }
    }
}