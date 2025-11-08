#define Condition
using System.Diagnostics;
using System;

namespace Conditional_Attribute
{
    class Program
    {

        [Conditional("DEBUG")]
        public static void DebugMethod()
        {
            Console.WriteLine("Debug Method executed");
        }      
        [Conditional("Condition")]
        public static void Loger()
        {
            Console.WriteLine("Log Method executed");
        }
        public static void NormalMethod()
        {
            Console.WriteLine("Normal Method executed");
        }
        static void Main3()//rename it to Main to set it a an entry
        {          
            Program.DebugMethod(); //compiled only in debug mode
            Program.NormalMethod();//compiled in both of them debug and release
           //Note : [Conditional("DEBUG")] works only with voids
           // _________________________________________________________________________
           Program.Loger(); //executed only if the condition above the function is declared in the file head or in .csproj



            // here (compiler decide which code to include based on the mode)
            #if DEBUG
                  Console.WriteLine("Debug");        
            #else
                 Console.WriteLine("release");
            #endif
                 Console.WriteLine("Always executed");

        }
    }
}

