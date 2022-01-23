using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopOne
{
    internal class Game
    {
        Player player1 = new Player();
        Player player2 = new Player();

        public void Play()
        {
            player1.name = "Connor";
            player2.name = "Lindsey";
            player1.score = 5;
            player2.score = 7;

            Console.WriteLine(player1.name);
            Console.WriteLine(player2.name);
            Console.WriteLine(player1.score);
            Console.WriteLine(player2.score);
        }
    }
}
