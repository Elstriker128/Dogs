using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_New
{
    internal class AnimalsComparor
    {
        public virtual int Compare(Animal a, Animal b)
        {
            if (a.Name != b.Name)
            {
                return a.Name.CompareTo(b.Name);
            }
            else if (a.ID != b.ID)
            {
                return a.ID.CompareTo(b.ID);
            }
            else
            {
                return -1;
            }
        }
    }
}
