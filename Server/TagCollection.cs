using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Concurrent;

namespace GNL.Automation.Server
{
    public class TagCollection 
    {

        //Fields
        protected ConcurrentDictionary<string, TagInfo> tagList = new ConcurrentDictionary<string, TagInfo>();

        //Constructor
        static TagCollection() { }
        public TagCollection() { }

        //Properties
        public int Count
        {
            get
            {
                return this.tagList.Count;
            }
        }

        public TagInfo this[string index]
        {
            get
            {
                TagInfo info = null;
                if (tagList.ContainsKey(index))
                {
                    info = (TagInfo)this.tagList[index];
                }
                return info;
            }
        }

        
        //Methods
        public bool Contains(TagInfo t)
        {
            return this.tagList.ContainsKey(t.TagName);
        }


        public void Add(TagInfo tag)
        {
            this.tagList.TryAdd(tag.TagName,tag);
        }

        public void Clear()
        {
            this.tagList.Clear();
        }

        //public TagInfo FindTag(UInt32 tagHandle)
        //{
        //    foreach (TagInfo info2 in this.tagList)
        //    {
        //        if (info2.TagHandle == tagHandle)
        //        {
        //            return info2;
        //        }
        //    }
        //    return null;
        //}

        public TagInfo FindTag(String tagName)
        {
            if (this.tagList.ContainsKey(tagName))
                return this.tagList[tagName];
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return this.tagList.GetEnumerator();
        }

        public void Remove(TagInfo obj)
        {
            Remove(obj.TagName);
        }

        public void Remove(string obj)
        {
            TagInfo info = null;
            this.tagList.TryRemove(obj,out info);
        }
    }
}
