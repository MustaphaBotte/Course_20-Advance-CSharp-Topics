using System;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Person
{
    //Mutable
    struct MutablePoint
    {
        public int X;
        public int Y;

        public MutablePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    //Immutable
    struct ImmutablePoint
    {
        public readonly  int X;
        public readonly  int Y;

        public ImmutablePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        public ImmutablePoint ChangeX(int newX) => new ImmutablePoint(newX, this.Y);
        public ImmutablePoint ChangeY(int newY) => new ImmutablePoint(this.X, newY);

    }

    //Mutable
    class MutablePerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public MutablePerson(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    //Immutable
    class ImmutablePerson
    {
        public readonly string Name;
        public readonly int Age;

        public ImmutablePerson(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public ImmutablePerson UpdateInfo(string name, int age)
        {
            return new ImmutablePerson(name, age);
        }
    }

    class program
    {
        public static void PrintList(List<int> data)
        {
            foreach(int num in data)
            {
                Console.Write(num+" ");
            }
            Console.WriteLine();
        }
        static void Main()
        {
           // ____________________________________ Value Types _______________________________________________
            //Each "modification" modify the original value 
            MutablePoint point1 = new MutablePoint(10, 20);
            point1.X = 30; 
            Console.WriteLine(point1.X); // here point1 is mutable so any change affect the original memory zone 


            //Each "modification" creates a copy
            ImmutablePoint Immpoint1 = new ImmutablePoint(10, 20);
            Console.WriteLine(Immpoint1.X);
            Immpoint1 = Immpoint1.ChangeX(20);
            Console.WriteLine(Immpoint1.X);// here Immpoint1 is immutable so any change will create a new instance

            // ____________________________________ reference Types _______________________________________________
            //Each "modification" modify the old object 
            MutablePerson me = new MutablePerson("mustapha", 21);
            Console.WriteLine(me.Name);
            me.Name="mohammed";
            Console.WriteLine(me.Name);// here person is mutable so any change affect the original memory zone 


            ImmutablePerson Imme = new ImmutablePerson("mustapha", 21);
            Console.WriteLine(Imme.Name);
            Imme = Imme.UpdateInfo("mohammed", 21);
            Console.WriteLine(me.Name);// here person is Immutable so any change will create a new instance (GC will clean the memory after)

            //------------------------------- more examples---------------------------------------
            string name = "ahmed";
            string tempname = name;
            //at this point both name and tempname pointing to the same memory address but this
            tempname = "My name is " + tempname;
            //will create a new instance and the old value of name is still unchanged:

            Console.WriteLine(name); //output: ahmed
            Console.WriteLine(tempname); // output: My name is ahmed

            //---------------------------- collections----------------------------
            List<int> data = new List<int> { 10, 20, 30, 40, 50 };
            List<int> Temp = data;
            Console.WriteLine(data==Temp); //true : same memory address

            Temp.Add(60);     // any change affect the orginal list so list is mutable
            PrintList(data);  // 10 20 30 40 50 60
            PrintList(Temp);  // 10 20 30 40 50 60

            //but 
            Temp.Append(70);  //append function  returning a new copy (we didn't affect the output to temp so 70 not exist in temp)
            PrintList(data);  // 10 20 30 40 50 60
            PrintList(Temp);  // 10 20 30 40 50 60

            //arrays are mutable
            int[] array = new int[] { 1, 2, 3 };
            int[] arraycopy = array;
            array[0] = 10; // Mutates the array no copy needed (both array and temparray pointing to the same memory address)

            //ImmutableList are Immutable
            var immutableNumbers = ImmutableList.Create(1, 2, 3);
            var newNumbers = immutableNumbers.Add(4); // Returns new list


            //to make string mutable use stringBuilderclass
            StringBuilder stringBuilder = new StringBuilder("hello");
            StringBuilder TempstringBuilder = stringBuilder;
            stringBuilder.Append(" world");

            Console.WriteLine(stringBuilder.ToString());     //back to string 
            Console.WriteLine(TempstringBuilder.ToString()); //back to string 

        }
    }
}