using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _16.TaskParallelLibrary_Cancel_Parallel_For_Each
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // Store the CancellationToken
            var po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            Console.WriteLine("Press 'z' to cancel.");

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'z')
                    cts.Cancel();

                Console.WriteLine("Press any key to exit");
            });

            // add some numbers in the collection
            var numbers = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine("Parallel.For");
            // parallel loop through the collection
            Parallel.For(0, numbers.Count, i =>
            {
                Thread.Sleep(900);
                Console.WriteLine("Number: {0}, Thread Id= {1}", numbers[i], Thread.CurrentThread.ManagedThreadId);

                // if the cancellation token is being processed, stop the Parallel For loop
                po.CancellationToken.ThrowIfCancellationRequested();
            });

            Console.WriteLine();

            Console.WriteLine("Parallel.ForEach");
            Parallel.ForEach(numbers, number =>
            {
                Thread.Sleep(900);
                Console.WriteLine("Number: {0}, Thread Id= {1}", number, Thread.CurrentThread.ManagedThreadId);

                // if the cancellation token is being processed, stop the Parallel For loop
                po.CancellationToken.ThrowIfCancellationRequested();
            });

            Console.ReadKey();
        }
    }
}
