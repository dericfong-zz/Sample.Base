//using System;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;

//namespace Sample.Base.Core.Helpers
//{
//    public static class EncryptionHelper
//    {
//        public static string EncryptString(string text)
//        {
//            if (string.IsNullOrEmpty(text))
//                throw new ArgumentNullException("text");

//            byte[] encryptedBytes;
//            using (var aesAlg = GetRijndaelManaged())
//            {
//                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
//                {
//                    using (var msEncrypt = new MemoryStream())
//                    {
//                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//                        {
//                            using (var swEncrypt = new StreamWriter(csEncrypt))
//                            {
//                                swEncrypt.Write(text);
//                            }
//                        }

//                        encryptedBytes = msEncrypt.ToArray();
//                    }
//                }
//            }

//            return HttpServerUtility.UrlTokenEncode(encryptedBytes);
//        }

//        public static string DecryptString(string cipherText)
//        {
//            if (string.IsNullOrWhiteSpace(cipherText))
//                throw new ArgumentNullException("cipherText");

//            byte[] encryptedBytes;
//            try
//            {
//                encryptedBytes = System.Web.HttpServerUtility.UrlTokenDecode(cipherText);
//            }
//            catch (Exception)
//            {
//                throw new Exception("Cipher text is not encoded correctly");
//            }

//            string text;
//            using (var aesAlg = GetRijndaelManaged())
//            {
//                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
//                {
//                    using (var msDecrypt = new MemoryStream(encryptedBytes))
//                    {
//                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//                        {
//                            using (var srDecrypt = new StreamReader(csDecrypt))
//                            {
//                                text = srDecrypt.ReadToEnd();
//                            }
//                        }
//                    }
//                }
//            }

//            return text;
//        }

//        private static RijndaelManaged GetRijndaelManaged()
//        {
//            string EncryptionKey = AppDefs.AppSettings.EncryptionKey;
//            if (String.IsNullOrWhiteSpace(EncryptionKey))
//                throw new ArgumentNullException("EncryptionKey");

//            string EncryptionSalt = "EncryptionSaltValueString!@#";

//            var saltBytes = Encoding.ASCII.GetBytes(EncryptionSalt);
//            var key = new Rfc2898DeriveBytes(EncryptionKey, saltBytes);

//            var aesAlg = new RijndaelManaged();
//            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
//            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

//            return aesAlg;
//        }
//    }
//}
