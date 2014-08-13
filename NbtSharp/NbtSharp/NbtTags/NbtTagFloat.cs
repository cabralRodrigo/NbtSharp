using NbtSharp.Extensions;
using System;
using System.IO;
using System.Linq;

namespace NbtSharp.NbtTag
{
    public class NbtTagFloat : NbtTagBase
    {
        private float data;

        public NbtTagFloat() : base(NbtTagType.Float) { }

        public override void Read(Stream stream)
        {
            byte[] arrayData = stream.ReadBytes(4);

            if (!Nbt.IsLittleEndian)
                arrayData = arrayData.Reverse().ToArray();

            this.data = BitConverter.ToSingle(arrayData, 0);
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
