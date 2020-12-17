using System;
using System.Threading.Tasks;

namespace _07.Task_Task_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNameLastName();

            Console.ReadLine();
        }

        public static void GetNameLastName()
        {
            // parrent Task
            var mainTask = Task.Run(() =>
            {
                // child tasks
                var nameLastName = new string[2];
                new Task(() => nameLastName[0] = "John",
                    TaskCreationOptions.AttachedToParent).Start();

                new Task(() => nameLastName[1] = "Doe",
                    TaskCreationOptions.AttachedToParent).Start();

                return nameLastName;
            });

            // combine child tasks
            var combine = mainTask.ContinueWith(
            MainParentTask =>
            {
                foreach (string i in MainParentTask.Result)
                {
                    Console.Write(i + " ");
                }
            });
        }
    }
}
