using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;

class Program
{
    class Person
    {
        public static DataTable GetAllPeople()
        {


            string ConnectionString = @"Server=.\MSSQLSERVER1;Database=DLMS; User=sa;Password=123456;TrustServerCertificate=True;";

            DataTable People = new DataTable();
            string Query = @"select * from people ";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(cmdText: Query, connection: sqlConnection))
                    {
                        sqlConnection.Open();
                        DataTable people = new DataTable();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        people.Load(sqlDataReader);
                        return people;
                        // the resources are released by clr calling Dispose
                    }
                }
            }
            catch (SqlException EX)
            {
                Console.WriteLine("Error code= " + EX.ErrorCode);
            }
            finally
            {

            }
            return null;
        }
    }

    class FileBytes: IDisposable
    {
        public byte[] Buffer = new byte[0];
        FileStream stream;
        public FileBytes(FileStream stream)
        {
            this.stream = stream;
            this.Buffer = new byte[stream.Length];
            stream.Read(Buffer,0, Buffer.Length);
        }
        public byte[] ReadBytes()
        {
            return this.Buffer;
        }
        public void Dispose()
        {
            if (stream != null)
            {
                stream.Close();
                Buffer = null; //the GC will collect it later
                Console.WriteLine("Hi im the cleaner . the clr called me");
            }
        }       
    }
    class ClsFile
    {
        private  FileStream Filecontent = null;
        string Path ="";
        public ClsFile(string Path)
        {
            this.Path = Path;
        }
        public FileBytes Read()
        {
            if (File.Exists(Path))
            {
                Filecontent = File.Open(Path, FileMode.Open);
                return new FileBytes(Filecontent);
            }
            return null;
        }
    }
    static void Main()
    {
        DataTable people = Person.GetAllPeople();
        foreach(DataRow row in people.Rows)
        {
            Console.WriteLine(row[0]);
        }
        ClsFile file = new ClsFile(@"..\..\..\ConsoleApp1.csproj");
        FileBytes fileBytes;
        using (fileBytes = file.Read())
        {
            foreach (byte databyte in fileBytes.Buffer)
            {
                Console.Write((char)databyte);
                // output = Hi im the cleaner . the clr called me
                //from dispose function 
            }
        }

        // i will get error here because the Buffer is no longer exists
        foreach (byte databyte in fileBytes.Buffer)
        {
            Console.Write((char)databyte);          
        }
    }

}