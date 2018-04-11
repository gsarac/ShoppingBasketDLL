using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBasketDLL;

namespace ShoppingBasketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BuyXGetXFree milkDiscount = new BuyXGetXFree();
            milkDiscount.FreeQuantity = 1;
            milkDiscount.Description = "Buy 3 milks get 4th free";            
            milkDiscount.QuantityForDiscont = 3;
            milkDiscount.ProductIdForDiscount = 2;

            BuyXGetYDiscount breadDiscount = new BuyXGetYDiscount();
            breadDiscount.ProductIdForDiscount = 1;
            breadDiscount.Description = "Buy 2 butters get one bread at 50% off";
            breadDiscount.DiscountPrecentage = 50;
            breadDiscount.QuantityForDiscont = 2;

            BasketItem butter = new BasketItem();
            butter.Id = 1;
            butter.Name = "Butter";
            butter.Price = 0.8m;

            BasketItem milk = new BasketItem();
            milk.Id = 2;
            milk.Name = "Milk";
            milk.Price = 1.15m;
            milk.ItemDiscount = milkDiscount;

            BasketItem bread = new BasketItem();
            bread.Id = 3;
            bread.Name = "Bread";
            bread.Price = 1m;
            bread.ItemDiscount = breadDiscount;

            Scenario1(milk, butter, bread );
            Scenario2( butter, bread);
            Scenario3(milk);
            Scenario4(milk, butter, bread);
            Console.ReadKey();
        }

        private static void Scenario1(BasketItem milk, BasketItem butter, BasketItem bread)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            milk.Quantity = 1;
            shoppingBasket.AddToBasket(milk);
            butter.Quantity = 1;
            shoppingBasket.AddToBasket(butter);
            bread.Quantity = 1;
            shoppingBasket.AddToBasket(bread);

            List<BasketItem> basketItems = shoppingBasket.GetBasketItems();
            decimal basketTotalAmount = shoppingBasket.GetBasketTotalAmount();

            LogToConsole(basketItems, basketTotalAmount, "Scenario1");

        }

        private static void Scenario2(BasketItem butter, BasketItem bread)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            butter.Quantity = 2;
            shoppingBasket.AddToBasket(butter);
            bread.Quantity = 2;
            shoppingBasket.AddToBasket(bread);

            List<BasketItem> basketItems = shoppingBasket.GetBasketItems();
            decimal basketTotalAmount = shoppingBasket.GetBasketTotalAmount();

            LogToConsole(basketItems, basketTotalAmount, "Scenario2");

        }

        private static void Scenario3(BasketItem milk)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            milk.Quantity = 4;
            shoppingBasket.AddToBasket(milk);

            List<BasketItem> basketItems = shoppingBasket.GetBasketItems();
            decimal basketTotalAmount = shoppingBasket.GetBasketTotalAmount();

            LogToConsole(basketItems, basketTotalAmount, "Scenario3");

        }


        private static void Scenario4(BasketItem milk, BasketItem butter, BasketItem bread)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            milk.Quantity = 8;
            shoppingBasket.AddToBasket(milk);
            butter.Quantity = 2;
            shoppingBasket.AddToBasket(butter);
            bread.Quantity = 1;
            shoppingBasket.AddToBasket(bread);

            List<BasketItem> basketItems = shoppingBasket.GetBasketItems();
            decimal basketTotalAmount = shoppingBasket.GetBasketTotalAmount();

            LogToConsole(basketItems, basketTotalAmount, "Scenario4");

        }

        private static void LogToConsole(List<BasketItem> basketItems, decimal basketTotalAmount, string scenario)
        {
            Console.WriteLine("");
            Console.WriteLine(scenario);
            Console.WriteLine("==========================================");
            foreach (var item in basketItems)
            {
                Console.WriteLine("Item: {0}  Quantity: {1}  Amount: {2} ", item.Name, item.Quantity, item.Amount );
                if (item.DiscountAmount > 0)
                {
                    Console.WriteLine("     Item discount: {0}  Discount amount: {1} ", item.ItemDiscount.Description, item.DiscountAmount); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Amount total: {0}", basketTotalAmount);
            Console.WriteLine("==========================================");

        }
    }
}
