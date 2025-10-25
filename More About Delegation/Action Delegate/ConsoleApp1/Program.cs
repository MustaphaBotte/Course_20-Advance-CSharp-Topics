class Program
{

    public static void Printer()
    {
        Console.WriteLine("Hello World");
    }
    public static void MessagePrinter(string message)
    {
        Console.WriteLine(message);
    }
    static int Main()
    {
        Action ParameterLessAction = Printer;
        Action<string> ParameterdAction = MessagePrinter;

        // action is just built in delegate like func but for procedures (no return type and take up to 10 parameter)

        ParameterLessAction();
        ParameterdAction("Hello World");

        return 0;
    }
       


}