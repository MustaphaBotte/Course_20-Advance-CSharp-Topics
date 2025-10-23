delegate bool Holder(int x);
public class Program
{
    class Calculator()
    {
        public static void CheckNumber(int x,Holder deleg)
        {
            if(deleg.Invoke(x))
            {
                Console.WriteLine("Bigger Than 0");
            }
            else
            {
                Console.WriteLine("less Than 0");
            }
        }
    }
    public static  bool FirstMethodcheck(int x)
    {
        return x > 0;
    }
    public static bool SecondMethodcheck(int x) => x > 0;

    static void Main()
    {
        Calculator.CheckNumber(10, (int x) => { return x > 0; });
        Calculator.CheckNumber(10, delegate(int x){ return x > 0; });
        Calculator.CheckNumber(10, x => { return x > 0; });
        Calculator.CheckNumber(10, SecondMethodcheck);
        Calculator.CheckNumber(10, FirstMethodcheck);
    }
}