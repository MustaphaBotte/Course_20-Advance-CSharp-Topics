using System;
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
                      //  Console.WriteLine(content);
                        return content;
                    }
                }
            }
        }
        static async Task Main(string[] args)
        {
            

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            string URL = "https://www.amazon.com";

            TaskFactory<string> taskFactory = new TaskFactory<string>(tokenSource.Token,TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously,TaskScheduler.Default);

            Task<string> File1 = taskFactory.StartNew(() => DownloadFile(URL));
            Task<string> File2 = taskFactory.StartNew(() => DownloadFile(URL));
            Task<string> File3 = taskFactory.StartNew(() => DownloadFile(URL));
            try
            {
                Task.WaitAll(File1, File2, File3);
                Console.WriteLine(File1.Result.Length);
            }
            catch
            {
                tokenSource.Cancel(); // thiw will cancel them all in any error happend
            }

            Console.WriteLine("=================================================================================");
    

        }
    }
}
