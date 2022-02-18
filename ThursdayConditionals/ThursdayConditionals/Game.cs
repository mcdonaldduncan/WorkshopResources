using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayConditionals
{
    class Game
    {
        int altInput;

        public void Menu()
        {
            bool browse = true;
            while (browse)
            {
                PrintMenuOptions();
                //GetPlayerInput();

                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Case 0");
                        break;
                    case "1":
                        Console.WriteLine("Case 1");
                        break;
                    case "2":
                        Console.WriteLine("Case 2");
                        break;
                    case "3":
                        Console.WriteLine("Case 3");
                        break;
                    default:
                        Console.WriteLine("Try Again");
                        break;
                }
                Continue();
            }
        }

        void PrintMenuOptions()
        {
            Console.WriteLine("Menu:\n0:\n1:\n2:\n3:\n");
        }

        void GetPlayerInput()
        {
            bool persist = true;
            while (persist)
            {
                try
                {
                    altInput = Convert.ToInt32(Console.ReadLine());
                    persist = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter your input as a number");
                    persist = true;
                    continue;
                }
            }
        }

        void Continue()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
