using System;
using System.Threading;

namespace _01.Threads_Abort
{
    class Program
    {
        public static void Main(string[] args)
        {
            var thread1 = new Thread(new ThreadStart(Counter));
            thread1.Start();

            Console.WriteLine($"Thread started at ID: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Aborting thread...");

            thread1.Interrupt(); // Instead of Abort() use Interrupt() to stop a thread

            Console.WriteLine("Thread Aborted");
            Console.WriteLine($"Thread IsAlive: {thread1.IsAlive} Thread state: {thread1.ThreadState}");

            Console.ReadKey();
        }

        public static void Counter()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
