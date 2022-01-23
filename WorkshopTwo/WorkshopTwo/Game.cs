using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTwo
{
    internal class Game
    {
        Player player = new Player();
        ShopKeeper shopKeeper = new ShopKeeper();

        void Play()
        {
            player.name = "Morty";
            shopKeeper.name = "Rick";

            shopKeeper.money = 100;
            player.money = 75;

            player.Rob();
            player.Buy();

            shopKeeper.Restock();
        }
    }
}
