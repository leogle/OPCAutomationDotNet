using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GNL.Automation.Server
{
    public class OPCServer
    {
        //Fields         
        private String serialNumber = "JVRPS53R5V64226N62H4";
        private String cLSIDServer = String.Empty;
        private UInt32 serverRate = 1000;
        private String serverName = String.Empty;
        private String serverDescr = String.Empty;
        private String exePath = String.Empty;
        private TagCollection tagList = new TagCollection();

        public String CLSIDServer
        {
            get
            {
                return cLSIDServer;
            }
            set
            {
                cLSIDServer = value;
            }
        }
        public UInt32 ServerRate
        {
            get
            {
                return serverRate;
            }
            set
            {
                serverRate = value;
            }
        }
        public String SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value;
            }
        }
        public String ServerName
        {
            get
            {
                return serverName;
            }
            set
            {
                serverName = value;
            }
        }
        public String ServerDescr
        {
            get
            {
                return serverDescr;
            }
            set
            {
                serverDescr = value;
            }
        }
        public String ExePath
        {
            get
            {
                return exePath;
            }
            set
            {
                exePath = value;
            }
        }
        public TagCollection TagList
        {
            get { return tagList; }
            set { tagList = value; }
        }

        //Nested Type    


        //Constructor
        public OPCServer() { }
        static OPCServer() { }

        //Callback Function

        public bool EnableWriteNotification(WtOPCInterface.WriteNotificationDelegate Callback, bool ConvertToNativeType)
        {
            return WtOPCInterface.EnableWriteNotification(Callback, ConvertToNativeType);
        }

        //Methods
        public bool RemoveTag(string tagName)
        {
            bool flag = WtOPCInterface.RemoveTag(this.TagList[tagName].TagHandle);
            if (flag)
            {
                this.tagList.Remove(tagName);
            }
            return flag;
        }

        public bool SetTagProperties(UInt32 TagHandle, UInt32 PropertyID, String Description, Object Value)
        {
            return WtOPCInterface.SetTagProperties(TagHandle, PropertyID, Description, Value);
        }
        public bool InitOPCSvr()
        {
            return WtOPCInterface.InitWTOPCsvr(this.CLSIDServer, this.ServerRate);
        }
        public bool SuspendTagUpdates(UInt32 TagHandle, bool OnOff)
        {
            return WtOPCInterface.SuspendTagUpdates(TagHandle, OnOff);
        }
        public Int32 NumbrClientConnections()
        {
            return WtOPCInterface.NumbrClientConnections();
        }
        public UInt32 CreateTag(String TagName, object TagValue, String TagDescr, TagQuality TagInitialQuality, bool IsWritable)
        {
            UInt32 num = WtOPCInterface.CreateTag(TagName, TagValue, (UInt16)TagInitialQuality, IsWritable);
            if (num > 0)
            {
                TagInfo tagInfo = new TagInfo
                {
                    TagHandle = num,
                    TagName = TagName,
                    TagQuality = TagInitialQuality,
                    TagValue = TagValue,
                    TagDescr = TagDescr
                };
                this.tagList.Add(tagInfo);
            }
            return num;
        }
        public bool ConvertVBDateToFileTime1(ref double VBDate, ref System.Runtime.InteropServices.ComTypes.FILETIME FileTime)
        {
            return WtOPCInterface.ConvertVBDateToFileTime1(ref VBDate, ref FileTime);
        }
        //public bool UpdateTagWithTimeStamp(UInt32 TagHandle, Object Value, TagQuality Quality, System.Runtime.InteropServices.ComTypes.FILETIME timestamp)
        //{
        //    bool flag = WtOPCInterface.UpdateTagWithTimeStamp(TagHandle, Value, (UInt16)Quality, timestamp);
        //    if (flag)
        //    {
        //        this.tagList[].TagValue = Value;
        //    }
        //    return flag;
        //}
        public bool UnregisterServer()
        {
            return WtOPCInterface.UnregisterServer(this.CLSIDServer, this.ServerName);
        }
        public short OPCSvrRevision()
        {
            return WtOPCInterface.WTOPCsvrRevision();
        }
        public bool UninitOPCSvr()
        {
            return WtOPCInterface.UninitWTOPCsvr();
        }
        public bool ConvertFileTimeToVBDate1(ref System.Runtime.InteropServices.ComTypes.FILETIME FileTime, ref double VBDate)
        {
            return WtOPCInterface.ConvertFileTimeToVBDate1(ref FileTime, ref VBDate);
        }
        public bool ResetServerRate(UInt32 ServerRate)
        {
            return WtOPCInterface.ResetServerRate(ServerRate);
        }
        public char SetOPCsvrQualifier(char qualifier)
        {
            return WtOPCInterface.SetWtOPCsvrQualifier(qualifier);
        }
        public bool EndUpdateTags()
        {
            return WtOPCInterface.EndUpdateTags();
        }
        //public bool UpdateTagToList(UInt32 TagHandle, Object Value, TagQuality Quality)
        //{
        //    bool flag = WtOPCInterface.UpdateTagToList(TagHandle, Value, (UInt16)Quality);
        //    if (flag)
        //    {
        //        this.tagList.FindTag(TagHandle).TagValue = Value;
        //    }
        //    return flag;
        //}
        public void SetServerState(OpcServerState ServerState)
        {
            WtOPCInterface.SetServerState(ServerState);
        }
        public void RequestDisconnect()
        {
            WtOPCInterface.RequestDisconnect();
        }

        public bool UpdateTag(UInt32 TagHandle, Object Value, TagQuality Quality)
        {
            bool flag = WtOPCInterface.UpdateTag(TagHandle, Value, (UInt16)Quality);
            //if (flag)
            //{
            //    this.tagList.FindTag(TagHandle).TagValue = Value;
            //}
            return flag;
        }
        public bool Deactivate30MinTimer(string serialNumber)
        {
            var res =  WtOPCInterface.Deactivate30MinTimer(serialNumber);
            if (res == 1)
            {
                return true;
            }
            return false;
        }
        public bool SetCaseSensitivity(bool bOn)
        {
            return WtOPCInterface.SetCaseSensitivity(bOn);
        }
        public bool RefreshAllClients()
        {
            return WtOPCInterface.RefreshAllClients();
        }
        public bool AddLocalServiceKeysToRegistry(String ServerName)
        {
            return WtOPCInterface.AddLocalServiceKeysToRegistry(ServerName);
        }
        public bool UpdateTagByName(String Name, Object Value, TagQuality Quality)
        {
            bool flag = WtOPCInterface.UpdateTagByName(Name, Value, (UInt16)Quality);
            if (flag)
            {
                //为什么只更新TagValue？
                this.tagList.FindTag(Name).TagValue = Value;
            }
            return flag;
        }
        public bool SetThreadingModel(UInt32 dwCoInit)
        {
            return WtOPCInterface.SetThreadingModel(dwCoInit);
        }
        public bool ReadTag(UInt32 TagHandle, ref Object Value)
        {
            return WtOPCInterface.ReadTag(TagHandle, ref Value);
        }
        public bool StartUpdateTags()
        {
            return WtOPCInterface.StartUpdateTags();
        }
        public void SetVendorInfo(String VendorInfo)
        {
            WtOPCInterface.SetVendorInfo(VendorInfo);
        }
        public UInt32 SetHashing(UInt32 sizeHash)
        {
            return WtOPCInterface.SetHashing(sizeHash);
        }
        public bool ReadTagWithTimeStamp(UInt32 TagHandle, ref Object Value, ref UInt16 Quality, ref System.Runtime.InteropServices.ComTypes.FILETIME Timestamp)
        {
            return WtOPCInterface.ReadTagWithTimeStamp(TagHandle, ref Value, ref Quality, ref Timestamp);
        }
        public bool UpdateRegistry()
        {
            return WtOPCInterface.UpdateRegistry(this.CLSIDServer, this.ServerName, this.ServerDescr, this.ExePath);
        }
    }
}
