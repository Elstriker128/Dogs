using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_New
{
    class AnimalsComparatorByName : AnimalsComparor
    {
        public override int Compare(Animal a, Animal b)
        {
            if (a.BirthDate != b.BirthDate)
            {
                return a.BirthDate.CompareTo(b.BirthDate);
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
