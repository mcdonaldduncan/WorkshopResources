using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTwo
{
    internal class Program
    {
        //floating point arithmetic

        static void Main()
        {
            // 1/3 = .3333333333 repeating
            // 1/10 = .1 or 0.0001100110011001100110011001100110011001100110011

            float x = 0.03f;
            float y = 0.09f;

            float z = x + y;

            float test = .12f;

            Console.WriteLine(z == test);

            Console.WriteLine(z);
            Console.WriteLine(test);

            Console.ReadKey();

        }
    }
}
