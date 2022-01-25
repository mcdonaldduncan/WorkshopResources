using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicPuppets
{
    public class Item
    {
        private string name = "";
        private double value = 0;

        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
    }
}