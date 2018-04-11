using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDLL
{
    class ShoppingBasketTotals
    {

        private static List<BasketItem> BasketItemsList = null;
        private decimal BasketAmount; 


        public ShoppingBasketTotals(Dictionary<int, BasketItem> basketItems)  
        {
            BasketItemsList = new List<BasketItem>();
            decimal basketAmount = 0;

            foreach (var item in basketItems)
            {
                item.Value.DiscountAmount = 0;
                if (item.Value.ItemDiscount != null)
                {
                    item.Value.DiscountAmount =   item.Value.ItemDiscount.CalculateDiscount(item.Value, basketItems[item.Value.ItemDiscount.ProductIdForDiscount].Quantity);
                }

                item.Value.Amount = item.Value.Quantity * item.Value.Price - item.Value.DiscountAmount;

                BasketItemsList.Add(item.Value);

                basketAmount += item.Value.Amount;
            }

            BasketAmount = basketAmount;

        }

        public List<BasketItem> GetBasketItemList()
        {
            return BasketItemsList;
        }

        public decimal GetBasketAmount()
        {
            return BasketAmount;
        }

    }
}
