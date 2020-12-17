using System;
using System.Threading.Tasks;

namespace _12.TaskParallelLibrary_Introduction
{
    class Program
    {
        // Set of public types and APIs in the Task and Threading namespaces.
        // starting with the .NET 4 onwards
        static void Main(string[] args)
        {
            var sourceCollection = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "k" };

            Console.WriteLine("Sequential execution");
            foreach (var item in sourceCollection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Parallel execution");
            Parallel.ForEach(sourceCollection, item =>
            {
                Console.WriteLine(item);
            });

            Console.ReadKey();
        }
    }
}
