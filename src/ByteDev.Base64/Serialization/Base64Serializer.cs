using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace ByteDev.Base64.Serialization
{
    /// <summary>
    /// Represents a base64 encoded string serializer.
    /// </summary>
    public class Base64Serializer : IBase64Serializer
    {
        /// <summary>
        /// Serializes an object to a base64 string.
        /// </summary>
        /// <param name="obj">Object to serialize to base64.</param>
        /// <returns>Serialized representation of <paramref name="obj" />.</returns>
        public string Serialize(object obj)
        {
            using (var stream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                // Convert object to a stream
                binaryFormatter.Serialize(stream, obj);

                var bytes = Compress(stream);
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Deserialize a base64 serialized representation to type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to.</typeparam>
        /// <param name="base64">Serialized base64 string representation.</param>
        /// <returns>Deserialized type.</returns>
        public T Deserialize<T>(string base64)
        {
            var compressedBytes = Convert.FromBase64String(base64);

            using (var stream = new MemoryStream())
            {
                Decompress(compressedBytes, stream);
                stream.Position = 0;
                var formatter = new BinaryFormatter();

                return (T)formatter.Deserialize(stream);
            }
        }
        
        private static byte[] Compress(Stream stream)
        {
            using (var resultStream = new MemoryStream())
            {
                using (var writeStream = new GZipStream(resultStream, CompressionMode.Compress, true))
                {
                    CopyBuffered(stream, writeStream);
                }

                var resultArray = resultStream.ToArray();

                return resultArray;
            }
        }

        private static void Decompress(byte[] compressedBytes, Stream outputStream)
        {
            var memoryStream = new MemoryStream(compressedBytes);

            try
            {
                using (var readStream = new GZipStream(memoryStream, CompressionMode.Decompress, true))
                {
                    memoryStream = null;
                    CopyBuffered(readStream, outputStream);
                }
            }
            finally
            {
                memoryStream?.Dispose();
            }
        }

        private static void CopyBuffered(Stream readStream, Stream writeStream)
        {
            if (readStream.CanSeek)
                readStream.Position = 0;

            var bytes = new byte[4096];
            int byteCount;

            while ((byteCount = readStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                writeStream.Write(bytes, 0, byteCount);
            }
        }
    }
}
