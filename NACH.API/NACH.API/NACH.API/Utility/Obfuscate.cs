using System.Security.Cryptography;
using System.Text;

namespace NACH.API.Utility
{
    public class Obfuscate
    {
        private static string CurrentKey = "%&@#,?*:";

        public static string Encrypt(string strText, out bool isSuccess)
        {
            isSuccess = false;
            return Obfuscate.ObfuscateString(strText, Obfuscate.CurrentKey, out isSuccess);
        }

        public static string Decrypt(string strText, out bool isSuccess)
        {
            isSuccess = false;
            return Obfuscate.ClarifyString(strText, Obfuscate.CurrentKey, out isSuccess);
        }

        private static string ObfuscateString(string strText, string strEncrKey, out bool isSuccess)
        {
            isSuccess = true;
            string text = "";
            try
            {
                if (string.IsNullOrEmpty(strText))
                {
                    isSuccess = false;
                    text = "The string which needs to be encrypted can not be null.";
                    return text;
                }
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                byte[] bytes = Encoding.ASCII.GetBytes(strEncrKey);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(strText);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                streamWriter.Flush();
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                return strText;
            }
        }


        private static string ClarifyString(string strText, string sDecrKey, out bool isSuccess)
        {
            isSuccess = true;
            string text = "";
            try
            {
                if (string.IsNullOrEmpty(strText))
                {
                    isSuccess = false;
                    text = "The string which needs to be decrypted can not be null.";
                    return text;
                }
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream(Convert.FromBase64String(strText));
                byte[] bytes = Encoding.ASCII.GetBytes(sDecrKey);
                return new StreamReader(new CryptoStream(stream, dESCryptoServiceProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read)).ReadToEnd();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                return strText;
            }
        }



    }
}
