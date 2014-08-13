using NbtSharp.NbtTag;
using System;

namespace NbtSharp.Factory
{
    public static class NbtTagFactory
    {
        public static NbtTagBase GetNbtTagFromType(NbtTagType type)
        {
            switch (type)
            {
                case NbtTagType.End:
                    return new NbtTagEnd();
                case NbtTagType.Byte:
                    return new NbtTagByte();
                case NbtTagType.Short:
                    return new NbtTagShort();
                case NbtTagType.Int:
                    return new NbtTagInt();
                case NbtTagType.Long:
                    return new NbtTagLong();
                case NbtTagType.Float:
                    return new NbtTagFloat();
                case NbtTagType.Double:
                    return new NbtTagDouble();
                case NbtTagType.ByteArray:
                    return new NbtTagByteArray();
                case NbtTagType.String:
                    return new NbtTagString();
                case NbtTagType.List:
                    return new NbtTagList();
                case NbtTagType.Compound:
                    return new NbtTagCompound();
                case NbtTagType.IntArray:
                    return new NbtTagIntArray();
                default:
                    return null;
            }
        }

        public static NbtTagBase GetNbtTagFromByte(byte id)
        {
            NbtTagType type;
            if (Enum.TryParse<NbtTagType>(id.ToString(), out type))
                return NbtTagFactory.GetNbtTagFromType(type);
            else
                return null;
        }
    }
}
