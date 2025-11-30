using Microsoft.Win32;
namespace ConsoleApp1
{
    internal class DeletingFromregistry
    {
        static void Main()
        {
            try
            {
                using (RegistryKey MainKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey SubKey = MainKey.OpenSubKey(@"SOFTWARE\DLMS",true))
                    {
                        if (SubKey != null)
                        {
                            SubKey.DeleteValue("admin");
                        }
                        else
                        {
                            Console.WriteLine("not found");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
