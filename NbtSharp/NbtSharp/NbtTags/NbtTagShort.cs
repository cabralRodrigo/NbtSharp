using NbtSharp.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NbtSharp.NbtTag
{
    [DebuggerDisplay("{data}")]
    public class NbtTagShort : NbtTagBase
    {
        private short data;

        public NbtTagShort() : base(NbtTagType.Short) { }

        public override void Read(Stream stream)
        {
            byte[] arrayData = stream.ReadBytes(2);

            if (!Nbt.IsLittleEndian)
                arrayData = arrayData.Reverse().ToArray();

            this.data = BitConverter.ToInt16(arrayData, 0);
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
