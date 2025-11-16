using Microsoft.Win32;
namespace ConsoleApp1
{
    internal class PermissionToWrite
    {       
        static void Main(string[] args)
        {             
            try
            {
                 Registry.SetValue(Registry.LocalMachine + @"\SOFTWARE\DLMS", "admin", "admin",RegistryValueKind.String);
                // if your app is 32bit this key &value will be written to HKyemachine/wow6432bit
                // The redirection is mainly implemented at the machine level (HKEY_LOCAL_MACHINE)
                // to avoid conflicts in a shared space between 32-bit and 64-bit applications.
                Console.WriteLine("operation success");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //we you will try to execute the program
            //windows will ask for adminastrator permissions
            // [application.manifest]
        }
    }
}
 