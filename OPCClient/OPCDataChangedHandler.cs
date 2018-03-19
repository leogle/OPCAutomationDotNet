/*******************************************************************
 * * 文件名： DataChangedHandler.cs
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

namespace GNL.Automation.OPCClient
{
    public delegate void OPCDataChangedHandler(List<OPCChangeModel> arg);
   
}
