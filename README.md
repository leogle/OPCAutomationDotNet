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