using mainclassSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static mainclassqf.WebsocketServer_封装;

namespace myappdll
{
    internal class 手持扫码枪
    {
        /// <summary>
        /// 手持扫码枪读出的内容
        /// </summary>
        internal static List<string> _读码内容 = new List<string>();

        internal static mainclassqf.Socket_Client tcp_sys = new mainclassqf.Socket_Client();


        internal static void 初始化()
        {
            string path = mainclassSoft.系统类.Config.File_MyAppSys_Config + "\\手持扫码枪.txt";
            tcp_sys.Config.path = path;

            tcp_sys.Config.参数.IP = "192.168.100.100";
            tcp_sys.Config.参数.Port = 9004;
            tcp_sys.参数读写(1);

            tcp_sys.Action_接收数据 += async (data) =>
            {
                if (!工作.Err_编辑中(out string msgErr1) || !Err.工作中(out msgErr1) || !Err.系统忙(申明.myForm25_sys, out msgErr1))
                {
                    IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                    return;
                }


                string str = Encoding.Default.GetString(data).Trim();
                if (用户_.user_sys.Config.当前登陆的用户信息.权限 != 用户.enum权限.操作员 &&
                          用户_.user_sys.Config.当前登陆的用户信息.权限 != 用户.enum权限.开发者)
                {
                    Log.Add(false, $"扫码枪扫码: 请切换到操作员用户", Log.enumLogState.All);
                    IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                    return;
                }
                Log.Add(true, $"扫码枪扫码,接收:{str}");
                var rt = Err_扫码中重码(str, out msgErr1, true); //检测扫码中是否有重码
                if (rt)
                {
                    _读码内容.Add(str);
                    if (_读码内容.Count == 工件.gj_sys.Config.文件.数量.每盘个数)
                    {
                        Log.Clear();
                        Log.Add(true, $"扫码枪扫码,数量达到每盘个数,启动触发....<{_读码内容.Count}>", Log.enumLogState.All);
                        await 加工.启动加工();
                    }
                }
            };

            tcp_sys.Connect连接(out string msgErr);
            isInistiall = true;
        }
        static bool isInistiall = false;
        internal static void 释放()
        {
            if (!isInistiall)
            {
                return;
            }

            tcp_sys.Stop关闭连接(out string msgErr);

        }

        internal static void 标题栏状态()
        {
            Form_main.form_Main.Invoke((Action)(() =>
            {
                Form_main.form_Main.uiButton_清空读码.Visible = 系统类_myApp.Config.参数.使能_手持扫码枪;
            }));

            if (!系统类_myApp.Config.参数.使能_手持扫码枪)
            {
                return;
            }
            List<string[]> lst = new List<string[]>();
            lst.Add(new string[] { "-1", "手持扫码枪未连接" });
            lst.Add(new string[] { "1", "手持扫码枪连接中" });
            申明.myForm25_sys.标题栏显状态_添加显示(tcp_sys.Config.连接状态, lst);

          //  Log.Add(true, tcp_sys.Config.参数.IP);
        }

        internal static bool Err_扫码中重码(string value, out string msgErr, bool Is错误时弹窗 = true)
        {
            msgErr = "";
            if (_读码内容.Contains(value))
            {
                msgErr = "扫码枪,检测到有重复扫码";
                string m = msgErr;
                if (Is错误时弹窗)
                {
                    Form_main.form_Main.Invoke((Action)(() =>
                    {
                        Sunny25.Messagebox.Show(m, "Err", Sunny25.MessageboxButtons.OK, Sunny25.MessageboxStatus.Red);
                    }));
                }
                return false;
            }
            return true;
        }

    }
}
