using Microsoft.Win32;

namespace ConsoleApp1
{
    internal class WritingFromRegistry
    {
        static void Main1(string[] args)//rename it to Main if you wanna run this file
        {
            try
            {
                Registry.SetValue(Registry.CurrentUser.ToString() + @"\SOFTWARE\DLMS", "admin", "admin");
                //writing only in CurrentUser (loged in user)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Remember to handle exceptions appropriately, as working with the Registry can result in exceptions if there are permission issues or if the specified key doesn't exist.
            }
        }
    }
}
