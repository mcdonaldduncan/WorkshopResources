using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace TestProj
{
    class Utility
    {
        public static Random random = new Random();

        public static void Pause()
        {
            Print("Press any key to continue");

            ReadKey();
        }

        public static void Print(string toPrint)
        {
            WriteLine(toPrint);
        }

        public static string InputToLower()
        {
            string playerInput = ReadLine().ToLower();
            return playerInput;
        }

        public static string PrintValueName(int value)
        {
            if (value == 11)
                return "Jack";
            if (value == 12)
                return "Queen";
            if (value == 13)
                return "King";
            if (value == 14 || value == 1)
                return "Ace";
            else
                return value.ToString();
        }
    }
}
