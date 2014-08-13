using System;
using System.Diagnostics;
using System.IO;

namespace NbtSharp.NbtTag
{
    public abstract partial class NbtTagBase
    {
        protected readonly NbtTagType type;

        public NbtTagType TagType { get { return type; } }

        public NbtTagBase(NbtTagType type)
        {
            this.type = type;
        }

        public abstract void Read(Stream stream);

        protected void ValidateIdOfTag(Stream stream)
        {
            byte byteReaded = (byte)stream.ReadByte();
            if ((byte)this.type != byteReaded)
                throw new ArgumentException(string.Format("Error on parsing the stream into nbt tag. The value experted are '{0}', received '{1}'", (byte)this.type, byteReaded));
        }
    }
}
