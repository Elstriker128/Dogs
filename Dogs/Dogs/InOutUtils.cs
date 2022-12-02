using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dogs_New
{
    static class InOutUtils
    {
       public static void PrintBreeds(AnimalContainer Breeds)
        {
            for (int i = 0; i < Breeds.Count; i++)
            {
                Console.WriteLine(Breeds.Get(i).Breed);
            }
        }
        public static void PrintToCSVFile(string filename, AnimalContainer AllAnimals)
        {
            string[] lines = new string[AllAnimals.Count + 1];
            lines[0] = String.Format($"{"Species"}, {"Reg.nr"}, {"Name"}, {"Breed"}, {"Birthdate"}, {"Gender"}, {"Aggresive"}");
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                Animal current = AllAnimals.Get(i);
                if(current is Dog)
                {
                    Dog dog = (Dog)current;
                    lines[i + 1] = String.Format($" {"DOG"}, {dog.ID}, {dog.Name}, {dog.Breed}, {dog.BirthDate}, {dog.Gender}, {dog.Aggresive}");
                }
                else if(current is Cat)
                {
                    Cat cat = (Cat)current;
                    lines[i + 1] = String.Format($" {"CAT"}, {cat.ID}, {cat.Name}, {cat.Breed}, {cat.BirthDate}, {cat.Gender}");
                }
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        // New section for the project
        public static AnimalContainer ReadAnimals(string filename)
        {
            AnimalContainer animals = new AnimalContainer();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach(string line in lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);

                Gender gender;
                Enum.TryParse(Values[5], out gender);

                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "HAMSTER":
                        GuineaPig hamster = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(hamster);
                        break;
                    default:
                        break;
                }

            }
            return animals;
        }

        public static Register ReadDogsRegister(string filename)
        {
            Register animals = new Register();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);

                Gender gender;
                Enum.TryParse(Values[5], out gender);

                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "HAMSTER":
                        GuineaPig hamster = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(hamster);
                        break;
                    default:
                        break;
                }
            }
            return animals;
        }
        public static void PrintAnimals(string label, AnimalContainer animals)
        {
            Console.WriteLine(new string('-', 98));
            Console.WriteLine("| {0,-94} |", label);
            Console.WriteLine(new string('-', 98));
            Console.WriteLine("| {0,-7} | {1,8} | {2,-15} | {3,-15} | {4,-12} | {5,-8} | {6,-11} |",
            "Species", "Reg.Nr", "Name", "Breed", "Birthdate", "Gender", "Aggresive");
            Console.WriteLine(new string('-', 98));

            for (int i = 0; i < animals.Count; i++)
            {
                
                Animal current = animals.Get(i);
                if(current is Dog)
                {
                    Dog dog=(Dog)current;
                    Console.WriteLine("| {0,-7} | {1,8} | {2,-15} | {3,-15} | {4,-12:yyyy-MM-dd} | {5,-8} | {6,-11} |",
                        "DOG", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender, dog.Aggresive);
                }
                else if(current is Cat)
                {
                    Cat cat = (Cat)current;
                    Console.WriteLine("| {0,-7} | {1,8} | {2,-15} | {3,-15} | {4,-12:yyyy-MM-dd} | {5,-8} | {6,-11} |",
                    "CAT", cat.ID, cat.Name, cat.Breed, cat.BirthDate, cat.Gender, "No Data");
                }
                else if(current is GuineaPig)
                {
                    GuineaPig hamster = (GuineaPig)current;
                    Console.WriteLine("| {0,-7} | {1,8} | {2,-15} | {3,-15} | {4,-12:yyyy-MM-dd} | {5,-8} | {6,-11} |",
                       "GUINEA", hamster.ID, hamster.Name, hamster.Breed, hamster.BirthDate, hamster.Gender, "No Data");
                }
                

            }
        }
        /*public static void PrintDogs(Register AllAnimals)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-18} | ",
           "Reg.Nr.", "Name", "Breed", "Birthdate", "Gender", "Vaccination date");
            Console.WriteLine(new string('-', 74));

            Dog dog;
            for (int i = 0; i < AllAnimals.DogsCount(); i++)
            {
                dog = AllAnimals.ReturnIndexArrayValue(i);
                if (dog.LastVaccinationDate != DateTime.MinValue)
                {

                     Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-8} |",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender, dog.LastVaccinationDate);
                }
                else
                {
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-8} |",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender, "No Vaccination");
                }
            }
            Console.WriteLine(new string('-', 74));
        }*/
        public static List<Vaccination> ReadAllVaccinations(string filename)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(filename);
            foreach (string Line in Lines)
            {
                string[] Values = Line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);

                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
    }
}
