using System.Collections.Generic;
using System.Runtime.InteropServices;

class Entry
{
    class ClsTest
    {
        char a; 
        int x;  
        char b;
    };
    struct Test
    {
        char a; //2 bytes
        int x;  //4 bytes
        char b; //2 bytes
    };//12 bytes in total
    struct Test2
    {
        char a; //2 bytes
        char b; //2 bytes
        int x;  //4 bytes

    };//8 bytes in total
    static void Main2()
    {
       // Nullable<int> ID = null; //Assign null value to integer
        double before = GC.GetTotalMemory(true);
        Console.WriteLine(((before) / 1000) / 1000 + " MB");
       // Test[] data = new Test[100000000];

        double after = GC.GetTotalMemory(true);
        unsafe
        {
            Console.WriteLine(sizeof(Test2));
            Console.WriteLine(((after-before)/1000)/1000 + " MB");
        }
    }
}