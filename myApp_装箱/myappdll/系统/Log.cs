using mainclassSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class Log
    {

        public enum enumLogState
        {
            Log,
            Work,
            All,
        }

        static mainclassSoft.Log logWork_sys;

        static bool 是否保存日志 = true;
        internal static void Add(bool status, string message, enumLogState logState = enumLogState.Log)
        {
            bool 使能_Log = false;
            bool 使能_LogWork = false;

            switch (logState)
            {
                case enumLogState.Log:

                    if (功能.Config.使能_日志_work && 工作.Config.工作状态 == 10)
                    {
                        Form_main.form_Main.uI_Log1.是否储存日志 = 是否保存日志 ? false : 是否保存日志;
                        使能_LogWork = true;
                    }

                    使能_Log = true;
                    break;
                case enumLogState.Work:
                    使能_LogWork = true;
                    break;
                case enumLogState.All:
                    使能_Log = true;
                    使能_LogWork = true;
                    break;
            }
            if (使能_Log)
            {
                Form_main.form_Main.uI_Log1.Add(status, message);
            }
            if (使能_LogWork)
            {
                Add_Work(status, message);
            }
            Form_main.form_Main.uI_Log1.是否储存日志 = 是否保存日志;
        }

        static void Add_Work(bool status, string message)
        {
            if (!功能.Config.使能_日志_work || logWork_sys is null)
            {
                return;
            }
            logWork_sys.Add(status, message);
        }



        /// <summary>
        /// 清空日志显示
        /// </summary>
        internal static void Clear()
        {
            Form_main.form_Main.uI_Log1.清空();
        }

        internal static void 释放()
        {
            Form_main.form_Main.uI_Log1.释放();

            if (功能.Config.使能_日志_work)
            {
                logWork_sys.释放();
            }

        }

        internal static void 初始化()
        {
            是否保存日志 = Form_main.form_Main.uI_Log1.是否储存日志;
            if (!功能.Config.使能_日志_work)
            {
                return;
            }


            mainclassSoft.Log.info_初始值_ info = new mainclassSoft.Log.info_初始值_();
            info.使能_清除日志线程 = false;
            info.日志文件标识 = "Work";
            info.保存期限 = 页面设置_main.Config.参数.日志保存时间;
            info.是否储存日志 = true;
            logWork_sys = new mainclassSoft.Log(info);

        }

    }
}
