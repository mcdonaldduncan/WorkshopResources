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


    }
}
