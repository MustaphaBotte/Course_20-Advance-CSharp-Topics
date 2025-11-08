
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Custom_attribute
{
    class Program
    {
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
        class CustomAttribute : Attribute
        {
            public string Description { get; set; } = "";

            public CustomAttribute(string description)
            {
                Description = description;
            }
            public override string ToString()
            {
                return "Attribute description : "+this.Description;
            }
        }

        [Custom("This is a Class attribute")]
        class Book
        {
            public string ISBN { set; get; } = "";
            public string Name { set; get; } = "";
            public string Author { set; get; } = "";
            public string Description { set; get; } = "";
            public Book(string iSBN, string name, string author, string description)
            {
                ISBN = iSBN;
                Name = name;
                Author = author;
                Description = description;
            }
            [Custom("This is a Method attribute")]
            public void Print()
            {
                Console.WriteLine(this.Name);
                Console.WriteLine(this.ISBN);
                Console.WriteLine(this.Description);
                Console.WriteLine(this.Author);
            }
        }
       
        static void Main()
        {
            Book book = new Book("Testing", "Testing", "Testing", "Testing");
            book.Print();
            foreach (CustomAttribute attribute in book.GetType().GetCustomAttributes<CustomAttribute>(false))
            {
                Console.WriteLine(attribute.ToString());
            }
            //now we can read meta data of the class using reflection



            foreach (MethodInfo method in book.GetType().GetMethods())
            {
                string? desc = method.GetCustomAttribute<CustomAttribute>()?.Description;
                if(desc!=null)
                {
                    Console.WriteLine(method.Name+ " has attribute : "+ method.GetCustomAttribute<CustomAttribute>()?.Description);
                }// get CustomAttribute description for the class at run time using reflection
                if (desc == null)
                {
                    Console.WriteLine(method.Name + " have no attribute : ");
                }// get CustomAttribute description for the methods at run time using reflection
            }
        }
    }
}