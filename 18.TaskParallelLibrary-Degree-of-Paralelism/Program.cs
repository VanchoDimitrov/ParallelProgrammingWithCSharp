using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _18.TaskParallelLibrary_Degree_of_Paralelism
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("New York");
            cities.Add("Dublin");
            cities.Add("London");
            cities.Add("Munich");
            cities.Add("Barcelona");
            cities.Add("Madrid");
            cities.Add("Moscow");
            cities.Add("Oslo");
            cities.Add("Skopje");

            // Assigning a value to MaxDegreeOfParallelism limits how many concurrent tasks will be used.
            Parallel.ForEach(cities, new ParallelOptions { MaxDegreeOfParallelism = 4 }, city =>
             {
                 Console.WriteLine("City Name: {0}, Thread Id= {1}", city, Thread.CurrentThread.ManagedThreadId);
             });

            Console.ReadKey();
        }
    }
}
