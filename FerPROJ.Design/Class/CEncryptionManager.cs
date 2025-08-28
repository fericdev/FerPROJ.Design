using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class
{
    public class CEncryptionManager
    {
        #region Encrypt
        public static string Encrypt(string plainText, string privateKey = null)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(GetKey(privateKey));
                aesAlg.IV = new byte[aesAlg.BlockSize / 8]; // IV (Initialization Vector) can be random

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        #endregion

        #region Decrypt
        public static string Decrypt(string cipherText, string privateKey = null)
        {
            if (string.IsNullOrEmpty(cipherText)) {
                return string.Empty;
            }
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(GetKey(privateKey));
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        private static string GetKey(string privateKey = null) {
            string text = privateKey ?? "FerPROJ";
            byte[] textBytes = Encoding.UTF8.GetBytes(text);

            using (MD5 md5 = MD5.Create()) {
                byte[] hashBytes = md5.ComputeHash(textBytes);
                string hashHex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashHex;
            }
        }
        #endregion
    }
}
