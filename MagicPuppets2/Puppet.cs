using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicPuppets
{
    public class Puppet:Item
    {


        private string material1 = "";
        private string material2 = "";
        private string material3 = "";
        private string rarity = "rare";

        public string Material1 { get => material1; set => material1 = value; }
        public string Material2 { get => material2; set => material2 = value; }
        public string Material3 { get => material3; set => material3 = value; }
        public string Rarity { get => rarity; set => rarity = value; }
    }
}