using NbtSharp.Extensions;
using System;
using System.IO;
using System.Linq;

namespace NbtSharp.NbtTag
{
    public class NbtTagByteArray : NbtTagBase
    {
        private byte[] data;

        public NbtTagByteArray() : base(NbtTagType.ByteArray) { }

        public override void Read(Stream stream)
        {
            byte[] arrayDataLength = stream.ReadBytes(4);

            if (!Nbt.IsLittleEndian)
                arrayDataLength = arrayDataLength.Reverse().ToArray();

            int dataLength = BitConverter.ToInt32(arrayDataLength, 0);

            byte[] arrayData = stream.ReadBytes(dataLength);

            if (arrayData.Length != dataLength)
                throw new NbtException();

            this.data = arrayData;
        }

        public override string ToString()
        {
            return this.data.Length.ToString() + " bytes";
        }
    }
}
