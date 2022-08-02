using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindCat.GenRandom;


namespace FindCat
{
    internal class Program
    {
        static void Main()
        {
            int pos;
            int len;
            bool isFound;
            bool goAgain = true;

            while (goAgain)
            {
                isFound = false;
                Console.WriteLine("Gimme a number!");
                len = GetNumFromUser();
                pos = R.Next(len);

                for (int i = 0; i < len; i++)
                {
                    if (isFound)
                        break;

                    Console.WriteLine($"Guess: {i}");
                    Console.WriteLine($"Actual: {pos}");

                    isFound = CheckGuess(i, pos);
                    pos = Step(pos, 0, len);

                    Console.WriteLine(isFound);
                }
                for (int i = len - 1; i > 0; i--)
                {
                    if (isFound)
                        break;

                    Console.WriteLine($"Guess: {i}");
                    Console.WriteLine($"Actual: {pos}");

                    isFound = CheckGuess(i, pos);
                    pos = Step(pos, 0, len);

                    Console.WriteLine(isFound);
                }

                Console.WriteLine("Smack the Enter key to run it back");
                if (Console.ReadLine().ToLower() == "stop")
                {
                    goAgain = false;
                }
            }
        }

        static bool CheckGuess(int guess, int actual)
        {
            return guess == actual;
        }

        static int Step(int current, int min, int max)
        {
            if (R.Next(2) < 1)
            {
                if (current < max)
                {
                    return ++current;
                }
                else
                {
                    return --current;
                }
            }
            else
            {
                if (current > min)
                {
                    return --current;
                }
                else
                {
                    return ++current;
                }
            }
        }

        static int GetNumFromUser()
        {
            if (Int32.TryParse(Console.ReadLine(), out int x))
            {
                return x;
            }
            else
            {
                Console.WriteLine("Gimme a number, fool!");
                return GetNumFromUser();
            }
        }
    }

    class GenRandom
    {
        public static Random R = new Random();
        
    }
}


