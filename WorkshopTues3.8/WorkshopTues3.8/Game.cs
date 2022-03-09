using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopTues3._8
{
    internal class Game
    {
        Player _player = new Player();
        Vendor _vendor = new Vendor();
        Shop _shop = new Shop();


        void RunSim()
        {
            _player.health = 5;
            _vendor.health = 6;
            _shop.Battle(_player, _vendor);
        }


    }
}
