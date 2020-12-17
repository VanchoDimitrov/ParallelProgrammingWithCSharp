using System;
using System.Threading;

namespace _04.Thread_Thread_pool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main thread ID: " +
                $"{Thread.CurrentThread.ManagedThreadId}");

            Threadpool();

            Console.ReadLine();
        }

        public static void Threadpool()
        {
            // Check the Thread ID before Thread being placed inside a Thread pool
            Console.WriteLine($"Thread ID should be the same as Main method thread ID: " +
                $"{Thread.CurrentThread.ManagedThreadId}");

            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine($"Hello from the ThreadPool ID: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
