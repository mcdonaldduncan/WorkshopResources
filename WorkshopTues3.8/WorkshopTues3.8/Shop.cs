using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopTues3._8
{
    class Shop
    {
        public Player player = new Player();
        public Vendor vendor = new Vendor();

        public void OpenShop()
        {
            Console.WriteLine("select the index of your purchase");
            vendor.PrintInventory();

            BuyItem(GetInput());
        }

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

        public string ReturnString()
        {
            string input = Console.ReadLine();
            return input;
        }

        public int GetInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }

        public Item ReturnItemByName(string name)
        {
            foreach (var item in player.inventory)
            {
                if (item.name == name)
                {
                    return item;
                }
            }
            return ReturnItemByName("default");
        }

        public void BuyItem(int index)
        {
            player.inventory.Remove(ReturnItemByName("flashlight"));

            player.inventory.Add(vendor.inventory[index]);
            player.currency -= vendor.inventory[index].value;
            vendor.currency += vendor.inventory[index].value;
            vendor.inventory.RemoveAt(index);

            string name = ReturnString();
        }

        public void Battle(Player p, Vendor v)
        {
            if (p.health > v.health)
            {
                p.health++;
            }
            else
            {
                v.health++;
            }
        }


    }
}
