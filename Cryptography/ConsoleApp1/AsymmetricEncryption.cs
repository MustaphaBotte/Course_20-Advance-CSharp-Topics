using BCrypt.Net;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
namespace ConsoleApp1
{
    internal class ASymmetric
    {
        public static string Encrypt(string PublicKey,string Text)
        {
            using(RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
               RSA.FromXmlString(PublicKey);
                byte[] EncryptedData = RSA.Encrypt(Encoding.UTF8.GetBytes(Text),true);
                return Convert.ToBase64String(EncryptedData);
            }
        }
        public static string Dycrypt(string PrivateKey, string Cipher)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(PrivateKey);
                byte[] DecryptedData = RSA.Decrypt(Convert.FromBase64String(Cipher), true);
                return Encoding.UTF8.GetString(DecryptedData);
            }
        }
        static void Main(string[] args)
        {
            string Data = "HEllo world";

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                string PublicKey = RSA.ToXmlString(false);
                string PrivateKey = RSA.ToXmlString(true);

                Console.WriteLine("Public Key " + PublicKey+"\n");
                Console.WriteLine("Private Key " + PrivateKey+"\n");

                string cryptedtext = Encrypt(PublicKey, Data);
                Console.WriteLine("Encypted "+ cryptedtext);
                Console.WriteLine("Dycrypted " + Dycrypt(PrivateKey, cryptedtext));

                //part one will encrypt the data using part 2 public key
                //part two will decrypt the dara using his private key
                // and same for inverse
            }




        }
    }
}
