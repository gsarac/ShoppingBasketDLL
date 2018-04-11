using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingBasketDLL
{
    public class ShoppingBasket
    {
        private static Dictionary<int, BasketItem> BasketItems = null;


        public ShoppingBasket()
        {
            BasketItems = new Dictionary<int, BasketItem>();
        }

        /// <summary>
        /// Dodavanje artikla u košaricu
        /// </summary>
        /// <param name="item">Objekt tipa item</param>
        public void AddToBasket(BasketItem item)
        {           
            if (BasketItems.ContainsKey(item.Id))
                BasketItems[item.Id].Quantity += item.Quantity;
            else
                BasketItems.Add(item.Id, item);
        }

        /// <summary>
        /// Makni artikl iz košarice
        /// </summary>
        /// <param name="item">Objekt tipa item</param>
        public void RemoveFromBasket(BasketItem item)
        {
            if (BasketItems.ContainsKey(item.Id))
                BasketItems.Remove(item.Id);         
        }

        /// <summary>
        /// Dohvati artikle spremljene u košaricu
        /// </summary>
        /// <returns>Lista artikala u košarici sa izračunatim iznosima i popustima</returns>
        public List<BasketItem> GetBasketItems()
        {
             ShoppingBasketTotals basketItemsTotals = new  ShoppingBasketTotals(BasketItems);

            return basketItemsTotals.GetBasketItemList();
        }

        /// <summary>
        /// Dohvati ukupni iznos košarice
        /// </summary>
        /// <returns>Ukupni iznos košarice</returns>
        public decimal GetBasketTotalAmount()
        {
            ShoppingBasketTotals basketItemsTotals = new ShoppingBasketTotals(BasketItems);

            return basketItemsTotals.GetBasketAmount();
        }


         

    }
}
