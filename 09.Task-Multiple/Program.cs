using System;
using System.Threading;
using System.Threading.Tasks;

namespace _09.Task_Multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipleTasks();

            Console.ReadKey();
        }

        static void MultipleTasks()
        {
            // array of Tasks
            var task1 = new Task[2];

            task1[0] = Task.Run(() =>
            {
                Thread.Sleep(3000); // simulate operation
                Console.Write("John" + " ");
                return 1;
            });
            task1[1] = Task.Run(() =>
            {
                Thread.Sleep(1000); // simulate operation
                Console.Write("Doe" + " ");
                return 2;
            });

            //Task.WaitAll(task1);
            //Task.WaitAny(task1);
        }
    }
}
