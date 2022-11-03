using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoring10_5
{
    internal class Program // default class that gets provided with every project you make
    {
        static void Main(string[] args) // Main is the starting point of any code in the project -> initial execution point
        {
            Console.WriteLine("Hello World!");
            
            // To make anything happen in the code, it must happen here
            // Main should have as few lines of code as possible

            // Instantiating Variables
            // In .NET we have a few PRIMITIVE TYPES => default variables available in C#
            char variable1 = 'a'; // Any single character, surrounded by ''.
            string name = "Duncan"; // string is any sequence of characters. Always are surrounded by "". valid string: "The dog went up."
            int integer = 1; // Integer is any whole number value up to ______, 1, 2, 5, 100, 45000, cannot be: 1.5, 3.3
            float floatingPointNumber = 3.3f; // Float is any decimal number, up to __ degree of accuracy. Must end with f
            double doubleAccuracyFloatingPoint = 3.33d; // Double is any decimal number, up to __ degree of accuracy, Must end with d
            bool boolean = true; // Boolean is a true/false value. It can only ever be true or false

            int MyFavoriteNumber = 5;

            int sum = integer + MyFavoriteNumber;

            Console.WriteLine(sum); // Console.WriteLine prints something to the console

            // Control Structure: Something that tells the code what to run depending on some condition
            // if statement **
            // for loop
            // foreach loop
            // while loop
            
            if (sum > 4) // condition to evaluate, true will hit ==>, false will ignore ==> and hit =>
            {
                // ==>
                // code to run, if condition is true
                Console.WriteLine("Sum was greater than 4");
            }
            // =>

            // Conditional Operators
            // > (greater than),
            // < (less than),
            // >= (greater than or equal to),
            // <= (less than or equal to),
            // != (is not equal to),
            // == (is equal to)

            // sum > 4 evaluates to either true or false

            Console.ReadLine(); // Console.ReadLine reads all characters before enter is presses
        }
    }
}
