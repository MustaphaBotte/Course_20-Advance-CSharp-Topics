using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;
namespace ConsoleApp1
{
    internal class ImgEnc
    {
        private static string path = "../../../Img.jpg";
        private static string EncryptedImg = "../../../EncryptedImg.jpg";
        private static string DecryptedImg = "../../../DecryptedImg.jpg";
        private static void Encrypt(string InputImg,string Output,byte[] Key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;
                using (FileStream InputStream = new FileStream(InputImg, FileMode.Open)) 
                using (FileStream OutputStream = new FileStream(Output, FileMode.Create))
                using (ICryptoTransform cryptor = aes.CreateEncryptor())
                using (CryptoStream cryptoStream = new CryptoStream(OutputStream,cryptor,CryptoStreamMode.Write))
                {
                    OutputStream.Write(aes.IV, 0, aes.IV.Length);
                    InputStream.CopyTo(cryptoStream);
                }
            }
        }
        private static void Dycrypt(string InputImg, string Output, byte[] Key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;
                using (FileStream InputStream = new FileStream(InputImg, FileMode.Open))
                {
                    InputStream.Read(aes.IV, 0, aes.IV.Length);
                    using (FileStream OutputStream = new FileStream(Output, FileMode.Create))
                    using (ICryptoTransform Decryptor = aes.CreateDecryptor())
                    using (CryptoStream cryptoStream = new CryptoStream(OutputStream, Decryptor, CryptoStreamMode.Write))
                    {
                        InputStream.Seek(aes.IV.Length, SeekOrigin.Begin);
                        InputStream.CopyTo(cryptoStream);
                    }
                } 
            }
        }
        static void Main(string[] args)
        {
            byte[] Key = new byte[16];
            RandomNumberGenerator.Create().GetBytes(Key);

            byte[] IV = new byte[16];
            RandomNumberGenerator.Create().GetBytes(IV);

            Encrypt(path, EncryptedImg, Key, IV);

            Dycrypt(EncryptedImg, DecryptedImg, Key, IV);
        }
    }
}
