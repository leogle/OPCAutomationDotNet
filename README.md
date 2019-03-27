使用C#进行封装的OPC客户端和服务端
===
依赖项：
-----
*OPCAutomation<br>
*wtOPCSvr<br>
<br>
客户端使用方法：
-----
```C#
//初始化客户端
private OPCClientWrapper opcClient;
opcClient.Init("127.0.0.1", GlobalConfig.Instance.ConfigItem.Local.DataSourceName);
//添加点位变化事件回调
opcClient.OpcDataChangedEvent += new OPCDataChangedHandler(OpcClient_OpcDataChangedEvent);
//添加监视点位
opcClient.MonitorOPCItem(name);
```

服务端使用方法：
-----
```C#
//初始化
 private OPCSvrWapper opcServer;
 opcServer = new OPCSvrWapper();
opcServer.CLSIDServer = "AD5F2291-D45D-494C-8C08-62EA58512F9F";
opcServer.ServerName = SERVER_NAME;
//启动
opcServer.StartOPCServer();
//添加点位
opcServer.AddTag(name, value, value.ToString(), quality, false);
opcServer.UpdateTag(name, value, quality);
```
注意：由于OPC服务端在加载大量标签时占用较大内存，且.net程序有最大内存限制，超过内存会报OutMemory异常，
在需要监测大量设备时请谨慎使用，目前测试服务端可支撑20,000点点位监视，超过该范围情况请尝试使用C++调用wtOpcSvr.dll
