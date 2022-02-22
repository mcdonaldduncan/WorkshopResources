using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuesdayWorkshop5
{
    class Iteration
    {
        string[] types = {"Strawberry", "Banana", "Apple", "Orange"};
        string[] colors = { "Green", "Brown", "Blue", "Pink", "Purple", "Red", "Yellow" };

        public List<ColorfulFruit> colorfulFruits = new List<ColorfulFruit>();

        // Dynamically create a new list of items by taking in the values of two arrays
        public List<ColorfulFruit> MakeFruits()
        {
            List<ColorfulFruit> temp = new List<ColorfulFruit>();

            foreach (var type in types)
            {
                foreach (var color in colors)
                {
                    temp.Add(new ColorfulFruit(type, color));
                }

            }

            return temp;
        }

        // Print out all the items in a list
        public void PrintFruits()
        {
            foreach (var fruit in colorfulFruits)
            {
                Console.WriteLine($"A {fruit.color} {fruit.type}\n");
            }
        }


        // Return types
        public string TypesString()
        {
            string temp = "";
            foreach (var type in types)
            {
                temp += type;
            }
            return temp;
        }

        void ChangeFirstInstance()
        {
            types[0] = TypesString();
        }

        public void PrintTypes()
        {
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }
        }


    }
}
