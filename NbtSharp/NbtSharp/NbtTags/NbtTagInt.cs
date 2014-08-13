using NbtSharp.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NbtSharp.NbtTag
{
    [DebuggerDisplay("{data}")]
    public class NbtTagInt : NbtTagBase
    {
        private int data;

        public NbtTagInt() : base(NbtTagType.Int) { }

        public override void Read(Stream stream)
        {
            byte[] arrayData = stream.ReadBytes(4);

            if (!Nbt.IsLittleEndian)
                arrayData = arrayData.Reverse().ToArray();

            this.data = BitConverter.ToInt32(arrayData, 0);
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
