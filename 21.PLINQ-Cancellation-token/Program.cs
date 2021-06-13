using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _21.PLINQ_Cancellation_token
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'z')
                {
                    cts.Cancel();
                }

                Console.WriteLine("'z' key pressed.");
            });

            // 1. Data Source
            var numbers = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i);
            }

            // 2. Query


            //parallel processing
            // the data will not be in order. Hence AsOrdered() which runs in parallel.
            var query1 = (from n in numbers.AsParallel().WithDegreeOfParallelism(4).WithCancellation(cts.Token)
                          select n).ToList();

            // 3. Execution
            foreach (var i in query1)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
