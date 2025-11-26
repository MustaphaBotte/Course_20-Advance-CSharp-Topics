using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Hashing
    {
        private static string ComputeHash(string input)
        {
           using (SHA256 sHA2_256 = SHA256.Create())
            {
                byte[] inpusAsBytes = Encoding.UTF8.GetBytes(input);
                byte[] HashAsBytes  = sHA2_256.ComputeHash(inpusAsBytes);
                return Convert.ToHexString(HashAsBytes);           
            }
        }
        static void Main1(string[] args)//rename it to Main if you to run this entry
        {
            string Password = "mustapha";

            string Hash = ComputeHash(Password);
            Console.WriteLine(Hash);          
        }
    }
}



//     Hash functions, by design, are one-way functions. This means that you cannot directly reverse a hash to retrieve the original data.
//     Hashing is primarily used for integrity verification and not for data retrieval.