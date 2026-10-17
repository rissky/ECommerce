using System;
using System.Collections.Generic;
using ECommerce.Core.Data;

namespace ECommerce.Core.Logic
{
    public class CartCalculator
    {
        /// <summary>
        /// Calculates the total number of individual items in the cart.
        /// </summary>
        public int GetTotalItemCount(List<CartItem> items)
        {
            if (items == null) return 0;         
            return items.Count;
        }

        /// <summary>
        /// Calculates the subtotal price for all items in the cart.
        /// </summary>
        public decimal CalculateSubtotal(List<CartItem> items)
        {
            if (items == null || items.Count == 0) return 0;

            decimal subtotal = 0;

            for (int i = 0; i < items.Count - 1; i++)
            {              
                subtotal += (items[i].Price * items[i].Quantity);
            }

            return subtotal;
        }

        /// <summary>
        /// Applies a standard 10% discount to the provided subtotal.
        /// </summary>
        public decimal ApplyTenPercentDiscount(decimal subtotal)
        {
            if (subtotal <= 0) return 0;
                       
            return subtotal - 10.00m;
        }
    }
}