using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace GNL.Automation.Server
{
    public class WtOPCInterface
    {
        //Constructor
        public WtOPCInterface() { }
        static WtOPCInterface() { }

        //Methods
        [DllImport("WtOPCsvr.dll")]
        public static extern int Deactivate30MinTimer([MarshalAs(UnmanagedType.LPStr)] String SerialNumber);

        [DllImport("WtOPCsvr.dll")]
        public static extern short WTOPCsvrRevision();

        [DllImport("WtOPCsvr.dll")]
        public static extern bool SetThreadingModel(UInt32 dwCoInit);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool InitWTOPCsvr([MarshalAs(UnmanagedType.LPStr)] String CLSID_Svr, UInt32 ServerRate);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UninitWTOPCsvr();

        [DllImport("WtOPCsvr.dll")]
        public static extern bool ResetServerRate(UInt32 ServerRate);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateRegistry([MarshalAs(UnmanagedType.LPStr)] String CLSID_Svr, [MarshalAs(UnmanagedType.LPStr)] String Name, [MarshalAs(UnmanagedType.LPStr)] String Descr, [MarshalAs(UnmanagedType.LPStr)] String ExePath);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool AddLocalServiceKeysToRegistry([MarshalAs(UnmanagedType.LPStr)] String Name);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UnregisterServer([MarshalAs(UnmanagedType.LPStr)] String CLSID_Svr, [MarshalAs(UnmanagedType.LPStr)] String Name);

        [DllImport("WtOPCsvr.dll")]
        public static extern void SetVendorInfo([MarshalAs(UnmanagedType.LPStr)] String VendorInfo);

        [DllImport("WtOPCsvr.dll")]
        public static extern void SetServerState(OpcServerState ServerState);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool SetCaseSensitivity(bool bOn);

        [DllImport("WtOPCsvr.dll")]
        public static extern char SetWtOPCsvrQualifier(char qualifier);

        [DllImport("WtOPCsvr.dll")]
        public static extern UInt32 CreateTag([MarshalAs(UnmanagedType.LPStr)] String Name, Object Value, UInt16 InitialQuality, bool IsWritable);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateTag(UInt32 TagHandle, Object Value, UInt16 Quality);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateTagWithTimeStamp(UInt32 TagHandle, Object Value, UInt16 Quality, System.Runtime.InteropServices.ComTypes.FILETIME timestamp);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateTagByName([MarshalAs(UnmanagedType.LPStr)] String Name, Object Value, UInt16 Quality);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateTagWithTimeStampByName([MarshalAs(UnmanagedType.LPStr)] String Name, Object Value, System.Runtime.InteropServices.ComTypes.FILETIME TimeStamp, UInt16 Quality);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool SetTagProperties(UInt32 TagHandle, UInt32 PropertyID, [MarshalAs(UnmanagedType.LPStr)] String Description, Object Value);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool ReadTag(UInt32 TagHandle, ref Object Value);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool ReadTagWithTimeStamp(UInt32 TagHandle, ref Object Value, ref UInt16 Quality, ref System.Runtime.InteropServices.ComTypes.FILETIME Timestamp);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool SuspendTagUpdates(UInt32 TagHandle, bool OnOff);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool RemoveTag(UInt32 TagHandle);

        [DllImport("WtOPCsvr.dll")]
        public static extern UInt32 SetHashing(UInt32 sizeHash);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool StartUpdateTags();

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateTagToList(UInt32 TagHandle, Object Value, UInt16 Quality);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool UpdateTagWithTimeStampToList(UInt32 TagHandle, Object Value, System.Runtime.InteropServices.ComTypes.FILETIME TimeStamp, UInt16 Quality);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool EndUpdateTags();

        [DllImport("WtOPCsvr.dll")]
        public static extern Int32 NumbrClientConnections();

        [DllImport("WtOPCsvr.dll")]
        public static extern void RequestDisconnect();

        [DllImport("WtOPCsvr.dll")]
        public static extern bool RefreshAllClients();

        [DllImport("WtOPCsvr.dll")]
        public static extern bool ConvertVBDateToFileTime1(ref double VBDate, ref System.Runtime.InteropServices.ComTypes.FILETIME FileTime);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool ConvertFileTimeToVBDate1(ref System.Runtime.InteropServices.ComTypes.FILETIME FileTime, ref double VBDate);

        [DllImport("WtOPCsvr.dll")]
        public static extern bool VBCreateFileTime(UInt16 Year,
                                                    UInt16 Month,
                                                    UInt16 Day,
                                                    UInt16 Hour,
                                                    UInt16 Minute,
                                                    UInt16 Second,
                                                    UInt16 Milliseconds,
                                                    ref System.Runtime.InteropServices.ComTypes.FILETIME FileTime);

        public delegate void WriteNotificationDelegate(UInt32 hItem, ref Object Value, ref UInt32 ResultCode);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableWriteNotification(WriteNotificationDelegate Callback, bool ConvertToNativeType);

        public delegate void UnknownItemDelegate([MarshalAs(UnmanagedType.LPStr)] String PathName, [MarshalAs(UnmanagedType.LPStr)] String ItemName);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableUnknownItemNotification(UnknownItemDelegate Callback);

        public delegate void ItemRemovedDelegate(UInt32 hItem, [MarshalAs(UnmanagedType.LPStr)] String PathName, [MarshalAs(UnmanagedType.LPStr)] String ItemName);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableItemRemovalNotification(ItemRemovedDelegate Callback);

        public delegate void DisconnectDelegate(UInt32 NumbrClients);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableDisconnectNotification(DisconnectDelegate Callback);

        public delegate void EventMsgDelegate([MarshalAs(UnmanagedType.LPStr)] String Message);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableEventMsgs(EventMsgDelegate Callback);

        public delegate void RateChangeDelegate(UInt32 Handle, UInt32 Rate);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableRateNotification(RateChangeDelegate Callback);

        public delegate void DeviceReadDelegate(UInt32 hItem, ref Object Value, ref UInt16 Quality, ref System.Runtime.InteropServices.ComTypes.FILETIME Timestamp);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableDeviceRead(DeviceReadDelegate Callback);

        public delegate void ErrorCallbackDelegate(UInt32 handle, UInt32 ResultCode, [MarshalAs(UnmanagedType.LPStr)] String Message);
        [DllImport("WtOPCsvr.dll")]
        public static extern bool EnableErrorCallback(ErrorCallbackDelegate Callback);
    }
}
