using System;
using System.Collections.Generic;
using System.Linq;

namespace _19.PLINQ_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parallel LINQ or PLINQ is a parallel implementation of the Language-Integrated Query or LINQ pattern.

            // 1. Data Source
            var numbers = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i);
            }

            // 2. Query

            // sequential processing
            var query0 = from n in numbers
                         select n;

            //parallel processing
            var query1 = from n in numbers.AsParallel()
                         select n;

            var query2 = (from n in numbers.AsParallel()
                          select n).ToList();

            var query3 = (from n in numbers
                          select n).ToList().AsParallel();

            // method query
            var query4 = numbers.AsParallel().AsOrdered();

            // 3. Execution
            foreach (var i in query4)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
