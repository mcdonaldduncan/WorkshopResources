using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayWorkshop3
{
    class Student
    {
        public string name;
        public string hobbies;

        public Student(string n, string h)
        {
            name = n;
            hobbies = h;
        }

        public void Description(string n, string h)
        {
            Console.WriteLine($"My name is {n}, and I enjoy {h}");
        }

    }
}
