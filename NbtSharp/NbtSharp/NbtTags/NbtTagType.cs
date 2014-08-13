namespace NbtSharp.NbtTag
{
    public enum NbtTagType : byte
    {
        End = 0x0,
        Byte = 0x1,
        Short = 0x2,
        Int = 0x3,
        Long = 0x4,
        Float = 0x5,
        Double = 0x6,
        ByteArray = 0x7,
        String = 0x8,
        List = 0x9,
        Compound = 0xa,
        IntArray = 0xb
    }
}