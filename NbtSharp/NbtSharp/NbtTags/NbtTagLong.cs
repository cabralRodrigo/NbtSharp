using NbtSharp.Extensions;
using System;
using System.IO;
using System.Linq;

namespace NbtSharp.NbtTag
{
    public class NbtTagLong : NbtTagBase
    {
        private long data;

        public NbtTagLong() : base(NbtTagType.Long) { }

        public override void Read(Stream stream)
        {
            byte[] arrayData = stream.ReadBytes(8);
            if (!Nbt.IsLittleEndian)
                arrayData = arrayData.Reverse().ToArray();

            this.data = BitConverter.ToInt64(arrayData, 0);
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
