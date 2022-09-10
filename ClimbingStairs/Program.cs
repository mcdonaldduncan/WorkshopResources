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

            Dictionary<int, int> cache = new Dictionary<int, int>();


            int ClimbStairs(int n)
            {
                int p1 = 1; 
                int p2 = 1;
                for (int i = 0; i < n - 1; i++)
                {
                    int temp = p1;
                    p1 += p2;
                    p2 = temp;
                }

                return p1;
            }



            // Brute Force
            Console.WriteLine("Enter the number of stairs: ");
            int stairs = Convert.ToInt32(Console.ReadLine());
            //FindPermutations(stairs);
            Console.WriteLine("The number of permutations is: " + ClimbStairs(stairs));
            Console.ReadLine();

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

        }
    }
}
