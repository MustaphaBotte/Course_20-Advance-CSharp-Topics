using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using MessagePack;

[Serializable]
[MessagePackObject]
public partial class Person // partial class for privates cause message pack generate also a partial class
{
    [Key(0)]
    private string NationalNo = "WA450454"; 

    [Key(1)]
    public string Name { set; get; } = "";
    [Key(2)]
    public int Age { set; get; }

    [IgnoreDataMember]
    [Key(3)]
    private int PrivateAttribut=100; //this will be serialized because if the json function

    [IgnoreDataMember]
    public string N_No
    {
        get => this.NationalNo;
        set => this.NationalNo=value;
    }
    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
        NationalNo = "WA4545";
    }
    public Person() { }
}

public class Serialize
{
    public static void XML()
    {
        using (StreamWriter writer = new StreamWriter("../../../Object.xml", append: false,System.Text.Encoding.UTF8))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            List<Person> People = new List<Person>
            {
              new Person("Mustapha", 21),
              new Person("Ahmed", 21),
              new Person("Mohammed", 21),
              new Person("Said", 21),
              new Person("Karim", 21),
              new Person("Mounir", 21)
            };
            serializer.Serialize(writer, People);
        }


        using (StreamReader reader = new StreamReader("../../../Object.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            object? serialized = serializer.Deserialize(reader);
            List<Person>? People = serialized == null ? null : ((List<Person>)serialized);
            if (People != null)
            {
                foreach (Person person in People)
                {
                    Console.WriteLine("Name =" + person.Name);
                    Console.WriteLine("Age =" + person.Age);
                    Console.WriteLine("N_No =" + person.N_No);
                }
            }
        }
    }

    public static void JSON()
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));

        using (MemoryStream writer = new MemoryStream())
        {
            serializer.WriteObject(writer, new Person("Mustapha", 21));
            string DataString = System.Text.Encoding.UTF8.GetString(writer.ToArray());
            File.WriteAllText("../../../object.json", DataString);
        }
        
        using (FileStream reader = new FileStream("../../../object.json", FileMode.Open))
        { 
            object? serialized = serializer.ReadObject(reader);
            Person? person = serialized == null ? null : (Person)serialized;
            if (person != null)
            {          
                    Console.WriteLine("Name =" + person.Name);
                    Console.WriteLine("Age =" + person.Age);
                    Console.WriteLine("N_No =" + person.N_No);               
            }
        }
    }

    public static void Binary()
    {
        byte[] Binobject = MessagePackSerializer.Serialize<Person>(new Person("Mustapha", 21));
        File.WriteAllBytes("../../../object.bin", Binobject);

        using (FileStream reader = new FileStream("../../../object.bin",FileMode.Open))
        {
            Person? person = MessagePackSerializer.Deserialize<Person>(reader);
            if (person != null)
            {
                Console.WriteLine("Name =" + person.Name);
                Console.WriteLine("Age =" + person.Age);
                Console.WriteLine("N_No =" + person.N_No);
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Serialize.Binary();
        
    }
}
