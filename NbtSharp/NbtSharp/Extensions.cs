using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NbtSharp.Extensions
{
    public static class Extensions
    {
        private const int BUFFER_SIZE = 1024;

        public static byte[] ReadBytes(this Stream source, int count)
        {
            if (!source.CanRead)
                return new byte[0];

            List<byte> bytes = new List<byte>();

            int readedBytes = 0;
            byte[] buffer;
            do
            {
                buffer = new byte[BUFFER_SIZE];
                readedBytes = source.Read(buffer, 0, Math.Min(BUFFER_SIZE, count - bytes.Count < 0 ? 0 : count - bytes.Count));

                bytes.AddRange(buffer.Take(readedBytes));
            } while (readedBytes > 0 && bytes.Count < count);

            return bytes.ToArray();
        }
    }
}