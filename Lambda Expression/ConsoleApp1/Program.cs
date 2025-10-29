
class Entry
{
    public static Func<int, int> SquareEvent = x =>  x * x; //note : if you have multiple parameters then parentheses are mandatory (x,y) not x,y
    public static Action<string> SayHelloEvent = (message)=> { Console.WriteLine(message); };
    public  delegate void FileOpener(string path);

    
    public static void OpenFile(string path, FileOpener opener)
    {
        opener(path);
    }
    public static void OpenFile(string path, Action<string> opener)
    {
        opener(path);
    }
    public static void Main()
    {
        Console.WriteLine("Lambda expression " + Entry.SquareEvent(10));
        Entry.SayHelloEvent.Invoke("Hi Im lambda");
        FileOpener opener = (path) => { Console.WriteLine($"we are opening {path}"); };
        Entry.OpenFile("File.txt", opener);

        Action<string> opener2 = (path) => { Console.WriteLine($"we are opening {path}"); };
        opener2+= (path) => { Console.WriteLine($"opening {path}"); };
        Entry.OpenFile("File.txt",opener2);
        /////////////////////////////////////////////////////////////////////////////////
        Func<int> CreateCounter()
        {
            int count = 0; // Local variable

            // This lambda CAPTURES the 'count' variable
            return () => {
                count++;    // Can modify the captured variable!
                return count;
            };
        }

        var counter = CreateCounter();
        Console.WriteLine(counter()); // Output: 1
        Console.WriteLine(counter()); // Output: 2
        Console.WriteLine(counter()); // Output: 3
    }
}
