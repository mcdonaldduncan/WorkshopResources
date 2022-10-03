using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramAssignment
{
    internal class Weapon : Object
    {
        public enum Quality
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }
        
        Quality quality;

        int damage;
        int range;

        bool isTwoHanded;

        public virtual void Attack()
        {
            throw new NotImplementedException();
        }

        public virtual void Defend()
        {
            throw new NotImplementedException();
        }
    }
}
