using ECommerce.Core.Data;
using ECommerce.Core.Logic;


namespace ECommerce.Tests
{
    public class ShopingCart_Tests
    {
        [SetUp]
        public void Setup()
        {
            // This runs before every test, but we'll instantiate our carts locally 
            // inside the tests to keep the AAA pattern crystal clear
        }

        [Test]
        public void GetTotalPrice_WithMultipleItems_CalculatesCorrectly()
        {
            // 1. ARRANGE: Set up the initial state and data
            ShopingCart cart = new ShopingCart();

            // Create items (Price * Quantity)
            CartItem item1 = new CartItem("Apple", 2, 5);  // Subtotal: 10
            CartItem item2 = new CartItem("Banana", 1, 3); // Subtotal: 3

            cart.AddItem(item1);
            cart.AddItem(item2);

            // We expect 10 + 3 = 13
            decimal expectedTotal = 13.00m;

            // 2. ACT: Execute the method we are testing
            decimal actualTotal = cart.GetTotalPrice();

            // 3. ASSERT: Verify the result matches our expectations
            Assert.That(actualTotal, Is.EqualTo(expectedTotal).Within(0.01m), "The total price should be the sum of (Price * Quantity) for all items.");
        }

        [Test]
        public void AddItem_ValidItem_ReturnsTrueAndAddsToCart()
        {
            // 1. ARRANGE
            ShopingCart cart = new ShopingCart();
            CartItem validItem = new CartItem("Laptop", 1, 1000);

            // 2. ACT
            bool result = cart.AddItem(validItem);

            // 3. ASSERT
            Assert.That(result, Is.True, "Adding a valid, non-null item should return true.");
            Assert.That(cart.GetItems().Count, Is.EqualTo(1), "The cart should contain exactly 1 item after adding.");
        }

        [Test]
        public void AddItem_NullItem_ReturnsFalse()
        {
            // 1. ARRANGE
            ShopingCart cart = new ShopingCart();
            CartItem nullItem = null;

            // 2. ACT
            bool result = cart.AddItem(nullItem);

            // 3. ASSERT
            Assert.That(result, Is.False, "Adding a null item should return false.");
            Assert.That(cart.GetItems().Count, Is.EqualTo(0), "The cart should remain empty.");
        }
    }
}