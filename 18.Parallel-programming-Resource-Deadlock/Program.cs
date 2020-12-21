using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlankCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Thread 1 acquires Lock A
            // Thread 2 acquires Lock B

            // Explanation
            // Thread 1 attemnts to acquire lock B, but it is already held by Thread 2 as per the above hence
            // Thread 1 is blocked.

            // Thread 2 attemnts to acquire lock A, but it is already held by Thread 1 as per the above hence
            // Thread 2 is blocked.

            var registers = new CashRegisters();

            var thread1 = new Thread(() =>
            {
                registers.TransferFromRegister1ToRegister2(500);
            });

            var thread2 = new Thread(() =>
            {
                registers.TransferFromRegister2ToRegister1(500);
            });

            var thread3 = new Thread(() =>
            {
                registers.TransferFromRegister2ToRegister1(300);
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadKey();
        }

        class CashRegisters
        {
            private decimal Register1Balance;
            private decimal Register2Balance;

            // locks
            private object A = new object();
            private object B = new object();

            public CashRegisters()
            {
                this.Register1Balance = 1000;
                this.Register2Balance = 1000;
            }

            public void TransferFromRegister1ToRegister2(decimal amount)
            {
                lock (A)
                {
                    // Simulate
                    Thread.Sleep(100);
                    Register1Balance -= amount;

                    lock (B)
                    {
                        Thread.Sleep(100);
                        Register2Balance += amount;
                    }
                }

                Console.WriteLine($"You transfered {amount} from Register 1 to Register 2");
                Console.WriteLine($"Balance of Register 1 {Register1Balance} Balance of Register 2 is {Register2Balance}");
                Console.WriteLine();
            }

            public void TransferFromRegister2ToRegister1(decimal amount)
            {
                lock (A)
                {
                    Thread.Sleep(100);
                    Register2Balance -= amount;

                    lock (B)
                    {
                        Thread.Sleep(100);
                        Register1Balance += amount;
                    }
                }

                Console.WriteLine($"You transfered {amount} from Register 2 to Register 1");
                Console.WriteLine($"Balance of Register 2 {Register1Balance} Balance of Register 1 is {Register2Balance}");
                Console.WriteLine();
            }
        }
    }
}
