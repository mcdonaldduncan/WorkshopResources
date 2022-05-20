using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static TestProj.Utility;

namespace TestProj
{
    class Menu
    {
        BlackJack blackJack = new BlackJack();
        HighLow highLow = new HighLow();
        War war = new War();

        // Print menu to allow entry into each game mode
        public void MenuLayout()
        {
            bool persist = true;

            Print("Choose a Game!\n");
            Print("0: War\n1: High-Low\n2: BlackJack\n3: Exit");

            while (persist)
            {
                string playerInput = ReadLine();

                switch (playerInput)
                {
                    case "0":
                        war.Play();
                        break;
                    case "1":
                        highLow.Play();
                        break;
                    case "2":
                        blackJack.Play();
                        break;
                    case "3":
                        Print("Exiting");
                        persist = false;
                        break;
                    default:
                        Print("I'm sorry, maybe the directions weren't clear. Read carefully and try again!");
                        break;
                }
            }
        }
    }
}
