using System;
using System.Threading;
using System.Threading.Tasks;

namespace _23.Asynchronous_development
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main function thread id: " + Thread.CurrentThread.ManagedThreadId);

            Start();

            Console.ReadKey();
        }

        static async Task Start()
        {
            var obj = new Program();
            await obj.Method1();
        }


        public async Task Method1()
        {
            Console.WriteLine("Method 1 out of Task runs on thread id: " + Thread.CurrentThread.ManagedThreadId);

            await Task.Run(() =>
            {
                Console.WriteLine(" runs inside Task, thread ID: " + Thread.CurrentThread.ManagedThreadId);
            });
        }
    }
}
