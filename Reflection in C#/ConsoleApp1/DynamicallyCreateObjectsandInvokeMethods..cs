using System;

namespace _Reflection
{ 
    class ClsType
    {
        class test
        {
            public string name = "";
        }
        static void Main2()//change the name to Main if you want run this file as an entry
        {
            Type type = typeof(Type);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type.IsValueType);
            Console.WriteLine(type.IsClass);
            Console.WriteLine(type.Attributes);
            Console.WriteLine(type.BaseType);
            Console.WriteLine(type.DeclaringType);
            Console.WriteLine(type.IsInterface);

        }
    }
}