using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopTues3._8
{
    class Vendor : Person
    {
        public string inventoryPrint;

        public void PrintInventory()
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.name}\n");
            }

        }

        public void GenerateInventory()
        {
            inventory.Add(new Item("sock", 2));
            inventory.Add(new Item("mitten", 4));
            inventory.Add(new Item("glove", 3));
        }
    }
}
