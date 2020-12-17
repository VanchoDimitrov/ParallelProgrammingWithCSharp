using System;
using System.Threading;
using System.Threading.Tasks;

namespace _01.Task_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

            MyName();

            Console.ReadKey();
        }

        public static void MyName()
        {
            Console.WriteLine($"MyName Thread ID before Task: {Thread.CurrentThread.ManagedThreadId}");

            var task1 = Task.Run(() =>
                Console.WriteLine($"John Doe, wunning on a Thread ID: {Thread.CurrentThread.ManagedThreadId}")
            );
        }
    }
}
