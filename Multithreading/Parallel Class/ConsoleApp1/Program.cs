using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static string DownloadFile(string Path)
        {
            WebRequest httpClient = HttpWebRequest.Create(Path);
            {
                WebResponse response = httpClient.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        Console.WriteLine(Task.CurrentId);
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
                        Console.WriteLine("=========================================");
                        return content;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Parallel.For(0, 10,(i) =>{ DownloadFile("https://www.amazon.com"); });
            // each time we are creating a new task that use some thread from thread pool

            Console.WriteLine("******************************************************************************************");
            string[] Urls = new string[] { "https://www.amazon.com", "https://www.amazon.com", "https://www.amazon.com" };
            Parallel.ForEach(Urls, (url)=> DownloadFile(url));
            // again fro each url we are creating a new task that use some thread from thread pool
            Console.WriteLine("******************************************************************************************");

            string Url = "https://www.google.com";
            Parallel.Invoke(() => DownloadFile(Url), () => DownloadFile(Url), () => DownloadFile(Url));
            // again fro each function call we are creating a new task that use some thread from thread pool
            Console.WriteLine("******************************************************************************************");

        }
    }
}










//The Parallel class in C# provides a simple and efficient way to implement parallelism in your applications.
//It's particularly useful for scenarios where you need to perform operations concurrently across collections or
//execute multiple independent actions simultaneously.
//However, always consider thread safety and the nature of the tasks when using this class.

//Parallel.For: Executes a for loop in which iterations may run in parallel.
//Parallel.ForEach: Executes a foreach loop over any IEnumerable or IEnumerable<T> where iterations may run in parallel.
//Parallel.Invoke: Executes each provided Action in parallel.