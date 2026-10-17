using ECommerce.Core.Data;

namespace ECommerce.Core.Logic
{
    public class ShopingCart
    {
        private List<CartItem> Cart { get; set; }
        public ShopingCart()
        {
            Cart = new List<CartItem>();
        }

       /// <summary>
       /// Adds the specified item to the cart.
       /// </summary>
       /// <param name="item">The item to add to the cart. If null, no item is added and the method returns false.</param>
       /// <returns>true if the item was added; otherwise, false.</returns>
        public bool AddItem(CartItem item)
        {
            if (item == null)
            {
                return false;
            }
            else
            {
                Cart.Add(item);
                return true;
            }
        }
        /// <summary>
        /// Removes the specified item from the cart.
        /// </summary>
        /// <remarks>Modifies the Cart collection.</remarks>
        /// <param name="item">The cart item to remove.</param>
        /// <returns>true if the item was removed; false if the item is null or not present in the cart.</returns>
        public bool RemoveItem(CartItem item)
        {
            if (item == null)
            {
                return false;
            }
            if(Cart.Contains(item))
            {
                Cart.Remove(item);
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Gets the list of items in the cart.
        /// </summary>
        /// <returns>The list of CartItem objects.</returns>
        /// <exception cref="Exception">Thrown when Cart is null.</exception>
        public List<CartItem> GetItems()
        {
            if (Cart == null)
            {
                throw new Exception("Cart is null");
            }
            else
            {
                return Cart;
            }
        }
        /// <summary>
        /// Calculates the total price of items in the cart by summing each item's price multiplied by its quantity.
        /// </summary>
        /// <remarks>Returns zero when the cart contains no items.</remarks>
        /// <returns>The total price as a decimal.</returns>
        /// <exception cref="Exception">Thrown when Cart is null.</exception>
        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            if (Cart == null)
            {
                throw new Exception("Cart is null");
            }
            else
            {
                foreach (var item in Cart)
                {
                    totalPrice += item.Price * item.Quantity;
                }
            }
            return totalPrice;
        }
    }
}
