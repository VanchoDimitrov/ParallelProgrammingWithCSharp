using System;
using System.Threading;
using System.Threading.Tasks;

namespace _15.TaskParallelLibrary_Cancel_Parallel_For_Parallel_For_Each
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


            Parallel.For(0, 100, i =>
            {
                Thread.Sleep(500);
                Console.WriteLine("{0} on Thread ID {1}", i, Thread.CurrentThread.ManagedThreadId);

                // if the cancellation token is being processed, stop the Parallel For loop
                po.CancellationToken.ThrowIfCancellationRequested();
            });

            Console.ReadKey();
        }
    }
}
