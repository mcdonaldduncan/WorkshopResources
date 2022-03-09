using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopTues3._8
{
    class Shop
    {
        public Player player = new Player();
        public Vendor vendor = new Vendor();


        public void StartShop()
        {
            player.GenerateCurrency();
            vendor.GenerateInventory();
            

        }

        public void PrintOptions()
        {
            vendor.PrintInventory();

            Console.WriteLine($"player has {player.currency} moneys");
        }

        public int GetInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }

        public void BuyItem(int index)
        {
            player.inventory.Add(vendor.inventory[index]);
            player.currency -= vendor.inventory[index].value;
            vendor.currency += vendor.inventory[index].value;
            vendor.inventory.RemoveAt(index);
            
        }


    }
}
