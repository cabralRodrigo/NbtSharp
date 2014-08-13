using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbtSharp.Extensions;
using System.IO;

namespace NbtSharp.NbtTag
{
    public class NbtTagDouble : NbtTagBase
    {
        private double data;

        public NbtTagDouble() : base(NbtTagType.Double) { }

        public override void Read(Stream stream)
        {
            byte[] arrayData = stream.ReadBytes(8);

            if (!Nbt.IsLittleEndian)
                arrayData = arrayData.Reverse().ToArray();

            this.data = BitConverter.ToDouble(arrayData, 0);
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}
