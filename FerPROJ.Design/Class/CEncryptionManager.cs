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
        #region Encrypt Text
        public static string EncryptText(string plainText, string privateKey = null)
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

        #region Encrypt File
        public static void EncryptFile(string inputFile, string outputFile, string privateKey = null) {
            byte[] key = new Rfc2898DeriveBytes(GetKey(privateKey), Encoding.UTF8.GetBytes(GetKey(privateKey))).GetBytes(32);

            using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
            using (Aes aes = Aes.Create()) {
                aes.Key = key;
                aes.GenerateIV();
                fsOut.Write(aes.IV, 0, aes.IV.Length);

                using (CryptoStream cs = new CryptoStream(fsOut, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open)) {
                    fsIn.CopyTo(cs);
                }
            }
        }
        #endregion

        #region Decrypt Text
        public static string DecryptText(string cipherText, string privateKey = null)
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

        #region Decrypt File
        public static void DecryptFile(string inputFile, string outputFile, string privateKey = null) {
            byte[] key = new Rfc2898DeriveBytes(GetKey(privateKey), Encoding.UTF8.GetBytes(GetKey(privateKey))).GetBytes(32);

            using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
            using (Aes aes = Aes.Create()) {
                byte[] iv = new byte[16];
                fsIn.Read(iv, 0, iv.Length);
                aes.Key = key;
                aes.IV = iv;

                using (CryptoStream cs = new CryptoStream(fsIn, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (FileStream fsOut = new FileStream(outputFile, FileMode.Create)) {
                    cs.CopyTo(fsOut);
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
