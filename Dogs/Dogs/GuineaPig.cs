using Dogs_New;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_New
{
    class GuineaPig : Animal
    {
        private const int VaccinationDuration = 1;
        public GuineaPig(int id, string name, string breed, DateTime birthdate, Gender gender) : base(id, name, breed, birthdate, gender)
        {

        }
        public override bool RequiresVaccination
        {
            get
            {

                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
            }
        }
    }
}
