using System.Configuration;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings ConnectiontoDb = ConfigurationManager.ConnectionStrings["connection"];



            string projectname = ConfigurationManager.AppSettings["ApplicationName"] ?? "";
            string version = ConfigurationManager.AppSettings["Version"] ?? "";

            Console.WriteLine(ConnectiontoDb.Name);
            Console.WriteLine(ConnectiontoDb.ConnectionString);
            Console.WriteLine(ConnectiontoDb.ProviderName);
            Console.WriteLine(ConnectiontoDb.Name);

            Console.WriteLine(projectname);
            Console.WriteLine(version);


            //app.config after compile time moved to the bin folder and renamed to projectname.dll.config

        }
    }
}
