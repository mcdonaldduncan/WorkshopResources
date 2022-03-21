using System;

namespace WorkshopTues3._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.StartShop();
            shop.PrintOptions();

            shop.BuyItem(shop.GetInput());
            
            shop.PrintOptions();
            Console.ReadKey();

            Console.WriteLine("Hello World!");
        }
    }
}
