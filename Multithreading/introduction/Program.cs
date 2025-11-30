using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Thread t = new Thread(Function1);
            t.Start();

            Thread t2 = new Thread(delegate () { Function2("Func2"); });//parametrized thread using delegate
            t2.Start();

            Thread t3 = new Thread(() => Function2("Func3"));//parametrized thread using lambda
            t3.Start();

            ParameterizedThreadStart pts = new ParameterizedThreadStart(Function3);//parametrized thread using lambda ParameterizedThreadStart
            Thread t4 = new Thread(pts);
            t4.Start("Func4");


            t.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            // block the main tread until those two threads to finish

            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine("\t Main " + i);
            }

        }
        private static void Function1()
        {
            for(int i=0; i<= 20;i++)
            {
                Console.WriteLine("Func1 "+i);
            }
        }
        private static void Function2(string funcname)
        {
            for (int i = 0; i <= 20; i++)
            {

                Console.WriteLine($"{funcname} " + i);
            }
        }
        private static void Function3(object funcname)
        {
            for (int i = 0; i <= 20; i++)
            {

                Console.WriteLine($"{funcname} " + i);
            }
        }

    }
}
//Multithreading in C# refers to the concurrent execution of multiple threads within the same application.
//A thread is the smallest unit of execution in a process, and multithreading allows you to perform multiple 
//tasks simultaneously, improving performance and responsiveness in certain scenarios.
//Threading in C# allows you to create and manage threads to execute multiple operations concurrently.
//Multithreading is a powerful technique that can significantly improve the performance of applications that can benefit from concurrent execution of tasks. However, it also introduces challenges such as synchronization and coordination between threads. Therefore, careful design and understanding of multithreading concepts are essential for creating robust multithreaded applications in C#.
