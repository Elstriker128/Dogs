using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_New
{
     class AnimalContainer
    {
        private Animal[] animals;
        private int Capacity;
        public int Count { get; set; }

        public AnimalContainer(int capacity = 16)
        {
            this.Capacity= capacity;
            this.animals = new Animal[capacity];
        }
        public AnimalContainer(AnimalContainer container) : this()
        {
            if(container.Count>=this.Capacity)
            {
                this.Capacity = container.Capacity * 2;
            }            

            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public void Add(Animal animal)
        {
            if(this.Count==this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }
        public Animal Get(int index)
        {
            return this.animals[index];
        }
        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if(this.Capacity < minimumCapacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for(int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }           
        }
        public void Put(Animal animal, int index)
        {
            if(index >= 0 || index <= this.Count)
            {
                this.animals[index] = animal;
            }
            else
            {
                Console.WriteLine("No data in the required index space");
            }
        }
        public void Insert(Animal animal, int index)
        {
            if (index >= 0 || index <= this.Count)
            {                
                for (int i = this.Count; i > index; i--)
                {
                    this.animals[i] = this.animals[i - 1];
                }
                this.Count++;
                this.animals[index] = animal;                

            }
            else
            {
                Console.WriteLine("No data in the required index space");
            }
        }
        public void Remove(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i]==animal)
                {
                    for (int j = i; j < this.Count-1; j++)
                    {
                        this.animals[j] = this.animals[j + 1];
                    }
                    this.Count--;
                }
            }           
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (i == index)
                    {
                        for (int j = i; j < this.Count - 1; j++)
                        {
                            this.animals[j] = this.animals[j + 1];
                        }
                        this.Count--;
                    }
                }
            }
            else
            {
                Console.WriteLine("No data in the required index space");
            }
        }
        public void Sort(AnimalsComparor comparor)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count-1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if(comparor.Compare(a,b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag= true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new AnimalsComparor());
        }
        public AnimalContainer Intersect(AnimalContainer other)
        {
            AnimalContainer result = new AnimalContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.Get(i);
                if(other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Animal animal in this.animals)
            {
                if (animal.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }        
        public AnimalContainer FindBreeds()
        {
            AnimalContainer Breed = new AnimalContainer();
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);               
                if (!Breeds.Contains(animal.Breed))
                {
                    Breeds.Add(animal.Breed);
                    Breed.Add(animal);
                }
            }
            return Breed;
        }
        public AnimalContainer FilterByBreed(string breed)
        {
            AnimalContainer filtered = new AnimalContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal.Breed.Equals(breed))
                {
                    filtered.Add(animal);
                }
            }
            return filtered;
        }
        private Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal.ID == ID)
                {
                    return animal;
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindDogByID(vaccination.AnimalID);
                if (animal != null)
                {
                    if (vaccination > animal.LastVaccinationDate)
                    {
                        animal.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }        
        public AnimalContainer FindNonVaccinated()
        {
            AnimalContainer NonVaccinated = new AnimalContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);

                if (animal.RequiresVaccination == true && (animal is GuineaPig)==false)
                {
                    NonVaccinated.Add(animal);
                }
            }
            return NonVaccinated;
        }
    }
}
