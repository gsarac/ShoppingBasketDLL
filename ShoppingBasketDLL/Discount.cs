using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDLL
{
    public class Discount
    {
        public string Description { get; set; }
        public int QuantityForDiscont { get; set; }
        public int ProductIdForDiscount { get; set; }


        /// <summary>
        /// Izračun popusta
        /// </summary>
        /// <param name="basketItem">Artikl u košarici</param>
        /// <param name="itemCheckQuantity">Količina x artikala za dobivanje popusta</param>
        /// <returns>Iznos popusta</returns>
        public virtual decimal CalculateDiscount(BasketItem basketItem, int itemCheckQuantity)
        {
            return 0m;
        }

    }

    /// <summary>
    /// Popust - besplatani artikli za određenu količinu artikla
    /// </summary>
    public class BuyXGetXFree : Discount
    {
        public int FreeQuantity { get; set; }



        /// <summary>
        /// Izračun popusta - besplatani artikli za određenu količinu artikla
        /// </summary>
        /// <param name="basketItem">Artikl u košarici</param>
        /// <param name="itemCheckQuantity">Količina x artikala za dobivanje popusta</param>
        /// <returns>Iznos popusta</returns>
        public override decimal CalculateDiscount(BasketItem basketItem, int itemCheckQuantity)
        {
            decimal discount;
            int applicableQuantity = basketItem.Quantity / (QuantityForDiscont + FreeQuantity);

            discount = applicableQuantity * basketItem.Price;

            return discount;
        }
    }

    /// <summary>
    /// Popust za y artikl za određenu kolicinu x artikala
    /// </summary>
    public class BuyXGetYDiscount : Discount
    {
        public int DiscountPrecentage { get; set; }


        /// <summary>
        /// Izračun popusta - popust za y artikl za određenu kolicinu x artikala
        /// </summary>
        /// <param name="basketItem">Artikl u košarici</param>
        /// <param name="itemCheckQuantity">Količina x artikala za dobivanje popusta</param>
        /// <returns>Iznos popusta</returns>
        public override decimal CalculateDiscount(BasketItem basketItem, int itemCheckQuantity)
        {
            decimal discount;
            int applicableQuantity = itemCheckQuantity / QuantityForDiscont ;



            if (applicableQuantity < basketItem.Quantity)
                discount = applicableQuantity * basketItem.Price * DiscountPrecentage / 100;
            else
                discount = basketItem.Quantity * basketItem.Price * DiscountPrecentage / 100;

            return discount;
        }
    }


}
