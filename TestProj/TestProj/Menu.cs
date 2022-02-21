using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static TestProj.Utility;

namespace TestProj
{
    class Menu
    {
        public void MenuLayout()
        {
            bool persist = true;

            Print("Choose a Game!\n");
            Print("0: War\n1: High-Low");

            while (persist)
            {
                string playerInput = ReadLine();

                switch (playerInput)
                {
                    case "0":

                        break;
                    case "1":

                        break;
                    case "2":
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
