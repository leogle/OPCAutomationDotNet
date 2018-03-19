/*******************************************************************
 * * 文件名： OPCChangedModel.cs
 * * 文件作用：
 * *-------------------------------------------------------------------
 * * 修改历史记录：
 * * 修改时间      修改人    修改内容概要
 * * 2012-11-30    lrh       新增
 * *******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GNL.Automation.Server;

namespace GNL.Automation.OPCClient
{
    public class OPCChangeModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private TagQuality quality;

        public TagQuality Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
    }
}
