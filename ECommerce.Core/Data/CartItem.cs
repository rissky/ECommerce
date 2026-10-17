using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Data
{
    public class CartItem
    {
        public CartItem(string name, int quantity, int price)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }
            if(price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }

            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public int Price { get; private set; }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(newQuantity));
            }
            Quantity = newQuantity;
        }
    }
}
