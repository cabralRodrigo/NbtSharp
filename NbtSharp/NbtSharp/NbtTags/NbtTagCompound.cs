using NbtSharp.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace NbtSharp.NbtTag
{
    [DebuggerDisplay("{{TagName}: {data.Count}}")]
    public class NbtTagCompound : NbtTagBase
    {
        private bool readName = true;

        internal bool ReadName
        {
            get { return readName; }
            set { readName = value; }
        }

        private Dictionary<string, NbtTagBase> data = new Dictionary<string, NbtTagBase>();

        public NbtTagCompound() : base(NbtTagType.Compound) { }

        public string TagName { get; set; }

        public override void Read(Stream stream)
        {
            if (readName)
                this.TagName = Nbt.ReadTagName(stream);


            bool readTag = true;

            byte tagID;
            NbtTagBase tag;
            do
            {
                tagID = (byte)stream.ReadByte();
                tag = NbtTagFactory.GetNbtTagFromByte(tagID);

                if (tag.TagType != NbtTagType.End)
                {
                    if (tag.TagType == NbtTagType.Compound)
                    {
                        tag.Read(stream);
                        this.data.Add(((NbtTagCompound)tag).TagName, tag);
                    }
                    else
                    {
                        string tagName = Nbt.ReadTagName(stream);
                        tag.Read(stream);

                        this.data.Add(tagName, tag);
                    }
                }
                else
                    readTag = false;

            } while (readTag);
        }

        public void ValidateStreamForReading(Stream stream)
        {
            base.ValidateIdOfTag(stream);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tag_Compound(\"{0}\"):{1}{{{1}", this.TagName, Environment.NewLine);

            foreach (var item in data)
                if (item.Value.TagType == NbtTagType.Compound)
                    sb.AppendLine(item.Value.ToString());
                else
                    sb.AppendFormat("Tag_{0}(\"{1}\"): \"{2}\"{3}", item.Value.TagType.ToString(), item.Key, item.Value.ToString(), Environment.NewLine);

            sb.Append(Environment.NewLine + "}");
            return sb.ToString();
        }
    }
}
