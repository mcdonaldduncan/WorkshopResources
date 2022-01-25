using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPuppets
{
    class Supplier: Person
    {
        //public IDictionary<string, float> supplies = new Dictionary<string, float>();
        
        //public void Assignment()
        //{
        //    supplies.Add("sock", 5);
        //    supplies.Add("googlyeye", 5);
        //    supplies.Add("pompom", 5);
        //    supplies.Add("pipecleaner", 5);
        //    supplies.Add("toothpick", 5);
        //    supplies.Add("felt", 5);
        //    supplies.Add("glitter", 5);
        //    supplies.Add("hay", 5);
        //    supplies.Add("vynil", 5);
            
        //}

        public List<Material> supplies = new List<Material>()
        {
            new Material{Name = "sock", Value = 5},
            new Material{Name = "googlyeye", Value = 5},
            new Material{Name = "pompom", Value = 5},
            new Material{Name = "pipecleaner", Value = 5},
            new Material{Name = "toothpick", Value = 5},
            new Material{Name = "felt", Value = 5},
            new Material{Name = "glitter", Value = 5},
            new Material{Name = "hay", Value = 5},
            new Material{Name = "vynil", Value = 5}

            
        };
    }
}
