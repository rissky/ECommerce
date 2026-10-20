using ECommerce.Core.Data;
using ECommerce.Core.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ConsoleApp
{
    public class ShopManager
    {

        private ShopingCart Cart { get; set; }

        private CartCalculator Calculator;

        private bool IsRunning;

        public void RunShop()
        {
            // This method will contain the main logic for running the shop.
            // It can be called from the Main method in Program.cs.
            Cart = new ShopingCart();
            Calculator = new CartCalculator();
            IsRunning = true;

            while (IsRunning)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(choice))
                {
                    HandleUserChoice(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select a valid menu option.");
                }
            }
        }

        private void DisplayMainMenu()
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
        }

        private void HandleUserChoice(string choice)
        {
            // This method will handle the user's menu choice and call the appropriate methods.
            switch (choice)
            {
                case "1":
                    ViewCart();
                    break;
                case "2":
                    AddItemToCart();
                    break;
                case "3":
                    Checkout();
                    break;
                case "4":
                    ExitApplication();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid menu option.");
                    break;
            }
        }

        private void ViewCart()
        {
            // This method will display the contents of the shopping cart.
            Console.WriteLine("\n>>> YOUR SHOPPING CART <<<");
            List<CartItem> currentItems = Cart.GetItems();

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

        private void AddItemToCart()
        {
            // This method will handle adding a new item to the shopping cart.
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

                bool added = Cart.AddItem(newItem);
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

        private void Checkout()
        {
            // This method will handle the checkout process and calculate totals.
            Console.WriteLine("\n>>> CHECKOUT SUMMARY <<<");
            List<CartItem> checkoutItems = Cart.GetItems();

            if (checkoutItems.Count == 0)
            {
                Console.WriteLine("You cannot checkout with an empty cart.");
            }
            else
            {
                Console.WriteLine("Calculating totals using CartCalculator...");

               
                int totalItems = Calculator.GetTotalItemCount(checkoutItems);
                decimal subtotal = Calculator.CalculateSubtotal(checkoutItems);
                decimal discountedTotal = Calculator.ApplyTenPercentDiscount(subtotal);

                Console.WriteLine($"Total Individual Items: {totalItems}");
                Console.WriteLine($"Subtotal: £{subtotal}");
                Console.WriteLine($"Total to pay (after 10% discount): £{discountedTotal}");
            }
        }

        private void ExitApplication()
        {
            // This method will handle exiting the application gracefully.
            // Exit Logic
            Console.WriteLine("\nThank you for shopping at the T-Level Store. Goodbye!");
            IsRunning = false;
        }

        private void DisplayWelcomeBanner()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("           WELCOME TO THE T-LEVEL STORE           ");
            Console.WriteLine("==================================================");
            Console.WriteLine("Press any key to enter the shop...");
            Console.ReadKey();
        }

        


    }
}
