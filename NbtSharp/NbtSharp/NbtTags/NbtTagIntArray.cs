using NbtSharp.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace NbtSharp.NbtTag
{
    public class NbtTagIntArray : NbtTagBase
    {
        private int[] data;

        public NbtTagIntArray() : base(NbtTagType.IntArray) { }

        public override void Read(Stream stream)
        {
            byte[] arrayDataLength = stream.ReadBytes(4);
            if (!Nbt.IsLittleEndian)
                arrayDataLength = arrayDataLength.Reverse().ToArray();
            UInt32 dataLength = BitConverter.ToUInt32(arrayDataLength, 0);

            this.data = new int[dataLength];

            for (int i = 0; i < dataLength; i++)
            {
                byte[] arrayItem = stream.ReadBytes(4);
                if (!Nbt.IsLittleEndian)
                    arrayItem = arrayItem.Reverse().ToArray();
                this.data[i] = BitConverter.ToInt32(arrayItem, 0);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("{");
            for (int i = 0; i < this.data.Length; i++)
                sb.Append(i.ToString() + (i == this.data.Length - 1 ? string.Empty : "|"));
            sb.Append("}");

            return sb.ToString();
        }
    }
}
