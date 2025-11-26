using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;
namespace ConsoleApp1
{
    internal class Salting
    {
        private static string GenerateRandomSalt(int Workers)
        {
            return BCrypt.Net.BCrypt.GenerateSalt(Workers);
        }
        static void Main2(string[] args)//rename it to Main if you to run this entry
        {
            string Password = "mustapha";

            string Salt = GenerateRandomSalt(20);
            string Hash = BCrypt.Net.BCrypt.HashPassword(Password, Salt);
            Console.WriteLine(Salt);
            Console.WriteLine(Hash);

            Console.WriteLine(BCrypt.Net.BCrypt.Verify(Password,Hash));
        }
    }
}
