using System;
using System.Threading;
using System.Threading.Tasks;

namespace _06.Task_return_value
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

            MyName();

            Console.ReadKey();
        }

        public static string MyName()
        {
            Console.WriteLine($"MyName Thread ID before Task: {Thread.CurrentThread.ManagedThreadId}");

            var task1 = Task.Run(() =>
            {
                return $"John Doe, running on a thread ID: {Thread.CurrentThread.ManagedThreadId}";
            });

            return task1.Result;
        }
    }
}
