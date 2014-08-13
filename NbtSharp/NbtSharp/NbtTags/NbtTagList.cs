using NbtSharp.Extensions;
using NbtSharp.Factory;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace NbtSharp.NbtTag
{
    public class NbtTagList : NbtTagBase
    {
        private NbtTagBase[] data;

        public NbtTagList() : base(NbtTagType.List) { }

        public override void Read(Stream stream)
        {
            byte tagsID = (byte)stream.ReadByte();

            NbtTagType tagsType;
            if (!Enum.TryParse<NbtTagType>(tagsID.ToString(), out tagsType))
                throw new NbtException();

            byte[] arrayDataLength = stream.ReadBytes(4);
            if (!Nbt.IsLittleEndian)
                arrayDataLength = arrayDataLength.Reverse().ToArray();
            UInt32 dataLength = BitConverter.ToUInt32(arrayDataLength, 0);

            this.data = new NbtTagBase[dataLength];
            for (int i = 0; i < dataLength; i++)
            {
                NbtTagBase tag = NbtTagFactory.GetNbtTagFromType(tagsType);
                if (tagsType == NbtTagType.Compound)
                    ((NbtTagCompound)tag).ReadName = false;
                tag.Read(stream);
                this.data[i] = tag;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (NbtTagBase tag in this.data)
                sb.AppendFormat("{0}{1},{0}", Environment.NewLine, tag.ToString());
            
            return sb.ToString();
        }
    }
}
