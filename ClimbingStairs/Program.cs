using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingStairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int permutations = 0;

            Console.WriteLine("Enter the number of stairs: ");
            int stairs = Convert.ToInt32(Console.ReadLine());
            FindPermutations(stairs);
            Console.WriteLine("The number of permutations is: " + permutations);

            void FindPermutations(int n)
            {
                IterateTree(0, n);
            }
            
            void IterateTree(int current, int target)
            {
                if (current > target)
                    return;

                if (current == target)
                {
                    permutations++;
                    return;
                }

                int i = current + 1;
                int j = current + 2;
                IterateTree(i, target);
                IterateTree(j, target);
            }
            Console.ReadLine();
        }
    }
}
