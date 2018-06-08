using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace GerenciarEquipe.Services
{
    /// <summary>
    /// Classe responsável por criptografar dados.
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// Chave usada na criptografia
        /// </summary>
        private static string Key
        {
            get { return "b29bc307a05ff58f92551f7e7cfb927ac8e2b5cbc8d15b118b19cef9e0ebde58cd296bfa703f17c067020f63646908dd"; }
        }

        /// <summary>
        /// Criptografa uma string.
        /// </summary>
        /// <param name="str">String a ser criptografada.</param>
        /// <returns>String criptografada.</returns>
        public static string Encrypt(string str)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] PlainText = new UTF8Encoding().GetBytes(str);
            byte[] Salt = new UTF8Encoding().GetBytes(Key.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Key, Salt);
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(PlainText, 0, PlainText.Length);
            cryptoStream.FlushFinalBlock();

            byte[] CipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(CipherBytes).Replace("/", "_").Replace("+", "-");
        }

        /// <summary>
        /// Descriptografa uma string.
        /// </summary>
        /// <param name="Text">String a ser descriptografada.</param>
        /// <returns>String descriptografada.</returns>
        public static string DecryptString(string Text)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            byte[] EncryptedData = Convert.FromBase64String(Text.Replace("_", "/").Replace("-", "+"));
            byte[] Salt = new UTF8Encoding().GetBytes(Key.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Key, Salt);
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

            byte[] PlainText = new byte[EncryptedData.Length];
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);

            memoryStream.Close();
            cryptoStream.Close();

            return new UTF8Encoding().GetString(PlainText, 0, DecryptedCount);
        }

        /// <summary>
        /// Criptografa strings usando o padrão MD5.
        /// </summary>
        /// <param name="texto">Texto a ser criptografado.</param>
        /// <returns>String criptografada.</returns>
        public static string EncryptMD5(string texto)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(texto);
            buffer = provider.ComputeHash(buffer);
            StringBuilder strSaida = new StringBuilder();
            foreach (byte b in buffer)
            {
                strSaida.Append(b.ToString("x2").ToLower());
            }

            return strSaida.ToString();
        }

        // Verify a hash if is a MD5
        public static bool IsMD5(string texto)
        {
            return Regex.IsMatch(texto, "[0-9a-f]{32}");
        }

        // Verify a hash against a string.
        static bool VerifyMd5(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = EncryptMD5(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
