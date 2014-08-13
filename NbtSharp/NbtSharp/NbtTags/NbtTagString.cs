using NbtSharp.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace NbtSharp.NbtTag
{
    public class NbtTagString : NbtTagBase
    {
        private string data;

        public NbtTagString() : base(NbtTagType.String) { }

        public override void Read(Stream stream)
        {
            byte[] arrayDataLength = stream.ReadBytes(2);
            if (!Nbt.IsLittleEndian)
                arrayDataLength = arrayDataLength.Reverse().ToArray();
            UInt16 dataLength = BitConverter.ToUInt16(arrayDataLength, 0);

            this.data = Encoding.UTF8.GetString(stream.ReadBytes(dataLength));
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
