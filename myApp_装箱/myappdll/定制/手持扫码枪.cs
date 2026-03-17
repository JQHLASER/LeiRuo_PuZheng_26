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

            tcp_sys.Action_接收数据 += async (data) => await on_扫码处理(data);

            tcp_sys.Connect连接Async();
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
                Form_main.form_Main.label_手持扫码枪_扫码计数.Visible = 系统类_myApp.Config.参数.使能_手持扫码枪;
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


        static async Task on_扫码处理(byte[] data)
        {
            if (!工作.Err_编辑中(out string msgErr1) || !Err.工作中(out msgErr1) || !Err.系统忙(申明.myForm25_sys, out msgErr1)
              || !Err.系统报警(申明.myForm25_sys, out msgErr1))
            {
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                return;
            }

            string[] work = new string[]
            {
                "权限",
                "接收内容日志",
                "是否在当前盘中重码",
                "是否在数据库中重码",
                "是否混料",
                "点检样件",

            };
            string str = Encoding.Default.GetString(data).Trim();

         

            bool rt = true;
            string msg = "";
            foreach (var s in work)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "接收内容日志")
                {
                    Log.Add(true, $"扫码枪扫码,接收:<{_读码内容.Count + 1}>{str}");
                }
                else if (s == "是否在当前盘中重码")
                {
                    #region 是否在当前盘中重码

                    rt = Err_扫码中重码(str, out msgErr1, false); //检测扫码中是否有重码

                    if (!rt)
                    {
                        显示不合格图像( str , "当前盘重码");
                    }


                    #endregion
                }
                else if (s == "是否在数据库中重码")
                {
                    #region 在数据库中重码检测

                    rt = dataBase.查询_防重_SN条码(str, out List<表.dataZX> lst, out msg);
                    if (!rt)
                    {
                        显示不合格图像(str,   "重码");
                    }
                    #endregion
                }
                else if (s == "是否混料")
                {
                    rt = 计算.混料检测_手持扫码枪(str, out msg);
                    if (!rt)
                    {
                        显示不合格图像(str, "混料");
                    }

                }
                else if (s == "权限")
                {
                    #region 权限

                    if (用户_.user_sys.Config.当前登陆的用户信息.权限 != 用户.enum权限.操作员 &&
                   用户_.user_sys.Config.当前登陆的用户信息.权限 != 用户.enum权限.开发者)
                    {
                        Log.Add(false, $"扫码枪扫码: 请切换到操作员用户", Log.enumLogState.All);
                        IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
                        rt = false;
                    }

                    #endregion
                }
                else if (s == "点检样件")
                {
                    #region 点检样件
                    rt = 计算.点检样品(str, out msg);
                    if (!rt)
                    {
                        显示不合格图像(str, "点检样品");
                    }
                    #endregion
                }
            }


            if (!rt)
            {
                IO_Zauto.Out_三色灯(IO_Zauto.enum三色灯.红灯, true);
            }
            else
            {
                #region 计数/工作

                _读码内容.Add(str);
                if (_读码内容.Count == 工件.gj_sys.Config.文件.数量.每盘个数)
                {
                    Log.Clear();
                    Log.Add(true, $"扫码枪扫码,数量达到每盘个数,启动触发....<{_读码内容.Count}>", Log.enumLogState.All);
                    await 加工.启动加工();
                }

                #endregion
            }



        }



        static void 显示不合格图像(string 当前码,string 错误标题)
        {
            var lst = new List<读码器.info_码信息_>();
            for (int i = 0; i < _读码内容.Count; i++)
            {
                lst.Add(new 读码器.info_码信息_ { 索引 = i, 码内容 = _读码内容[i] });
            }

            if (!string.IsNullOrWhiteSpace(当前码))
                lst.Add(new 读码器.info_码信息_ { 索引 = _读码内容.Count, 码内容 = 当前码 });


            if (lst.Count > 0)
            {
                计算.查看_读码器图像_手持扫码枪(lst, lst.Count - 1, 错误标题);
            }

        }



    }
}
