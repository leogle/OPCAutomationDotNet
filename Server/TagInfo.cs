using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;

namespace GNL.Automation.Server
{
    public class TagInfo
    {
        //Fields
        private String tagName = String.Empty;
        private UInt32 tagID = 0;
        private String tagDescr = String.Empty;
        private TagQuality  tagQuality = TagQuality.Bad;
        private object tagValue = null;
        private UInt32 tagHandle = 0;
        private FILETIME tagFT = new FILETIME();
        private String tagType = String.Empty;
        private bool tagIsWritable = false;

        //Constructor
        static TagInfo() { }
        public TagInfo() { }

        //Properties
        public String TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        public UInt32 TagID
        {
            get { return tagID; }
            set { tagID = value; }
        }
        public String TagDescr
        {
            get { return tagDescr; }
            set { tagDescr = value; }
        }
        public TagQuality TagQuality
        {
            get { return tagQuality; }
            set { tagQuality = value; }
        }
        public object TagValue
        {
            get { return tagValue; }
            set { tagValue = value; }
        }
        public UInt32 TagHandle
        {
            get { return tagHandle; }
            set { tagHandle = value; }
        }
        public FILETIME TagFT
        {
            get { return tagFT; }
            set { tagFT = value; }
        }
        public String TagType
        {
            get { return tagType; }
            set { tagType = value; }
        }
        public bool TagIsWritable
        {
            get { return tagIsWritable; }
            set { tagIsWritable = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is TagInfo)
            {
                TagInfo info = obj as TagInfo;
                return info.tagName == this.tagName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
