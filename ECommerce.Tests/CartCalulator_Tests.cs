using ECommerce.Core.Data;
using ECommerce.Core.Logic;


namespace ECommerce.Tests
{
    public class CartCalulator_Tests
    {


        [SetUp]
        public void Setup()
        {
            // This runs BEFORE every single [Test] method.
            // We initialize a valid item here so we don't have to repeat this setup 
            // in tests that just need an existing, valid CartItem. 
        }

        [Test]
        public void CalculateSubtotal_WithMultipleItems_CalculatesCorrectly()
        {
            // 1. ARRANGE: Set up the initial state and data
            CartCalculator calculator = new CartCalculator();
            List<CartItem> items = new List<CartItem>
            {
                new CartItem("Apple", 2, 5),  // Subtotal: 10
                new CartItem("Banana", 1, 3)  // Subtotal: 3
            };
            decimal expectedSubtotal = 13.00m;
            // 2. ACT: Execute the method we are testing
            decimal actualSubtotal = calculator.CalculateSubtotal(items);
            // 3. ASSERT: Verify the result matches our expectations
            Assert.That(actualSubtotal, Is.EqualTo(expectedSubtotal).Within(0.01m), "The subtotal should be the sum of (Price * Quantity) for all items.");
        }
        [Test]
        public void ApplyTenPercentDiscount_WithPositiveSubtotal_CalculatesCorrectly()
        {
            // 1. ARRANGE
            CartCalculator calculator = new CartCalculator();
            decimal subtotal = 100.00m;
            decimal expectedTotalAfterDiscount = 90.00m; // 10% discount
            // 2. ACT
            decimal actualTotalAfterDiscount = calculator.ApplyTenPercentDiscount(subtotal);
            // 3. ASSERT
            Assert.That(actualTotalAfterDiscount, Is.EqualTo(expectedTotalAfterDiscount).Within(0.01m), "Applying a 10% discount should reduce the subtotal by 10%.");
        }

        [Test]
        public void GetTotalItemCount_WithMultipleItems_ReturnsCorrectCount()
        {
            // 1. ARRANGE
            CartCalculator calculator = new CartCalculator();
            List<CartItem> items = new List<CartItem>
            {
                new CartItem("Apple", 2, 5),
                new CartItem("Banana", 1, 3),
                new CartItem("Orange", 3, 4)
            };
            int expectedCount = 3; // We have three distinct items
            // 2. ACT
            int actualCount = calculator.GetTotalItemCount(items);
            // 3. ASSERT
            Assert.That(actualCount, Is.EqualTo(expectedCount), "The total item count should reflect the number of distinct items in the cart.");
        }   
    }
}
