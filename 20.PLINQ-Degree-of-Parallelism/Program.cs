using System;
using System.Collections.Generic;
using System.Linq;

namespace _20.PLINQ_Degree_of_Parallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Data Source
            var numbers = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i);
            }

            // 2. Query

            //parallel processing
            // the data will not be in order. Hence AsOrdered() which runs in parallel.
            var query1 = from n in numbers.AsParallel().WithDegreeOfParallelism(4).AsOrdered()
                         select n;

            var query2 = (from n in numbers.AsParallel()
                          select n).ToList();

            var query3 = (from n in numbers
                          select n).ToList().AsParallel();

            // 3. Execution
            foreach (var i in query1)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
