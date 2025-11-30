using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static int Counter = 0;
        public static object Locker=new object();
        public static void Increment()
        {
            for(int i=0;i<100000000;i++)
            {
                lock (Locker)
                {
                    
                    Counter += 1;
                }
            }
        }
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(Increment);
            //t1.Start();


            //Thread t2 = new Thread(Increment);
            //t2.Start();

            //t1.Join();
            //t2.Join();

            Console.WriteLine("Incrementing Finish :"+Counter);
            // WITOUT LOCK YOU WILL GET INCORRECT RESULT BECAUSE MULTIPLE 
            // THREADS INCREMENTING THE SAME VALUE IN THE SAME TIME
            // THE LOCK WILL CONTROL THE ORDER USING FIFO 
            // ALWAYS USE OBJECT IN LOCK DONT USE STRING BECAUSE IN .NET THE git add .gitSTRING IS INTERNING
        }
    }
}
