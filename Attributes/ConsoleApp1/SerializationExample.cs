using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    [Serializable]
    public class Person
    {
        [NonSerialized]
        public string Name= "";
        public int Id;
        public Person(string name,int id)
        {
            this.Id = id;
            this.Name = name;
        }
        public Person() { }
    }
    public static void json(Program.Person p)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(p.GetType());
        using(MemoryStream stream = new MemoryStream())
        {
            serializer.WriteObject(stream, p);
            string jsonobject =System.Text.Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(jsonobject);

            stream.Position = 0;
            Person? temp =(Person)serializer.ReadObject(stream);
            Console.WriteLine(temp.Name);
            Console.WriteLine(temp.Id);
            
        }

    }
    static void Main2() //rename it to Main to set it a an entry
    {
        Person p = new Person("mustapha", 1000);
        Program.json(p);
        //in this example we used two attributes:
        // [Serializable] : to make the class Serializable
        // and  [NonSerialized] to prevent a field from been Serializable
    }
}