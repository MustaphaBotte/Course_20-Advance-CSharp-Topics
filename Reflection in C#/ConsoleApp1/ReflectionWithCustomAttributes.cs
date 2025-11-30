using System;
using System.Reflection;

namespace _Reflection
{
    class Program2
    {
        [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method,AllowMultiple =false)]
        class DocumentaionAttribute: Attribute
        {
            public string Description { private set; get; } = "";
            public DocumentaionAttribute(string Description)
            {
                this.Description = Description;
            }
        }
        class AdditionalInfoAttribute : Attribute
        {
            public string Description { private set; get; } = "";
            public AdditionalInfoAttribute(string Description)
            {
                this.Description = Description;
            }
        }
        [Documentaion("Person That represent a person in our system")]
        class Person 
        {
            public string Name;
            public int Age;
            public string Address;
            public Person(string name, int age, string address)
            {
                Name = name;
                Age = age;
                Address = address;
            }
            [Documentaion("methos That send a fax to the person address")]
            [AdditionalInfo("procedure that take two parameters Subject and Content")]
            public void SendFax(string Subject,string Content)
            {
                Console.WriteLine($"Sending Fax to this address");

            }         
            [Documentaion("method That return info as a plain text")]
            [AdditionalInfo("return string and can be overridden")]
            public override string ToString()
            {
                return $"{Name}, Age: {Age}, Address: {Address}";
            }
        }

       
        static void Main1()//change the name to Main if you want run this file as an entry
        {
            Person p = new Person("mustapha", 21, "my address");
            Type type = typeof(Person);



            Console.WriteLine("============Class Attribute==============");
            foreach (DocumentaionAttribute attribute in type.GetCustomAttributes<DocumentaionAttribute>())
            {
                Console.WriteLine(type.FullName + " " + attribute.Description);
            }



            MethodInfo[] methods = type.GetMethods();
            Console.WriteLine("\n==============Methods Attribute=============");
            foreach(MethodInfo method in methods)
            {
                foreach (Attribute attribute in method.GetCustomAttributes<Attribute>())
                {
                    if(attribute is DocumentaionAttribute documentaion)
                    {
                        Console.WriteLine(method.Name + " " + documentaion.Description);
                    }
                    else if (attribute is AdditionalInfoAttribute additionalInfo)
                    {
                        Console.WriteLine(method.Name + " " + additionalInfo.Description);
                    }
                }             
            }

        }
    }
}