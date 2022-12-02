using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_New
{
     public class Register
    {
        private List<Animal> AllAnimals;

        public Register()
        {
            AllAnimals = new List<Animal>();
        }
        public Register(List<Animal> animals)
        {
            AllAnimals = new List<Animal>();
            foreach(Animal animal in animals)
            {
                this.AllAnimals.Add(animal);
            }
        }
        public void Add(Animal animal)
        {
            AllAnimals.Add(animal);
        }
        public int AnimalsCount()
        {
            return this.AllAnimals.Count;
        }
        public Animal ReturnIndexArrayValue(int index)
        {
            return this.AllAnimals[index];
        }
        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {               
                Animal animal = this.ReturnIndexArrayValue(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
        //public int CountByGender(Gender gender)
        //{
        //    int count = 0;
        //    foreach (Animal animal in this.AllAnimals)
        //    {
        //        if (animal.Gender.Equals(gender))
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
        //public Animal FindOldestDog()
        //{
        //    Register RightDogs = new Register();
        //    return this.FindOldestDog(RightDogs);
        //}
        //public Animal FindOldestDog(string breed)
        //{
        //    Register Filtered = this.FilterByBreed(breed);
        //    return this.FindOldestDog(Filtered);
        //}
        //private Animal FindOldestDog(Register RightDogs)
        //{
        //    Animal oldest = this.ReturnIndexArrayValue(0);
        //    Animal current;
        //    for (int i = 1; i < this.DogsCount(); i++)
        //    {
        //        current = this.ReturnIndexArrayValue(i);
        //        if (DateTime.Compare(oldest.BirthDate, current.BirthDate) > 0)
        //        {
        //            oldest = current;
        //        }
        //    }
        //    return oldest;
        //}
        //public List<string> FindBreeds()
        //{
        //    List<string> Breeds = new List<string>();
        //    foreach (Animal animal in this.AllAnimals)
        //    {
        //        string breed = animal.Breed;
        //        if (!Breeds.Contains(breed))
        //        {
        //            Breeds.Add(breed);
        //        }
        //    }
        //    return Breeds;
        //}
        //public Register FilterByBreed(string breed)
        //{
        //    Register filtered = new Register();
        //    foreach (Animal animal in this.AllAnimals)
        //    {
        //        if (animal.Breed == breed)
        //        {
        //            filtered.Add(animal);
        //        }
        //    }
        //    return filtered;
        //}
        //private Animal FindDogByID(int ID)
        //{
        //    foreach (Animal animal in this.AllAnimals)
        //    {
        //        if (animal.ID == ID)
        //        {
        //            return animal;
        //        }
        //    }
        //    return null;
        //}
        //public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        //{
        //    foreach (Vaccination vaccination in Vaccinations)
        //    {
        //        Animal animal = this.FindDogByID(vaccination.DogID);
        //        if (animal != null)
        //        {
        //            if (vaccination > animal.LastVaccinationDate)
        //            {
        //                animal.LastVaccinationDate = vaccination.Date;
        //            }
        //        }
        //    }
        //}
        //public Register FindNonVaccinated()
        //{
        //    Register NonVaccinated = new Register();
        //    foreach (Animal animal in this.AllAnimals)
        //    {
        //        if (animal.RequiresVaccination() == true)
        //        {
        //            NonVaccinated.Add(animal);
        //        }
        //    }
        //    return NonVaccinated;
        //}
        //public bool Contains(Animal animal)
        //{
        //    return AllAnimals.Contains(animal);
        //}
    }
}
