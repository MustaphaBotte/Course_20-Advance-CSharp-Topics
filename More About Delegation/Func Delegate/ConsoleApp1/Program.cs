using System.Reflection.Metadata;
using static Math;

class Math
{
    public delegate int MathDelegate(int Num1, int Num2);
    public MathDelegate Handler ;
    public int InvokeFunctions(int Num1, int Num2)
    {
       return Handler?.Invoke(Num1, Num2)??0;
    }
}
class MathUsingFunc
{
    public event Func<int,int,int> MathEvent;
    public void InvokeFunctions(int Num1, int Num2)
    {
        foreach (Func<int, int, int> handler in MathEvent.GetInvocationList())
        {
            Console.WriteLine(handler(100, 20));
        }
    }
}
class Program
{
    public static int Sum(int Num1, int Num2)
    {
        return Num2 + Num1;
    }
    public static int Sub(int Num1, int Num2)
    {
        return Num1-Num2  ;
    }
    public static int Mult(int Num1, int Num2)
    {
        return Num2 * Num1;
    }
    public static int Div(int Num1, int Num2)
    {
        return Num1/Num2 ;
    }
    static void Main()
    {
        Math mathDelegate = new Math();
        mathDelegate.Handler += Sum;
        mathDelegate.Handler += Sub;
        mathDelegate.Handler += Mult;
        mathDelegate.Handler += Div;

        //Console.WriteLine(mathDelegate.InvokeFunctions(20, 20));//this will print last invoked function result

        foreach (Math.MathDelegate handler in mathDelegate.Handler.GetInvocationList())
        {
            Console.WriteLine(handler(100, 20));
        }

        // we can simplify the delegate declaration by using Func
        MathUsingFunc mathUsingFunc = new MathUsingFunc();
        mathUsingFunc.MathEvent += Sum;
        mathUsingFunc.MathEvent += Sub;
        mathUsingFunc.MathEvent += Mult;
        mathUsingFunc.MathEvent += Div;

        //foreach (Math.MathDelegate handler in mathUsingFunc.MathEvent.GetInvocationList())
        //{
        //    Console.WriteLine(handler(100, 20));
        //} // you cant GetInvocationList out side the event class
        // so i put the console.write in the InvokeFunctions
        mathUsingFunc.InvokeFunctions(100,20);
    }
}