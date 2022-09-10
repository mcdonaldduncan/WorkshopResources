using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

        }

        public int[] TwoSum(int[] nums, int target)
        {
            int[] indices = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (nums[i] + nums[j] == target)
                    {
                        indices[0] = i;
                        indices[1] = j;
                        return indices;
                    }
                }

            }

            return indices;
        }


        public int RomanToInt(string s)
        {
            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000},
            };

            int totalValue = 0;
            int prevValue = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (table[s[i].ToString()] < prevValue)
                {
                    totalValue -= table[s[i].ToString()];
                }
                else
                {
                    totalValue += table[s[i].ToString()];
                }

                prevValue = table[s[i].ToString()];
            }
               

            return totalValue;
        }
    }
}
