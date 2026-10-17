using ECommerce.Core.Data;

namespace ECommerce.Tests
{
    public class CartItem_Tests
    {
        // Private field to hold our test object
        private CartItem _testItem;

        [SetUp]
        public void Setup()
        {
            // This runs BEFORE every single [Test] method.
            // We initialize a valid item here so we don't have to repeat this setup 
            // in tests that just need an existing, valid CartItem.
            _testItem = new CartItem("Standard Item", 1, 100);
        }

        // --- Constructor Guard Clause Tests ---

        [Test]
        public void Constructor_ValidInputs_CreatesItemSuccessfully()
        {
            // ACT
            CartItem item = new CartItem("Laptop", 2, 500);

            // ASSERT
            Assert.That(item.Name, Is.EqualTo("Laptop"));
            Assert.That(item.Quantity, Is.EqualTo(2));
            Assert.That(item.Price, Is.EqualTo(500));
        }

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            // ACT & ASSERT
            // We use Assert.Throws with a lambda function "() =>" to capture the exception 
            // when attempting to instantiate a CartItem with erroneous data.
            Assert.Throws<ArgumentException>(() => new CartItem("", 1, 10), "An empty name should trigger an ArgumentException.");
            Assert.Throws<ArgumentException>(() => new CartItem("   ", 1, 10), "A whitespace name should trigger an ArgumentException.");
        }

        [Test]
        public void Constructor_ZeroOrNegativeQuantity_ThrowsArgumentException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new CartItem("Apple", 0, 10), "Quantity of 0 should trigger an ArgumentException.");
            Assert.Throws<ArgumentException>(() => new CartItem("Apple", -5, 10), "Negative quantity should trigger an ArgumentException.");
        }

        [Test]
        public void Constructor_NegativePrice_ThrowsArgumentException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new CartItem("Apple", 1, -1), "Negative price should trigger an ArgumentException.");
        }

        // --- UpdateQuantity Tests ---

        [Test]
        public void UpdateQuantity_ValidQuantity_UpdatesSuccessfully()
        {
            // ARRANGE 
            // We use the _testItem instantiated in [SetUp]
            int newQuantity = 5;

            // ACT
            _testItem.UpdateQuantity(newQuantity);

            // ASSERT
            Assert.That(_testItem.Quantity, Is.EqualTo(newQuantity), "The Quantity property should match the newly updated value.");
        }

        [Test]
        public void UpdateQuantity_ZeroOrNegativeQuantity_ThrowsArgumentException()
        {
            // ARRANGE 
            // We use the _testItem instantiated in [SetUp]

            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() => _testItem.UpdateQuantity(0), "Updating to 0 should trigger an ArgumentException.");
            Assert.Throws<ArgumentException>(() => _testItem.UpdateQuantity(-3), "Updating to a negative number should trigger an ArgumentException.");
        }
    }
}
