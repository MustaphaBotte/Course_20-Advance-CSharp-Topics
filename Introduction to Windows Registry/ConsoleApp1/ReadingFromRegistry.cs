using Microsoft.Win32;

namespace ConsoleApp1
{
    internal class ReadingFromregistry
    {
        static void Main2(string[] args)//rename it to Main if you wanna run this file
        {
            try
            {
                string? Value = Registry.GetValue(Registry.CurrentUser.ToString() + @"\SOFTWARE\DLMS", "admin",null) as string;
                Console.WriteLine(Value);
                //reading from  CurrentUser (loged in user)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Remember to handle exceptions appropriately, as working with the Registry can result in exceptions if there are permission issues or if the specified key doesn't exist.
        }
    }
}
