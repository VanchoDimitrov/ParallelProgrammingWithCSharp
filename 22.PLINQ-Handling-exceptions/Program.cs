using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _22.PLINQ_Handling_exceptions
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
                    cts.Cancel();

                Console.WriteLine("Press any key to exit");
            });

            // 1. Data Source
            var numbers = new List<int>();

            for (int i = 0; i < 10000; i++)
            {
                numbers.Add(i);
            }

            // 2. Query

            try
            {
                //parallel processing
                // the data will not be in order. Hence AsOrdered() which runs in parallel.
                var query1 = from n in numbers.AsParallel().WithDegreeOfParallelism(4).WithCancellation(cts.Token)
                             select n;

                // 3. Execution
                foreach (var i in query1)
                    Console.WriteLine(i);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions != null)
                    foreach (Exception e in ae.InnerExceptions)
                        Console.WriteLine(e.Message);                
            }


            Console.ReadKey();
        }
    }
}
