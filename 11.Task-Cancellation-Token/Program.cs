using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11.Task_Cancellation_Token
{
    class Program
    {
        static void Main()
        {

            ImportSource();

            Console.ReadKey();
        }

        public static void ImportSource()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            var task1 = Task.Run(() => Import(token), token);

            Thread.Sleep(500);

            // if we attempt to cancel the token
            CancelToken(cancellationTokenSource);
        }

        public static void CancelToken(CancellationTokenSource cancellationTokenSource)
        {
            Console.WriteLine("Cancellation in process!");
            cancellationTokenSource.Cancel();
        }

        static void Import(CancellationToken token)
        {
            int i = 0;
            do
            {
                Thread.Sleep(100);
                // check if the token is cancelled
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Token was cancelled");
                    break;
                }
                else
                {
                    Console.WriteLine("Importing data is in process!");
                    Import(token);
                    i++;
                }
               
            } while (i < 1);
        }
    }
}