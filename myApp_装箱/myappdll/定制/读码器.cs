
using Newtonsoft.Json;
using Sunny25;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;

namespace myappdll
{
    internal class 读码器
    {
        internal static mainclassqf.Socket_Client tcp_sys = new mainclassqf.Socket_Client();
        internal static mainclassqf.解码_qf jm_sys = new mainclassqf.解码_qf();


        public enum enum通讯辅助
        {
            None,
            等待接收,
            已接收,
        }


        public class info_码信息_
        {
            /// <summary>
            /// 从0开始
            /// </summary>
            public int 索引 { set; get; }
            public string 码内容 { set; get; }
        }




        public class info_参数_
        {
            public string ip { set; get; } = "192.168.100.100";
            public int port { set; get; } = 9004;

            public string 启动读码 { set; get; } = "LON";
            public string 停止读码 { set; get; } = "LOFF";
            public string 未读出码内容 { set; get; } = "ERROR";


            public string 读码器图像文件夹 { set; get; } =Path .Combine (AppDomain .CurrentDomain .BaseDirectory , "ReadImage") ;

        }


        internal class Config
        {
            internal static info_参数_ 参数 { set; get; } = new info_参数_();
            internal static enum通讯辅助 通讯辅助 { set; get; } = enum通讯辅助.None;
            internal static string 接收内容 { set; get; } = string.Empty;

            /// <summary>
            /// 0:无,10:读码中
            /// </summary>
            internal static int 读码状态 { set; get; } = 0;

            internal static string 缓存_切换模板指令 { set; get; } = "";


        }


        internal static void 初始化()
        {
            if (系统类_myApp.Config.参数.使能_手持扫码枪)
            {
                return;
            }


            string path = mainclassSoft.系统类.Config.File_MyAppSys_Config + "\\readCode.cfg";
            info_参数_ info = Config.参数;
            new mainclassSoft.系统类().读写参数(ref info, 1, path, out string msgErr);
            Config.参数 = info;
            new mainclassqf.文件_文件夹().文件夹_不存在时新建(Config.参数.读码器图像文件夹);


            tcp_sys.Config.参数.IP = Config.参数.ip;
            tcp_sys.Config.参数.Port = Config.参数.port;

            tcp_sys.参数读写(1);

            tcp_sys.Action_接收数据 += On_接收数据;
            tcp_sys.Connect连接(out msgErr);


            jm_sys.Action_0 += On_接收数据_jm;
            mainclassqf.解码_qf.info_参数_ infoJm = new mainclassqf.解码_qf.info_参数_();
            infoJm.类型 = mainclassqf.解码_qf.enum类型.后缀_0D_0A;
            jm_sys.初始化(infoJm);
            isInistiall = true;
        }
        static bool isInistiall = false;
        internal static void 释放()
        {

            if (!isInistiall)
            {
                return;
            }
            tcp_sys.Action_接收数据 -= On_接收数据;
            jm_sys.Action_0 -= On_接收数据_jm;

            jm_sys.释放();
            tcp_sys.Stop关闭连接(out string msgErr);

        }

        internal static void 标题栏状态()
        {
            if ( 系统类_myApp.Config.参数.使能_手持扫码枪)
            {
                return;
            }
            List<string[]> lst = new List<string[]>();
            lst.Add(new string[] { "-1", "读码器未连接" });
            lst.Add(new string[] { "1", "读码器连接中" });
            申明.myForm25_sys.标题栏显状态_添加显示(tcp_sys.Config.连接状态, lst);


            lst.Clear();
            lst.Add(new string[] { "10", "读码器读码中" });
            申明.myForm25_sys.标题栏显状态_添加显示(Config.读码状态, lst);
        }

        static void On_接收数据(byte[] data)
        {
            jm_sys.解码(data, "", null, 0);
        }

        static void On_接收数据_jm(byte[] data)
        {
            string str = new mainclassqf.编码Encoding().byteToStrig(data);
            Log.Add(true, $"读码器,接收到内容,{str}");
            if (Config.通讯辅助 == enum通讯辅助.等待接收)
            {
                Config.通讯辅助 = enum通讯辅助.已接收;
            }
            Config.接收内容 = str;
        }


        static void 发送(string 指令)
        {
            if (tcp_sys.Config.连接状态 != 0)
            {
                return;
            }

            string str = $"{指令}\r\n";
            Log.Add(true, $"读码器,send<{str}>");
            tcp_sys.Send发送(str, new mainclassqf.编码Encoding().Encoding_编码());


        }


        internal static bool 读码(out List<info_码信息_> lst码信息, out List<info_码信息_> lst不为空的码信息, out string msgErr)
        {
            lst码信息 = new List<info_码信息_>();
            lst不为空的码信息 = new List<info_码信息_>();
            msgErr = string.Empty;
            bool rt = true;
             
            List<string> lstWork = new List<string>();
            lstWork.Add("Err");
            lstWork.Add("切换模板");
            lstWork.Add("读码");


            Config.读码状态 = 10;

            Log.Add(rt, $"读码器,启动读码...");
            foreach (var s in lstWork)
            {
                if (!rt)
                {
                    break;
                }
                else if (s == "Err")
                {
                    if (!tcp_sys.Err_未连接())
                    {
                        rt = false;
                        msgErr = "读码器未连接";
                    }
                    else if (!Err_读码中(out msgErr))
                    {
                        rt = false;
                    }
                }
                else if (s == "切换模板")
                {
                    rt = 切换模板();
                }
                else if (s == "读码")
                {
                    #region 读码

                    Config.接收内容 = string.Empty;
                    Config.通讯辅助 = enum通讯辅助.等待接收;

                    string 指令 = Config.参数.启动读码;
                    发送(指令);

                    for (global::System.Int32 i = 0; i < 30 * 1000 / 100; i++)
                    {
                        Thread.Sleep(100);
                        if (Config.通讯辅助 == enum通讯辅助.已接收)
                        {
                            break;
                        }
                    }

                    发送(Config.参数.停止读码);

                    if (Config.通讯辅助 == enum通讯辅助.等待接收 || string.IsNullOrEmpty(Config.接收内容))
                    {
                        rt = false;
                        msgErr = "读码器无响应";
                    }
                    else if (Config.接收内容.Trim() == Config.参数.未读出码内容)
                    {
                        rt = false;
                        msgErr = "未读出码内容";
                    }
                    else
                    {
                        msgErr = "读码成功";

                        解析(Config.接收内容, out lst码信息, out lst不为空的码信息);

                    }


                    #endregion
                }

            }
            Log.Add(rt, $"读码器,读码结束,{msgErr}");

            Config.读码状态 = 0;
            return rt;
        }


        /// <summary>
        /// 读码后解析
        /// </summary>
        /// <param name="读码内容"></param>
        /// <param name="lst码信息"></param>
        static void 解析(string 读码内容, out List<info_码信息_> lst所有码信息, out List<info_码信息_> lst不为空的码信息)
        {
            lst不为空的码信息 = new List<info_码信息_>();
            lst所有码信息 = new List<info_码信息_>();
            string[] ReadCode_Beff = 读码内容.Split(',');
            for (int i = 0; i < ReadCode_Beff.Length; i++)
            {
                info_码信息_ info = new info_码信息_();
                info.索引 = i;
                info.码内容 = ReadCode_Beff[i].Trim();
                if (ReadCode_Beff[i].Trim() == Config.参数.未读出码内容)
                {
                    info.码内容 = "";
                }

                lst所有码信息.Add(info);
                if (!string.IsNullOrEmpty(info.码内容))
                {
                    lst不为空的码信息.Add(info);
                }
            }

        }



        internal static bool Err_读码中(out string msgErr)
        {
            msgErr = string.Empty;
            bool rt = true;
            if (Config.读码状态 == 10)
            {
                msgErr = "读码器读码中";
                rt = false;
            }

            return true;
        }

        /// <summary>
        /// 读码器读出码之间的防重
        /// </summary>
        /// <param name="lst码内容"></param>
        /// <returns></returns>
        internal static bool 读码内容防重(List<info_码信息_> lst不为空的码信息, out List<string> lst重码码内容)
        {
            bool rt = true;
            List<string> lst码内容 = new List<string>();
            foreach (var s in lst不为空的码信息)
            {
                lst码内容.Add(s.码内容);
            }


            new mainclassqf.List_().查询重复的内容(lst码内容, out lst重码码内容);
            rt = lst重码码内容.Count > 0 ? false : true;

            // Log.Add(rt, $" {JsonConvert.SerializeObject(lst码内容, Formatting.Indented)}");

            if (!rt)
            {
                string json = JsonConvert.SerializeObject(lst重码码内容, Formatting.Indented);
                Log.Add(rt, $"读码内容重复,\r\n{json}");
            }

            return rt;
        }


        internal static void 读取图像(string path_image, out Bitmap img)
        {
            string path = Config.参数.读码器图像文件夹 + $"\\{path_image}";
            bool rt = new mainclassqf.Image_().读取图片文件(path, out img, out string msgErr);

            string show = rt ? $"读取图像,{path_image}" : $"读取图像,{path_image},失败,{msgErr}";
            Log.Add(rt, show);
        }



        internal static bool 切换模板()
        {
            bool rt = true;
            string msgErr = string.Empty;

            if (Config.缓存_切换模板指令.Trim() != 工件.gj_sys.Config.文件.读码指令.Trim())
            {
                #region 读码

                Config.接收内容 = string.Empty;
                Config.通讯辅助 = enum通讯辅助.等待接收;
                Config.缓存_切换模板指令 = string.Empty;


                string 指令 = 工件.gj_sys.Config.文件.读码指令;
                发送(指令);

                for (global::System.Int32 i = 0; i < 30 * 1000 / 100; i++)
                {
                    Thread.Sleep(100);
                    if (Config.通讯辅助 == enum通讯辅助.已接收)
                    {
                        break;
                    }
                }

                if (Config.通讯辅助 == enum通讯辅助.等待接收 || string.IsNullOrEmpty(Config.接收内容))
                {
                    rt = false;
                    msgErr = "读码器无响应";
                }
                else if (Config.接收内容.Trim().Contains("OK,BLOAD"))
                {
                    Config.缓存_切换模板指令 = 工件.gj_sys.Config.文件.读码指令.Trim();
                    msgErr = "读码器,切换模板成功";
                }
                else
                {
                    rt = false;
                    msgErr = "读码器,切换模板失败";

                }
                Config.接收内容 = string.Empty;
                Config.通讯辅助 = enum通讯辅助.等待接收;

                Log.Add(rt, msgErr);
                #endregion

            }

            return rt;

        }




    }
}
