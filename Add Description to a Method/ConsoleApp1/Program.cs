namespace methoddescription
{
    /// <summary>
    /// main class that contains the entry
    /// </summary>
    class Program
    {
        /// <summary>
        /// Use this method to print any thing on the console
        /// </summary>
        /// <param name="message">represent the message</param>
        private static void Printer(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// adds two numbers of int32
        /// </summary>
        /// <param name="num1">represent the first number to be added</param>
        /// <param name="num2">represent the second number to be added</param>
        /// <returns>int32 represent the sum of those two numbers</returns>
        private static  int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
       
        private static void Main()
        {
            Console.WriteLine(Sum(10,10));
            Program.Printer("hello");
        }
    }
}
