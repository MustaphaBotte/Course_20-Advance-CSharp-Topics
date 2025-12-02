using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static string DownloadFile(string Path)
        {
            WebRequest httpClient = HttpWebRequest.Create(Path);
            {
                WebResponse response = httpClient.GetResponse();
                using(Stream stream = response.GetResponseStream())
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
                        Console.WriteLine(content);
                        return content;
                    }
                }
            }          
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("started");
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            await Task.Run(() => { DownloadFile("https://www.amazon.com"); });
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("finished");
            Console.ReadLine();

            //Task.Run its just to simplify dealing with threads manually
            // it will execute your code in some pool threads
        }
    }
}
