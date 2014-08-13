using System.Diagnostics;
using System.IO;

namespace NbtSharp.NbtTag
{
    [DebuggerDisplay("{data}")]
    public class NbtTagByte : NbtTagBase
    {
        private byte data;

        public NbtTagByte() : base(NbtTagType.Byte) { }

        public override void Read(Stream stream)
        {
            this.data = (byte)stream.ReadByte();
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
