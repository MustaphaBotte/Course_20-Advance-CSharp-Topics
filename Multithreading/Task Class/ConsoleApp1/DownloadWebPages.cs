using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp1.Program;
namespace ConsoleApp1
{
    internal class Program
    {
        public class DownloadedDataEventArgs : EventArgs
        {
            public byte[] Result = new byte[0];
            public int Length = 0;
            public DownloadedDataEventArgs(byte[] Result)
            {
                this.Result = Result;
                this.Length = Result.Length;
            }
        }
        public static async Task<byte[]> DownloadWebPageAsync(string Url, EventHandler<DownloadedDataEventArgs> CallBack)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    byte[] data = new byte[0];
                    web.Headers[HttpRequestHeader.UserAgent] =
                                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                                "(KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36";
                    web.Headers[HttpRequestHeader.Accept] =
                        "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    web.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.9";

                    TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
                    web.DownloadDataCompleted += (sender, e) =>
                    {
                        CallBack.Invoke(null,new DownloadedDataEventArgs(e.Result));
                        tcs.SetResult(e.Result);
                    };
                    web.DownloadDataAsync(new Uri(Url));
                    return await tcs.Task;
               }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new byte[0];
            }
        }
        public static void PrintDataInfo(object? sender,DownloadedDataEventArgs eventArgs)
        {
            Console.WriteLine($"bytes are fetched with success. Size ={eventArgs.Length} Bytes");
        }
        static  async Task Main(string[] args)
        {
            string url = "https://www.itgovernanceusa.com/files/Contents_Writing_Secure_Code.pdf";
            Console.WriteLine("Download Started");
            Task File1 = DownloadWebPageAsync(url, PrintDataInfo);
            Task File2 = DownloadWebPageAsync(url, PrintDataInfo);
            Task File3 = DownloadWebPageAsync(url, PrintDataInfo);
            Task File4 = DownloadWebPageAsync(url, PrintDataInfo);
            await Task.WhenAll(File1, File2, File3,File4);
            Console.WriteLine("Download Finished");
        }
    }
}
