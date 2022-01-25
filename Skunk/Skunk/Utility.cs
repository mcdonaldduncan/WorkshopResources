using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skunk
{
    public class Utility
    {

        private static Random r = new Random();

        public static Random R { get => r; set => r = value; }
    }
}
