using mainclassqf;
using Newtonsoft.Json;
using Sunny25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myappdll
{
    internal class 生产计数
    {
        internal static mainclassSoft.生产计数 js_sys = new mainclassSoft.生产计数();



        internal static void 初始化()
        {
            js_sys.Action_LogMsg += On_LogMsg;

            js_sys.Config.功能.使能_良品 = 功能.Config.使能_生产计数_良品;
            js_sys.Config.功能.使能_不良品 = 功能.Config.使能_生产计数_不良品;
            js_sys.Config.功能.使能_零件 = 功能.Config.使能_生产计数_零件;


            Form_main.form_Main.生产计数ToolStripMenuItem.Visible = false;
            Form_main.form_Main.设置ToolStripMenuItem.Visible = false;
            if (js_sys.Config.功能.使能_良品 || js_sys.Config.功能.使能_不良品 || js_sys.Config.功能.使能_零件)
            {
                Form_main.form_Main.生产计数ToolStripMenuItem.Visible = true;
                Form_main.form_Main.设置ToolStripMenuItem.Visible = js_sys.Config.功能.使能_零件 ;
            }

            js_sys.读写参数(1);
        }

        internal static void 释放()
        {
            js_sys.Action_LogMsg -= On_LogMsg;


        }

        static void On_LogMsg(bool status, string msg)
        {
            Log.Add(status, msg);
        }
    }
}