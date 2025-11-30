using System.Collections.Generic;
using System.Runtime.InteropServices;

class Entry2
{

    static void Main()
    {
        Nullable<int> ID = null; //Assign null value to integer
        //or in short
        int? ID2 = null;
        if (!ID.HasValue)
        {
            Console.WriteLine("Id Is null");
        }
        if (ID == null)
        {
            Console.WriteLine("Id Is null");
        }
        int TempID = ID ?? 0; //assign 0 to temp if ID isnull otherwise affect the id value
        Console.WriteLine(TempID);

        string? Name = null;//nullable
        Console.WriteLine("My name is "+Name?.ToLower()); //condition

        DateTime? date = DateTime.Now;
        Console.WriteLine(((DateTime)date).Day);
        date = null; //null datetime

    }
}