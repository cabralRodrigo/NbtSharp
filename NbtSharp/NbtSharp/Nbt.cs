using NbtSharp.Extensions;
using NbtSharp.NbtTag;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace NbtSharp
{
    public class Nbt
    {
        public static bool IsLittleEndian = false;

        public static NbtTagCompound ReadFromStream(Stream stream)
        {
            NbtTagCompound compound = new NbtTagCompound();

            compound.ValidateStreamForReading(stream);
            compound.Read(stream);

            return compound;
        }

        public static string ReadTagName(Stream stream)
        {
            byte[] bytesTagNameLength = stream.ReadBytes(2);

            if (!IsLittleEndian)
                bytesTagNameLength = bytesTagNameLength.Reverse().ToArray();

            int tagNameLength = BitConverter.ToUInt16(bytesTagNameLength, 0);

            var bytesTagName = stream.ReadBytes(tagNameLength);

            return Encoding.UTF8.GetString(bytesTagName);
        }
    }
}
