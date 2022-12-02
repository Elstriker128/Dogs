using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace Dogs_New
{
    public class Program
    {
        static void Main(string[] args)
        {
            Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            AnimalContainer container = InOutUtils.ReadAnimals(@"Animals.csv");
            AnimalContainer OldContainer = new AnimalContainer(container);
            Register register = InOutUtils.ReadDogsRegister(@"Animals.csv");

            Console.WriteLine(new string('-', 98));
            Console.WriteLine("Container information:");
            InOutUtils.PrintAnimals("Input data", container);
            Console.WriteLine(new string('-', 98));
            Console.WriteLine();
                     
            Console.WriteLine($"Agresyvių šunų skaičius registre: {register.CountAggresiveDogs()}");
            Console.WriteLine();

            AnimalContainer Breeds = container.FindBreeds();
            Console.WriteLine("Dog breeds: ");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            
            List<Vaccination> VaccinationsData = InOutUtils.ReadAllVaccinations(@"Vaccinations.csv");
            container.UpdateVaccinationsInfo(VaccinationsData);
            Console.Write("Input Breed:");
            string selectedBreed = Console.ReadLine();
            if(File.Exists($"{selectedBreed}.csv"))
            {
                File.Delete($"{selectedBreed}.csv");
            }
            AnimalContainer requiresVaccination = container.FindNonVaccinated();
            AnimalContainer FilteredByBreed = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintAnimals("Reikia skiepyti (" + selectedBreed + ")", requiresVaccination.Intersect(FilteredByBreed));
            Console.WriteLine();

            Console.WriteLine(new string('-', 98));
            Console.WriteLine("Non Vaccinated dogs' info:");
            Console.WriteLine(new string('-', 98));
            AnimalContainer NonVaccinated = container.FindNonVaccinated();
            InOutUtils.PrintAnimals("Non Vaccinated dogs", NonVaccinated);
            Console.WriteLine();

            AnimalContainer ReFiltered = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintAnimals("Filtered by breeds",ReFiltered);
            string filename = selectedBreed + ".csv";
            InOutUtils.PrintToCSVFile(filename, ReFiltered);

            Console.WriteLine(new string('-', 98));
            Console.WriteLine(" First sorted container information:");
            AnimalContainer SortedContainer = container;
            SortedContainer.Sort(new AnimalsComparor());
            InOutUtils.PrintAnimals("First sorted container", SortedContainer);
            Console.WriteLine();
            Console.WriteLine(new string('-', 98));
            Console.WriteLine();

            Console.WriteLine(new string('-', 98));
            Console.WriteLine(" Second sorted container information:");
            AnimalContainer SecSortedContainer = container;
            SecSortedContainer.Sort(new AnimalsComparatorByName());
            InOutUtils.PrintAnimals("Second sorted container", SortedContainer);
            Console.WriteLine();
            Console.WriteLine(new string('-', 98));
            Console.WriteLine();
        }
    }
}
