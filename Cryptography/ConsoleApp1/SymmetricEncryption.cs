using BCrypt.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace ConsoleApp1
{
    internal class Symmetric
    {
        public static string Encrypt(string Key,string Text)
        {
            using (Aes aes = Aes.Create())
            {
                RandomNumberGenerator rng = RandomNumberGenerator.Create();
                rng.GetBytes(aes.IV);
                aes.Key = Encoding.UTF8.GetBytes(Key);

              using (ICryptoTransform cryptor =  aes.CreateEncryptor(aes.Key,aes.IV))
              {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        memoryStream.Write(aes.IV,0,aes.IV.Length);
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(Text);
                            }
                        }
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }
        public static string Dycrypt(string Key, string Text)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] Cipher = Convert.FromBase64String(Text);
                aes.Key = Encoding.UTF8.GetBytes(Key);
                int Ivsize = aes.BlockSize / 8;
                byte[] iv = new byte[Ivsize];
                Array.Copy(Cipher, 0, iv, 0, iv.Length);

                aes.IV = iv;
                using (ICryptoTransform cryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(Text)))
                    {
                        memoryStream.Seek(Ivsize, SeekOrigin.Begin);
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                               return  streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
        static void Main5(string[] args)//rename it to Main
        {
            byte[] Key=new byte[16];
            RandomNumberGenerator.Create().GetBytes(Key);
           
           string First = Symmetric.Encrypt(Convert.ToBase64String(Key),"mustapha");
           string Second = Symmetric.Encrypt(Convert.ToBase64String(Key), "mustapha");
            Console.WriteLine(First +"\n"+Second);

            First = Symmetric.Dycrypt(Convert.ToBase64String(Key), First);
            Second = Symmetric.Dycrypt(Convert.ToBase64String(Key), Second);
            Console.WriteLine(First + "\n" + Second);
        }
    }
}
