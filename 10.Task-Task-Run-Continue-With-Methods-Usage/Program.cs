using System;
using System.Threading;
using System.Threading.Tasks;

namespace _10.Task_Task_Run_Continue_With_Methods_Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            Console.WriteLine(Name() + $" runs on a thread id {Thread.CurrentThread.ManagedThreadId}")
            ).ContinueWith(t =>
            Console.Write(LastName() + $" runs on a thread id {Thread.CurrentThread.ManagedThreadId}")
            ).Wait();

            Console.ReadKey();
        }

        static string Name()
        {
            return "John";
        }

        static string LastName()
        {
            return "Doe";
        }
    }
}
