using System;
using System.Threading.Tasks;

namespace _08.Task_Task_Factory
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
            // parrent task
            var MainParentTask = Task.Run(() =>
            {
                // child tasks
                var nameLastName = new string[2];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);
                tf.StartNew(() => nameLastName[0] = "John");
                tf.StartNew(() => nameLastName[1] = "Doe");

                return nameLastName;
            });

            // combine tasks
            var combine = MainParentTask.ContinueWith(
            parentTask =>
            {
                foreach (string i in MainParentTask.Result)
                {
                    Console.Write(i + " ");
                }
            });
            combine.Wait();
        }
    }
}
