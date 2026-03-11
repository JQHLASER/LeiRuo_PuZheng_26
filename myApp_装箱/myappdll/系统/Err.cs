using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class Err:mainclassSoft.Err
    {
        #region 日志事件

        internal static void 初始化()
        {
            Action_LogMsg += On_ErrMsg;
        }
        internal static void 释放()
        {
            Action_LogMsg -= On_ErrMsg;
        }
        static void On_ErrMsg(bool status,string LogMsg)
        {
            Log .Add (status, LogMsg);
        }

        #endregion




    }
}
