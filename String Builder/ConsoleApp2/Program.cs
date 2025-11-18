using System.Diagnostics;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void Concatenation(string Value,int Count)
        {
            string result="";
            for(int i=0;i<Count;i++)
            {
                result += Value;
            }

        }
        public static void ConcatenationUsingBuilder(string Value, int Count)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                result.Append(Value);
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Concatenation("mustapha", 1000);
            stopwatch.Stop();

            long CurrentMemoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine("memory :" + (CurrentMemoryAfter));
            Console.WriteLine("Time :" + stopwatch.ElapsedMilliseconds);


            Stopwatch stopwatch2 = Stopwatch.StartNew();
            long CurrentMemory = GC.GetTotalMemory(true);
            ConcatenationUsingBuilder("mustapha", 1000);
            stopwatch2.Stop();

            long CurrentMemoryAfter2 = GC.GetTotalMemory(true);
            Console.WriteLine("memory :" + (CurrentMemoryAfter2 - CurrentMemory));
            Console.WriteLine("Time :" + stopwatch2.ElapsedMilliseconds);
            GC.Collect();


            //summart
            //normal string in every += create a new string (immutable)
            //string builder in every .append just modify the internal buffer no copy needed (only in same cases when the buffer is full) 

        }
    }
}
