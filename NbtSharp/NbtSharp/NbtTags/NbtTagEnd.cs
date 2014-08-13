using System.IO;

namespace NbtSharp.NbtTag
{
    public class NbtTagEnd : NbtTagBase
    {
        public NbtTagEnd() : base(NbtTagType.End) { }

        public override void Read(Stream stream) { }
    }
}
