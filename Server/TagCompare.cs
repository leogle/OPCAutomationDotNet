using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GNL.Automation.Server
{
    class TagCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            TagInfo tag1 = (TagInfo)x;
            TagInfo tag2 = (TagInfo)y;

            return tag1.TagName.CompareTo(tag2.TagName);
        }
    }
}
