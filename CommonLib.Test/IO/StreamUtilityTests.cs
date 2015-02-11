using jaytwo.Common.Extensions;
using jaytwo.Common.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;
using jaytwo.Common.System;

namespace jaytwo.Common.Test.IO
{
    [TestFixture]
    public static class StreamUtilityTests
    {
        private static IEnumerable<TestCaseData> CopyStreamToStream_TestCases()
        {
            yield return new TestCaseData(null, new MemoryStream(), "hello world", 0).Throws(typeof(ArgumentNullException));            
            yield return new TestCaseData(new MemoryStream(), null, "hello world", 0).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(new MemoryStream(), new MemoryStream(), "hello world", 0).Returns("hello world");
            yield return new TestCaseData(new MemoryStream(), new MemoryStream(), "hello world", 2).Returns("llo world");
        }

        [Test]
        [TestCaseSource("CopyStreamToStream_TestCases")]
        public static string CopyStreamToStream(Stream source, Stream target, string message, int skipBytes)
        {
            var sourceArray = Encoding.UTF8.GetBytes(message);

            using (source)
            using (target)
            {
                if (source != null)
                {
                    source.Write(sourceArray);
                    source.Position = skipBytes;
                }

                StreamUtility.CopyStreamToStream(source, target);
                target.Position = 0;

                var resultBytes = StreamUtility.GetBytesFromStream(target);
                var result = Encoding.UTF8.GetString(resultBytes);
                return result;
            }
        }

#if !NET_4_0
        [Test]
        [TestCaseSource("CopyStreamToStream_TestCases")]
        public static string Stream_CopyTo(Stream source, Stream target, string message, int skipBytes)
        {
            var sourceArray = Encoding.UTF8.GetBytes(message);

            using (source)
            using (target)
            {
                if (source != null)
                {
                    source.Write(sourceArray);
                    source.Position = skipBytes;
                }

                StreamExtensions.CopyTo(source, target);
                
                target.Position = 0;

                var resultBytes = StreamUtility.GetBytesFromStream(target);
                var result = Encoding.UTF8.GetString(resultBytes);
                return result;
            }
        }
#endif

        public static IEnumerable<TestCaseData> ComputeHash_Stream_TestCases()
        {
            string stringToHash = "hello world";

            //http://www.fileformat.info/tool/hash.htm?text=hello+world
            yield return new TestCaseData(new Func<Stream, byte[]>(x => StreamUtility.ComputeMD5Hash(x)), stringToHash).Returns("5eb63bbbe01eeed093cb22bb8f5acdc3").SetName("ComputeMd5Hash");
            yield return new TestCaseData(new Func<Stream, byte[]>(x => StreamUtility.ComputeSHA1Hash(x)), stringToHash).Returns("2aae6c35c94fcfb415dbe95f408b9ce91ee846ed").SetName("ComputeSHA1Hash");
            yield return new TestCaseData(new Func<Stream, byte[]>(x => StreamUtility.ComputeSHA256Hash(x)), stringToHash).Returns("b94d27b9934d3e08a52e52d7da7dabfac484efe37a5380ee9088f7ace2efcde9").SetName("ComputeSHA256Hash");

            yield return new TestCaseData(new Func<Stream, byte[]>(x => x.ComputeMD5Hash()), stringToHash).Returns("5eb63bbbe01eeed093cb22bb8f5acdc3").SetName("ComputeMd5Hash (Extension)");
            yield return new TestCaseData(new Func<Stream, byte[]>(x => x.ComputeSHA1Hash()), stringToHash).Returns("2aae6c35c94fcfb415dbe95f408b9ce91ee846ed").SetName("ComputeSHA1Hash (Extension)");
            yield return new TestCaseData(new Func<Stream, byte[]>(x => x.ComputeSHA256Hash()), stringToHash).Returns("b94d27b9934d3e08a52e52d7da7dabfac484efe37a5380ee9088f7ace2efcde9").SetName("ComputeSHA256Hash (Extension)");

            // reading bytes from stream
            yield return new TestCaseData(new Func<Stream, byte[]>(x => StreamUtility.GetBytesFromStream(x)), stringToHash).Returns("68656c6c6f20776f726c64").SetName("GetBytesFromStream");
            yield return new TestCaseData(new Func<Stream, byte[]>(x => x.ReadAllBytes()), stringToHash).Returns("68656c6c6f20776f726c64").SetName("ReadAllBytes (Extension)");
        }

        [Test]
        [TestCaseSource("ComputeHash_Stream_TestCases")]
        public static string ComputeHash_Stream(Func<Stream, byte[]> hashMethod, string stringToHash)
        {
            var sourceArray = Encoding.UTF8.GetBytes(stringToHash);
            using (var memoryStream = new MemoryStream(sourceArray))
            {
                var resultBytes = hashMethod.Invoke(memoryStream);
                var resultHex = ByteArrayUtility.ToHexString(resultBytes).ToLower();
                return resultHex;
            }
        }

        [Test]
        [TestCaseSource("ComputeHash_Stream_TestCases")]
        public static string ComputeHash_Stream_NonSeekable(Func<Stream, byte[]> hashMethod, string stringToHash)
        {
            var sourceArray = Encoding.UTF8.GetBytes(stringToHash);
            using (var memoryStream = MockRepository.GeneratePartialMock<MemoryStream>(sourceArray))
            {
                memoryStream.Stub(x => x.CanSeek).Return(false);
                
                var resultBytes = hashMethod.Invoke(memoryStream);
                var resultHex = ByteArrayUtility.ToHexString(resultBytes).ToLower();
                return resultHex;
            }
        }

        public static IEnumerable<TestCaseData> ComputeHash_ByteArray_TestCases()
        {
            string stringToHash = "hello world";

            yield return new TestCaseData(new Func<byte[], byte[]>(x => ByteArrayUtility.ComputeMD5Hash(x)), stringToHash).Returns("5eb63bbbe01eeed093cb22bb8f5acdc3").SetName("ComputeMd5Hash (Extension)");
            yield return new TestCaseData(new Func<byte[], byte[]>(x => ByteArrayUtility.ComputeSHA1Hash(x)), stringToHash).Returns("2aae6c35c94fcfb415dbe95f408b9ce91ee846ed").SetName("ComputeSHA1Hash (Extension)");
            yield return new TestCaseData(new Func<byte[], byte[]>(x => ByteArrayUtility.ComputeSHA256Hash(x)), stringToHash).Returns("b94d27b9934d3e08a52e52d7da7dabfac484efe37a5380ee9088f7ace2efcde9").SetName("ComputeSHA256Hash (Extension)");

            //http://www.fileformat.info/tool/hash.htm?text=hello+world
            yield return new TestCaseData(new Func<byte[], byte[]>(x => x.ComputeMD5Hash()), stringToHash).Returns("5eb63bbbe01eeed093cb22bb8f5acdc3").SetName("ComputeMd5Hash (Extension)");
            yield return new TestCaseData(new Func<byte[], byte[]>(x => x.ComputeSHA1Hash()), stringToHash).Returns("2aae6c35c94fcfb415dbe95f408b9ce91ee846ed").SetName("ComputeSHA1Hash (Extension)");
            yield return new TestCaseData(new Func<byte[], byte[]>(x => x.ComputeSHA256Hash()), stringToHash).Returns("b94d27b9934d3e08a52e52d7da7dabfac484efe37a5380ee9088f7ace2efcde9").SetName("ComputeSHA256Hash (Extension)");
        }

        [Test]
        [TestCaseSource("ComputeHash_ByteArray_TestCases")]
        public static string ComputeHash_ByteArray(Func<byte[], byte[]> hashMethod, string stringToHash)
        {
            var sourceArray = Encoding.UTF8.GetBytes(stringToHash);
            var resultBytes = hashMethod.Invoke(sourceArray);
            var resultHex = ByteArrayUtility.ToHexString(resultBytes).ToLower();
            return resultHex;
        }

        public static IEnumerable<TestCaseData> ByteArrayUtility_ToHexString_TestCases()
        {
            yield return new TestCaseData(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Returns("00010203040506070809");
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToHexString_TestCases")]
        public static string ByteArrayUtility_ToHexString(byte[] bytes)
        {
            return ByteArrayUtility.ToHexString(bytes);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToHexString_TestCases")]
        public static string ByteArrayExtensions_AsHexString(byte[] bytes)
        {
            return bytes.AsHexString();
        }

        public static IEnumerable<TestCaseData> ByteArrayUtility_ToBase64String_TestCases()
        {
            yield return new TestCaseData(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Returns("AAECAwQFBgcICQ==");
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToBase64String_TestCases")]
        public static string ByteArrayUtility_ToBase64String(byte[] bytes)
        {
            return ByteArrayUtility.ToBase64String(bytes);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToBase64String_TestCases")]
        public static string ByteArrayExtensions_AsBase64String(byte[] bytes)
        {
            return bytes.AsBase64String();
        }

        public static IEnumerable<TestCaseData> ByteArrayUtility_ToUtf8String_TestCases()
        {
            yield return new TestCaseData(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64  }).Returns("hello world");
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToUtf8String_TestCases")]
        public static string ByteArrayUtility_ToUtf8String(byte[] bytes)
        {
            return ByteArrayUtility.ToUtf8String(bytes);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToUtf8String_TestCases")]
        public static string ByteArrayExtensions_AsUtf8String(byte[] bytes)
        {
            return bytes.AsUtf8String();
        }

        public static IEnumerable<TestCaseData> ByteArrayUtility_ToInt16_TestCases()
        {
            yield return new TestCaseData(new byte[] { 1 }).Throws(typeof(ArgumentException));
            yield return new TestCaseData(new byte[] { 1, 0, 0 }).Throws(typeof(ArgumentException));
            yield return new TestCaseData(new byte[] { 1, 0 }).Returns(1);
            yield return new TestCaseData(new byte[] { 0, 1 }).Returns(256);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToInt16_TestCases")]
        public static short ByteArrayUtility_ToInt16(byte[] bytes)
        {
            return ByteArrayUtility.ToInt16(bytes);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToInt16_TestCases")]
        public static short ByteArrayExtensions_AsInt16(byte[] bytes)
        {
            return bytes.AsInt16();
        }

        public static IEnumerable<TestCaseData> ByteArrayUtility_ToInt32_TestCases()
        {
            yield return new TestCaseData(new byte[] { 1, 0, 0 }).Throws(typeof(ArgumentException));
            yield return new TestCaseData(new byte[] { 1, 0, 0, 0, 0 }).Throws(typeof(ArgumentException));
            yield return new TestCaseData(new byte[] { 1, 0, 0, 0 }).Returns(1);
            yield return new TestCaseData(new byte[] { 0, 0, 1, 0 }).Returns(65536);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToInt32_TestCases")]
        public static int ByteArrayUtility_ToInt32(byte[] bytes)
        {
            return ByteArrayUtility.ToInt32(bytes);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToInt32_TestCases")]
        public static int ByteArrayExtensions_AsInt32(byte[] bytes)
        {
            return bytes.AsInt32();
        }

        public static IEnumerable<TestCaseData> ByteArrayUtility_ToInt64_TestCases()
        {
            yield return new TestCaseData(new byte[] { 1, 0, 0, 0, 0, 0, 0 }).Throws(typeof(ArgumentException));
            yield return new TestCaseData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 }).Throws(typeof(ArgumentException));
            yield return new TestCaseData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }).Returns(1);
            yield return new TestCaseData(new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 }).Returns(4294967296);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToInt64_TestCases")]
        public static long ByteArrayUtility_ToInt64(byte[] bytes)
        {
            return ByteArrayUtility.ToInt64(bytes);
        }

        [Test]
        [TestCaseSource("ByteArrayUtility_ToInt64_TestCases")]
        public static long ByteArrayExtensions_AsInt64(byte[] bytes)
        {
            return bytes.AsInt64();
        }   

    }
}
