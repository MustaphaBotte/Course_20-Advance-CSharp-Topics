using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class SimpleExample
    {
        public static async Task<string> HeavyWork()
        {
            Console.WriteLine("Task ID" + Thread.CurrentThread.ManagedThreadId); // main thread id
            await Task.Delay(5000);
            Console.WriteLine("Task ID" + Thread.CurrentThread.ManagedThreadId);// thread pool id
            return "Heavy Work done";
            // everything after await will be executed by thread pool 
        }
        static async Task Main1(string[] args)//rename it to Main
        {
            Console.WriteLine("Main ID " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Application Calling Heavy Work");

            Task<string> task= HeavyWork();

            Console.WriteLine("Some Other work");
            await task;


            Console.WriteLine("Application Done");
            Console.WriteLine(task.Result);

        }
    }
}
