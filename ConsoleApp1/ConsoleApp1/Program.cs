using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student duncan = new Student("Duncan", "He/Him/His", "Programming, Reading, Swimming and Video Games");
            duncan.Description();
            Console.ReadKey();
        }

        private class Student
        {
            string name;
            string pronouns;
            string hobbies;


            public Student(string n, string p, string h)
            {
                name = n;
                pronouns = p;
                hobbies = h;
            }

            public void Description()
            {
                Console.WriteLine($"Hi, my name is {name}, my pronouns are {pronouns} and I enjoy {hobbies}.");
            }
        }
    }
}
