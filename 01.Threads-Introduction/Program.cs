using System;
using System.Threading;

namespace _01.Threads_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thread – Allocation of a CPU time to a process.

            var thread1 = new Thread(new ThreadStart(SayHello));

            thread1.Start();

            Thread.Sleep(3000); // simulate operation
            Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

            // If we do Join then the threads join as the main thread ID
            //thread1.Join();
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //SayHello();

            // Print if thread1 is still alive or not
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + $" IsAlive: {thread1.IsAlive}");

            // print the thread state
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + $" Thread State: {thread1.ThreadState}");

            Console.ReadKey();
        }

        public static void SayHello()
        {
            Thread.Sleep(5000); // simulate some operation
            Console.WriteLine($"Hello from Method thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
