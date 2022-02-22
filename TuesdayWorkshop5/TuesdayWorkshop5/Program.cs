using System;

namespace TuesdayWorkshop5
{
    class Program
    {
        static void Main()
        {
            // Class instance
            Iteration iteration = new Iteration();

            // Calling a collection and a method from the class instance
            iteration.colorfulFruits = iteration.MakeFruits();

            iteration.PrintFruits();

            Console.ReadLine();

        }
    }
}
