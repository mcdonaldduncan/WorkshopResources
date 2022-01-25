using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPuppets
{
    class Display
    {
        public delegate void PrintOption(string message);
        public static PrintOption Print;


        public static void PrintCommandLine(string message)
        {
            Console.WriteLine(message);
        }

        
    }
}
