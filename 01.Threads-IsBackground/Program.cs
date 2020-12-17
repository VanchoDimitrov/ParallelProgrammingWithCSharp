using System;
using System.Threading;

namespace _01.Threads_IsBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(new ThreadStart(PrintMyName));
            thread1.IsBackground = true;
            thread1.Start();

            Console.WriteLine($"Main Thread at Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Is it background thread: {thread1.IsBackground}");

            Console.ReadKey();
        }

        public static void PrintMyName()
        {
            Thread.Sleep(1000); // simulate operation
            Console.WriteLine($"John Doe: at Thread ID: {Thread.CurrentThread.ManagedThreadId}");

        }
    }
}
