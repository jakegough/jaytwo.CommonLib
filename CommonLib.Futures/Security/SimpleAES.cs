using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web;
using System.Linq;

namespace jaytwo.Common.Security
{
    public class SimpleAES
    {
        public static SimpleAES CreateFromKey(string keyHex)
        {
            byte[] key = HexToByteArray(keyHex);
            return new SimpleAES(key);
        }

        public static SimpleAES CreateFromBase64(string base64)
        {
            byte[] key = Convert.FromBase64String(base64);
            return new SimpleAES(key);
        }

        public static SimpleAES CreateFromPassphrase(string passphrase)
        {
            var key = GetKeyFromPassphrase(passphrase);
            return new SimpleAES(key);
        }

        public byte[] Key { get; private set; }
        private UTF8Encoding encoder;

        public SimpleAES(byte[] key)
        {
            Key = key;
            encoder = new UTF8Encoding();
        }

        public string EncryptString(string clearText)
        {
            var decryptedBytes = encoder.GetBytes(clearText);
            var encryptedBytes = EncryptBytes(decryptedBytes);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string DecryptString(string encryptedText)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var decryptedBytes = DecryptBytes(encryptedBytes);
            return encoder.GetString(decryptedBytes);
        }

		public string EncryptStringAsUrlToken(string clearText)
		{
			var bytesToEnrypt = encoder.GetBytes(clearText);
			var result = EncryptBytesAsUrlToken(bytesToEnrypt);
			return result;
		}

		public string DecryptUrlTokenAsString(string encryptedText)
		{
			var decryptedBytes = DecryptUrlTokenAsBytes(encryptedText);
			var result = encoder.GetString(decryptedBytes);
			return result;
		}

        public byte[] EncryptBytes(byte[] buffer)
        {
            using (var crypto = CreateAesCryptoServiceProvider())
            using (var encryptor = crypto.CreateEncryptor())
            {
                var encrypted = Transform(buffer, encryptor);
                var result = crypto.IV.Concat(encrypted).ToArray();

                return result;
            }
        }

        public byte[] DecryptBytes(byte[] buffer)
        {
            using (var crypto = CreateAesCryptoServiceProvider())
            {
                var initializationVectorSizeBytes = (crypto.BlockSize / 8);
                var initializationVector = buffer.Take(initializationVectorSizeBytes).ToArray();
                var encrypted = buffer.Skip(initializationVectorSizeBytes).ToArray();

                using (var decryptor = crypto.CreateDecryptor(crypto.Key, initializationVector))
                {
                    return Transform(encrypted, decryptor);
                }
            }
        }

		public string EncryptBytesAsUrlToken(byte[] buffer)
		{
			var encryptedBytes = EncryptBytes(buffer);
			var result = HttpServerUtility.UrlTokenEncode(encryptedBytes);
			return result;
		}

		public byte[] DecryptUrlTokenAsBytes(string encryptedText)
		{
			var bytesToDecrypt = HttpServerUtility.UrlTokenDecode(encryptedText);
			var result = DecryptBytes(bytesToDecrypt);
			return result;
		}

        private AesCryptoServiceProvider CreateAesCryptoServiceProvider()
        {
            var result = new AesCryptoServiceProvider();
            result.Key = Key;
            result.GenerateIV();

            return result;
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            using (var stream = new MemoryStream())
            {
                using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                }

                var result = stream.ToArray();
                return result;
            }
        }

        public static byte[] HexToByteArray(string hex)
        {
            if (hex == null)
            {
                throw new ArgumentNullException("hex");
            }

            var result = Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();

            return result;
        }

        public static byte[] GetKeyFromPassphrase(string passphrase)
        {
            var passphraseBytes = UTF8Encoding.Default.GetBytes(passphrase);
            using (var sha1 = SHA1.Create())
            {
                var result = sha1.ComputeHash(passphraseBytes).Take(16).ToArray();
                return result;
            }
        }
    }
}