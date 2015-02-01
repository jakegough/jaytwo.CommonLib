using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jaytwo.Common.Extensions;

namespace jaytwo.Common.Test.Extensions
{
    [TestFixture]
    public static class StreamExtensionsTests
    {
        [Test]
        public static void StreamExtensions_GetReader()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream(encoding.GetBytes(message)))
            using (var reader = memoryStream.GetReader())
            {
                Assert.AreEqual(message, reader.ReadToEnd());
            }
        }

        [Test]
        public static void StreamExtensions_GetReader_with_encoding()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream(encoding.GetBytes(message)))
            using (var reader = memoryStream.GetReader(encoding))
            {
                Assert.AreEqual(message, reader.ReadToEnd());
            }
        }

        [Test]
        public static void StreamExtensions_GetWriter()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream())
            using (var writer = memoryStream.GetWriter())
            {
                writer.Write(message);
                writer.Flush();

                Assert.AreEqual(message, encoding.GetString(memoryStream.ToArray()));
            }
        }

        [Test]
        public static void StreamExtensions_GetWriter_with_encoding()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream())
            using (var writer = memoryStream.GetWriter(encoding))
            using (var reader = memoryStream.GetReader(encoding))
            {
                writer.Write(message);
                writer.Flush();

                memoryStream.Position = 0;

                Assert.AreEqual(message, reader.ReadToEnd());
            }
        }



        [Test]
        public static void StreamExtensions_Write()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(encoding.GetBytes(message));
                Assert.AreEqual(message, encoding.GetString(memoryStream.ToArray()));
            }

            Assert.Throws(typeof(ArgumentNullException), () => ((Stream)null).Write(new byte[] { }));
            Assert.Throws(typeof(ArgumentNullException), () => new MemoryStream().Write((byte[])null));
        }

        [Test]
        public static void StreamExtensions_ReadBytes()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream())
            {
                var bytesToWrite = encoding.GetBytes(message);
                memoryStream.Write(bytesToWrite, 0, bytesToWrite.Length);
                memoryStream.Position = 0;

                Assert.AreEqual(message, encoding.GetString(memoryStream.ReadBytes(message.Length)));
            }

            Assert.Throws(typeof(ArgumentNullException), () => ((Stream)null).ReadBytes(9));
        }

        [Test]
        public static void StreamExtensions_ReadAllBytes()
        {
            var encoding = Encoding.UTF8;
            var message = "hello world";

            using (var memoryStream = new MemoryStream())
            {
                var bytesToWrite = encoding.GetBytes(message);
                memoryStream.Write(bytesToWrite, 0, bytesToWrite.Length);
                memoryStream.Position = 0;

                Assert.AreEqual(message, encoding.GetString(memoryStream.ReadAllBytes()));
            }
        }
    }
}
