using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Obsolete_attribute
{
    class Program
    {
        [Obsolete("This method is deprecated and it will not included in our next versions\n use Program.Function2() instead")]
        public static void Function()
        {
            Console.WriteLine("The Obsolete attribute in C# is used to mark program entities (such as classes, methods, properties, etc.)\n"
            +"that are considered obsolete or deprecated.\n" +
            "This attribute informs developers that the marked entity should not be used because it is outdated or will be removed in future versions of the code.\n" + 
            "It also allows you to provide a custom message to suggest an alternative or explain the reason for deprecation.");
        }
        public static void Function2()
        {
            Console.WriteLine("New Function");
        }
        static void Main5() //rename it to Main to set it a an entry
        {
            Program.Function(); //IDE shows a green warning to the user with a deprecated message
            Program.Function2();
        }
    }
}