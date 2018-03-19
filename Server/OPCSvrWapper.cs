using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GNL.Automation.Server
{
    public class OPCSvrWapper
    {
        //Fields
        private OPCServer oPCSvr = new OPCServer();
        private Int32 interval = 0;
        //private Thread OPCSvrThread = null;

        //Constructor
        static OPCSvrWapper() { }
        public OPCSvrWapper() { }

        //Properties  
        public OPCServer OPCSvr
        {
            get { return this.oPCSvr; }
            set { this.oPCSvr = value; }
        }
        public Int32 Interval
        {
            get
            {
                return interval;
            }
            set
            {
                //this.OPCSvrThread.Suspend();
                interval = value;
                //this.OPCSvrThread.Resume();
            }
        }
        public TagCollection TagList
        {
            get
            {
                return this.oPCSvr.TagList;
            }
        }
        public String ServerName
        {
            get { return this.oPCSvr.ServerName; }
            set { this.oPCSvr.ServerName = value; }
        }
        public UInt32 ServerRate
        {
            get { return this.oPCSvr.ServerRate; }
            set { this.oPCSvr.ServerRate = value; }
        }
        public String ServerDescr
        {
            get { return this.oPCSvr.ServerDescr; }
            set { this.oPCSvr.ServerDescr = value; }
        }
        public String ExePath
        {
            get { return this.oPCSvr.ExePath; }
            set { this.oPCSvr.ExePath = value; }
        }
        public String SerialNumber
        {
            get { return this.oPCSvr.SerialNumber; }
            set { this.oPCSvr.SerialNumber = value; }
        }
        public String CLSIDServer
        {
            get { return this.oPCSvr.CLSIDServer; }
            set { this.oPCSvr.CLSIDServer = value; }
        }

        //Methods
        public bool ActivateOPCSvr(String serialNum)
        {
            SerialNumber = serialNum;
            return OPCSvr.Deactivate30MinTimer(serialNum);
        }

        ////该函数可能不需要！
        //public void ConfigOPCSvr(String svrName, String svrDescr, String exePath, UInt32 svrRate)
        //{
        //    ServerName = svrName;
        //    ServerDescr = svrDescr;
        //    ExePath = exePath;
        //    ServerRate = svrRate;
        //}

        public void StartOPCServer()
        {
            if (!ActivateOPCSvr("JVRPS53R5V64226N62H4"))
            {
                new OPCSvrException("<ERROR>Wrong Serial Number, activate server failed!");
            }
            if (!OPCSvr.InitOPCSvr())
            {
                throw new OPCSvrException("<ERROR> Init OPC Server Failed!");
            }
            if (!OPCSvr.UpdateRegistry())
            {
                throw new OPCSvrException("<ERROR> Register To The Windows Failed!");
            }
        }

        public void StopOPCServer()
        {
            OPCSvr.RefreshAllClients();
            //OPC2.0需要关闭客户端连接
            OPCSvr.RequestDisconnect();
            //int retval = OPCSvr.NumbrClientConnections();
            //if (retval == 0)
            //{
                if (!OPCSvr.UninitOPCSvr())
                {
                    throw new OPCSvrException("<ERROR> Uninit OPC Server Failed!");
                }
                if (!OPCSvr.UnregisterServer())
                {
                    throw new OPCSvrException("<ERROR> Unregister OPC Server Failed!");
                }
            //}
            //else
            //{
            //    throw new ClientExistException("<ERROR> Connected Clients Exists, End OPC Server Failed!");
            //}
        }

        public void AddTag(String TagName, object TagValue, String TagDescr, TagQuality TagInitialQuality, bool IsWritable)
        {
            UInt32 retval;
            retval = OPCSvr.CreateTag(TagName, TagValue, TagDescr, TagInitialQuality, IsWritable);
            if (retval <= 0)
            {
                throw new OPCSvrException("<ERROR> Add Tag Failed!");
            }
        }

        public void UpdateTag(UInt32 TagHandle, Object Value, TagQuality Quality)
        {
            if (!OPCSvr.UpdateTag(TagHandle, Value, Quality))
            {
                throw new OPCSvrException("<ERROR> Update Tag Failed!");
            }
        }

        public void UpdateTag(string tagName, object value, TagQuality quanlity)
        {
            TagInfo info = TagList.FindTag(tagName);
            UpdateTag(info.TagHandle, value, quanlity);
        }

        public void DeleteTag(string tagName)
        {
            if (!OPCSvr.RemoveTag(tagName))
            {
                throw new OPCSvrException("<ERROR> Delete Tag Failed!");
            }
        }

        public void SetServerRate(UInt32 svrRate)
        {
            if (OPCSvr.ResetServerRate(svrRate))
            {
                this.ServerRate = svrRate;
            }
            else
            {
                throw new OPCSvrException("<ERROR> Set Server Rate Failed!");
            }
        }

        public void EnableWriteNotification(WtOPCInterface.WriteNotificationDelegate Callback, bool ConvertToNativeType)
        {
            if (!OPCSvr.EnableWriteNotification(Callback, ConvertToNativeType))
            {
                throw new OPCSvrException("<ERROR> EnableWriteNotification Failed!");
            }
        }

        /// <summary>
        /// 生成CLSID,唯一标识一个opcserver应用
        /// </summary>
        /// <returns></returns>
        public static String GenCLSID()
        {
            Guid idSvr = new Guid();
            idSvr = Guid.NewGuid();

            return idSvr.ToString();
        }
    }
}
