using System;
using System.Threading;

namespace _18.Parallel_programming_Resource_Deadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Comments
            //deadlock situation

            //Thread 1 acquires lock A.
            //Thread 2 acquires lock B.

            //Explanation
            //Thread 1 attempts to acquire lock B, but it is already held by Thread 2 as per the above and hence 
            //Thread 1 is blocked.

            //Thread 2 attempts to acquire lock A, but it is already held by Thread 1 as per the above and hence
            //Thread 2 is blocked.
            #endregion


            var bankAccounts = new BankAccounts();

            var thread1 = new Thread(() =>
            {
                bankAccounts.TransferFromCityBankToLombardBank(500);
            });

            Thread thread2 = new Thread(() =>
            {
                bankAccounts.TransferFromLombarBankToCitybank(500);
            });

            thread1.Start();
            thread2.Start();

            Console.ReadKey();
        }
    }

    class BankAccounts
    {
        private decimal CityBankBalance;
        private decimal LombardBankBalance;

        //these are my locks
        private object A = new object();
        private object B = new object();

        public BankAccounts()
        {
            // lets say we have that much on our accounts
            CityBankBalance = 1000;
            LombardBankBalance = 1000;
        }

        public void TransferFromCityBankToLombardBank(int amount)
        {
            lock (A)
            {
                //Simulate computing time to get the value;
                Thread.Sleep(100);
                CityBankBalance -= amount;

                lock (B)
                {
                    //Simulate computing time to get the value;
                    Thread.Sleep(100);
                    LombardBankBalance += amount;
                }
            }

            Console.WriteLine($"You transfered {amount} from your City bank account to your Lombard bank account.");
            Console.WriteLine($"Balance of your City bank account: {CityBankBalance}");
            Console.WriteLine($"Balance of your Lombard bank account: {LombardBankBalance}");
            Console.WriteLine();
        }

        public void TransferFromLombarBankToCitybank(int amount)
        {
            lock (B)
            {
                //Simulate computing time to get the value;
                Thread.Sleep(100);
                LombardBankBalance -= amount;

                lock (A)
                {
                    //Simulate computing time to get the value;
                    Thread.Sleep(100);
                    CityBankBalance += amount;
                }
            }

            Console.WriteLine($"You transfered {amount} from your Lombard bank account to your City bank account.");
            Console.WriteLine($"Balance of your City bank account: {CityBankBalance}");
            Console.WriteLine($"Balance of your Lombard bank account: {LombardBankBalance}");
            Console.WriteLine();
        }
    }
}
